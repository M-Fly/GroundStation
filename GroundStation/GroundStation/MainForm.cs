using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

using GroundStation.Constants;
using GroundStation.DataRecording;

namespace GroundStation
{
    public partial class MainForm : Form
    {
        bool DEBUG_ENABLED = true;

        private StringBuilder receivedData = new StringBuilder();
        private Debugging.ArduinoDebugging debugFunction;
        private DataMaster MainDataMaster = new DataMaster();

        System.IO.StreamWriter DataFile = new System.IO.StreamWriter(
            "M - Fly Telemtry " + DateTime.Now.ToString("yyyy MMMM dd hh mm") + ".txt", true);

        bool PayloadDropped = false;

        public MainForm()
        {
            InitializeComponent();

            if (DEBUG_ENABLED)
            {
                debugFunction = new Debugging.ArduinoDebugging(ParseData);
            }
        }

        // TODO: CONVERT VARIABLES INTO PROPER UNITS: ALTITUDE in FT. VELOCITY IN FT/S.
        // TODO: Verify that length of data (number of terms) is correct -> validate message
        // Parses data into a List
        public void ParseData(string InputString)
        {
            //Divide data by each comma
            string[] DataString = InputString.Split(',');

            //Checks for the "MX2" tag. If no tag, we are not receiving data from MX2 vehicle
            if (!DataString[1].Equals("MX2"))
            {
                Console.WriteLine("Not Reading MX2");
            }

            //Checks for 'A', 'B', or 'C' messages. If none, sends an error message

            //'A' message delivers time in milliseconds, barometric altitude (meters),
            //      airspeed, payload drop time, and payload drop altitude (meters)
            if (DataString[0].Equals("A"))
            {
                // A,MX2,MILLIS,ALT_BARO,ANALOG_PITOT,PRESS,TEMP,DROP_TIME,DROP_ALT

                DataDefault InDefault = new DataDefault();
                InDefault.time_seconds = Convert.ToDouble(DataString[2]) * ConversionFactors.MILLIS_TO_SECONDS;
                InDefault.alt_bar_ft = Convert.ToDouble(DataString[3]) * ConversionFactors.METERS_TO_FEET;

                int AnalogPitotValue = (int) Convert.ToDouble(DataString[4]);
                InDefault.pressure_pa = Convert.ToDouble(DataString[5]);
                InDefault.temperature_c = Convert.ToDouble(DataString[6]);

                InDefault.dropTime_seconds = Convert.ToDouble(DataString[7]) * ConversionFactors.MILLIS_TO_SECONDS;
                InDefault.dropAlt_ft = Convert.ToDouble(DataString[8]) * ConversionFactors.METERS_TO_FEET;

                InDefault.airspeed_ft_s = PitotLibrary.GetAirspeedFeetSeconds(AnalogPitotValue, InDefault.temperature_c, InDefault.pressure_pa);

                DataFile.WriteLine(InDefault.ToString());

                MainDataMaster.DefaultDataList.Add(InDefault);

                panelAltitudePlot.UpdateAltitude(InDefault.time_seconds, InDefault.alt_bar_ft);
                panelInstruments.UpdateInstruments(InDefault.airspeed_ft_s, InDefault.alt_bar_ft);

                

                if (!PayloadDropped && InDefault.dropTime_seconds > 0)
                {
                    // graphGPS1.UpdateLatLonDrop() -> Get last latitude/longitude and display on graph
                    panelDropStatus.UpdateDrop(InDefault.dropTime_seconds, InDefault.alt_bar_ft);
                    panelAltitudePlot.UpdateAltitudeDrop(InDefault.dropTime_seconds, InDefault.dropAlt_ft);

                    int gpsCount = MainDataMaster.GpsDataList.Count;
                    if (gpsCount > 0)
                    {
                        DataGPS lastGpsData = MainDataMaster.GpsDataList[gpsCount - 1];
                        panelGPSPlot.UpdateLatLonDrop(lastGpsData.gps_lat, lastGpsData.gps_lon);
                    }

                    PayloadDropped = true;
                }
            }

            //'B' message delivers time in milliseconds, the gps system, the gps latitude,
            //      the gps longitude, the gps measurement for groundspeed in knots, 
            //        gps course (degrees), gps altitude (meters), 
            //        gps hdop, and gps fixtime (milliseconds)
            //      Converts meters to feet, and knots to ft/s
            //      Divide some variables to restore proper values 
            else if (DataString[0].Equals("B"))
            {
                // Parse GPS Data
                DataGPS GpsData = new DataGPS();
                GpsData.time_seconds = Convert.ToDouble(DataString[2]) * ConversionFactors.MILLIS_TO_SECONDS;
                GpsData.gps_system = DataString[3];
                GpsData.gps_lat = (Convert.ToDouble(DataString[4])) / 1000000; //degrees
                GpsData.gps_lon = (Convert.ToDouble(DataString[5])) / 1000000; //degrees
                GpsData.gps_speed_ft_s = ((Convert.ToDouble(DataString[6])) / 1000) * ConversionFactors.KNOTS_TO_FPS; //Converts Speed from Knots to ft/s
                GpsData.gps_course = (Convert.ToDouble(DataString[7])) / 1000; //degrees
                GpsData.gps_alt_ft = ((Convert.ToDouble(DataString[8])) / 1000) * ConversionFactors.METERS_TO_FEET;
                GpsData.gps_hdop = (Convert.ToDouble(DataString[9])) / 10;
                //GpsData.gps_fixtime_millis = Convert.ToDouble(DataString[10]); //Currently in millis

                DataFile.WriteLine(GpsData.ToString());

                MainDataMaster.GpsDataList.Add(GpsData);

                // Update GPS Panel with new location
                panelGPSPlot.UpdateLatLon(GpsData.gps_lat, GpsData.gps_lon);
            }

            //'C' message delivers gyro data. Gives time in milliseconds; x, y, and z gyro values;
            //      and x, y, and z acceleration values.
            //      Gyro in radians/s
            //      Acceleration in m/s^2
            else if (DataString[0].Equals("C"))
            {
                DataAccelGyro GyroData = new DataAccelGyro();
                GyroData.time_seconds = Convert.ToDouble(DataString[2]) * ConversionFactors.MILLIS_TO_SECONDS;
                GyroData.gyro_x = Convert.ToDouble(DataString[3]);
                GyroData.gyro_y = Convert.ToDouble(DataString[4]);
                GyroData.gyro_z = Convert.ToDouble(DataString[5]);
                GyroData.accel_x = Convert.ToDouble(DataString[6]);
                GyroData.accel_y = Convert.ToDouble(DataString[7]);
                GyroData.accel_z = Convert.ToDouble(DataString[8]);

                DataFile.WriteLine(GyroData.ToString());

                MainDataMaster.GryoAccelDataList.Add(GyroData);
            }
            else
            {
                Console.WriteLine("Error in reading InputString: YOU MESSED UP!");
            }

        }

        public void UpdateGPSPlayback(DataGPS indata)
        {
            panelGPSPlot.UpdateLatLon(indata.gps_lat, indata.gps_lon);
        }

        public void UpdateDefaultPlayback(DataDefault indata)
        {
            panelAltitudePlot.UpdateAltitude(indata.time_seconds, indata.alt_bar_ft);
            panelInstruments.UpdateInstruments(indata.airspeed_ft_s, indata.alt_bar_ft);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (string portname in SerialPort.GetPortNames())
            {
                cmbSerialPort.Items.Add(portname);
            }
        }

        private void openPort_Click(object sender, EventArgs e)
        {

            if (!xbeeSerial.IsOpen && !String.IsNullOrWhiteSpace(cmbSerialPort.Text))
            {
                xbeeSerial.PortName = cmbSerialPort.Text;
                if (!xbeeSerial.IsOpen) xbeeSerial.Open();
            }
        }

        private void closePort_Click(object sender, EventArgs e)
        {
            if (xbeeSerial.IsOpen) xbeeSerial.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            receivedData.Append(xbeeSerial.ReadExisting());
        }

        private void parseTimer_Tick(object sender, EventArgs e)
        {
            string total = receivedData.ToString();

            string[] message = total.Split(';');

            int lastIndex = total.LastIndexOf(';');

            for (int i = 0; i < (message.Length - 1); i++)
            {
                ParseData(message[i]);
            }

            if (lastIndex >= 0)
            {
                receivedData.Remove(0, lastIndex + 1);
            }
        }
    }
}

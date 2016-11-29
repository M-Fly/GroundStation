using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XBee.Converters;
using XBee.Devices;
using XBee.Frames;
using XBee.Observable;
using System.IO.Ports;
using System.IO;

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
            "M - Fly Telemtry " + DateTime.Now.ToString("yyyy MMMM dd hh mm"));

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
            const double KNOTS_TO_FPS = 1.68781;
            const double METERS_TO_FEET = 3.28084;
            const double MILLIS_TO_SECONDS = 0.001; //May not be used

            

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
                DataDefault InDefault = new DataDefault();
                InDefault.time_seconds = Convert.ToDouble(DataString[2]) * MILLIS_TO_SECONDS; // NEEDS CONVERSION
                InDefault.alt_bar_ft = Convert.ToDouble(DataString[3]) * METERS_TO_FEET;
                InDefault.airspeed_ft_s = Convert.ToDouble(DataString[4]); // NEEDS CONVERSION
                InDefault.dropTime_seconds = Convert.ToDouble(DataString[5]) * MILLIS_TO_SECONDS;
                InDefault.dropAlt_ft = Convert.ToDouble(DataString[6]) * METERS_TO_FEET;

                MainDataMaster.default_data.Add(InDefault);

                panelAltitudePlot.UpdateAltitude(InDefault.time_seconds, InDefault.alt_bar_ft);
                panelInstruments.UpdateInstruments(InDefault.airspeed_ft_s, InDefault.alt_bar_ft);

                bool newDrop = false; // TODO: Update NewDrop values to include new drop data

                if (newDrop)
                {
                    // graphGPS1.UpdateLatLonDrop() -> Get last latitude/longitude and display on graph
                    panelDropStatus.UpdateDrop(InDefault.dropTime_seconds, InDefault.alt_bar_ft);
                    panelAltitudePlot.UpdateAltitudeDrop(InDefault.dropTime_seconds, InDefault.dropAlt_ft);
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
                GpsData.time_seconds = Convert.ToDouble(DataString[2]) * MILLIS_TO_SECONDS;
                GpsData.gps_system = DataString[3];
                GpsData.gps_lat = (Convert.ToDouble(DataString[4])) / 1000000; //degrees
                GpsData.gps_lon = (Convert.ToDouble(DataString[5])) / 1000000; //degrees
                GpsData.gps_speed_ft_s = ((Convert.ToDouble(DataString[6])) / 1000) * KNOTS_TO_FPS; //Converts Speed from Knots to ft/s
                GpsData.gps_course = (Convert.ToDouble(DataString[7])) / 1000; //degrees
                GpsData.gps_alt_ft = ((Convert.ToDouble(DataString[8])) / 1000) * METERS_TO_FEET;
                GpsData.gps_hdop = (Convert.ToDouble(DataString[9])) / 10;
                GpsData.gps_fixtime_millis = Convert.ToDouble(DataString[10]); //Currently in millis

                MainDataMaster.gps_data.Add(GpsData);

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
                GyroData.time_seconds = Convert.ToDouble(DataString[2]) * MILLIS_TO_SECONDS;
                GyroData.gyro_x = Convert.ToDouble(DataString[3]);
                GyroData.gyro_y = Convert.ToDouble(DataString[4]);
                GyroData.gyro_z = Convert.ToDouble(DataString[5]);
                GyroData.accel_x = Convert.ToDouble(DataString[6]);
                GyroData.accel_y = Convert.ToDouble(DataString[7]);
                GyroData.accel_z = Convert.ToDouble(DataString[8]);

                MainDataMaster.gyro_data.Add(GyroData);
            }
            else
            {
                Console.WriteLine("Error in reading InputString: YOU MESSED UP!");
            }

            // Saving Data to File

            //string name = "M-Fly Telemtry " + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

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
            serialTimer.Start();
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

        private void serialTimer_Tick(object sender, EventArgs e)
        {
            SerialOutput.Text = receivedData.ToString();
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

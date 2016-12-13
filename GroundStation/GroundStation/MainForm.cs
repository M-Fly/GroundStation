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
using GroundStation.Playback;

namespace GroundStation
{
    public partial class MainForm : Form
    {
        private const bool DEBUG_ENABLED = true;

        private StringBuilder ReceivedData = new StringBuilder();

        private Debugging.ArduinoDebugging debugFunction;

        private DataMaster MainDataMaster = new DataMaster();

        private StreamWriter DataFile = new StreamWriter("M - Fly Telemtry " + DateTime.Now.ToString("yyyy MMMM dd hh mm") + ".txt", true);

        private bool PayloadDropped = false;

        private Playback.Playback PlaybackController;

        #region Form Controls

        public MainForm()
        {
            InitializeComponent();

            /*DropPrediction.Vector3 pos = new DropPrediction.Vector3(0, 0, 100);
            DropPrediction.Vector3 vel = new DropPrediction.Vector3(20, 20, 0);

            DropPrediction.PredictionAlgorithmEuler tf2 = new DropPrediction.PredictionAlgorithmEuler();
            DropPrediction.Vector3 result = tf2.PredictionIntegrationFunction(pos, vel);
            
            DropPrediction.PredictionAlgorithmLagrange tf = new DropPrediction.PredictionAlgorithmLagrange();
            tf.EulerLagrange(0, 0, 100, 20, 20);
            */

            PlaybackController = new Playback.Playback(MainDataMaster, UpdateDefaultPlayback, UpdateGPSPlayback);

            if (DEBUG_ENABLED)
            {
                debugFunction = new Debugging.ArduinoDebugging(ParseData);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (string portname in SerialPort.GetPortNames())
            {
                cmbSerialPort.Items.Add(portname);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Data Parsing

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

                // Parse Data from String
                DataDefault InDefault = new DataDefault();
                InDefault.time_seconds = Convert.ToDouble(DataString[2]) * ConversionFactors.MILLIS_TO_SECONDS;
                InDefault.alt_bar_ft = Convert.ToDouble(DataString[3]) * ConversionFactors.METERS_TO_FEET;

                int AnalogPitotValue = (int) Convert.ToDouble(DataString[4]);
                InDefault.pressure_pa = Convert.ToDouble(DataString[5]);
                InDefault.temperature_c = Convert.ToDouble(DataString[6]);

                InDefault.dropTime_seconds = Convert.ToDouble(DataString[7]) * ConversionFactors.MILLIS_TO_SECONDS;
                InDefault.dropAlt_ft = Convert.ToDouble(DataString[8]) * ConversionFactors.METERS_TO_FEET;

                // Calculate Airspeed from Analog Value
                InDefault.airspeed_ft_s = PitotLibrary.GetAirspeedFeetSeconds(AnalogPitotValue, InDefault.temperature_c, InDefault.pressure_pa);

                // Write Data to File
                DataFile.WriteLine(InDefault.ToString());

                // Add data object to data master list
                MainDataMaster.DefaultDataList.Add(InDefault);

                // Update teh standart altitude plot and instruments
                panelAltitudePlot.UpdateAltitude(InDefault.time_seconds, InDefault.alt_bar_ft);
                panelInstruments.UpdateInstruments(InDefault.airspeed_ft_s, InDefault.alt_bar_ft);

                // Check if a payload has been dropped
                if (!PayloadDropped && InDefault.dropTime_seconds > 0)
                {
                    panelDropStatus.UpdateDrop(InDefault.dropTime_seconds, InDefault.alt_bar_ft);
                    panelAltitudePlot.UpdateAltitudeDrop(InDefault.dropTime_seconds, InDefault.dropAlt_ft);

                    // Get the last GPS coordinate to plot drop on the GPS panel
                    //      -> Will not show if GPS list is empty, no GPS position information
                    int gpsCount = MainDataMaster.GpsDataList.Count;
                    if (gpsCount > 0)
                    {
                        DataGPS lastGpsData = MainDataMaster.GpsDataList[gpsCount - 1];
                        panelGPSPlot.UpdateLatLonDrop(lastGpsData.gps_lat, lastGpsData.gps_lon);
                    }

                    // Set PayloadDropped to true
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

                // Write data to file
                DataFile.WriteLine(GpsData.ToString());

                // Add data object to DataMaster
                MainDataMaster.GpsDataList.Add(GpsData);

                // Update GPS Panel with new location
                panelGPSPlot.UpdateLatLon(GpsData.gps_lat, GpsData.gps_lon);

                // ####
                //
                // STILL NEEDS WORK
                //
                //
                // Input data into prediction function #####
                DropPrediction.Vector3 pos = new DropPrediction.Vector3(0, 0, GpsData.gps_alt_ft / ConversionFactors.METERS_TO_FEET);

                GpsData.gps_speed_ft_s = 45;

                double velX = GpsData.gps_speed_ft_s * Math.Sin(GpsData.gps_course * ConversionFactors.DEG_TO_RAD) / ConversionFactors.METERS_SECONDS_TO_FEET_SECONDS;
                double velY = GpsData.gps_speed_ft_s * Math.Cos(GpsData.gps_course * ConversionFactors.DEG_TO_RAD) / ConversionFactors.METERS_SECONDS_TO_FEET_SECONDS;
                DropPrediction.Vector3 vel = new DropPrediction.Vector3(velX, velY, 0);

                DropPrediction.Vector3 result = DropPrediction.PredictionAlgorithmEuler.PredictionIntegrationFunction(pos, vel);

                double dx = result.x * ConversionFactors.METERS_TO_FEET;
                double dy = result.y * ConversionFactors.METERS_TO_FEET;

                Console.WriteLine(Math.Sqrt(dx * dx + dy * dy));

                double lat = GpsData.gps_lat + dy / PhysicsConstants.EARTH_RADIUS_FT * ConversionFactors.RAD_TO_DEG;

                double lonRadius = PhysicsConstants.EARTH_RADIUS_FT * Math.Cos(lat * ConversionFactors.DEG_TO_RAD);

                double lon = GpsData.gps_lon + dx / lonRadius * ConversionFactors.RAD_TO_DEG;

                panelGPSPlot.UpdateLatLonPredict(lat, lon);
                //
                //
                //
                //
                //
                //
            }

            //'C' message delivers gyro data. Gives time in milliseconds; x, y, and z gyro values;
            //      and x, y, and z acceleration values.
            //      Gyro in radians/s
            //      Acceleration in m/s^2
            else if (DataString[0].Equals("C"))
            {
                // Parse incoming data
                DataAccelGyro GyroData = new DataAccelGyro();
                GyroData.time_seconds = Convert.ToDouble(DataString[2]) * ConversionFactors.MILLIS_TO_SECONDS;
                GyroData.gyro_x = Convert.ToDouble(DataString[3]);
                GyroData.gyro_y = Convert.ToDouble(DataString[4]);
                GyroData.gyro_z = Convert.ToDouble(DataString[5]);
                GyroData.accel_x = Convert.ToDouble(DataString[6]);
                GyroData.accel_y = Convert.ToDouble(DataString[7]);
                GyroData.accel_z = Convert.ToDouble(DataString[8]);

                // Write data to file
                DataFile.WriteLine(GyroData.ToString());

                // Add data object to DataMaster
                MainDataMaster.GryoAccelDataList.Add(GyroData);
            }
            else
            {
                // If unknown message, write information to console
                DataFile.WriteLine("Unknown Message: " + InputString);
            }
        }

        private void parseTimer_Tick(object sender, EventArgs e)
        {
            // String to hold all incoming data
            string incomingData = ReceivedData.ToString();

            // Last index of the incoming data
            int lastIndex = incomingData.LastIndexOf(';');

            // Splitting the string into invidual messages
            string[] message = incomingData.Split(';');

            // Pass in complete messages into the parsing function
            for (int i = 0; i < (message.Length - 1); i++)
            {
                ParseData(message[i]);
            }

            // Remove all parsed data from receivedData
            if (lastIndex >= 0)
            {
                ReceivedData.Remove(0, lastIndex + 1);
            }
        }

        #endregion

        #region Serial Port Region

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
            ReceivedData.Append(xbeeSerial.ReadExisting());
        }

        #endregion

        #region Playback Functionality

        //Playback button. Wipe data, and put data into playback
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear the altitude and GPS plots to prepare for playback
            panelAltitudePlot.ClearAlt();
            panelGPSPlot.ClearGPS();

            // Stop the debug function if it is running
            if (debugFunction != null) debugFunction.Stop();

            // Close the serial port (if open)
            closePort_Click(null, null);

            // Reset and start the playback of data
            PlaybackController.ResetPlayback();
            PlaybackController.Play();
        }

        // Delegate Function to Facilitate Playback of GPS Data
        // REQUIRES: Not-Null DataGPS object
        // EFFECTS:  Adds point to panelGPSPlot
        // MODIFIES: Nothing
        public void UpdateGPSPlayback(DataGPS indata)
        {
            panelGPSPlot.UpdateLatLon(indata.gps_lat, indata.gps_lon);
        }

        // Delegate Function to Facilitate Playback of Default Data
        // REQUIRES: Not-Null DataDefault object
        // EFFECTS:  Adds point to panelAltitudePlot and panelInstruments
        // MODIFIES: Nothing
        public void UpdateDefaultPlayback(DataDefault indata)
        {
            panelAltitudePlot.UpdateAltitude(indata.time_seconds, indata.alt_bar_ft);
            panelInstruments.UpdateInstruments(indata.airspeed_ft_s, indata.alt_bar_ft);
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PlaybackController != null) PlaybackController.SetPlaybackSpeed(1);
        }

        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (PlaybackController != null) PlaybackController.SetPlaybackSpeed(2);
        }

        private void xToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (PlaybackController != null) PlaybackController.SetPlaybackSpeed(4);
        }

        private void xToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (PlaybackController != null) PlaybackController.SetPlaybackSpeed(8);
        }

        #endregion
    }
}

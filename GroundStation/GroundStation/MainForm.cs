using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        // Debugging controls
        private const bool DEBUG_ENABLED = false;
        private Debugging.ArduinoDebugging debugFunction;

        // Flight Barrier controls for the Flying Pilgrim field in Ann Arbor, MI
        private const bool FLYING_PILGRIM = false;

        // Playback controls
        private Playback.Playback PlaybackController;

        // StringBuilder to hold incoming data before it is parsed
        private StringBuilder ReceivedData = new StringBuilder();
        private const int A_MSG_LEN = 9;
        private const int B_MSG_LEN = 10;
        private const int C_MSG_LEN = 9;

        // DataMaster to keep track of telemetry data
        private DataMaster MainDataMaster = new DataMaster();

        // StreamWriter file to write data to a file
        private StreamWriter dataFile = new StreamWriter("M-Fly Telemetry " + DateTime.Now.ToString("yyyy MMMM dd hh mm") + ".txt", true);
        private StreamWriter rawDataFile = new StreamWriter("M-Fly Raw Telemetry " + DateTime.Now.ToString("yyyy MMMM dd hh mm") + ".txt", true);

        // Variable to keep track of when a payload is dropped
        private bool PayloadDropped = false;

        private LatLng targetLocation = new LatLng()
        {
            lat = 42.17,
            lon = -83.42
        };

        // DateTime to keep track of when items come into the ground station
        private DateTime startTime = DateTime.MaxValue;

        #region Form Controls

        public MainForm()
        {
            InitializeComponent();

            PlaybackController = new Playback.Playback(MainDataMaster, UpdateDefaultPlayback, UpdateGPSPlayback);

            // Enable debug-specific functionality
            if (DEBUG_ENABLED)
            {
                debugFunction = new Debugging.ArduinoDebugging(ParseData);
            }
            // Otherwise, run non-debug-specific functionality
            else
            {
                panelGPSPlot.UpdateLatLonTarget(targetLocation.lat, targetLocation.lon);
            }

            if (FLYING_PILGRIM)
            {
                panelGPSPlot.PilgrimBarrier();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Get all serial ports
            String[] ports = SerialPort.GetPortNames();

            foreach (string portname in ports)
            {
                // Extract the number and add to "COM" (to get rid of any extraneous characters)
                String portReplaced = "COM" + Regex.Replace(portname, @"\D*(\d+)\D*", "$1");

                // Only adds the serial port if it hasn't already been added
                if (!cmbSerialPort.Items.Contains(portReplaced))
                {
                    cmbSerialPort.Items.Add(portReplaced.Trim());
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close serial port if it is open
            if (xbeeSerial.IsOpen)
            {
                xbeeSerial.Close();
            }

            // Close the data file
            dataFile.Flush();
            dataFile.Close();
            dataFile = null;

            rawDataFile.Flush();
            rawDataFile.Close();
            rawDataFile = null;

            // Disable the parsing timer
            parseTimer.Enabled = false;

            // Close the video source (if it is open)
            panelCamera.CloseVideoSource();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelCamera.PromptVideoSource();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelCamera.CloseVideoSource();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Data Parsing

        private class LatLng
        {
            public double lat;
            public double lon;
        }

        // TODO: Verify that length of data (number of terms) is correct -> validate message
        // Parses data into a List
        public void ParseData(string InputString)
        {
            rawDataFile.WriteLine(InputString);

            // Divide data by each comma
            string[] DataString = InputString.Split(',');

            // Ensure that there are at least 2 data objects in the string
            if (DataString.Length < 2) return;

            // Initialize the start time (if necessary) and get the total seconds from the start time
            if (startTime > DateTime.Now) startTime = DateTime.Now;
            double dataSeconds = DateTime.Now.Subtract(startTime).TotalSeconds;

            // Checks for the "MX2" tag. If no tag, we are not receiving data from MX2 vehicle
            if (!DataString[1].Equals("MX2"))
            {
                Console.WriteLine("Not Reading MX2");
            }

            // Checks for 'A', 'B', or 'C' messages. If none, sends an error message

            // 'A' message delivers time in milliseconds, barometric altitude (meters),
            //      airspeed, payload drop time, and payload drop altitude (meters)
            if (DataString[0].Equals("A"))
            {
                // A,MX2,MILLIS,ALT_BARO,ANALOG_PITOT,PRESS,TEMP,DROP_TIME,DROP_ALT

                // Ignore data string if the lengths are not equal
                if (DataString.Length < A_MSG_LEN) return;

                // Parse Data from String
                DataDefault inDefault = new DataDefault();
                inDefault.time_seconds = dataSeconds;
                inDefault.alt_bar_ft = Convert.ToDouble(DataString[3]) * ConversionFactors.METERS_TO_FEET;

                int AnalogPitotValue = (int) Convert.ToDouble(DataString[4]);
                inDefault.pressure_pa = Convert.ToDouble(DataString[5]);
                inDefault.temperature_c = Convert.ToDouble(DataString[6]);

                inDefault.dropTime_seconds = Convert.ToDouble(DataString[7]) * ConversionFactors.MILLIS_TO_SECONDS;
                inDefault.dropAlt_ft = Convert.ToDouble(DataString[8]) * ConversionFactors.METERS_TO_FEET;

                // Calculate Airspeed from Analog Value
                inDefault.airspeed_ft_s = PitotLibrary.GetAirspeedFeetSeconds(AnalogPitotValue, inDefault.temperature_c, inDefault.pressure_pa);

                // Write Data to File
                dataFile.WriteLine(inDefault.ToString());

                // Add data object to data master list
                MainDataMaster.DefaultDataList.Add(inDefault);

                // Update the standard altitude plot and instruments
                panelAltitudePlot.UpdateAltitude(inDefault.time_seconds, inDefault.alt_bar_ft);
                panelInstruments.UpdateInstruments(inDefault.airspeed_ft_s, inDefault.alt_bar_ft);

                // Check if a payload has been dropped
                if (!PayloadDropped && inDefault.dropTime_seconds > 0)
                {
                    panelDropStatus.UpdateDrop(inDefault.time_seconds, inDefault.alt_bar_ft);
                    panelAltitudePlot.UpdateAltitudeDrop(inDefault.time_seconds, inDefault.dropAlt_ft);

                    // Get the last GPS coordinate to plot drop on the GPS panel
                    // Sends aircraft and predicted drop GPS coordinates to DropPredictionStatus panel
                    //      -> Will not show if GPS list is empty, no GPS position information
                    int gpsCount = MainDataMaster.GpsDataList.Count;
                    if (gpsCount > 0)
                    {
                        DataGPS lastGpsData = MainDataMaster.GpsDataList[gpsCount - 1];
                        panelGPSPlot.UpdateLatLonDrop(lastGpsData.gps_lat, lastGpsData.gps_lon);

                        panelDropPredictionStatus.UpdatePlaneLatLon(lastGpsData.gps_lat, lastGpsData.gps_lon);

                        LatLng predictedLatLng = PredictPayloadDropLoc(lastGpsData);
                        if (predictedLatLng != null)
                        {
                            panelDropPredictionStatus.UpdatePredictLatLon(predictedLatLng.lat, predictedLatLng.lon);
                        }
                    }

                    // Set PayloadDropped to true
                    PayloadDropped = true;
                }
            }

            // 'B' message delivers time in milliseconds, the gps system, the gps latitude,
            //      the gps longitude, the gps measurement for groundspeed in knots, 
            //        gps course (degrees), gps altitude (meters), 
            //        gps hdop, and gps fixtime (milliseconds)
            //      Converts meters to feet, and knots to ft/s
            //      Divide some variables to restore proper values 
            else if (DataString[0].Equals("B"))
            {
                // B,MX2,MILLIS,GPS_SYSTEM,LAT,LON,GPS_SPEED,GPS_COURSE,GPS_ALT,GPS_HDOP

                // Ignore data string if the lengths are not equal
                if (DataString.Length < B_MSG_LEN) return;

                // Parse GPS Data
                DataGPS gpsData = new DataGPS();
                gpsData.time_seconds = dataSeconds;
                gpsData.gps_system = DataString[3];
                gpsData.gps_lat = (Convert.ToDouble(DataString[4])) / 1000000; //degrees
                gpsData.gps_lon = (Convert.ToDouble(DataString[5])) / 1000000; //degrees
                gpsData.gps_speed_ft_s = ((Convert.ToDouble(DataString[6])) / 1000) * ConversionFactors.KNOTS_TO_FPS; //Converts Speed from Knots to ft/s
                gpsData.gps_course = (Convert.ToDouble(DataString[7])) / 1000; //degrees
                gpsData.gps_alt_ft = ((Convert.ToDouble(DataString[8])) / 1000) * ConversionFactors.METERS_TO_FEET;
                gpsData.gps_hdop = (Convert.ToDouble(DataString[9])) / 10;

                // Write data to file
                dataFile.WriteLine(gpsData.ToString());

                // Add data object to DataMaster
                MainDataMaster.GpsDataList.Add(gpsData);

                // Update GPS Panel with new location
                panelGPSPlot.UpdateLatLon(gpsData.gps_lat, gpsData.gps_lon);

                // Predict payload drop location and display location on screen if it exists
                LatLng predictedLatLng = PredictPayloadDropLoc(gpsData);
                if (predictedLatLng != null)
                {
                    panelGPSPlot.UpdateLatLonPredict(predictedLatLng.lat, predictedLatLng.lon);
                }
            }

            // 'C' message delivers gyro data. Gives time in milliseconds; x, y, and z gyro values;
            //      and x, y, and z acceleration values.
            //      Gyro in radians/s
            //      Acceleration in m/s^2
            else if (DataString[0].Equals("C"))
            {
                // C,MX2,MILLIS,GYROX,GYROY,GYROZ,ACCELX,ACCELY,ACCELZ

                // Ignore data string if the lengths are not equal
                if (DataString.Length < C_MSG_LEN) return;

                // Parse incoming data
                DataAccelGyro gyroData = new DataAccelGyro();
                gyroData.time_seconds = dataSeconds;
                gyroData.gyro_x = Convert.ToDouble(DataString[3]);
                gyroData.gyro_y = Convert.ToDouble(DataString[4]);
                gyroData.gyro_z = Convert.ToDouble(DataString[5]);
                gyroData.accel_x = Convert.ToDouble(DataString[6]);
                gyroData.accel_y = Convert.ToDouble(DataString[7]);
                gyroData.accel_z = Convert.ToDouble(DataString[8]);

                // Write data to file
                dataFile.WriteLine(gyroData.ToString());

                // Add data object to DataMaster
                MainDataMaster.GryoAccelDataList.Add(gyroData);
            }
            else
            {
                // If unknown message, write information to console
                dataFile.WriteLine("Unknown Message: " + InputString);
            }
        }

        private LatLng PredictPayloadDropLoc(DataGPS gpsData)
        {
            DropPrediction.Vector3 windSpeed = new DropPrediction.Vector3(panelWindInput.getWindX(), panelWindInput.getWindY());
            Console.WriteLine("Wind: " + windSpeed.x + ", " + windSpeed.y);

            // Return if there are no items in the default data list
            if (MainDataMaster.DefaultDataList.Count == 0) return null;

            // Get the aircraft altitude in Meters from the latest default data object
            double aircraftAlt = MainDataMaster.DefaultDataList[MainDataMaster.DefaultDataList.Count - 1].alt_bar_ft;
            aircraftAlt /= ConversionFactors.METERS_TO_FEET;

            // Get the initial position based on altitude
            DropPrediction.Vector3 landingPos = new DropPrediction.Vector3(0, 0, aircraftAlt);

            // Calculate the x and y velocities from heading
            double velX = gpsData.gps_speed_ft_s * Math.Sin(gpsData.gps_course * ConversionFactors.DEG_TO_RAD) / ConversionFactors.METERS_SECONDS_TO_FEET_SECONDS;
            double velY = gpsData.gps_speed_ft_s * Math.Cos(gpsData.gps_course * ConversionFactors.DEG_TO_RAD) / ConversionFactors.METERS_SECONDS_TO_FEET_SECONDS;
            DropPrediction.Vector3 vel = new DropPrediction.Vector3(velX, velY, 0);

            // Get the resulting delta-location from the aircraft
            DropPrediction.Vector3 result = DropPrediction.PredictionAlgorithmEuler.PredictionIntegrationFunction(landingPos, vel, windSpeed);

            // Find dx and dy in feet from the aircraft.
            double dx = result.x * ConversionFactors.METERS_TO_FEET;
            double dy = result.y * ConversionFactors.METERS_TO_FEET;

            // Find the latitude and longitude of the paylaod
            LatLng res = new LatLng();

            res.lat = gpsData.gps_lat + dy / PhysicsConstants.EARTH_RADIUS_FT * ConversionFactors.RAD_TO_DEG;

            double lonRadius = PhysicsConstants.EARTH_RADIUS_FT * Math.Cos(res.lat * ConversionFactors.DEG_TO_RAD);
            res.lon = gpsData.gps_lon + dx / lonRadius * ConversionFactors.RAD_TO_DEG;

            // Return the latitude and longitude
            return res;
        }

        // Reads through ReceivedData, extracts telemetry messages, and sends them
        // to the parsing function
        private void parseTimer_Tick(object sender, EventArgs e)
        {
            // String to hold all incoming data
            string incomingData = ReceivedData.ToString();

            if (String.IsNullOrWhiteSpace(incomingData)) return;

            Console.Write(incomingData);

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
            if (lastIndex >= 0) ReceivedData.Remove(0, lastIndex + 1);
        }

        #endregion

        #region Serial Port

        private void openPort_Click(object sender, EventArgs e)
        {
            // Opens the serial port if it is not already open
            if (!xbeeSerial.IsOpen && !String.IsNullOrWhiteSpace(cmbSerialPort.Text))
            {
                xbeeSerial.PortName = cmbSerialPort.Text;

                // Attempt to open the serial port. Display an error message on failure
                try
                {
                    xbeeSerial.Open();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Connect Error");
                }

                // Check if the serial port is open and set status to appropriate message
                if (xbeeSerial.IsOpen)
                {
                    lblConnectionStatus.Text = "Connected!";
                }
                else
                {
                    lblConnectionStatus.Text = "Connection Failed";
                }
            }
        }

        private void closePort_Click(object sender, EventArgs e)
        {
            // Closes the serial port if it is open
            if (xbeeSerial.IsOpen) xbeeSerial.Close();

            // Set status to not connected
            lblConnectionStatus.Text = "Not Connected";
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Read data coming in from the serial port and add it to the ReceivedData StringBuilder
            ReceivedData.Append(xbeeSerial.ReadExisting());
        }

        #endregion

        #region Playback Functionality

        // Playback button. Wipe data, and put data into playback
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

            hasDroppedPlayback = false;
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
        bool hasDroppedPlayback = false;

        public void UpdateDefaultPlayback(DataDefault indata)
        {
            panelAltitudePlot.UpdateAltitude(indata.time_seconds, indata.alt_bar_ft);
            panelInstruments.UpdateInstruments(indata.airspeed_ft_s, indata.alt_bar_ft);

            // Check for a drop in the playback (hasDroppedPlayback should be reset in playToolback function)
            if (!hasDroppedPlayback && indata.dropTime_seconds > 0)
            {
                // Update altitude with drop
                panelAltitudePlot.UpdateAltitudeDrop(indata.time_seconds, indata.dropAlt_ft);

                // Check for a GPS drop, if it exists update the panel
                DataGPS lastGps = PlaybackController.GetGPSBeforeTime(indata.time_seconds);
                if (lastGps != null) panelGPSPlot.UpdateLatLonDrop(lastGps.gps_lat, lastGps.gps_lon);

                // Set hasDroppedPlayback to true
                hasDroppedPlayback = true;
            }
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

        private void jump10sBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackController.JumpTenSecondsBeforeDrop();
        }

        #endregion
    }
}

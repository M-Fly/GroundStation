using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroundStation.DataRecording;
using System.Windows.Forms;
using GroundStation.Panels;



namespace GroundStation.Playback
{
    class Playback
    {
        // Constants for timer frequency
        const int PLAYBACK_HZ = 10;

        // Current elapsed time
        double elapsed_time = 0.0;

        // Variables to keep track of array indices
        int lastDefaultIndex = 0;
        int lastGpsIndex = 0;

        // Playback speed (x1)
        int playbackSpeed = 1;

        //Timer for facilitating playback
        Timer playbackTimer = new Timer();

        // DataMaster object, where data is held
        DataMaster dataMaster;

        // Delegates to add values back in the main form
        public delegate void DataGPSDelegate(DataGPS indata);
        public delegate void DataDefaultDelegate(DataDefault indata);

        DataGPSDelegate GPSDelegate;
        DataDefaultDelegate DefaultDelegate;

        // Playback
        //
        // Constructor to setup Playback functionality
        //
        // REQUIRES:
        //      DataMaster dm_in - DataMaster object containing flight data
        //      DataDefaultDelegate inDefaultDelegate - Delegate to add "standard" data to telemetry display
        //      DataGPSDelegate inGPSDelegate - Delegate to add GPS data to the telemetry display
        //
        public Playback(DataMaster dm_in, DataDefaultDelegate inDefaultDelegate, DataGPSDelegate inGPSDelegate)
        {
            dataMaster = dm_in;

            // Set delegate objects
            GPSDelegate = inGPSDelegate;
            DefaultDelegate = inDefaultDelegate;

            // Initialize timer
            playbackTimer.Interval = 1000 / PLAYBACK_HZ;
            playbackTimer.Tick += tmrPlaybackTick;

            // Ensure that the itmer is disabled
            playbackTimer.Enabled = false;
        }

        // Play
        //
        // Enables the playback feature by starting the timer
        //
        public void Play()  
        {
            //Enable timer
            playbackTimer.Start();
            playbackTimer.Enabled = true;
        }

        // ResetPlayback
        //
        // Resets all values to their default state so that playback can be repeated
        //
        // MODIFIES:
        //      playbackTimer
        //      elapsed_time
        //      lastDefaultIndex
        //      lastGpsIndex
        //      playbackSpeed
        //
        public void ResetPlayback()
        {
            // Dissable the timer and reset elapsed time
            playbackTimer.Enabled = false;
            elapsed_time = 0.0;

            // Reset indices to 0
            lastDefaultIndex = 0;
            lastGpsIndex = 0;

            // Ensure playback speed is set to 1x
            playbackSpeed = 1;
        }

        // SetPlaybackSpeed
        //
        // Sets a new play speed
        //
        // REQUIRES:
        //      int inspeed - new playback speed > 0
        //
        // MODIFIES:
        //      playbackSpeed
        //
        public void SetPlaybackSpeed(int inspeed)
        {
            // Ensure that inspeed is greater than 0
            if (inspeed <= 0) return;

            // Set the new playbackSpeed
            playbackSpeed = inspeed;
        }

        // tmrPlaybackTick
        //
        // Goes through our lists of default and GPS objects. One loop for each reads through the information.
        // Each for loop begins from the last "tick", then reads data up to an index equal to the current time
        // Use Delegate Method to call functions and send data back to the MainForm
        //
        private void tmrPlaybackTick(object sender, EventArgs e)
        {
            // Set the new elapsed_time
            elapsed_time += playbackSpeed * playbackTimer.Interval / 1000.0;

            // Get the last default index as variables
            int currentDefaultIndex = lastDefaultIndex;
            int currentGpsIndex = lastGpsIndex;

            // Loop through the DefaultDataList and add respective data to the MainForm
            for (; (currentDefaultIndex < dataMaster.DefaultDataList.Count) && 
                    (dataMaster.DefaultDataList[currentDefaultIndex].time_seconds <= elapsed_time);
                    currentDefaultIndex++)
            {
                DefaultDelegate(dataMaster.DefaultDataList[currentDefaultIndex]);
            }

            // Loop through the GpsDataList and add respective data to the MainForm
            for (; (currentGpsIndex < dataMaster.GpsDataList.Count) && 
                    (dataMaster.GpsDataList[currentGpsIndex].time_seconds <= elapsed_time);
                    currentGpsIndex++)
            {
                GPSDelegate(dataMaster.GpsDataList[currentGpsIndex]);
            }

            // If the indices are both greater than what is present in the arrays,
            // stop the timer and end the playback
            int defaultItems = dataMaster.DefaultDataList.Count;
            int gpsItems = dataMaster.GpsDataList.Count;

            if (currentDefaultIndex >= defaultItems - 1 && gpsItems >= gpsItems - 1)
            {
                playbackTimer.Stop();
                playbackTimer.Enabled = false;
            }

            // Set the new last indices
            lastDefaultIndex = currentDefaultIndex;
            lastGpsIndex = currentGpsIndex;
        }
    }
}

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
        //Const for timer frequency
        const int PLAYBACK_HZ = 10;

        double elapsed_time = 0.0;

        int lastDefaultIndex = 0;
        int lastGpsIndex = 0;

        int playbackSpeed = 1;

        //Timer for facilitating playback
        Timer playbackTimer = new Timer();

        DataMaster dataMaster;

        public delegate void DataGPSDelegate(DataGPS indata);
        public delegate void DataDefaultDelegate(DataDefault indata);

        DataGPSDelegate GPSDelegate;
        DataDefaultDelegate DefaultDelegate;

        public Playback(DataMaster dm_in, DataDefaultDelegate inDefaultDelegate, DataGPSDelegate inGPSDelegate)
        {
            dataMaster = dm_in;

            // Set delegate objects
            GPSDelegate = inGPSDelegate;
            DefaultDelegate = inDefaultDelegate;

            //Initialize timer
            playbackTimer.Interval = 1000 / PLAYBACK_HZ;
            playbackTimer.Tick += tmrPlaybackTick;

            playbackTimer.Enabled = false;
        }

        public void Play()  
        {
            //Enable timer
            playbackTimer.Start();
            playbackTimer.Enabled = true;
        }

        public void ResetPlayback()
        {
            playbackTimer.Enabled = false;
            elapsed_time = 0.0;

            lastDefaultIndex = 0;
            lastGpsIndex = 0;

            playbackSpeed = 1;
        }

        public void SetPlaybackSpeed(int inspeed)
        {
            playbackSpeed = inspeed;
        }

        //Receives:
        //Modifies:
        //Effects: Goes through our lists of default and GPS objects. One loop for each reads through the information
        //          Each for loop begins from the last "tick", then reads data up to an index equal to the current time
        // Use Delegate Method to Call functions
        private void tmrPlaybackTick(object sender, EventArgs e)
        {
            elapsed_time += playbackSpeed * playbackTimer.Interval / 1000.0;
            int currentDefaultIndex = lastDefaultIndex;
            int currentGpsIndex = lastGpsIndex;

            for (; (currentDefaultIndex < dataMaster.DefaultDataList.Count) && 
                    (dataMaster.DefaultDataList[currentDefaultIndex].time_seconds <= elapsed_time);
                    currentDefaultIndex++)
            {
                DefaultDelegate(dataMaster.DefaultDataList[currentDefaultIndex]);
            }
          
                
            for (; (currentGpsIndex < dataMaster.GpsDataList.Count) && 
                    (dataMaster.GpsDataList[currentGpsIndex].time_seconds <= elapsed_time);
                    currentGpsIndex++)
            {
                GPSDelegate(dataMaster.GpsDataList[currentGpsIndex]);
            }

            int defaultItems = dataMaster.DefaultDataList.Count;
            int gpsItems = dataMaster.GpsDataList.Count;

            if (currentDefaultIndex >= defaultItems - 1 && gpsItems >= gpsItems - 1)
            {
                playbackTimer.Stop();
            }

            lastDefaultIndex = currentDefaultIndex;
            lastGpsIndex = currentGpsIndex;

            
        }
    }
}

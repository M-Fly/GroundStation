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
        int PLAYBACK_HZ = 5;

        double elapse_time = 0;

        int lastDefaultIndex = 0;
        int lastGpsIndex = 0;

        int playbackspeed = 1;

        //Timer for facilitating playback
        Timer playbackTimer = new Timer();

        List <DataDefault> defaultDataList;
        List <DataGPS> gpsDataList;

        public delegate void DataGPSDelegate(DataGPS indata);
        public delegate void DataDefaultDelegate(DataDefault indata);
        DataGPSDelegate GPSDelegate;
        DataDefaultDelegate DefaultDelegate;

        public void GraphPlayback(List <DataDefault> in_default, List <DataGPS> in_gps, DataDefaultDelegate inDefaultDelegate, DataGPSDelegate inGPSDelegate)  
        {
            //Initialize timer
            playbackTimer.Interval = 1000 / PLAYBACK_HZ;
            playbackTimer.Tick += tmrPlaybackTick;

            //Enable timer
            playbackTimer.Enabled = true;

           
            defaultDataList = in_default;
            gpsDataList = in_gps;

            // Set delegate objects
            GPSDelegate = inGPSDelegate;
            DefaultDelegate = inDefaultDelegate;
        }

        public void SetPlaybackSpeed(int inspeed)
        {
            playbackspeed = inspeed;
        }

        //Receives:
        //Modifies:
        //Effects: Goes through our lists of default and GPS objects. One loop for each reads through the information
        //          Each for loop begins from the last "tick", then reads data up to an index equal to the current time
        // Use Delegate Method to Call functions
        private void tmrPlaybackTick(object sender, EventArgs e)
        {
            elapse_time += playbackspeed * playbackTimer.Interval / 1000.0;
            int currentDefaultIndex = lastDefaultIndex;
            int currentGpsIndex = lastGpsIndex;

            bool bothCompleted = true;
            for (; (currentDefaultIndex < defaultDataList.Count) && 
                    (defaultDataList[currentDefaultIndex].time_seconds <= elapse_time);
                    currentDefaultIndex++)
            {
                //AltitudePlot.UpdateAltitude(default_mg[i].time_seconds, default_mg[i].alt_bar_ft);
                DefaultDelegate(defaultDataList[currentDefaultIndex]);

                bothCompleted &= false;
            }
          
                
            for (; (currentGpsIndex < gpsDataList.Count) && 
                    (gpsDataList[currentGpsIndex].time_seconds <= elapse_time);
                    currentGpsIndex++)
            {
                //GraphGPS.UpdateLatLon(gps_mg[j].gps_lat, gps_mg[j].gps_lon);
                GPSDelegate(gpsDataList[currentGpsIndex]);

                bothCompleted &= false;
            }

            lastDefaultIndex = currentDefaultIndex;
            lastGpsIndex = currentGpsIndex;

            if (bothCompleted)
            {
                playbackTimer.Stop();
                playbackTimer.Dispose();
            }
        }
    }
}

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

        double num_ticks = 0;

        int before_i = 0;
        int before_j = 0;

        //Timer for facilitating playback
        Timer playbackTimer = new Timer();

        List <DataDefault> default_mg;
        List <DataGPS> gps_mg;

        public delegate void DataGPSDelegate(DataGPS indata);
        public delegate void DataDefaultDelegate(DataDefault indata);
        DataGPSDelegate GPSDelegate;
        DataDefaultDelegate DefaultDelegate;





        public void GraphPlayback(List <DataDefault> in_default, List <DataGPS> in_gps, DataDefaultDelegate inGPSDelegate, DataGPSDelegate inDefaultDelegate)  
        {
            //Initialize timer
            playbackTimer.Interval = 1000 / PLAYBACK_HZ;
            playbackTimer.Tick += tmrPlaybackTick;

            //Enable timer
            playbackTimer.Enabled = true;

           
            default_mg = in_default;
            gps_mg = in_gps;
            GPSDelegate = inDefaultDelegate;
            DefaultDelegate = inGPSDelegate;
           

        }

        // Use Delegate Method to Call functions

        private void tmrPlaybackTick(object sender, EventArgs e)
        {


            double elapse_time = num_ticks * playbackTimer.Interval * 1000;
            int i = before_i;
            int j = before_j;

            for (; default_mg[i].time_seconds <= elapse_time; i++)
            {
                //AltitudePlot.UpdateAltitude(default_mg[i].time_seconds, default_mg[i].alt_bar_ft);
                DefaultDelegate(default_mg[i]);   

            }
          
                
            for (; gps_mg[j].time_seconds <= elapse_time; j++)
            {
                //GraphGPS.UpdateLatLon(gps_mg[j].gps_lat, gps_mg[j].gps_lon);
                GPSDelegate(gps_mg[j]);

            }

            before_i = i;
            before_j = j;
            
            num_ticks++;

        }
    }
}

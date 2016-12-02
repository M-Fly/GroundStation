using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroundStation.DataRecording;
using System.Windows.Forms;

namespace GroundStation.Playback
{
    class Playback
    {
        //Const for timer frequency
        const int PLAYBACK_HZ = 5;

        //Timer for facilitating playback
        Timer playbackTimer = new Timer();

        public void GraphPlayback(List <DataDefault> in_default, List <DataGPS> in_gps)  
        {
            //Initialize timer
            playbackTimer.Interval = 1000 / PLAYBACK_HZ;
            playbackTimer.Tick += tmrPlaybackTick;

            //Enable timer
            playbackTimer.Enabled = true;
        }

        private void tmrPlaybackTick(object sender, EventArgs e)
        {



        }
    }
}

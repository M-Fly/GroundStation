using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation.DataRecording
{
    class DataDefault
    {
        public double time_seconds;

        public double alt_bar_ft;
        public double airspeed_ft_s;

        public double dropTime_seconds;
        public double dropAlt_ft;

        //Writes all Default data into a string and returns the string
        public String ToString()
        {
            String s = "A," 
                + time_seconds + ","
                + alt_bar_ft + ","
                + airspeed_ft_s + ","
                + dropTime_seconds + ","
                + dropAlt_ft;

            return s;
        }
    }
}

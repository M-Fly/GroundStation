using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation.DataRecording
{
    public class DataD
    {
        public double time_seconds;
        public double alt;

        public override string ToString()
        {
            String D = "D,"
                + time_seconds + ","
                + alt;

            return D;
        }
    }
}

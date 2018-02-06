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
        public double alt_1;
        public double alt_2;

        public override string ToString()
        {
            String D = "D,"
                + time_seconds + ","
                + alt_1 + ","
                + alt_2 + ",";

            return D;
        }
    }
}

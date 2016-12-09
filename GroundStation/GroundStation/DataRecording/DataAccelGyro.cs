using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation.DataRecording
{
    public class DataAccelGyro
    {
        public double time_seconds;

        // Gyro vals are in Radians / Seconds
        public double gyro_x;
        public double gyro_y;
        public double gyro_z;

        // Accel vals are in Meters / Seconds^2
        public double accel_x;
        public double accel_y;
        public double accel_z;

        //Writes all Default data into a string and returns the string
        public override String ToString()
        {
            String s = "C," 
                + time_seconds + ","
                + gyro_x + ","
                + gyro_y + ","
                + gyro_z + ","
                + accel_x + ","
                + accel_y + ","
                + accel_z;

            return s;
        }
    }
}

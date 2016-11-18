using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation.DataRecording
{
    class DataGPS
    {
        public double time_seconds;
        public String gps_system;

        public double gps_lat;
        public double gps_lon;

        public double gps_speed_ft_s;
        public double gps_course;
        public double gps_alt_ft;

        public double gps_hdop;
        public double gps_fixtime_millis;

        // REQUIRES: Nothing
        // MODIFIES: Nothing
        // EFFECTS:  Returns a header for a CSV File to outline what each column is
        public String GetHeader()
        {
            return "TIME (MILLIS), GPS SYSTEM, LATITUDE, LONGITUDE, GROUND SPEED (FT/S), COURSE (DEG), ALTITUDE (FT), HDOP, FIX TIME (MILLIS)";
        }
    }
}

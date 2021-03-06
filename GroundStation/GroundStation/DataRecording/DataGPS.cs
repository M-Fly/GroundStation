﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation.DataRecording
{
    public class DataGPS
    {
        public double time_seconds;
        public String gps_system;

        public double gps_lat;
        public double gps_lon;

        public double gps_speed_ft_s;
        public double gps_course;
        public double gps_alt_ft;

        public double gps_hdop;

        //Writes all Default data into a string and returns the string
        public override String ToString()
        {
            String s = "B,"
                + time_seconds + ","
                + gps_system + ","
                + gps_lat + ","
                + gps_lon + ","
                + gps_speed_ft_s + ","
                + gps_course + ","
                + gps_alt_ft + ","
                + gps_hdop + ",";

            return s;
        }
    }
}

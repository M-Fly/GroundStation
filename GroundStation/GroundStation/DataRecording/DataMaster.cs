using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation.DataRecording
{
    class DataMaster
    {
        // Saving data to files happens here

        public List<DataAccelGyro> gyro_data = new List<DataAccelGyro>();

        public List<DataDefault> default_data = new List<DataDefault>();

        public List<DataGPS> gps_data = new List<DataGPS>();
        
       

    }
}

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
        // Lists to store data objects

        public List<DataDefault> DefaultDataList = new List<DataDefault>();
        public List<DataGPS> GpsDataList = new List<DataGPS>();
        public List<DataAccelGyro> GryoAccelDataList = new List<DataAccelGyro>();
        public List<DataD> DataDList = new List<DataD>();
     }
}

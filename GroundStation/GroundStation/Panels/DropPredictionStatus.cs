using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroundStation.Panels
{
    public partial class DropPredictionStatus : UserControl
    {
        public DropPredictionStatus()
        {
            InitializeComponent();
        }

        // UpdateDropLatLon
        //
        // Updates the text fields in the drop prediction diplay when the payload is dropped
        //
        // REQUIRES:
        //      double drop_lat - drop latitude in degrees
        //      double drop_lon - drop longitude in degrees
        //      double plane_lat - drop latitude in degrees
        //      double plane_lon - drop longitude in degrees
        //
        // EFFECTS:
        //      Updates the drop prediciton display labels. Shows last GPS predition for payload
        //      drop and aircraft during drop.
        //

        public void UpdatePredictLatLon(double drop_lat, double drop_lon, double plane_lat, double plane_lon)
        {
            Drop_Predict_GPS.Text = String.Format("Drop Lat Lon: {0:000000}, {1:000000}", drop_lat, drop_lon);
            Drop_Plane_GPS.Text = String.Format("Plane Lat Lon: {0:000000}, {1:000000}", plane_lat, plane_lon);
        }
    }
}

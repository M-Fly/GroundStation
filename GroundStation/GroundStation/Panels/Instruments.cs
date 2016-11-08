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
    public partial class Instruments : UserControl
    {
        public Instruments()
        {
            InitializeComponent();

        }

        //Requires: Airspeed in feet per second, Altitude in feet
        //Modifies: Instruments_Alt and Instruments_Airspeed labels
        //Effects: Instruments display
        public void UpdateInstruments(double airspeed_fts, double alt_ft)
        {
            Instruments_Alt.Text = String.Format("Altitude: {0:0.0} ft", alt_ft); //States Altitude
            Instruments_Airspeed.Text = String.Format("Ground Speed: {0:0.00} ft/s", airspeed_fts); //States Airspeed
         }
    }
}

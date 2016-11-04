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
         //Modifies:
         //Effects: Instruments display
         public void UpdateInstruments(double airspeed_fts, double alt_ft)
         {
            Instruments_Airspeed.Text = "Speed: " + airspeed_fts + " ft/s."; //States Airspeed
            Instruments_Alt.Text = "Altitude: " + alt_ft + " ft."; //States Altitude
         }
    }
}

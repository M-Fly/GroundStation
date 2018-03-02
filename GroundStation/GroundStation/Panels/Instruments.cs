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

        // UpdateInstruments
        //
        // Updates the instrument display with the current airspeed and altitude readouts
        //
        // REQUIRES:
        //      double airspeed_fts - Airspeed in feet per second
        //      double alt_ft - Altitude in feet
        // MODIFIES:
        //      Instruments_Alt and Instruments_Airspeed labels
        //
        public void UpdateInstruments(double airspeed_fts, double alt_ft)
        {
            // Update the altitude and airspeed labels
            //Instruments_Alt.Text = String.Format("Altitude: {0:0.0} ft", alt_ft);
            Instruments_Airspeed.Text = String.Format("Ground Speed: {0:0.00} ft/s", airspeed_fts);
         }
        
        public void UpdateInstrumentsAir(double airspeed_fts)
        {
            // Update airspeed only
            Instruments_Airspeed.Text = String.Format("Airspeed: {0:0.00} ft/s", airspeed_fts);
        }

        public void UpdateInstrumentsAlt(double alt_ft)
        {
            Instruments_Alt.Text = String.Format("Altitude: {0:0.0} ft", alt_ft);
        }
    }
}

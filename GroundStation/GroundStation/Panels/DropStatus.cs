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
    public partial class DropStatus : UserControl
    {
        public DropStatus()
        {
            InitializeComponent();

        }
        
        //Requires: altitude in feet and time in seconds
        //Modifies: Nothing
        //Effects: drop status display
        public void UpdateDrop(double time_s, double alt_ft)
        {
            Payload_Time_Status.Text = String.Format("Drop Time: {0:0.0} s", time_s);       //States time that payload was dropped.
            Payload_Alt_Status.Text = String.Format("Drop Altitude: {0:0.0} ft", alt_ft);   //States altitude that payload was dropped.
        }
    }
}

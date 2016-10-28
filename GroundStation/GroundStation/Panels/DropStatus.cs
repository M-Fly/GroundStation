using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panels.GroundStation
{
    public partial class DropStatus : UserControl
    {
        public DropStatus()
        {
            InitializeComponent();

        }
        
        //Requires altitude and time
        //Effects drop status display
        public void UpdateDrop(int alt, int time)
        {
            Payload_Time_Status.Text = "Time: " + time+ " s"; //States time that payload was dropped.
            Payload_Alt_Status.Text = "Altitude: " + alt + " ft"; //States altitude that payload was dropped.
        }
    }
}

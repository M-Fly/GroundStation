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
    public partial class WindParameters : UserControl
    {
        public WindParameters()
        {
            InitializeComponent();
        }

        // Returns the Wind Speed that was entered into the textbox. Units are (m/s)
        public double getWindSpeed()
        {
            return Convert.ToDouble(WindParameters_SpeedInput.Text);
        }
        
        // Returns the Wind Direction that was entered into the textbox. Units are (degrees)
        public double getWindDirection()
        {
            return Convert.ToDouble(WindParameters_DirectionInput.Text);
        }
    }
}

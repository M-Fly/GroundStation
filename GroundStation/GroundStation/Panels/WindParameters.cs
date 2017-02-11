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
            double wind;
            if (Double.TryParse(WindParameters_SpeedInput.Text, out wind))
            {
                return wind;
            }
            else
            {
                return 0.0;
            }
        }
        
        // Returns the Wind Direction that was entered into the textbox. Units are (degrees)
        public double getWindDirection()
        {
            double dir;
            if (Double.TryParse(WindParameters_DirectionInput.Text, out dir))
            {
                return dir;
            }
            else
            {
                return 0.0;
            }
        }

        public double getWindX()
        {
            return getWindSpeed() * Math.Sin(getWindDirection() * Math.PI / 180.0);
        }

        public double getWindY()
        {
            return getWindSpeed() * Math.Cos(getWindDirection() * Math.PI / 180.0);
        }
    }
}

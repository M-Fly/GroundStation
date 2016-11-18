using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;



namespace GroundStation.Panels
{
    public partial class Camera : UserControl
    {
        public Camera()
        {
            InitializeComponent();

            ImageViewer viewer = new ImageViewer();
            Capture capture = new Capture();
            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {
                viewer.Image = capture.QueryFrame();
            });
            viewer.ShowDialog();

        }
    }
}

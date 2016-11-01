using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XBee.Converters;
using XBee.Devices;
using XBee.Frames;
using XBee.Observable;



namespace GroundStation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Probobility of being succesfull - test code
            Random rnd = new Random();
            int test_prob = rnd.Next(1, 100);
            label1.Text = (test_prob.ToString());
        }
    }


   







}

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

        Random rand = new Random((int) DateTime.UtcNow.Ticks);

        bool dropped = false;

        int time = 0;

        private void tmrTestData_Tick(object sender, EventArgs e)
        {
            double altitude = rand.NextDouble() * 75 + 50;

            instruments1.UpdateInstruments(rand.NextDouble() * 30 + 10, altitude);

            graphGPS1.UpdateLatLon(rand.NextDouble() * 5 + 40, rand.NextDouble() * -80 - 5);

            altitudePlotPanel.UpdateAltitude(time++, altitude);

            if (true || !dropped && rand.Next(0, 100) == 57)
            {
                dropStatusPanel.UpdateDrop(120, 87);
            }
        }
    }


   







}

﻿using System;
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

        int time_debug = 0;

        private void tmrTestData_Tick(object sender, EventArgs e)
        {
            double airspeed_ft_s = rand.NextDouble() * 30 + 10;
            double altitude_ft = rand.NextDouble() * 75 + 50;
            double lat_deg = rand.NextDouble() * 5 + 40;
            double long_deg = rand.NextDouble() * -80 - 5;

            instruments1.UpdateInstruments(airspeed_ft_s, altitude_ft);

            graphGPS1.UpdateLatLon(lat_deg, long_deg);

            altitudePlotPanel.UpdateAltitude(time_debug++, altitude_ft);

            if (!dropped && rand.Next(0, 50) == 0)
            {
                dropStatusPanel.UpdateDrop((int) altitude_ft, time_debug);
                graphGPS1.UpdateLatLonDrop(lat_deg, long_deg);

                dropped = true;
            }
        }
    }


   







}

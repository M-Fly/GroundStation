﻿using System;
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
        public void UpdateDrop(double alt_ft, double time_s)
        {
            Payload_Time_Status.Text = "Time: " + time_s + " s"; //States time that payload was dropped.
            Payload_Alt_Status.Text = "Altitude: " + alt_ft + " ft"; //States altitude that payload was dropped.
        }
    }
}

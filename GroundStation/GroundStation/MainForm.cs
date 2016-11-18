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
using System.IO.Ports;


namespace GroundStation
{
    public partial class MainForm : Form
    {
        private StringBuilder receivedData = new StringBuilder();

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
            time_debug++;

            instruments1.UpdateInstruments(airspeed_ft_s, altitude_ft);

            graphGPS1.UpdateLatLon(lat_deg, long_deg);

            altitudePlotPanel.UpdateAltitude(time_debug, altitude_ft);

            if (!dropped && rand.Next(0, 50) == 0)
            {
                dropStatusPanel.UpdateDrop((int) altitude_ft, time_debug);
                graphGPS1.UpdateLatLonDrop(lat_deg, long_deg);
                altitudePlotPanel.UpdateAltitudeDrop(time_debug, altitude_ft);

                dropped = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (string portname in SerialPort.GetPortNames())
            {
                cmbSerialPort.Items.Add(portname);
            }
            serialTimer.Start();
        }

        private void openPort_Click(object sender, EventArgs e)
        {

            if (!xbeeSerial.IsOpen)
            {
                xbeeSerial.PortName = cmbSerialPort.Text;
                if (!xbeeSerial.IsOpen) xbeeSerial.Open();
            }
        }

        private void closePort_Click(object sender, EventArgs e)
        {
            if (xbeeSerial.IsOpen) xbeeSerial.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

    
            receivedData.Append(xbeeSerial.ReadExisting());

            
            string[] message;

            message = receivedData.ToString().Split();
            
           
            

        }

        private void serialTimer_Tick(object sender, EventArgs e)
        {
            SerialOutput.Text = receivedData.ToString();
            
        }
    }


   







}

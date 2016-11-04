using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace GroundStation.Panels
{
    public partial class GraphGPS : UserControl
    {
        //For Latitude vs Longitude plot
        PlotView LatLongPlot;
        PlotModel LatLong_PlotModel;
        LineSeries LatLong_LineSeries;

        public GraphGPS()
        {
            InitializeComponent();

            //Initialize Latitude-Longitude plot elements
            LatLong_PlotModel = new PlotModel
            {
                Title = "Latitude vs Longitude Plot",
                PlotType = PlotType.XY
            };

            //Initialize LatLong_LineSeries
            LatLong_LineSeries = new LineSeries
            {
                Title = "Latitude and Longitude (Degrees)",
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Black,
            };

            LatLong_PlotModel.Series.Add(LatLong_LineSeries);
            LatLongPlot = new PlotView();
            LatLongPlot.Model = LatLong_PlotModel;
            LatLongPlot.Dock = DockStyle.Fill;
            LatLongPlot.Location = new Point(0, 0);
            this.Controls.Add(LatLongPlot);

            //Test - REMOVE BEFORE FLIGHT
            LatLong_PlotModel.Series.Add(new FunctionSeries(Math.Cos, -10, 10, 3.14159 / 2, "cos(x)"));
        }

        //Receives: doubles Latitude and Longitude
        //Modifies:
        //Effects:
        private void Update_LatLong(double lat_deg, double lon_deg)
        {
            LatLong_LineSeries.Points.Add(new DataPoint(lat_deg, lon_deg));
            LatLong_PlotModel.InvalidatePlot(true);
        }
    }
}

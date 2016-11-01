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
                Title = "Longitude (Degrees)",
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Black,
            };


        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            LatLong_PlotModel.InvalidatePlot(true);
                LatLong_LineSeries.Points.Add(new DataPoint(3, 5));
        }
    }
}

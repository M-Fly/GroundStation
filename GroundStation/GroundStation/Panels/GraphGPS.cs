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
        LineSeries LatLong_LineSeries_Drop;
        LineSeries LatLong_LineSeries_Target;
        LineSeries LatLong_LineSeries_Predict;

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
                //Title = "Latitude and Longitude (Degrees)",
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Blue,
            };

            //Line Series for drop coordinates
            LatLong_LineSeries_Drop = new LineSeries
            {
                //Title = "Latitude and Longitude of Drop (Degrees)",
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Transparent,
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Yellow,
                MarkerSize = 5,
            };

            //Line Series for Target Location
            LatLong_LineSeries_Target = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Transparent,
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Black,
                MarkerSize = 3,
            };

            //Line Series for Predicted Location
            LatLong_LineSeries_Predict = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Transparent,
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Red,
                MarkerSize = 3,
            };

            LatLong_PlotModel.Series.Add(LatLong_LineSeries);
            LatLong_PlotModel.Series.Add(LatLong_LineSeries_Drop);
            LatLong_PlotModel.Series.Add(LatLong_LineSeries_Target);
            LatLong_PlotModel.Series.Add(LatLong_LineSeries_Predict);
            LatLongPlot = new PlotView();
            LatLongPlot.Model = LatLong_PlotModel;
            LatLongPlot.Dock = DockStyle.Fill;
            LatLongPlot.Location = new Point(0, 0);
            this.Controls.Add(LatLongPlot);
        }

        //Update functions for coordinates, drop location, target location, and prediction location
        //below

        //Receives: doubles Latitude and Longitude
        //Modifies: 
        //Effects: 
        public void UpdateLatLon(double lat_deg, double lon_deg)
        {
            // Longitude goes first because it is the x position
            // Latitude goes second because it is the y position
            LatLong_LineSeries.Points.Add(new DataPoint(lon_deg, lat_deg));
            LatLong_PlotModel.InvalidatePlot(true);
        }

        //Receives: doubles Latitude and Longitude of Drop
        //Modifies:
        //Effects:
        public void UpdateLatLonDrop(double lat_drop_deg, double lon_drop_deg)
        {
            // Longitude goes first because it is the x position
            // Latitude goes second because it is the y position
            LatLong_LineSeries_Drop.Points.Add(new DataPoint(lon_drop_deg, lat_drop_deg));
            LatLong_PlotModel.InvalidatePlot(true);
        }

        //Receives: doubles Latitude and Longitude of Target
        //Modifies: Deletes previous target data before adding new target
        //Effects:
        public void UpdateLatLonTarget(double lat_target_deg, double lon_target_deg)
        {
            LatLong_LineSeries_Target.Points.Clear();
            LatLong_LineSeries_Target.Points.Add(new DataPoint(lon_target_deg, lat_target_deg));
            LatLong_PlotModel.InvalidatePlot(true);
        }

        //Receives: doubles Latitude and Longitude of Target
        //Modifies: Deletes previous prediction data before adding new prediction
        //Effects:
        public void UpdateLatLonPredict(double lat_target_deg, double lon_target_deg)
        {
            LatLong_LineSeries_Predict.Points.Clear();
            LatLong_LineSeries_Predict.Points.Add(new DataPoint(lon_target_deg, lat_target_deg));
            LatLong_PlotModel.InvalidatePlot(true);
        }

        //Receives:
        //Modifies: All LineSeries
        //Effects: WIPES ALL LINESERIES
        public void ClearGPS()
        {
            LatLong_LineSeries.Points.Clear();
            LatLong_LineSeries_Drop.Points.Clear();
            LatLong_LineSeries_Predict.Points.Clear();
            LatLong_LineSeries_Target.Points.Clear();
        }
    }
}

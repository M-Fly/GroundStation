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
        // Variables to keep track of the plot, plot model, and line series for the plot
        PlotView LatLonPlot;

        PlotModel LatLon_PlotModel;

        LineSeries LatLon_LineSeries;
        LineSeries LatLon_LineSeries_Drop;
        LineSeries LatLon_LineSeries_Target;
        LineSeries LatLon_LineSeries_Predict;

        // GraphGPS
        //
        // Constructor to setup the gps view plot and its respective series
        //
        public GraphGPS()
        {
            InitializeComponent();

            //Initialize Latitude-Longitude plot elements
            LatLon_PlotModel = new PlotModel
            {
                Title = "Latitude vs Longitude Plot",
                PlotType = PlotType.XY
            };

            //Initialize LatLong_LineSeries
            LatLon_LineSeries = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Blue,
            };

            //Line Series for drop coordinates
            LatLon_LineSeries_Drop = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Transparent,
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Yellow,
                MarkerSize = 5,
            };

            //Line Series for Target Location
            LatLon_LineSeries_Target = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Transparent,
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Black,
                MarkerSize = 3,
            };

            //Line Series for Predicted Location
            LatLon_LineSeries_Predict = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Transparent,
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Red,
                MarkerSize = 3,
            };

            // Add the series to the plot model
            LatLon_PlotModel.Series.Add(LatLon_LineSeries);
            LatLon_PlotModel.Series.Add(LatLon_LineSeries_Drop);
            LatLon_PlotModel.Series.Add(LatLon_LineSeries_Target);
            LatLon_PlotModel.Series.Add(LatLon_LineSeries_Predict);

            // Create the plot and set the below viewing properties
            LatLonPlot = new PlotView();
            LatLonPlot.Model = LatLon_PlotModel;
            LatLonPlot.Dock = DockStyle.Fill;
            LatLonPlot.Location = new Point(0, 0);

            // Add the LatLonPlot to the user control form
            this.Controls.Add(LatLonPlot);
        }

        #region GPS Plot Update Functions

        // UpdateLatLon
        //
        // Creates a new point on the plot with the aircraft's current location
        //
        // REQUIRES:
        //      double lat_deg - latitude in degrees
        //      double lon_deg - longitude in degrees
        //
        public void UpdateLatLon(double lat_deg, double lon_deg)
        {
            // Longitude goes first because it is the x position
            // Latitude goes second because it is the y position
            LatLon_LineSeries.Points.Add(new DataPoint(lon_deg, lat_deg));

            // Invalidate the plot so that it gets redrawn
            LatLon_PlotModel.InvalidatePlot(true);
        }

        // UpdateLatLonDrop
        //
        // Creates a new point at the specified latitude/longitude where the drop occurs
        //
        // REQUIRES:
        //      double lat_drop_deg - Drop latitude in degrees
        //      double lon_drop_deg - Drop longitude in degrees
        //
        public void UpdateLatLonDrop(double lat_drop_deg, double lon_drop_deg)
        {
            // Longitude goes first because it is the x position
            // Latitude goes second because it is the y position
            LatLon_LineSeries_Drop.Points.Add(new DataPoint(lon_drop_deg, lat_drop_deg));

            // Invalidate the plot so that it gets redrawn
            LatLon_PlotModel.InvalidatePlot(true);
        }

        // UpdateLatLonTarget
        //
        // Creates a single point at the specified latitude/longitudea at the target location
        //
        // REQUIRES:
        //      double lat_target_deg - Target latitude in degrees
        //      double lon_target_deg - Target longitude in degrees
        //
        public void UpdateLatLonTarget(double lat_target_deg, double lon_target_deg)
        {
            // Clear the old point and add the new one in its place
            LatLon_LineSeries_Target.Points.Clear();
            LatLon_LineSeries_Target.Points.Add(new DataPoint(lon_target_deg, lat_target_deg));

            // Invalidate the plot so that it gets redrawn
            LatLon_PlotModel.InvalidatePlot(true);
        }

        // UpdateLatLonPredict
        //
        // Creates a single point at the specified latitude/longitude at the target prediction location
        //
        // REQUIRES:
        //      double lat_target_deg - Target prediction latitude in degrees
        //      double lon_target_deg - Target prediction longitude in degrees
        //
        public void UpdateLatLonPredict(double lat_target_deg, double lon_target_deg)
        {
            // Clear the old point and add the new one in its place
            LatLon_LineSeries_Predict.Points.Clear();
            LatLon_LineSeries_Predict.Points.Add(new DataPoint(lon_target_deg, lat_target_deg));

            // Invalidate the plot so that it gets redrawn
            LatLon_PlotModel.InvalidatePlot(true);
        }

        #endregion

        // ClearGPS
        //
        // Clears all the line series and clears the plot
        //
        // MODIFEIS:
        //      All LineSeries
        // EFFECTS:
        //      WIPES ALL LINESERIES
        //
        public void ClearGPS()
        {
            LatLon_LineSeries.Points.Clear();
            LatLon_LineSeries_Drop.Points.Clear();
            LatLon_LineSeries_Predict.Points.Clear();
            LatLon_LineSeries_Target.Points.Clear();

            LatLon_PlotModel.InvalidatePlot(true);
        }
    }
}

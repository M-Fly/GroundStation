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
    public partial class AltitudePlot : UserControl
    {
        // Variables to keep track of the plot, plot model, and line series for the plot
        PlotView Altitude_Plot;

        PlotModel Altitude_Plot_Model;

        LineSeries Altitude_Series;
        LineSeries Altitude_Series_Drop;
        LineSeries Altitude_Limit_Series;

        // Altitude limit to display on the chart
        private double ALTITUDE_LIMIT_FT = 100;

        // AltitudePlot
        //
        // Constructor that sets up the altitude plot model and the line series for the plot
        //
        public AltitudePlot()
        {
            InitializeComponent();

            // Setup plot model
            Altitude_Plot_Model = new PlotModel
            {
                Title = "Altitude Plot",
                PlotType = PlotType.XY         
            };

            // Setup the line series for the altitude, altitude limit, and altitude dropo series

            Altitude_Series = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Blue,
            };

            Altitude_Limit_Series = new LineSeries
            {
                LineStyle = LineStyle.Dash,
                Color = OxyColors.Red,
            };

            Altitude_Series_Drop = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Color = OxyColors.Transparent,
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Yellow,
                MarkerSize = 5,

            };

            // Add the series to the altitude plot
            Altitude_Plot_Model.Series.Add(Altitude_Series);
            Altitude_Plot_Model.Series.Add(Altitude_Series_Drop);
            Altitude_Plot_Model.Series.Add(Altitude_Limit_Series);

            // Create the plot and setup parameters
            Altitude_Plot = new PlotView();
            Altitude_Plot.Model = Altitude_Plot_Model;
            Altitude_Plot.Dock = DockStyle.Fill;
            Altitude_Plot.Location = new Point(0, 0);

            // Add the plot to the control (as the only control)
            this.Controls.Add(Altitude_Plot);
        }

        // UpdateAltitudePlot
        //
        // REQUIRES:
        //      double time_seconds - current time in seconds
        //      double altitude_feet - aircraft altitude in feet
        //
        // EFFECTS:
        //      Adds the current altitude to the plot at the given time in seconds
        //
        public void UpdateAltitude(double time_seconds, double altitude_feet)
        {
            // Add the new point
            Altitude_Series.Points.Add(new DataPoint(time_seconds, altitude_feet));

            // The below creates a constant line at the limiting altitude, that we must
            // be above in order to drop the payload and count in the competition

            // If there are no points in the altitude limit series, create two new points
            if (Altitude_Limit_Series.Points.Count == 0)
            {
                Altitude_Limit_Series.Points.Add(new DataPoint(time_seconds, ALTITUDE_LIMIT_FT));
                Altitude_Limit_Series.Points.Add(new DataPoint(time_seconds, ALTITUDE_LIMIT_FT));
            }

            // Move the last point in the altitude limit series to the last point in the altitude series
            DataPoint lastPoint = Altitude_Limit_Series.Points[1];
            Altitude_Limit_Series.Points[1] = new DataPoint(time_seconds, lastPoint.Y);

            // Invalidate the plot so that it can be redrawn
            Altitude_Plot_Model.InvalidatePlot(true);
        }

        // UpdateAltitudeDrop
        //
        // Creates a single point at drop position(s) to clearly delineate the payload drop
        //
        // REQUIRES:
        //      double time_drop_seconds - current time in seconds
        //      double altitude_drop_feet - aircraft altitude in feet
        //
        // EFFECTS:
        //      Adds the drop altitude to the plot at the given time in seconds
        //
        public void UpdateAltitudeDrop(double time_drop_seconds, double altitude_drop_feet)
        {
            // Add the drop time/altitude to the plot
            Altitude_Series_Drop.Points.Add(new DataPoint(time_drop_seconds, altitude_drop_feet));

            // Invalidate the plot so that data is redrawn
            Altitude_Plot_Model.InvalidatePlot(true);
        }

        // ClearAlt
        //
        // MODIFIES:
        //      All LineSeries
        //
        // EFFECTS:
        //      WIPES ALL LINESERIES
        //
        public void ClearAlt()
        {
            Altitude_Series.Points.Clear();
            Altitude_Series_Drop.Points.Clear();

            Altitude_Plot_Model.InvalidatePlot(true);
        }
    }
}

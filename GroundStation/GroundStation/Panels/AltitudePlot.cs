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
        PlotView Altitude_Plot;

        PlotModel Altitude_Plot_Model;

        LineSeries Altitude_Series;
        
        LineSeries Altitude_Series_Drop;

        public AltitudePlot()
        {
            InitializeComponent();

            Altitude_Plot_Model = new PlotModel
            {
                Title = "Altitude Plot",
                PlotType = PlotType.XY         
            };

            Altitude_Series = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Blue,
            };

            // Initializing LineSeries for Altitude Drop Point
            Altitude_Series_Drop = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Transparent,
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Yellow,
                MarkerSize = 5,

            };
            Altitude_Plot_Model.Series.Add(Altitude_Series);
            Altitude_Plot_Model.Series.Add(Altitude_Series_Drop);
            Altitude_Plot = new PlotView();
            Altitude_Plot.Model = Altitude_Plot_Model;
            Altitude_Plot.Dock = DockStyle.Fill;
            Altitude_Plot.Location = new Point(0, 0);
            this.Controls.Add(Altitude_Plot);
        }

        public void UpdateAltitude(double time_seconds, double altitude_feet)
        {
            Altitude_Series.Points.Add(new DataPoint(time_seconds, altitude_feet));
            Altitude_Plot_Model.InvalidatePlot(true);
        }

        public void UpdateAltitudeDrop(double time_drop_seconds, double altitude_drop_feet)
        {
            Altitude_Series_Drop.Points.Add(new DataPoint(time_drop_seconds, altitude_drop_feet));
            Altitude_Plot_Model.InvalidatePlot(true);
        }

        //Receives:
        //Modifies: All LineSeries
        //Effects: WIPES ALL LINESERIES
        public void ClearAlt()
        {
            Altitude_Series.Points.Clear();
            Altitude_Series_Drop.Points.Clear();
        }
    }
}

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

        public AltitudePlot()
        {
            InitializeComponent();

            Altitude_Plot_Model = new PlotModel
            {
                Title = "Test",
                PlotType = PlotType.XY         
            };

            Altitude_Series = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Title = "Altitude (ft.)",
                Background = OxyColors.PowderBlue,
                Color = OxyColors.Black,
            };

            Altitude_Plot_Model.Series.Add(Altitude_Series);
            Altitude_Plot = new PlotView();
            Altitude_Plot.Model = Altitude_Plot_Model;
            Altitude_Plot.Dock = DockStyle.Fill;
            Altitude_Plot.Location = new Point(0, 0);
            this.Controls.Add(Altitude_Plot);
            Altitude_Plot_Model.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));

        }

        private void AltitudePlot_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // generates two sets of random numbers
            Random rnd = new Random();
            double test_probx = rnd.Next(0, 4);
            double test_proby = rnd.Next(0, 1);
            double test_probx1 = rnd.Next(4, 8);
            double test_proby1 = rnd.Next(0, 1);
            Altitude_Series.Points.Add(new DataPoint(test_probx, test_proby));
            Altitude_Series.Points.Add(new DataPoint(test_probx1, test_proby1));

            Altitude_Plot_Model.InvalidatePlot(true);
        }
    }
}

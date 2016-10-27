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

namespace Panels.GroundStation
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


            };

            Altitude_Plot_Model.Series.Add(Altitude_Series);
            Altitude_Plot = new PlotView();
            Altitude_Plot.Model = Altitude_Plot_Model;
            Altitude_Plot.Dock = DockStyle.Fill;
            Altitude_Plot.Location = new Point(0, 0);
            this.Controls.Add(Altitude_Plot);


        }

        private void AltitudePlot_Load(object sender, EventArgs e)
        {

        }
    }
}

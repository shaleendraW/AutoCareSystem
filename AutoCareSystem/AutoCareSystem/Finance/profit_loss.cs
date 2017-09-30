using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCareSystem
{
    public partial class profit_loss : f_stats
    {
        public profit_loss()
        {
            InitializeComponent();
        }

        private void SetChartType(object sender, EventArgs e)
        {
            if (radBar.Checked == true)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else if (radLine.Checked == true)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
            else if (radPie.Checked == true)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
        }
    }
}

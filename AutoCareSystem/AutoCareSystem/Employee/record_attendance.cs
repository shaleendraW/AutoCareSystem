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
    public partial class record_attendance : UserControl
    {
        public record_attendance()
        {
            InitializeComponent();

            
        }

        private void timer_tick(object sender, EventArgs e)
        {
            bunifuCustomLabel4.Text = System.DateTime.Now.ToString("hh:mm:ss");
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void record_attendance_Load(object sender, EventArgs e)
        {
            bunifuCustomLabel3.Text = DateTime.Now.ToString("yyy-MM-dd");
            bunifuCustomLabel4.Text = System.DateTime.Now.ToString("hh:mm:ss");
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(this.timer_tick);
            timer.Interval = 1000;
            timer.Enabled = true;
        }
    }
}

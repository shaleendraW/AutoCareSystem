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

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          materialLabel3.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}

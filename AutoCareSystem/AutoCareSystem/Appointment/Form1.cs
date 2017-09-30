using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCareSystem
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            appointmet_sub1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            assign_technicain1.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            slots1.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            customer_manage1.BringToFront();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            appointmet_sub1.BringToFront();
        }

        private void customer_manage1_Load(object sender, EventArgs e)
        {

        }
    }
}

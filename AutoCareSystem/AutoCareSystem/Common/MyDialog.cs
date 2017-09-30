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
    public partial class MyDialog : MetroFramework.Forms.MetroForm
    {
        private MyDialog(String header, String desc)
        {
            InitializeComponent();
            txtTitle.Text = header;
            tbxDesc.Text = desc;
        }

        public static void Show(String header, String desc)
        {
            new MyDialog(header, desc).ShowDialog();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

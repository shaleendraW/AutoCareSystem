using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCareSystem
{
    public partial class SubFuncSameer : MetroFramework.Forms.MetroForm
    {
        public SubFuncSameer()
        {
            InitializeComponent();
            // Run background task
            ExtractExpensesData();
            ExtractIncomeData();

            //Task task = Task.Run((Action)BindGridView);
        }

        private void SubFunc_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e) // Side Tab : Expenses
        {
            expenses1.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e) // Side Tab : Income
        {
            income1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bills1.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e) // Side Tab : Loans
        {
            loans1.BringToFront();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e) // Side Tab : Profit/Loss
        {
            profit_loss1.BringToFront();
        }

        // Background Methods Implementation

        private void ExtractIncomeData()
        {
            // Select Data from tables and insert them into the 'income' table
            string query = "";
            //string query = "INSERT INTO vehicles VALUES('" + key + "','" + txtVehicleNo.Text + "','" + txtVehicleType.Text + "','" + txtBrand.Text + "','" + txtModel.Text + "','" + DateTime.Now + "')";
            Database db = new Database();
            db.sqlQuery(query);
            //if (db.nonQuery())
            {
               // new Dialog("Success...!", "Vehicle Registered :)").ShowDialog();
                //resetFields();
                //("");
            }
        }

        private void ExtractExpensesData()
        {
            // Select Data from tables and insert them into the 'expenses' table
            //String query = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ExtractIncomeData();
            ExtractExpensesData();
            //backgroundWorker1.ReportProgress(1);
        }
        
    }
}

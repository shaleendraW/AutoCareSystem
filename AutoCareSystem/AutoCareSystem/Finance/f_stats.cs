using System;
using System.Windows.Forms;

namespace AutoCareSystem
{
    public partial class f_stats : UserControl
    {
        public f_stats()
        {
            InitializeComponent();
            radBar.Checked = true;
            radYearly.Checked = true;
            radSeparate.Checked = true;
            cmbYear.Items.Insert(0, "Select");
            cmbYear.SelectedIndex = 0;
            cmbMonth.SelectedIndex = 0;
        }

        private void radYearly_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radYearly.Checked == true)
            {
                cmbYear.Enabled = false;
                cmbMonth.Enabled = false;
            }
        }

        private void radMonthly_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radMonthly.Checked == true)
            {
                cmbYear.Enabled = true;
                cmbMonth.Enabled = false;
            }
        }

        private void radWeekly_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radWeekly.Checked == true)
            {
                cmbYear.Enabled = true;
                cmbMonth.Enabled = true;
            }
        }



        protected void CreateExpensesView()
        {
            try
            {
                string query = "CREATE VIEW dynamic_expenses AS SELECT e_type, SUM(e_amount) AS e_total_amount FROM expenses GROUP BY e_type";
                Database db = new Database();
                db.sqlQuery(query);
                if (db.nonQuery())
                {
                    MessageBox.Show("Expenses View Create Success");
                    db.getConnection().Close();
                }
                else
                {
                    MessageBox.Show("Expenses View Create Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected void CreateIncomeView()
        {
            try
            {
                string query = "CREATE VIEW dynamic_income AS SELECT i_type, SUM(i_amount) AS l_total_amount FROM income GROUP BY i_type";
                Database db = new Database();
                db.sqlQuery(query);
                if (db.nonQuery())
                {
                    MessageBox.Show("Income View Create Success");
                    db.getConnection().Close();
                }
                else
                {
                    MessageBox.Show("Income View Create Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected void DropExpensesView()
        {
            try
            {
                string query = "DROP VIEW dynamic_income";
                Database db = new Database();
                db.sqlQuery(query);
                if (db.nonQuery())
                {
                    MessageBox.Show("Expenses View Drop Success");
                    db.getConnection().Close();
                }
                else
                {
                    MessageBox.Show("Expenses View Drop Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected void DropIncomeView()
        {
            try
            {
                string query = "DROP VIEW dynamic_income";
                Database db = new Database();
                db.sqlQuery(query);
                if (db.nonQuery())
                {
                    MessageBox.Show("Income View Drop Success");
                    db.getConnection().Close();
                }
                else
                {
                    MessageBox.Show("Income View Drop Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}

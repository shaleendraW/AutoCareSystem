using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AutoCareSystem
{
    public partial class expenses : f_stats
    {
        string periodOfView = "Yearly", displayMode = "Separate", chartType = "Bar";
        int periodMonth, periodYear;

        private void radYearly_CheckedChanged(object sender, EventArgs e)
        {
            if (radYearly.Checked == true)
            {
                periodOfView = "Yearly";
                cmbYear.Enabled = false;
                cmbMonth.Enabled = false;
            }
        }

        private void radMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (radMonthly.Checked == true)
            {
                periodOfView = "Monthly";
                cmbYear.Enabled = true;
                cmbMonth.Enabled = false;
                SettingCmbYearValues();
            }
        }

        private void radWeekly_CheckedChanged(object sender, EventArgs e)
        {
            if (radWeekly.Checked == true)
            {
                periodOfView = "Weekly";
                cmbYear.Enabled = true;
                cmbMonth.Enabled = true;
                SettingCmbYearValues();
            }
        }

        private void radSeparate_CheckedChanged(object sender, EventArgs e)
        {
            if (radSeparate.Checked == true)
            {
                displayMode = "Separate";
            }
        }

        private void radTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (radTotal.Checked == true)
            {
                displayMode = "Total";
            }
        }

        public expenses()
        {
            InitializeComponent();
            SettingCmbYearValues();
            DataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.SelectedItem.ToString() != "Select")
            {
                periodYear = Convert.ToInt32(cmbYear.SelectedItem);
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonth.SelectedItem.ToString() != "Select")
            {
                periodMonth = cmbMonth.SelectedIndex;
            }
        }

        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            string viewQuery = "", displayQuery = "";
            if (periodOfView == "Yearly")
            {
                if (displayMode == "Separate")
                {
                    viewQuery = "CREATE VIEW dynamic_expenses AS SELECT e_type AS 'Type', year(e_date) AS 'Year', sum(e_amount) AS 'Amount' FROM expenses GROUP BY year(e_date), e_type;";
                    displayQuery = "SELECT Year, Type, Amount FROM dynamic_expenses";
                    RunQuery(viewQuery);
                    DisplayDataInTable1(displayQuery);
                }
                else
                {
                    viewQuery = "CREATE VIEW dynamic_expenses AS SELECT year(e_date) AS 'Year', sum(e_amount) as 'Amount' FROM expenses GROUP BY year(e_date);";
                    displayQuery = "SELECT Year, Amount FROM dynamic_expenses";
                    RunQuery(viewQuery);
                    DisplayDataInTable1(displayQuery);
                }
                DataGrid1.Sort(DataGrid1.Columns["Year"], ListSortDirection.Ascending);
            }
            else if (periodOfView == "Monthly")
            {
                if (displayMode == "Separate")
                {
                    viewQuery = "CREATE VIEW dynamic_expenses AS SELECT e_type AS 'Type', month(e_date) AS 'Month', sum(e_amount) AS 'Amount' FROM expenses WHERE year(e_date) = " + periodYear + " GROUP BY month(e_date), e_type;";
                    displayQuery = "SELECT Month, Type, Amount FROM dynamic_expenses";
                    RunQuery(viewQuery);
                    DisplayDataInTable1(displayQuery);
                }
                else
                {
                    viewQuery = "CREATE VIEW dynamic_expenses AS SELECT month(e_date) AS 'Month', sum(e_amount) as 'Amount' FROM expenses WHERE year(e_date) = " + periodYear + " GROUP BY month(e_date);";
                    displayQuery = "SELECT Month, Amount FROM dynamic_expenses";
                    RunQuery(viewQuery);
                    DisplayDataInTable1(displayQuery);
                }
                DataGrid1.Sort(DataGrid1.Columns["Month"], ListSortDirection.Ascending);
            }
            else // ------------------------ Weekly
            {
                if (displayMode == "Seprate")
                {
                    viewQuery = "";
                    displayQuery = "SELECT Week, Type, Amount FROM dynamic_expenses";
                }
                else
                {
                    viewQuery = "";
                    displayQuery = "SELECT Week, Amount FROM dynamic_expenses";
                }
                //DataGrid1.Sort(DataGrid1.Columns["Week"], ListSortDirection.Ascending);
            }
            //RunQuery(viewQuery); //                  CREATE VIEW

            //  DISPLAY VIEW in TABLE
            //DisplayDataInTable1(displayQuery);

            RunQuery("DROP VIEW dynamic_expenses"); // DROP VIEW
        }

        private void LoadChart()
        {
            //CreateExpensesView();
            //Load view data into the chart <- create a method for this
            DropExpensesView();
        }

        private void SetChartType(object sender, EventArgs e)
        {

            chart1.Series.Clear();
            if (radBar.Checked == true)
            {
                try
                {
                    //chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chartType = "Bar";
                }
                catch (Exception exc)
                {
                    MyDialog.Show("Exception...!", exc.ToString());
                }
            }
            else if (radLine.Checked == true)
            {
                try
                {
                    //chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartType = "Line";
                }
                catch (Exception exc)
                {
                    MyDialog.Show("Exception...!", exc.ToString());
                }
            }
            else if (radPie.Checked == true)
            {
                try
                {
                    //chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartType = "Pie";
                }
                catch (Exception exc)
                {
                    MyDialog.Show("Exception...!", exc.ToString());
                }
            }
        }

        private void btnLoadChart_Click(object sender, EventArgs e)
        {

            chart1.Series.Clear();
            chart1.Visible = true;
            chart1.BringToFront();
            int x, y;
            string type;

            if (chartType == "Bar")
            {
                if (displayMode == "Separate")
                {
                    chart1.Series.Add("Maintenance");
                    chart1.Series.Add("Order");
                    chart1.Series.Add("Other");
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    foreach (DataGridViewRow DGVR in DataGrid1.Rows)
                    {
                        x = int.Parse(DGVR.Cells[0].Value.ToString());
                        y = int.Parse(DGVR.Cells[2].Value.ToString());
                        type = DGVR.Cells[1].Value.ToString();
                        chart1.Series[type].Points.AddXY(x, y);
                    }
                }
                else
                {
                    chart1.Series.Add("Expenses");
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    foreach (DataGridViewRow DGVR in DataGrid1.Rows)
                    {
                        x = int.Parse(DGVR.Cells[0].Value.ToString());
                        y = int.Parse(DGVR.Cells[1].Value.ToString());
                        chart1.Series["Expenses"].Points.AddXY(x, y);
                    }
                }

            }
            else if (chartType == "Line")
            {
                if (displayMode == "Separate")
                {

                }
                else
                {

                }
            }
            else
            {
                if (displayMode == "Separate")
                {
                    chart1.Series.Add("Maintenance");
                    chart1.Series.Add("Order");
                    chart1.Series.Add("Other");
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chart1.Series[0].IsValueShownAsLabel = true;
                    chart1.Series[1].IsValueShownAsLabel = true;
                    chart1.Series[2].IsValueShownAsLabel = true;
                    foreach (DataGridViewRow DGVR in DataGrid1.Rows)
                    {
                        x = int.Parse(DGVR.Cells[0].Value.ToString());
                        y = int.Parse(DGVR.Cells[2].Value.ToString());
                        type = DGVR.Cells[1].Value.ToString();
                        chart1.Series[type].Points.AddXY(x, y);
                    }
                }
                else
                {
                    chart1.Series.Add("Expenses");
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chart1.Series[0].IsValueShownAsLabel = true;
                    foreach (DataGridViewRow DGVR in DataGrid1.Rows)
                    {
                        x = int.Parse(DGVR.Cells[0].Value.ToString());
                        y = int.Parse(DGVR.Cells[1].Value.ToString());
                        //type = DGVR.Cells[1].Value.ToString();
                        chart1.Series["Expenses"].Points.AddXY(x, y);
                    }
                }
            }
        }

        private void SettingCmbYearValues()
        {
            // Getting MIN and MAX Years and displaying them

            string query = "SELECT year(max(e_date)) AS 'Max', year(min(e_date)) AS 'Min' FROM expenses;";
            SqlDataReader sqlData = null;
            int maxYear, minYear;

            Database DB1 = new Database();
            DB1.sqlQuery(query);
            if (DB1.nonQuery())
            {
                sqlData = DB1.getData();
                while (sqlData.Read())
                {
                    maxYear = sqlData.GetInt32(0);
                    minYear = sqlData.GetInt32(1);
                    cmbYear.Items.Clear();
                    int x = 0;
                    cmbYear.Items.Insert(0, "Select");
                    cmbYear.SelectedIndex = 0;
                    x += 1;
                    for (; minYear <= maxYear; minYear++)
                    {
                        cmbYear.Items.Insert(x, minYear);
                        x += 1;
                    }
                }
            }

            // -- End of setting cmbYear values
        }

        private void RunQuery(string query)
        {
            try
            {
                Database db = new Database();
                db.sqlQuery(query);
                if (db.nonQuery())
                {
                    //MessageBox.Show("Creating View Success");
                    db.getConnection().Close();
                }
                else
                {
                    //MessageBox.Show("Creating View Failed");
                }
            }
            catch (Exception ex)
            {
                MyDialog.Show("Exception...!", ex.ToString());
            }
        }

        private void DisplayDataInTable1(string displayQuery)
        {
            this.DataGrid1.DataSource = null;
            this.DataGrid1.Rows.Clear();
            DataGrid1.Refresh();
            DataGrid1.BringToFront();
            try
            {
                Database db = new Database();

                db.sqlQuery(displayQuery);
                DataTable DT = db.executeQuery();
                DataGrid1.DataSource = DT;
            }
            catch (Exception exception)
            {
                MyDialog.Show("Exception...!", exception.ToString());
            }
        }
    }
}

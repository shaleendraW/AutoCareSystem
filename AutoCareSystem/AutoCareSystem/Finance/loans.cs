using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutoCareSystem
{
    public partial class loans : UserControl
    {
        bool dataPassed = false;
        int id = -1;
        string fakeId = "";
        string operation = "default";
        string validation = "true";

        public loans()
        {
            InitializeComponent();
            bunifuCustomDataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RefreshButtonEnabled(dataPassed);

            BindGridView("SELECT CONCAT('LN000', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 0 AND 9 UNION SELECT CONCAT('LN00', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 10 AND 99 UNION SELECT CONCAT('LN0', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 100 AND 999 UNION SELECT CONCAT('LN', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 1000 AND 9999");
        }
        
        private void BindGridView(string query)
        {
            try
            {
                Database db = new Database();

                db.sqlQuery(query);
                DataTable DT = db.executeQuery();
                bunifuCustomDataGrid1.DataSource = DT;
                bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception exception)
            {
                MyDialog.Show("Exception...!", exception.ToString());
            }
        }

        private void BindGridView1(string query)
        {
            try
            {
                Database db = new Database();

                db.sqlQuery(query);
                DataTable DT = db.executeQuery();
                bunifuCustomDataGrid1.DataSource = DT;
                bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception exception)
            {
                MyDialog.Show("Exception...!", exception.ToString());
            }
        }
        private void BindGridView2(string query)
        {
            try
            {
                Database db = new Database();

                db.sqlQuery(query);
                DataTable DT = db.executeQuery();
                bunifuCustomDataGrid1.DataSource = DT;
                bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception exception)
            {
                MyDialog.Show("Exception...!", exception.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool add_status = true;

            if (string.IsNullOrWhiteSpace(txtAmount.Text) || string.IsNullOrWhiteSpace(txtMonthly.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPaid.Text) ||
                string.IsNullOrWhiteSpace(txtPeriod.Text) || string.IsNullOrWhiteSpace(txtRate.Text) ||
                string.IsNullOrWhiteSpace(txtTotal.Text))
            {
                MyDialog.Show("Error...!", "Please fill all fields");
            }
            else
            {
                add_status = ValidateFields();

                if (add_status == true)
                {
                    try
                    {
                        string query = "INSERT INTO loans VALUES ('" + txtName.Text + "', '" + dateStart.Value.ToString("yyyy-MM-dd") + "', " + int.Parse(txtPeriod.Text) + ", " + float.Parse(txtAmount.Text) + ", " + float.Parse(txtRate.Text) + ", '" + dateEnd.Value.ToString("yyyy-MM-dd") + "', " + float.Parse(txtMonthly.Text) + ", " + float.Parse(txtTotal.Text) + ", " + Convert.ToInt32(txtPaid.Text) + ")";
                        Database db = new Database();
                        db.sqlQuery(query);
                        if (db.nonQuery())
                        {
                            MyDialog.Show("Insert Successful", "Loan was successfully added");
                            clearFields();
                        }
                        else
                        {
                            MyDialog.Show("Insert Failed", "Adding Loan Failed");
                        }
                        db.getConnection().Close();
                        BindGridView("SELECT CONCAT('LN000', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 0 AND 9 UNION SELECT CONCAT('LN00', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 10 AND 99 UNION SELECT CONCAT('LN0', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 100 AND 999 UNION SELECT CONCAT('LN', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 1000 AND 9999");
                    }
                    catch (Exception exc)
                    {
                        MyDialog.Show("Exception...!", exc.ToString());
                    }

                }
                else
                {
                    MyDialog.Show("Error...!", "Input Error");

                }
            }
            
        }

        private bool ValidateFields() // return true-add, false-abort
        {
            Regex validateName = new Regex("^[a-zA-Z ]+$");
            Regex validatePeriod = new Regex("^[0-9]{1,3}$");
            Regex validateAmount = new Regex("^[0-9]{1,7}$");
            Regex validateRate = new Regex("^[0-9]{1,2}$");
            Regex validatePaid = new Regex("^[0-9]{1,3}$");

            if (!validateName.IsMatch(txtName.Text))
            {
                MyDialog.Show("Error...!", "Invalid Name");
            }
            else
            {
                if (!validatePeriod.IsMatch(txtPeriod.Text))
                {
                    MyDialog.Show("Error...!", "Invalid Period");
                }
                else
                {
                    if (!validateAmount.IsMatch(txtAmount.Text))
                    {
                        MyDialog.Show("Error...!", "Invalid Amount");
                    }
                    else
                    {
                        if (!validateRate.IsMatch(txtRate.Text))
                        {
                            MyDialog.Show("Error...!", "Invalid Rate");
                        }
                        else
                        {
                            if (!validatePaid.IsMatch(txtPaid.Text))
                            {
                                MyDialog.Show("Error...!", "Invalid Paid");
                            }
                            else
                            {
                                return true;
                            }
                            return false;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
            operation = "clear";
            validation = "bypass";
        }

        private void clearFields()
        {
            txtName.Text = string.Empty; ;
            txtPeriod.Text = string.Empty; ;
            txtAmount.Text = string.Empty; ;
            txtRate.Text = string.Empty; ;
            dateStart.Text = string.Empty;
            dateEnd.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtMonthly.Text = string.Empty;
            txtPaid.Text = string.Empty;
            RefreshButtonEnabled(false);
        }

        private void RefreshButtonEnabled(bool dataPassed)
        {
            btnUpdate.Enabled = dataPassed;
            btnRemove.Enabled = dataPassed;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool updateStatus = true;
            updateStatus = ValidateFields();

            if (updateStatus == true)
            {
                try
                {
                    string query = "UPDATE loans SET l_lender_name = '"+txtName.Text+"', l_start_date = '"+dateStart.Value.ToString("yyyy-MM-dd")+"', l_period = "+Convert.ToInt32(txtPeriod.Text)+", l_amount = "+float.Parse(txtAmount.Text)+", l_rate = "+float.Parse(txtRate.Text)+", l_end_date = '"+dateEnd.Value.ToString("yyyy-MM-dd")+"', l_monthly_amount = "+float.Parse(txtMonthly.Text)+", l_total_amount = "+float.Parse(txtTotal.Text)+", l_paid_months = "+Convert.ToInt32(txtPaid.Text)+" WHERE l_id = "+id+"";
                    Database db = new Database();
                    db.sqlQuery(query);
                    if (db.nonQuery())
                    {
                        MyDialog.Show("Update Successful", "Loan was successfully Updated");
                        clearFields();
                    }
                    else
                    {
                        MyDialog.Show("Update Failed", "Updating Loan Failed");
                    }
                    db.getConnection().Close();
                    BindGridView("SELECT CONCAT('LN000', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 0 AND 9 UNION SELECT CONCAT('LN00', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 10 AND 99 UNION SELECT CONCAT('LN0', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 100 AND 999 UNION SELECT CONCAT('LN', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 1000 AND 9999");
                }
                catch (Exception exc)
                {
                    MyDialog.Show("Exception...!", exc.ToString());
                }

            }
            else
            {
                MyDialog.Show("Error...!", "Input Error");

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM loans WHERE l_id = " + id + "";
                Database db = new Database();
                db.sqlQuery(query);
                if (MessageBox.Show("Delete?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //delete the item 
                    if (db.nonQuery())
                    {
                        MyDialog.Show("Delete Successful", "Loan was deleted successfully");
                        db.getConnection().Close();
                        BindGridView("SELECT CONCAT('LN000', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 0 AND 9 UNION SELECT CONCAT('LN00', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 10 AND 99 UNION SELECT CONCAT('LN0', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 100 AND 999 UNION SELECT CONCAT('LN', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 1000 AND 9999");
                        clearFields();
                    }
                    else
                    {
                        MyDialog.Show("Delete Failed", "Deleting Loan Failed");
                    }
                }
                else
                {
                    //Cancel action 
                    MyDialog.Show("Delete Cancelled", "Delete Cancelled");
                }
            }
            catch (Exception exc)
            {
                MyDialog.Show("Exception...!", exc.ToString());
            }
        }

        private bool RefreshValidate()
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text) || string.IsNullOrWhiteSpace(txtMonthly.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPaid.Text) ||
                string.IsNullOrWhiteSpace(txtPeriod.Text) || string.IsNullOrWhiteSpace(txtRate.Text) ||
                string.IsNullOrWhiteSpace(txtTotal.Text))
            {
                //MyDialog.Show("Error...!", "Please fill all fields");
                return false;
            }
            else
            {
                //return ValidateFields();
                return true;
            }
        }

        private bool validate2()
        {
            Regex validateName = new Regex("^[a-zA-Z ]+$");
            Regex validatePeriod = new Regex("^[0-9]{1,3}$");
            Regex validateAmount = new Regex("^[0-9]{1,7}$");
            Regex validateRate = new Regex("^[0-9]{1,2}$");
            Regex validatePaid = new Regex("^[0-9]{1,3}$");

            if (!validateName.IsMatch(txtName.Text))
            {
               // MyDialog.Show("Error...!", "Invalid Name");
            }
            else
            {
                if (!validatePeriod.IsMatch(txtPeriod.Text))
                {
                    //MyDialog.Show("Error...!", "Invalid Period");
                }
                else
                {
                    if (!validateAmount.IsMatch(txtAmount.Text))
                    {
                       // MyDialog.Show("Error...!", "Invalid Amount");
                    }
                    else
                    {
                        if (!validateRate.IsMatch(txtRate.Text))
                        {
                            //MyDialog.Show("Error...!", "Invalid Rate");
                        }
                        else
                        {
                            if (!validatePaid.IsMatch(txtPaid.Text))
                            {
                                //MyDialog.Show("Error...!", "Invalid Paid");
                            }
                            else
                            {
                                return true;
                            }
                            return false;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        private void refreshValues(object sender, EventArgs e)
        {
            //if (/*RefreshValidate() && */operation == "clear")
            if(validation != "bypass")
            {
                try
                {
                    double amount = 0, rate = 0, period = 0;

                    if (txtAmount.Text != string.Empty)
                    {
                        try
                        {
                            amount = Convert.ToDouble(txtAmount.Text);
                        }
                        catch(System.FormatException exc)
                        {
                            MyDialog.Show("Error...!", "Invalid Amount Data Format");
                        }
                        if (txtRate.Text != string.Empty)
                        {
                            try
                            {
                                rate = Convert.ToDouble(txtRate.Text);
                            }
                            catch (System.FormatException exc)
                            {
                                MyDialog.Show("Error...!", "Invalid Rate Data Format");
                            }
                            if (txtPeriod.Text != string.Empty)
                            {
                                try
                                {
                                    period = Convert.ToDouble(txtPeriod.Text);
                                    rate = rate * (period / 12.00);
                                    rate = (rate + 100.00) / 100.00;
                                    double total = amount * rate;
                                    txtTotal.Text = Convert.ToString(total);
                                    double monthly = total / period;
                                    txtMonthly.Text = Convert.ToString(monthly);
                                    int periodInt = Convert.ToInt32(txtPeriod.Text);
                                    int numberOfYears = -1, numberOfMonths = -1;
                                    DateTime DT = dateStart.Value;
                                    int month = DT.Month;
                                    int day = DT.Day;
                                    int year = DT.Year;
                                    if (periodInt >= 12)
                                    {
                                        if ((periodInt % 12) != 0)
                                        {
                                            numberOfYears = periodInt / 12;
                                            numberOfMonths = periodInt - (numberOfYears * 12);
                                        }
                                        else
                                        {
                                            numberOfMonths = 0;
                                            numberOfYears = periodInt / 12;
                                        }
                                    }
                                    else
                                    {
                                        numberOfMonths = periodInt;
                                        numberOfYears = 0;
                                    }
                                    month = DT.Month + numberOfMonths;
                                    year = DT.Year + numberOfYears;
                                    if (month > 12)
                                    {
                                        year += 1;
                                        month -= 12;
                                    }
                                    dateEnd.Text = month + "/" + day + "/" + year;
                                }
                                catch (System.FormatException exc)
                                {
                                    MyDialog.Show("Error...!", "Invalid Data Format");
                                }
                            }
                        }
                    }
                    
                    

                }
                catch (Exception exc)
                {
                    MyDialog.Show("Exception...!", exc.ToString());
                }
                }
                else
                {
                    //MessageBox.Show("");
                }
            }
        



        private void CellClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            operation = "default";
            validation = "bypass";
            dataPassed = false;
            RefreshButtonEnabled(dataPassed);

            fakeId = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            id = int.Parse(getOriginalID(fakeId));

            txtName.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();

            string startDate = (Convert.ToDateTime(bunifuCustomDataGrid1.CurrentRow.Cells[2].Value)).ToShortDateString();
            dateStart.Text = startDate;

            txtPeriod.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            txtAmount.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            txtRate.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
            dateEnd.Text = (Convert.ToDateTime(bunifuCustomDataGrid1.CurrentRow.Cells[6].Value)).ToShortDateString();
            txtMonthly.Text = bunifuCustomDataGrid1.CurrentRow.Cells[7].Value.ToString();
            txtTotal.Text = bunifuCustomDataGrid1.CurrentRow.Cells[8].Value.ToString();
            txtPaid.Text = bunifuCustomDataGrid1.CurrentRow.Cells[9].Value.ToString();
            dataPassed = true;
            RefreshButtonEnabled(dataPassed);
        }

        private string getOriginalID(string fakeID)
        {
            string conID = fakeID;
            string[] parts = conID.Split('N');
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
            return parts[1];
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if ( radAll.Checked == true)
            {
                BindGridView("SELECT CONCAT('LN000', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 0 AND 9 UNION SELECT CONCAT('LN00', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 10 AND 99 UNION SELECT CONCAT('LN0', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 100 AND 999 UNION SELECT CONCAT('LN', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 1000 AND 9999");
            }
        }

        private void radPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (radPaid.Checked == true)
            {
                BindGridView("SELECT CONCAT('LN000', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 0 AND 9 UNION SELECT CONCAT('LN00', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 10 AND 99 UNION SELECT CONCAT('LN0', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 100 AND 999 UNION SELECT CONCAT('LN', l_id)  AS 'Lender ID', l_lender_name AS 'Lender Name', l_start_date AS 'Start Date', l_period AS 'Period', l_amount AS 'Amount', l_rate AS 'Rate (%)', l_end_date AS 'End Date', l_monthly_amount AS 'Monthly Amount', l_total_amount AS 'Total Amount', l_paid_months AS 'Months Paid' FROM loans WHERE l_id BETWEEN 1000 AND 9999");
            }
        }

        private void txtRate_Click(object sender, EventArgs e)
        {
            validation = "true";
        }
    }
}

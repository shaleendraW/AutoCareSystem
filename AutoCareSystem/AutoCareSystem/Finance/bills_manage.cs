using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AutoCareSystem
{
    public partial class bills_manage : UserControl
    {
        bool dataPassed = false;
        int id = -1;
        string fakeId = "";

        public bills_manage()
        {
            InitializeComponent();
            bunifuCustomDataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cmbType.SelectedIndex = 0;
            cmbFilter.SelectedIndex = 4;
            RefreshButtonEnabled(dataPassed);
            string query = "SELECT CONCAT('BL000', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 0 AND 9 UNION SELECT CONCAT('BL00', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 10 AND 99 UNION SELECT CONCAT('BL0', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 100 AND 999 UNION SELECT CONCAT('BL', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 1000 AND 9999";
            BindGridView(query);
        }

        public void BindGridView(string query)
        {
            try
            {
                Database db = new Database();
                SqlConnection conn = db.getConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = table;
                bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bunifuCustomDataGrid1.DataSource = bsource;
                conn.Close();
            }
            catch (SqlException ex)
            {
                MyDialog.Show("SQLException", Convert.ToString(ex));
            }
            catch (InvalidOperationException ex)
            {
                MyDialog.Show("InvalidOperationException", Convert.ToString(ex));
            }
            catch (Exception e)
            {
                MyDialog.Show("Exception...!", Convert.ToString(e));
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            cmbType.SelectedIndex = 0;
            txtMonthly.Text = "";
            txtPaid.Text = "";
            txtTotal.Text = "";
            paidDate.Text = string.Empty;
            issueDate.Text = string.Empty;
            dataPassed = false;
            RefreshButtonEnabled(dataPassed);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool add_status = true;
            add_status = validateFields();

            if (add_status == true)
            {
                try
                {
                    string query = "INSERT INTO bills VALUES ('" + cmbType.Text + "', " + float.Parse(txtTotal.Text) + ", " + float.Parse(txtMonthly.Text) + ", '" + issueDate.Value.ToString("yyyy-MM-dd") + "', " + float.Parse(txtPaid.Text) + ", '" + paidDate.Value.ToString("yyyy-MM-dd") + "')";
                    Database db = new Database();
                    db.sqlQuery(query);
                    if (db.nonQuery())
                    {
                        MyDialog.Show("Insert Successful", "Bill was successfully added");
                        db.getConnection().Close();
                        query = "SELECT CONCAT('BL000', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 0 AND 9 UNION SELECT CONCAT('BL00', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 10 AND 99 UNION SELECT CONCAT('BL0', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 100 AND 999 UNION SELECT CONCAT('BL', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 1000 AND 9999";
                        BindGridView(query);
                        clearFields();
                    }
                    else
                    {
                        MyDialog.Show("Insert Failed", "Adding Bill Failed");
                    }
                }
                catch (Exception ex)
                {
                    MyDialog.Show("Exception...!", ex.ToString());
                }
            }
            else
            {
                MyDialog.Show("Error...!", "Input Error");
            }
        }

        private bool validateFields() // return true-add, false-abort
        {
            Regex validateAmount = new Regex("^[0-9]{1,8}$");

            if (!validateAmount.IsMatch(txtMonthly.Text))
            {
                MyDialog.Show("Error...!", "Invalid Monthly Amount");
                
            }
            else
            {
                if (!validateAmount.IsMatch(txtPaid.Text))
                {
                    MyDialog.Show("Error...!", "Invalid Paid Amount");
                    
                }
                else
                {
                    if (!validateAmount.IsMatch(txtTotal.Text))
                    {
                        MyDialog.Show("Error...!", "Invalid Total Amount");
                        
                    }
                    else
                    {
                        if (Convert.ToInt32(txtMonthly.Text) > Convert.ToInt32(txtTotal.Text))
                        {
                            MyDialog.Show("Error...!", "Monthly Amount is greater than Total Amount");
                            
                        }
                        else
                        {
                            if (Convert.ToInt32(txtPaid.Text) > Convert.ToInt32(txtTotal.Text))
                            {
                                MyDialog.Show("Error...!", "Paid Amount is greater than Total Amount");
                            }
                            else
                            {
                                if (IsBillTypeInvalid(cmbType.Text))
                                {
                                    MyDialog.Show("Error...!", "Select Bill Type");
                                }
                                else
                                {
                                    if (issueDate.Value.Date > DateTime.Today)
                                    {
                                        MyDialog.Show("Error...!", "Issue Date is in the future");
                                    }
                                    else
                                    {
                                        if (paidDate.Value.Date > DateTime.Today)
                                        {
                                            MyDialog.Show("Error...!", "Paid Date is in the future");
                                        }
                                        else
                                        {
                                            if (paidDate.Value.Date < issueDate.Value.Date)
                                            {
                                                MyDialog.Show("Error...!", "Paid Date is lesser than Issue Date");
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
                        return false;
                    }
                    return false;
                }
                return false;
            }

            return false;
        }

        private bool IsBillTypeInvalid(string data)
        {
            if (data == "Electricity")
                return false;
            else if (data == "Internet")
                return false;
            else if (data == "Water")
                return false;
            else if (data == "Select Type")
                return true;
            else
                return true;
        }

        // implement validate methods
        // validation methods should be in  a separate class or be implemented here
        // check whether predefined functions for validation exists or not


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool update_status = true;
            update_status = validateFields();

            if (update_status == true)
            {
                try
                {
                    string query = "UPDATE bills SET b_type = '"+cmbType.Text+"', b_total_amount = '"+float.Parse(txtTotal.Text)+"', b_monthly_amount = '"+float.Parse(txtMonthly.Text)+"', b_issue_date = '"+issueDate.Value.ToString("yyyy-MM-dd")+"', b_paid_amount = "+float.Parse(txtPaid.Text)+", b_paid_date = '"+paidDate.Value.ToString("yyyy-MM-dd")+"' WHERE b_id = "+id+"";
                    Database db = new Database();
                    db.sqlQuery(query);
                    if (db.nonQuery())
                    {
                        MyDialog.Show("Update Successful", "Bill was successfully updated");
                        db.getConnection().Close();
                        query = "SELECT CONCAT('BL000', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 0 AND 9 UNION SELECT CONCAT('BL00', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 10 AND 99 UNION SELECT CONCAT('BL0', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 100 AND 999 UNION SELECT CONCAT('BL', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 1000 AND 9999";
                        BindGridView(query);
                        clearFields();
                    }
                    else
                    {
                        MyDialog.Show("Update Failed", "Updating Bill Failed");
                    }
                    
                }
                catch(Exception exc)
                {
                    MyDialog.Show("Exception...!", exc.ToString());
                }
            }
            else
            {
                MyDialog.Show("Error...!", "Input Error");
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
                try
                {
                    string query = "DELETE FROM bills WHERE b_id = " + id + "";
                    Database db = new Database();
                    db.sqlQuery(query);
                    if (MessageBox.Show("Delete?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //delete the item 
                        if (db.nonQuery())
                        {
                            MyDialog.Show("Delete Successful", "Bill was deleted successfully");
                            db.getConnection().Close();
                            query = "SELECT CONCAT('BL000', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 0 AND 9 UNION SELECT CONCAT('BL00', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 10 AND 99 UNION SELECT CONCAT('BL0', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 100 AND 999 UNION SELECT CONCAT('BL', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 1000 AND 9999";
                            BindGridView(query);
                            clearFields();
                        }
                        else
                        {
                            MyDialog.Show("Delete Failed", "Deleting Bill Failed");
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
        
        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataPassed = false;
            RefreshButtonEnabled(dataPassed);

            fakeId = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            id = int.Parse(getOriginalID(fakeId));
            //id = int.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
            string type = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            switch (type)
            {
                case "Electricity":
                    cmbType.SelectedIndex = 1;
                    break;
                case "Internet":
                    cmbType.SelectedIndex = 2;
                    break;
                case "Water":
                    cmbType.SelectedIndex = 3;
                    break;
            }
            txtTotal.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            txtMonthly.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();

            DateTime issueDateDT = Convert.ToDateTime(bunifuCustomDataGrid1.CurrentRow.Cells[4].Value);
            string issueDateShortDateString = issueDateDT.ToShortDateString();
            issueDate.Text = issueDateShortDateString;

            DateTime paidDateDT = Convert.ToDateTime(bunifuCustomDataGrid1.CurrentRow.Cells[6].Value);
            string paidDateShortDateString = paidDateDT.ToShortDateString();
            paidDate.Text = paidDateShortDateString;

            txtPaid.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();

            dataPassed = true;
            RefreshButtonEnabled(dataPassed);
        }

        private void RefreshButtonEnabled(bool dataPassed)
        {
            btnUpdate.Enabled = dataPassed;
            btnRemove.Enabled = dataPassed;
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cmbFilter.Text;

            switch (type)
            {
                case "All Types":
                    BindGridView("SELECT CONCAT('BL000', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 0 AND 9 UNION SELECT CONCAT('BL00', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 10 AND 99 UNION SELECT CONCAT('BL0', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 100 AND 999 UNION SELECT CONCAT('BL', b_id) AS 'Bill ID', b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_id BETWEEN 1000 AND 9999");
                    break;
                case "Electricity":
                    BindGridView("SELECT CONCAT('BL000', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 0 AND 9 UNION SELECT CONCAT('BL00', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 10 AND 99 UNION SELECT CONCAT('BL0', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 100 AND 999 UNION SELECT CONCAT('BL', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 1000 AND 9999");
                    break;
                case "Internet":
                    BindGridView("SELECT CONCAT('BL000', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 0 AND 9 UNION SELECT CONCAT('BL00', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 10 AND 99 UNION SELECT CONCAT('BL0', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 100 AND 999 UNION SELECT CONCAT('BL', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 1000 AND 9999");
                    break;
                case "Water":
                    BindGridView("SELECT CONCAT('BL000', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 0 AND 9 UNION SELECT CONCAT('BL00', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 10 AND 99 UNION SELECT CONCAT('BL0', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 100 AND 999 UNION SELECT CONCAT('BL', b_id) AS 'ID',  b_type AS 'Type', b_total_amount AS 'Total Amount', b_monthly_amount AS 'Monthly Amount', b_issue_date AS 'Issue Date', b_paid_amount AS 'Paid Amount', b_paid_date AS 'Paid Date' FROM bills WHERE b_type = '" + type + "' AND b_id BETWEEN 1000 AND 9999");
                    break;
            }
        }

        private string getOriginalID(string fakeID)
        {
            string conID = fakeID;
            // Split 
            string[] parts = conID.Split('L');
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
            //int id = Convert.ToInt32(parts[1]);
            return parts[1];
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bunifu.Framework.UI;
using System.Text.RegularExpressions;

namespace AutoCareSystem
{
    public partial class Appointmet_sub : UserControl
    {
        public Appointmet_sub()
        {
            InitializeComponent();
            initialization();
            loadData();
            bunifuCustomDataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bunifuCustomDataGrid1.ReadOnly = true;
            bunifuCustomDataGrid1.RowHeadersVisible = false;
            bunifuCustomDataGrid1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
            
        private void initialization()
        {
            btnAdd.Enabled = true;
            btnRemove.Enabled = false;
        }
        private void loadData()
        {

            try
            {
                Database db = new Database();
                String query = "select a.appointment_id as AppointmentID,c.fname,c.lname,c.nic,a.service_type,a.sDate,a.sTime,c.mobile,c.c_code from customers c,appointment a where c.c_code = a.c_code";
                
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                bunifuCustomDataGrid1.DataSource = dt;
                db.getConnection().Close();
                for (int i = 0; i < bunifuCustomDataGrid1.Columns.Count; i++)
                {
                    bunifuCustomDataGrid1.Columns[i].Visible = false;
                }
                bunifuCustomDataGrid1.Columns[0].Visible = true;
                bunifuCustomDataGrid1.Columns[0].HeaderText = "ID";
                bunifuCustomDataGrid1.Columns[1].Visible = true;
                bunifuCustomDataGrid1.Columns[1].HeaderText = "First Name";
                bunifuCustomDataGrid1.Columns[2].Visible = true;
                bunifuCustomDataGrid1.Columns[2].HeaderText = "Last Name";
                bunifuCustomDataGrid1.Columns[3].Visible = true;
                bunifuCustomDataGrid1.Columns[3].HeaderText = "NIC";
                bunifuCustomDataGrid1.Columns[4].Visible = true;
                bunifuCustomDataGrid1.Columns[4].HeaderText = "Type";
                bunifuCustomDataGrid1.Columns[5].Visible = true;
                bunifuCustomDataGrid1.Columns[5].HeaderText = "date";
                bunifuCustomDataGrid1.Columns[6].Visible = true;
                bunifuCustomDataGrid1.Columns[6].HeaderText = "Time";
                bunifuCustomDataGrid1.Columns[7].Visible = true;
                bunifuCustomDataGrid1.Columns[7].HeaderText = "Mobile";

                btnUpdate.Visible = false;
                btnRemove.Visible = false;
                btnAdd.Enabled = true;
                clear();

            }

            catch (SqlException ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            

        }
        public void clear()
        {
            bunifuCustomDataGrid1.ClearSelection();
            txtFname.Text = string.Empty;
            txtLname.Text = string.Empty;
            txtMobl.Text = string.Empty;
            txtNIC.Text = string.Empty;
            chkRepair.Checked = false;
            chkService.Checked = false;
         
        }
        public bool Validte_Data()
        {
            Regex validate_email = new Regex("^[a-zA-Z0-9]{1,20}@[a-zA-Z0-9]{1,20}.[a-zA-Z]{2,3}$");
            Regex Validate_alpha_numaric = new Regex("^[0-9a-zA-Z #,-]+$");
            Regex validate_phone_num = new Regex("^[0-9]{10}$");
            Regex validate_nic = new Regex("^[0-9]{9}[V,v]$");
            Regex validate_alphabatic = new Regex("^[a-zA-Z]+$");

            if (!validate_alphabatic.IsMatch(txtFname.Text))
            {
                MessageBox.Show("First Name Is Not Correct");
            }
            else
            {
                if (!validate_alphabatic.IsMatch(txtLname.Text))
                {
                    MessageBox.Show("Last Name Is Not Correct");
                }
                else
                {
                    if (!validate_nic.IsMatch(txtNIC.Text))
                    {
                        MessageBox.Show("NIC is Not Correct");
                    }
                    else
                    {
                        if (!validate_phone_num.IsMatch(txtMobl.Text))
                        {
                            MessageBox.Show("Mobile Number Is Not Valid");
                        }
                        else
                        {
                            if (!Validate_alpha_numaric.IsMatch("rrerwer"))
                            {
                                MessageBox.Show("Address Line 1 is Not correct");
                            }
                            else
                            {
                                if (!Validate_alpha_numaric.IsMatch("wrwerwe"))
                                {
                                    MessageBox.Show("Address Line 2 is Not correct");
                                }
                                else
                                {
                                    if (!Validate_alpha_numaric.IsMatch("werewr"))
                                    {
                                        MessageBox.Show("City is Not correct");
                                    }
                                    else
                                    {
                                        if (!validate_email.IsMatch("dss@ff.com"))
                                        {
                                            MessageBox.Show("E-mail is Not Valid");
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




        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "hh:mm";
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
          
        }
        private void search()
        {

            try
            {
                Database db = new Database();

                String q1 = "select a.appointment_id as AppointmentID,c.fname,c.lname,c.nic,a.service_type,a.sDate,a.sTime,c.mobile,c.c_code from customers c,appointment a where fname like '%" + txt_search.Text + "%' and c.cus_id = a.cus_id";
                //"select a.appointment_id as AppointmentID,c.fname,c.lname,c.nic,a.service_type,a.sDate,a.sTime,c.mobile,c.c_code from customers c,appointment a where c.c_code = a.c_code";


                db.sqlQuery(q1);
                DataTable dt = db.executeQuery();
                bunifuCustomDataGrid1.DataSource = dt;
                db.getConnection().Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        



        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            
            String service_type=null;
            if(chkRepair.Checked)
            {
                service_type = "repair";
            }
            else if(chkService.Checked)
            {
                service_type = "service";
            }
            else if(chkRepair.Checked&&chkService.Checked)
            {
                service_type = "service & repair";
            }
            else
            {
                MessageBox.Show("Please select a service type");
            }
            String sdate = dateTimePicker1.Value.ToString();
            String stime = dateTimePicker2.Value.ToString();
            String fname = txtFname.Text;
            String lname = txtLname.Text;
            String NIC = txtNIC.Text;
            String mobile = txtMobl.Text;
            String appId = CodeGenerator.generateAppointmentID();
            String cusId = CodeGenerator.generateCustomerID();

            bool status=Validte_Data();
            if (status == true)
            {
                if (dateTimePicker1.Value.Date >= DateTime.Today)
                {
                    string query1 = "INSERT INTO appointment(appointment_id,c_code,service_type,sdate,stime,e_code) VALUES  ( '" + appId + "', '" + cusId + "', '" + service_type + "', '" + sdate + "', '" + stime + "E0001" + "')";
                    string query2 = "INSERT INTO customers(c_code,fname,lname,nic,mobile) VALUES  ( '" + cusId + "', '" + fname + "', '" + fname + "', '" + NIC + "','" + mobile + "')";

                    Database db = new Database();
                    db.sqlQuery(query1);
                    db.sqlQuery(query2);
                    db.nonQuery();
                    db.getConnection().Close();
                    loadData();
                }
                else if(dateTimePicker1.Value.Date<DateTime.Today)
                {
                    MyDialog.Show("Date error","Please select a correct date");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            String id = Convert.ToString(selectedRow.Cells[0].Value);

            String sdate = dateTimePicker1.Value.ToString();
            String stime = dateTimePicker2.Value.ToString();
            String fname = txtFname.Text;
            String lname = txtLname.Text;
            String NIC = txtNIC.Text;
            String mobile = txtMobl.Text;
            String service_type = "repair";
            if (chkRepair.Checked)
            {
                service_type = "repair";
            }
            else if (chkService.Checked)
            {
                service_type = "service";
            }
            else if (chkRepair.Checked && chkService.Checked)
            {
                service_type = "service & repair";
            }
            else
            {
                MyDialog.Show("Error...", "Please select a service type");
            }


           
          
            {
                if (dateTimePicker1.Value.Date >= DateTime.Today)
                {
                    string query1 = "UPDATE appointment SET sdate = '" + sdate + "', stime = '" + stime + "', service_type = '" + service_type + "' WHERE appointment_id = '" + id + "'";              
                    string q = "select c_code from appointments where appointment_id='"+id+ "'";

                    String cusid = bunifuCustomDataGrid1.CurrentRow.Cells[8].Value.ToString();
                    /*SqlConnection conn = new SqlConnection("server=localhost;Trusted_Connection=yes;database=auto_care2;connection timeout=30");
                    SqlCommand command = new SqlCommand("select c_code from appointments where appointment_id='" + id + "'");
                    command.Connection = conn;
                    conn.Open();
                    string cusid = command.ExecuteReader().ToString();
                    conn.Close();*/
                   
                    string query2=  "UPDATE customers SET fname ='"+fname+"',lname='"+lname+"',nic='"+NIC+"',mobile='"+mobile+"'WHERE c_code ='"+cusid+ "'";
                    Database db = new Database();
                    db.sqlQuery(query1);
                   // db.sqlQuery(q);
                    db.sqlQuery(query2);
                    db.nonQuery();
                    db.getConnection().Close();
                    loadData();
                    clear();
                }
                else if (dateTimePicker1.Value.Date < DateTime.Today)
                {
                    MyDialog.Show("Date error", "Please select a correct date");
                }
            }
        } 

        private void btnRemove_Click(object sender, EventArgs e)
        {

            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            String id = Convert.ToString(selectedRow.Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM appointment WHERE appointment_id = '" + id + "'";
                Database db = new Database();
                db.sqlQuery(query);
                db.nonQuery();
                db.getConnection().Close();
                loadData();
                clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            btnAdd.Visible = true;
            btnAdd.Enabled = true;
        }

        private void txtMobl_OnValueChanged(object sender, EventArgs e)
        {
            
            if(System.Text.RegularExpressions.Regex.IsMatch(txtMobl.Text,"[^0-9]")&&txtMobl.Text.Length>10)
            {
                MessageBox.Show("Please enter a valid Mobile number");
                txtMobl.Text = txtMobl.Text.Remove(txtMobl.Text.Length - 1);
                
            }

        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFname.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            txtLname.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
           txtMobl.Text = bunifuCustomDataGrid1.CurrentRow.Cells[7].Value.ToString();
            txtNIC.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];


            btnUpdate.Visible = true;
            btnUpdate.Visible = true;
            btnAdd.Enabled = false;
            btnAdd.Visible = false;
            btnRemove.Enabled = true;
            btnRemove.Visible = true;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            search();
            
        }
    }
}

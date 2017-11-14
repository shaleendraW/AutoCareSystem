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
using System.IO;

namespace AutoCareSystem
{
    public partial class Employee_details : UserControl
    {
        public Employee_details()
        {
            InitializeComponent();
            EmployeeGridView();
        }



        private void EmployeeGridView()
        {
            try
            {
                Database db = new Database();
                string query = "select e_code AS 'Employee ID',fname AS 'FirstName',nic AS 'NIC',gender AS 'Gender',tel_phone AS 'Telephone' from employee";


                SqlConnection conn = db.getConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                BindingSource bsource = new BindingSource();
                bsource.DataSource = table;
                DataGridEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DataGridEmployee.DataSource = bsource;
                conn.Close();
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


        private void EmployeeGridViewBySearch(String Searchkey)
        {
            try
            {
                Database db = new Database();
                string query = "select e_code AS 'Employee ID',fname AS 'FirstName',nic AS 'NIC',gender AS 'Gender',tel_phone AS 'Telephone' from employee WHERE fname like '%" + Searchkey + "%'";


                SqlConnection conn = db.getConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                BindingSource bsource = new BindingSource();
                bsource.DataSource = table;
                DataGridEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DataGridEmployee.DataSource = bsource;
                conn.Close();
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



        private void resetFields()
        {
            txtEmpID.Text = string.Empty;
            txtFname.Text = string.Empty;
            txtLame.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtsearch.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressline2.Text = string.Empty;
            txtCardid.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtApt_hollyday.Text = string.Empty;
            rbFemale.Checked = false;
            rbMale.Checked = false;
            cmbPosition.SelectedIndex= 0;
            dpBirthday.Text = string.Empty;
            EmployeeGridView();



        }






        public  String getNeedeStringvalues(String EmployeeId, String clm_name)
        {
            try
            {
                String query = "SELECT  " + clm_name + " FROM employee WHERE e_code='" + EmployeeId + "'";
                Database db = new Database();
                db.sqlQuery(query);
                String NeedString = db.executeQuery(clm_name);
                db.getConnection().Close();
                return NeedString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
       
        public int getNeedINTvalues(String EmployeeId, String clm_name)
        {
            try
            {
                String query = "SELECT  " + clm_name + " FROM employee WHERE e_code='" + EmployeeId + "' ";
                Database db = new Database();
                db.sqlQuery(query);
                int NeedINT = Convert.ToInt32(db.executeQuery(clm_name));
                db.getConnection().Close();
                return NeedINT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
















        private void doubleBitmapControl1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Employee_details_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                string query = "select *from Employee";


                SqlConnection conn = db.getConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                BindingSource bsource = new BindingSource();
                bsource.DataSource = table;
              //  dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

               // dataGridView1.DataSource = bsource;
                conn.Close();
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

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EmployeeGridViewBySearch(txtsearch.Text);
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            EmployeeGridViewBySearch(txtsearch.Text);
        }

        private void DataGridEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = DataGridEmployee.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = DataGridEmployee.Rows[selectedrowindex];

            string EmpID = Convert.ToString(selectedRow.Cells[0].Value);
            txtEmpID.Text = EmpID;
            txtFname.Text = Convert.ToString(selectedRow.Cells[1].Value);
                txtNIC.Text = Convert.ToString(selectedRow.Cells[2].Value);
            txtTelephone.Text = Convert.ToString(selectedRow.Cells[4].Value);
            txtLame.Text = getNeedeStringvalues(EmpID, "lname");
            txtAddressLine1.Text = getNeedeStringvalues(EmpID, "add_line_01");
            txtAddressline2.Text = getNeedeStringvalues(EmpID, "add_line_02");
            txtCardid.Text= Convert.ToString( getNeedINTvalues(EmpID, "card_id"));
            txtCity.Text = getNeedeStringvalues(EmpID, "city");
            txtApt_hollyday.Text = Convert.ToString( getNeedINTvalues(EmpID, "acpt_holidays"));

           // dpBirthday.Value = DateTime.Parse(Convert.ToString(selectedRow.Cells[7].Value));
            dpBirthday.Value = DateTime.Parse(getNeedeStringvalues(EmpID, "b_date"));

            int index = cmbPosition.FindString(getNeedeStringvalues(EmpID, "position"));
            cmbPosition.SelectedIndex = index;

            if (Convert.ToString(selectedRow.Cells[3].Value)=="Male")
            {
                rbMale.Checked = true;
                rbFemale.Checked = false;
            }
            else if (Convert.ToString(selectedRow.Cells[3].Value) == "Female")
            {

                rbFemale.Checked = true;
                rbMale.Checked = false;
            }


            try
            {



                Database db = new Database();
                SqlConnection conn = db.getConnection();
                SqlCommand cmd = conn.CreateCommand();

                // string query = "select *from register";
                string sql = "select profile_pic from employee where e_code='" + EmpID + "'";
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd = new SqlCommand(sql, conn);

                SqlDataReader DataRead = cmd.ExecuteReader();
                DataRead.Read();




                if (DataRead.HasRows)
                {
                    //vehicleID.Text = DataRead[0].ToString();
                    byte[] image1 = (byte[])(DataRead[0]);

                    if (imageBox == null)
                    {
                        imageBox.Image = null;
                    }
                    else
                    {
                        MemoryStream mstreem = new MemoryStream(image1);
                        imageBox.Image = Image.FromStream(mstreem);
                    }
                }

                else
                {
                    MessageBox.Show("Not Avilible");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                imageBox.Image = null;

            }





        }

        private void btnRepairRemove_Click(object sender, EventArgs e)
        {
            int selectedrowindex = DataGridEmployee.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = DataGridEmployee.Rows[selectedrowindex];

            String Eid = Convert.ToString(selectedRow.Cells[0].Value);
           // String sid = Convert.ToString(selectedRow.Cells[1].Value);
        
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                         "Confirm Delete!!",
                                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {



                string query = "DELETE FROM employee WHERE e_code = '" + Eid + "' ";
                Database db = new Database();
                db.sqlQuery(query);    //pass query to sql query method
                db.nonQuery();          //pass the cmd to nonQuery method(for Insert)
                db.getConnection().Close();
                EmployeeGridView();  //reload table
                resetFields();   //clear all fileds
            }

        }

        private void btnRepairClear_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        private void btnRepairUpdate_Click(object sender, EventArgs e)
        {
            byte[] image = null;
            FileStream streem = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            image = brs.ReadBytes((int)streem.Length);

            int selectedrowindex = DataGridEmployee.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = DataGridEmployee.Rows[selectedrowindex];


            String EID = Convert.ToString(selectedRow.Cells[0].Value);

            string gender="";
            if (rbMale.Checked)
            {
                gender = "Male";


            }
            else if (rbFemale.Checked)
            {

                gender = "Female";


            }


            Database db = new Database();
            SqlConnection conn = db.getConnection();
            SqlCommand cmd = conn.CreateCommand();
            string query = "UPDATE employee SET fname = '" + txtFname.Text + "', lname= '" + txtLame.Text + "',b_date = '" + dpBirthday.Text + "',gender = '" + gender + "',add_line_01 = '" + txtAddressLine1.Text + "',add_line_02 = '" + txtAddressline2.Text + "',city = '" + txtCity.Text + "',nic = '" + txtNIC.Text + "',tel_phone = '" + txtTelephone.Text + "',position = '" + cmbPosition.Text + "',acpt_holidays = '" + txtApt_hollyday.Text + "',card_id = '" + txtCardid.Text + "',profile_pic='"+ image + "' WHERE e_code = '" + txtEmpID.Text + "' ";
            cmd.Parameters.Add(new SqlParameter("@image1", image));

            db.sqlQuery(query);
            if (db.nonQuery())
                MyDialog.Show("Success...!", "Status updated");

            else
                MyDialog.Show("Error...!", "Status not updated");

            db.getConnection().Close();
            EmployeeGridView();
            resetFields();
        }
        string imageLocation = "";
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName.ToString();
                imageBox.ImageLocation = imageLocation;
            }
        }

        private void materialLabel7_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }
    }
}

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

namespace AutoCareSystem
{
    public partial class payment_handle : UserControl
    {
        public payment_handle()
        {
            InitializeComponent();
        }

        private void repair_payment_Load(object sender, EventArgs e)
        {
            resetFields();
            cmbFilter.SelectedIndex = 0;
        }

        private void tbxVehicleNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void BindGridView(String skey)
        {
            try
            {
                String query;
                if (cmbFilter.SelectedIndex == 0)
                    query = "SELECT s.s_code AS ID, s.enter_date AS 'Service Date', s.next_date AS 'Next Date' FROM services s LEFT OUTER JOIN vehicles v ON s.v_code = v.v_code WHERE v.vehicle_number = '" + skey + "'";
                else
                    query = "SELECT r.r_code AS ID, e.fname+' '+lname AS Technician, r.repair_date AS 'Repair Date' FROM repairs r LEFT OUTER JOIN vehicles v ON r.v_code = v.v_code LEFT OUTER JOIN employee e ON r.e_code = e.e_code WHERE v.vehicle_number = '" + skey + "'";

                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                if (dt != null && dt.Rows.Count > 0)
                {
                    bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    bunifuCustomDataGrid1.DataSource = dt;
                    loadCustomerDetails(skey);
                }
                else
                {
                    resetFields();
                    MyDialog.Show("Opps!", "Vehicle not found");
                }

                db.getConnection().Close();
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
            bunifuCustomDataGrid1.DataSource = null;
            bunifuCustomDataGrid2.DataSource = null;
            lblCharges.Text = String.Empty;
            lblModel.Text = String.Empty;
            lblFullName.Text = String.Empty;
            lblPhoneNo.Text = String.Empty;
        }

        private void loadCustomerDetails(String skey)
        {
            try
            {
                String model = String.Empty;
                String full_name = String.Empty;
                String phone_num = String.Empty;
                String query = "SELECT v.model, c.fname, c.lname, c.mobile FROM vehicles v LEFT OUTER JOIN customers c ON v.c_code = c.c_code WHERE v.vehicle_number = '" + skey + "'";
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        model = Convert.ToString(row["model"]);
                        full_name = Convert.ToString(row["fname"])+" "+Convert.ToString(row["lname"]);
                        phone_num = Convert.ToString(row["mobile"]);
                    }
                    lblModel.Text = model;
                    lblFullName.Text = full_name;
                    lblPhoneNo.Text = phone_num;
                }
                db.getConnection().Close();
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

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            loadSubGridView(Convert.ToString(selectedRow.Cells[0].Value),(cmbFilter.SelectedIndex==0));
        }

        private void loadSubGridView(String id, bool b)
        {
            try
            {
                string query = null;
                Database db = new Database();
                if(b)
                    query = "SELECT st.name,ps.charges FROM provided_services ps LEFT OUTER JOIN service_types st ON ps.stid = st.stid WHERE ps.s_code = '" + id + "'";
                else
                    query = "SELECT rt.name,pr.charges FROM provided_repairs pr LEFT OUTER JOIN repair_types rt ON pr.rtid = rt.rtid WHERE pr.r_code = '" + id + "'";

                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                bunifuCustomDataGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bunifuCustomDataGrid2.DataSource = dt;
                db.getConnection().Close();
                calculateTotal(dt);
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

        private void calculateTotal(DataTable dt)
        {
            int charges = 0;

            foreach (DataRow row in dt.Rows)
                charges = charges + Convert.ToInt32(row["charges"]);
            

            lblCharges.Text = Convert.ToString(charges);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxSearchBox.Text.Length > 0)
            {
                if (Validator.IsValidVehicleNumber(tbxSearchBox.Text))
                {
                    resetFields();
                    BindGridView(tbxSearchBox.Text);
                }
                else
                {
                    MyDialog.Show("Error...!", "Invalid Vehicle Number");
                }
            }
            else
            {
                MyDialog.Show("Opps!", "Search Box is empty");
            }
        }

        private void tbxSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxSearchBox.Text = String.Empty;
            resetFields();
        }
    }
}

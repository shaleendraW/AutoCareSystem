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
using System.Data.OleDb;

namespace AutoCareSystem
{
    public partial class vehicle_manage : UserControl
    {

        public vehicle_manage()
        {
            InitializeComponent();
        }

        private void vehicle_manage_Load(object sender, EventArgs e)
        {
            setCustomers();
            BindGridView(null);
            enableButtons(false);
            cmbVehicleType.SelectedIndex = 0;
        }

        public void SetGridViewWidth()
        {
            bunifuCustomDataGrid1.Columns[0].Width = 50;
            bunifuCustomDataGrid1.Columns[1].Width = 200;
            bunifuCustomDataGrid1.Columns[2].Width = 100;
            bunifuCustomDataGrid1.Columns[3].Width = 100;
            bunifuCustomDataGrid1.Columns[4].Width = 100;
            bunifuCustomDataGrid1.Columns[5].Width = 100;
        }

        private void setCustomers()
        {
            try
            {
                string query = "SELECT * FROM customers";
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();

                Dictionary<string, string> comboSource = new Dictionary<string, string>();

                foreach (DataRow row in dt.Rows)
                {
                    String id = Convert.ToString(row["c_code"]);
                    String name = Convert.ToString(row["fname"]) + " " + Convert.ToString(row["lname"]);
                    comboSource.Add(id, name);
                }

                cmbCusName.DataSource = new BindingSource(comboSource, null);
                cmbCusName.DisplayMember = "Value";
                cmbCusName.ValueMember = "Key";
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void enableButtons(bool b)
        {
            btnRemove.Enabled = b;
            btnUpdate.Enabled = b;
            btnAdd.Enabled = !b;

            btnAdd.Cursor = (!b) ? Cursors.Hand : Cursors.Default;
            btnRemove.Cursor = (b) ? Cursors.Hand : Cursors.Default;
            btnUpdate.Cursor = (b) ? Cursors.Hand : Cursors.Default;

        }

        private void BindGridView(String skey)
        {
            try
            {
                String query;
                if (string.IsNullOrWhiteSpace(skey))
                    query = "SELECT v.v_code AS ID, c.fname+' '+c.lname AS Customer,v.vehicle_number AS 'Vehicle Number',v.vehicle_type AS Type,v.brand AS Brand,v.model AS Model FROM vehicles v LEFT OUTER JOIN customers c ON v.c_code = c.c_code";
                else
                    query = "SELECT v.v_code AS ID, c.fname+' '+c.lname AS Customer,v.vehicle_number AS 'Vehicle Number',v.vehicle_type AS Type,v.brand AS Brand,v.model AS Model FROM vehicles v LEFT OUTER JOIN customers c ON v.c_code = c.c_code WHERE v.vehicle_number LIKE '%" + skey+"%'";

                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bunifuCustomDataGrid1.DataSource = dt;
                db.getConnection().Close();
                SetGridViewWidth();
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

        private void addNewVehicle()
        {
            string key = ((KeyValuePair<string, string>)cmbCusName.SelectedItem).Key;
            String vehicle_type = cmbVehicleType.SelectedItem.ToString();
            String v_code = CodeGenerator.generateVehicleCode();
            string query = "INSERT INTO vehicles VALUES('" + v_code + "','" + key+"','" + tbxVehicleNo.Text + "','" + vehicle_type + "','" + tbxBrand.Text + "','" + tbxModel.Text + "','" + DateTime.Now + "')";
            Database db = new Database();
            db.sqlQuery(query);
            if (db.nonQuery())
            {
                MyDialog.Show("Success...!", "Vehicle Registered");
                resetFields();
                BindGridView(null);
            }
            else
            {
                MyDialog.Show("Error...!", "Vehicle Not Registered");
            }
            db.getConnection().Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxVehicleNo.Text) ||
                String.IsNullOrWhiteSpace(tbxBrand.Text) ||
                String.IsNullOrWhiteSpace(tbxModel.Text) ||
                String.IsNullOrWhiteSpace(tbxVehicleNo.Text))

                MyDialog.Show("Error...!", "Please fill all fields");

            else
            {
                if (Validator.IsValidName(tbxBrand.Text))
                {
                    if (Validator.IsValidVehicleNumber(tbxVehicleNo.Text))
                    {
                        if (Validator.IsValidName(tbxModel.Text))
                            addNewVehicle();
                        else
                            MyDialog.Show("Error...!", "Invalid Model Name");
                    }
                    else
                        MyDialog.Show("Error...!", "Invalid Vehicle Number");
                }
                else
                {
                    MyDialog.Show("Error...!", "Invalid Brand Name");
                }
            }
            
        }

        public void loadTexts(DataGridViewRow selectedRow)
        {
            tbxVehicleNo.Text = Convert.ToString(selectedRow.Cells[2].Value);
            tbxBrand.Text = Convert.ToString(selectedRow.Cells[4].Value);
            tbxModel.Text = Convert.ToString(selectedRow.Cells[5].Value);

            int index01 = cmbVehicleType.FindString(Convert.ToString(selectedRow.Cells[3].Value));
            cmbVehicleType.SelectedIndex = index01;

            int index02 = cmbCusName.FindString(Convert.ToString(selectedRow.Cells[1].Value));
            cmbCusName.SelectedIndex = index02;
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuCustomDataGrid1.SelectedCells.Count > 0)
            {
                int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

                loadTexts(selectedRow);
                enableButtons(true);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetFields();
            BindGridView(null);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            String v_code = Convert.ToString(selectedRow.Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM vehicles WHERE v_code = '" + v_code + "'";
                Database db = new Database();
                db.sqlQuery(query);     //pass query to sql query method 
                db.nonQuery();          //pass the cmd to nonQuery method(for Insert)
                db.getConnection().Close();
                BindGridView(null);         //reload table
                resetFields();          //reset all input fields
            }
            
        }

        private void resetFields()
        {
            cmbCusName.ResetText();
            cmbVehicleType.ResetText();
            tbxVehicleNo.Text = String.Empty;
            tbxBrand.Text = String.Empty;
            tbxModel.Text = String.Empty;
            bunifuCustomDataGrid1.ClearSelection();
            enableButtons(false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            String v_code = Convert.ToString(selectedRow.Cells[0].Value);
            String type = cmbVehicleType.SelectedItem.ToString();

            if (String.IsNullOrWhiteSpace(tbxVehicleNo.Text) ||
                String.IsNullOrWhiteSpace(tbxBrand.Text) ||
                String.IsNullOrWhiteSpace(tbxModel.Text) ||
                String.IsNullOrWhiteSpace(tbxVehicleNo.Text))

                MyDialog.Show("Error...!", "Please fill all fields");

            else
            {
                if (Validator.IsValidName(tbxBrand.Text))
                {
                    if (Validator.IsValidVehicleNumber(tbxVehicleNo.Text))
                    {
                        if (Validator.IsValidName(tbxModel.Text))
                        {
                            String query = "UPDATE vehicles SET vehicle_number = '" + tbxVehicleNo.Text + "', vehicle_type = '" + type + "', brand = '" + tbxBrand.Text + "', model = '" + tbxModel.Text + "' WHERE v_code = '" + v_code + "'";
                            Database db = new Database();
                            db.sqlQuery(query);
                            if (db.nonQuery())
                            {
                                BindGridView(null);
                                resetFields();
                                MyDialog.Show("Success...!", "Vehicle updated");
                            }
                            else
                            {
                                MyDialog.Show("Error...!", "Vehicle not updated");
                            }
                            db.getConnection().Close();
                        }
                        else
                            MyDialog.Show("Error...!", "Invalid Model Name");

                    }
                    else
                        MyDialog.Show("Error...!", "Invalid Vehicle Number");
                }
                else
                    MyDialog.Show("Error...!", "Invalid Brand Name");
                
            }   
        }

        private void tbxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            BindGridView( ((tbxSearch.Text.Length >= 7) ? tbxSearch.Text : null) );
        }

        private void tbxVehicleNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (Validator.IsValidVehicleNumber(tbxSearch.Text))
                BindGridView(tbxSearch.Text);
            else
                MyDialog.Show("Error...!", "Invalid Vehicle Number");
        }

        private void cmbCusName_Click(object sender, EventArgs e)
        {
            setCustomers();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCareSystem
{
    public partial class add_repair_faults : UserControl
    {
        private String vehicle_id;

        public add_repair_faults()
        {
            InitializeComponent();
        }

        private void new_add_repair_Load(object sender, EventArgs e)
        {
            setTechnicians();
            lblBrand.Text = String.Empty;
            lblModel.Text = String.Empty;
            enabaleFields(false);
            btnRemove.Enabled = false;
            btnRemove.Cursor = Cursors.Default;
            btnRepairAdd.Enabled = false;
            btnRepairAdd.Cursor = Cursors.Default;
        }

        private void enabaleFields(bool b)
        {
            tbxErrorCode.Enabled = b;
            tbxDesc.Enabled = b;
            tbxRemark.Enabled = b;
            cmbTechnician.Enabled = b;

            btnRepairAdd.Enabled = b;
            btnRepairAdd.Cursor = (b) ? Cursors.Hand : Cursors.Default;
        }

        private void tbxVehicleNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void tbxVehicleNumber_KeyUp(object sender, KeyEventArgs e)
        {
            enabaleFields( ((isFound(tbxVehicleNumber.Text)) ? true : false) ); 
        }

        private bool isFound(String skey)
        {
            try
            {
                String brand = null;
                String model = null;
                String query = "SELECT * FROM vehicles WHERE vehicle_number = '" + skey + "'";
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                if (dt != null && dt.Rows.Count == 1)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        vehicle_id = Convert.ToString(row["v_code"]);
                        brand = Convert.ToString(row["brand"]);
                        model = Convert.ToString(row["model"]);
                    }
                }
                else
                {
                    vehicle_id = null;
                }
                db.getConnection().Close();
                lblBrand.Text = brand;
                lblModel.Text = model;
                return (dt != null && dt.Rows.Count == 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                return false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string code = tbxErrorCode.Text;
            string desc = tbxDesc.Text;
            string remark = tbxRemark.Text;
            if (tbxErrorCode.Text.Length > 0 && tbxDesc.Text.Length > 0)
            {
                if (Validator.IsValidErrorCode(code))
                {
                    string[] row = { code, desc, remark };
                    bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    bunifuCustomDataGrid1.Rows.Add(row);
                    lblErrorCount.Text = bunifuCustomDataGrid1.Rows.Count.ToString();
                }
                else
                {
                    MyDialog.Show("Error..!", "Invalid Error Code");
                }
            }
            else
            {
                MyDialog.Show("Error..!", "Error Code && Description are Required");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = bunifuCustomDataGrid1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                bunifuCustomDataGrid1.Rows.RemoveAt(bunifuCustomDataGrid1.CurrentCell.RowIndex);
                lblErrorCount.Text = bunifuCustomDataGrid1.Rows.Count.ToString();
            }
            else
            {
                btnRemove.Enabled = false;
                btnRemove.Cursor = Cursors.Default;
            }
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRemove.Enabled = true;
            btnRemove.Cursor = Cursors.Hand;
        }

        private void setTechnicians()
        {
            string query = "SELECT * FROM employee WHERE technician_status = 'available'";
            Database db = new Database();
            db.sqlQuery(query);
            DataTable dt = db.executeQuery();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            foreach (DataRow row in dt.Rows)
            {
                String id = Convert.ToString(row["e_code"]);
                String name = Convert.ToString(row["fname"])+" "+ Convert.ToString(row["lname"]);
                comboSource.Add(id, name);
            }

            cmbTechnician.DataSource = new BindingSource(comboSource, null);
            cmbTechnician.DisplayMember = "Value";
            cmbTechnician.ValueMember = "Key";
        }

        private void btnRepairAdd_Click(object sender, EventArgs e)
        {
            string e_code = ((KeyValuePair<string, string>)cmbTechnician.SelectedItem).Key;
            String repair_date = repairDate.Value.ToString("yyyy-MM-dd");
            String r_code = CodeGenerator.generateRepairCode();
            if (Validator.IsValidPastDate(repair_date))
            {

                string query = "INSERT INTO repairs VALUES('" + r_code + "','" + e_code + "','" + vehicle_id + "','" + repair_date + "')";
                Database db = new Database();
                db.sqlQuery(query);
                if (db.nonQuery())
                {
                    MyDialog.Show("Success...!", "Repair Registered");
                    addVehicleFaults();
                    resetFields();
                }
                else
                {
                    MyDialog.Show("Error...!", "Repair Not Registered");
                }
            }
            else
            {
                MyDialog.Show("Error...!", "Invalid repair date");
            }
        }

        private void resetFields()
        {
            tbxVehicleNumber.Text = String.Empty;
            tbxErrorCode.Text = String.Empty;
            tbxDesc.Text = String.Empty;
            tbxRemark.Text = String.Empty;
            cmbTechnician.SelectedIndex = 0;
            repairDate.Value = DateTime.Today.AddDays(0);
            bunifuCustomDataGrid1.DataSource = null;
        }

        private void addVehicleFaults()
        {
            String r_code = Database.getLastInsertId("repairs", "r_code");
            Database db = new Database();
            foreach (DataGridViewRow row in bunifuCustomDataGrid1.Rows)
            {
                String exist_id = isExists(Convert.ToString(row.Cells[0].Value));
                String error_id = ( (exist_id != null) ? exist_id : addNewErrorCode() );
                if (!isVehicleErrorExists(r_code, error_id))
                {
                    string query = "INSERT INTO vehicle_errors VALUES('" + r_code + "','" + error_id + "','Pending','" + DateTime.Now + "')";
                    db.sqlQuery(query);
                    db.nonQuery();
                }
            }
            db.getConnection().Close();
        }

        private bool isVehicleErrorExists(string r_code, string error_id)
        {
            try
            {
                String query = "SELECT * FROM vehicle_errors WHERE r_code = '" + r_code + "' AND ecid = '" + error_id + "'";
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                db.getConnection().Close();
                return (dt != null && dt.Rows.Count == 1);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private String addNewErrorCode()
        {
            String query = "INSERT INTO error_codes VALUES('" + tbxErrorCode.Text + "','" + tbxDesc.Text + "','" + tbxRemark.Text + "','" + DateTime.Now + "')";
            Database db = new Database();
            db.sqlQuery(query);
            db.nonQuery(); 
            db.getConnection().Close();
            return Database.getLastInsertId("error_codes", "ecid"); ;
        }

        private void tbxErrorCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void tbxErrorCode_KeyUp(object sender, KeyEventArgs e)
        {
            if(tbxErrorCode.Text.Length >= 4)
                isExists(tbxErrorCode.Text);
            else
            {
                tbxDesc.Text = String.Empty;
                tbxRemark.Text = String.Empty;
            }
        }

        private String isExists(string key)
        {
            try
            {
                String query = "SELECT * FROM error_codes WHERE code = '" + key + "'";
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                db.getConnection().Close();
                if (dt != null && dt.Rows.Count == 1)
                {
                    tbxDesc.Text = Convert.ToString(dt.Rows[0]["description"]);
                    tbxRemark.Text = Convert.ToString(dt.Rows[0]["extra_details"]);
                    return Convert.ToString(dt.Rows[0]["ecid"]);
                }
                else
                {
                    tbxDesc.Text = String.Empty;
                    tbxRemark.Text = String.Empty;
                    return null;
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private void cmbTechnician_Click(object sender, EventArgs e)
        {
            setTechnicians();
        }
    }
}

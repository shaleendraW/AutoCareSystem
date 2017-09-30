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

namespace AutoCareSystem
{
    public partial class update_job_status : UserControl
    {
        public update_job_status()
        {
            InitializeComponent();
        }

        private void update_job_status_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            rbPending.Enabled = false;
            rbFinished.Enabled = false;
            lblErrorCode.Text = string.Empty;
            lblErrorDesc.Text = string.Empty;
        }

        private void tbxVehicleNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void checkForErrors(String skey, bool b)
        {
            try
            {
                string query;
                if (b)
                    query = "SELECT r.r_code AS 'Repair Code',ec.code AS 'Error Code',ec.description AS Description,ve.status AS Status FROM vehicle_errors ve LEFT OUTER JOIN error_codes ec ON ve.ecid = ec.ecid LEFT OUTER JOIN repairs r ON r.r_code = ve.r_code LEFT OUTER JOIN vehicles v ON v.v_code = r.v_code WHERE v.vehicle_number = '" + skey + "'";
                else
                    query = "SELECT r.r_code AS 'Repair Code',ec.code AS 'Error Code',ec.description AS Description,ve.status AS Status FROM vehicle_errors ve LEFT OUTER JOIN error_codes ec ON ve.ecid = ec.ecid LEFT OUTER JOIN repairs r ON r.r_code = ve.r_code WHERE ve.r_code = '" + skey + "'";
                
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                if (dt != null && dt.Rows.Count > 0)
                {
                    bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    bunifuCustomDataGrid1.DataSource = dt;
                    db.getConnection().Close();
                    lblErrorCount.Text = bunifuCustomDataGrid1.Rows.Count.ToString();
                    SetGridViewWidth();
                }
                else
                {
                    MyDialog.Show("Opps!", "No errors found");
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

        public void SetGridViewWidth()
        {
            bunifuCustomDataGrid1.Columns[0].Width = 100;
            bunifuCustomDataGrid1.Columns[1].Width = 100;
            bunifuCustomDataGrid1.Columns[2].Width = 400;
            bunifuCustomDataGrid1.Columns[3].Width = 100;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            bunifuCustomDataGrid1.DataSource = null;
            if (tbxSearchBox.Text.Length > 0)
                if (cmbFilter.SelectedIndex == 0)
                {
                    if (Validator.IsValidVehicleNumber(tbxSearchBox.Text))
                        checkForErrors(tbxSearchBox.Text, (cmbFilter.SelectedIndex == 0));
                    else
                        MyDialog.Show("Error...!", "Invalid Vehicle Number");
                }
                else
                {
                    if (Validator.IsValidPrimaryCode(tbxSearchBox.Text, "R"))
                        checkForErrors(tbxSearchBox.Text, (cmbFilter.SelectedIndex == 0));
                    else
                        MyDialog.Show("Error...!", "Invalid Repair Code");
                }
            else
                MyDialog.Show("Opps!", "Search key cannot be empty");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            tbxSearchBox.Text = string.Empty;
            lblErrorCode.Text = string.Empty;
            lblErrorDesc.Text = string.Empty;
            lblErrorCount.Text = "0";

            rbFinished.Checked = false;
            rbPending.Checked = false;
            rbPending.Enabled = false;
            rbFinished.Enabled = false;

            bunifuCustomDataGrid1.DataSource = null;
        }

        private void bunifuCustomDataGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            loadErrorDetails(selectedRow);

            rbPending.Enabled = true;
            rbFinished.Enabled = true;
        }


        public void loadErrorDetails(DataGridViewRow selectedRow)
        {
            lblErrorCode.Text = Convert.ToString(selectedRow.Cells[1].Value);
            lblErrorDesc.Text = Convert.ToString(selectedRow.Cells[2].Value);
            rbPending.Checked = (Convert.ToString(selectedRow.Cells[3].Value).Equals("Pending"));
            rbFinished.Checked = (Convert.ToString(selectedRow.Cells[3].Value).Equals("Finished"));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            string status = (rbFinished.Checked) ? "Finished" : "Pending";
            String repair_code = Convert.ToString(selectedRow.Cells[0].Value);
            String ecid = getErrorCodeID(Convert.ToString(selectedRow.Cells[1].Value));

            string query = "UPDATE vehicle_errors SET status = '" + status + "' WHERE r_code = '" + repair_code + "' AND ecid = '" + ecid + "'";
            Database db = new Database();
            db.sqlQuery(query);
            if (db.nonQuery())
                MyDialog.Show("Success...!", "Status updated");
            
            else
                MyDialog.Show("Error...!", "Status not updated");
            
            db.getConnection().Close();
            checkForErrors(tbxSearchBox.Text, (cmbFilter.SelectedIndex == 0));
        }

        /*private string getRepairCode(string vehicle_no)
        {
            string query = "SELECT r.r_code FROM repairs r LEFT OUTER JOIN vehicles v ON r.v_code = v.v_code WHERE v.vehicle_number = '" + vehicle_no + "'";
            Database db = new Database();
            db.sqlQuery(query);
            return db.executeQuery("r_code");
        }*/

        private string getErrorCodeID(string error_code)
        {
            string query = "SELECT ecid FROM error_codes  WHERE code = '" + error_code + "'";
            Database db = new Database();
            db.sqlQuery(query);
            return db.executeQuery("ecid");
        }

        private void tbxSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void cmbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            tbxSearchBox.Text = (cmbFilter.SelectedIndex == 0) ? "Vehicle Number" : "Repair Code";
            tbxSearchBox.HintText = (cmbFilter.SelectedIndex == 0) ? "Vehicle Number" : "Repair Code";
        }

        private void tbxSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Search();
            }
        }
    }
}

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
    public partial class repair_details : UserControl
    {
        public repair_details()
        {
            InitializeComponent();
        }

        private void new_repair_details_Load(object sender, EventArgs e)
        {
            BindGridView();
            setRepairTypes();
            enableButton(false,0);
            cmbFilter.SelectedIndex = 0;
            btnRemoveRepair.Enabled = false;
            btnRemoveRepair.Cursor = Cursors.Default;
        }

        private void enableButton(bool b, int i)
        {
            if (i==0)
            {
                btnRepairTypeRemove.Enabled = b;
                btnRepairTypeAdd.Enabled = b;
            }
            else if (i == 1)
            {
                btnRepairTypeRemove.Enabled = !b;
                btnRepairTypeAdd.Enabled = b;
            }
            else
            {
                btnRepairTypeRemove.Enabled = b;
                btnRepairTypeAdd.Enabled = !b;
            }

            btnRepairTypeRemove.Cursor = (btnRepairTypeRemove.Enabled) ? Cursors.Hand : Cursors.Default;
            btnRepairTypeAdd.Cursor = (btnRepairTypeAdd.Enabled) ? Cursors.Hand : Cursors.Default;
        }

        private void BindGridView()
        {
            try
            {
                Database db = new Database();
                string query = "SELECT r.r_code AS ID, e.fname+' '+e.lname AS Employee, v.vehicle_number AS 'Vehicle Number', r.repair_date AS 'Repair Date' FROM repairs r LEFT OUTER JOIN vehicles v ON r.v_code = v.v_code LEFT OUTER JOIN employee e ON r.e_code = e.e_code";

                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bunifuCustomDataGrid1.DataSource = dt;
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

        private void setRepairTypes()
        {
            string query = "SELECT rtid, name FROM repair_types";
            Database db = new Database();
            db.sqlQuery(query);
            DataTable dt = db.executeQuery();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            foreach (DataRow row in dt.Rows)
            {
                String id = Convert.ToString(row["rtid"]);
                String name = Convert.ToString(row["name"]);
                comboSource.Add(id, name);
            }

            cmbRepairTypes.DataSource = new BindingSource(comboSource, null);
            cmbRepairTypes.DisplayMember = "Value";
            cmbRepairTypes.ValueMember = "Key";
        }

        private void btnRepairTypeAdd_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            String id = Convert.ToString(selectedRow.Cells[0].Value);
            String key = ((KeyValuePair<string, string>)cmbRepairTypes.SelectedItem).Key;
            String charges = getCharges(key);
            string query = "INSERT INTO provided_repairs VALUES('" + id + "','" + key + "','" + charges + "','" + DateTime.Now + "')";
            Database db = new Database();
            db.sqlQuery(query);
            if (db.nonQuery())
            {
                MyDialog.Show("Success...!", "Repair added");
                loadSubGridView(id);
            }
        }

        private string getCharges(string key)
        {
            string query = "SELECT charges FROM repair_types WHERE rtid = '" + key + "'";
            Database db = new Database();
            db.sqlQuery(query);
            return db.executeQuery("charges");
        }

        private void loadSubGridView(String id)
        {
            try
            {
                Database db = new Database();
                string query = "SELECT rt.name,pr.charges FROM provided_repairs pr LEFT OUTER JOIN repair_types rt ON pr.rtid = rt.rtid WHERE pr.r_code = '" + id + "'";

                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                bunifuCustomDataGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bunifuCustomDataGrid2.DataSource = dt;
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

        private void bunifuCustomDataGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            enableButton(true, 1);
            btnRemoveRepair.Enabled = true;
            btnRemoveRepair.Cursor = Cursors.Hand;

            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            loadSubGridView(Convert.ToString(selectedRow.Cells[0].Value));
        }

        private void bunifuCustomDataGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            enableButton(true, 2);
            int selectedrowindex = bunifuCustomDataGrid2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid2.Rows[selectedrowindex];
            int index = cmbRepairTypes.FindString(Convert.ToString(selectedRow.Cells[0].Value));
            cmbRepairTypes.SelectedIndex = index;
        }

        private void btnRepairTypeRemove_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            String id = Convert.ToString(selectedRow.Cells[0].Value);
            String key = ((KeyValuePair<string, string>)cmbRepairTypes.SelectedItem).Key;

            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM provided_repairs WHERE r_code = '" + id + "' AND rtid = '" + key + "' ";
                Database db = new Database();
                db.sqlQuery(query);     //pass query to sql query method 
                db.nonQuery();          //pass the cmd to nonQuery method(for Insert)
                db.getConnection().Close();
                loadSubGridView(id);       //reload table
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.ClearSelection();
            bunifuCustomDataGrid2.DataSource = null;
            cmbFilter.SelectedIndex = 0;
            cmbRepairTypes.SelectedIndex = 0;
            tbxSearchBox.Text = string.Empty;
            btnRemoveRepair.Enabled = false;
            btnRemoveRepair.Cursor = Cursors.Default;
            BindGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (tbxSearchBox.Text.Length > 0)
                if (cmbFilter.SelectedIndex == 0)
                {
                    if (Validator.IsValidVehicleNumber(tbxSearchBox.Text))
                        serachRepairedVehicles(tbxSearchBox.Text, (cmbFilter.SelectedIndex == 0));
                    else
                        MyDialog.Show("Error...!", "Invalid Vehicle Number");
                }
                else
                {
                    if (Validator.IsValidPrimaryCode(tbxSearchBox.Text, "R"))
                        serachRepairedVehicles(tbxSearchBox.Text, (cmbFilter.SelectedIndex == 0));
                    else
                        MyDialog.Show("Error...!", "Invalid Repair Code");
                }
            else
                MyDialog.Show("Opps!", "Search key cannot be empty");
        }

        private void serachRepairedVehicles(string skey, bool b)
        {
            try
            {
                string query;
                if (b)
                    query = "SELECT r.r_code AS Code, e.full_name AS Employee, v.vehicle_number AS 'Vehicle Number', r.repair_date AS 'Repair Date' FROM repairs r LEFT OUTER JOIN vehicles v ON r.v_code = v.v_code LEFT OUTER JOIN employee e ON r.e_code = e.e_code  WHERE v.vehicle_number = '" + skey + "'";
                else
                    query = "SELECT r.r_code AS Code, e.full_name AS Employee, v.vehicle_number AS 'Vehicle Number', r.repair_date AS 'Repair Date' FROM repairs r LEFT OUTER JOIN vehicles v ON r.v_code = v.v_code LEFT OUTER JOIN employee e ON r.e_code = e.e_code  WHERE r.r_code = '" + skey + "'";

                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                if (dt != null && dt.Rows.Count > 0)
                {
                    bunifuCustomDataGrid2.DataSource = null;
                    bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    bunifuCustomDataGrid1.DataSource = dt;
                    db.getConnection().Close();
                }
                else
                {
                    MyDialog.Show("Opps!", "No repairs found");
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

        private void tbxSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void btnRemoveRepair_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            String id = Convert.ToString(selectedRow.Cells[0].Value);
            String key = ((KeyValuePair<string, string>)cmbRepairTypes.SelectedItem).Key;

            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM repairs WHERE r_code = '" + id + "' ";
                Database db = new Database();
                db.sqlQuery(query);
                db.nonQuery();   
                db.getConnection().Close();
                BindGridView();
                bunifuCustomDataGrid2.DataSource = null;
            }
        }

        private void repair_details_DoubleClick(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void cmbRepairTypes_Click(object sender, EventArgs e)
        {
            setRepairTypes();
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

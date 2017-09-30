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
    public partial class add_repair_types : UserControl
    {
        public add_repair_types()
        {
            InitializeComponent();
        }

        private void add_repair_types_Load(object sender, EventArgs e)
        {
            enableButtons(false);
            BindGridView(null);
        }

        private void BindGridView(String skey)
        {
            try
            {
                String query;
                if (string.IsNullOrWhiteSpace(skey))
                    query = "SELECT rtid AS ID, name AS Name, description AS Description, charges AS Charges FROM repair_types";
                else
                    query = "SELECT rtid AS ID, name AS Name, description AS Description, charges AS Charges FROM repair_types WHERE name LIKE '%" + skey + "%'";

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

        public void SetGridViewWidth()
        {
            bunifuCustomDataGrid1.Columns[0].Width = 50;
            bunifuCustomDataGrid1.Columns[1].Width = 250;
            bunifuCustomDataGrid1.Columns[2].Width = 400;
            bunifuCustomDataGrid1.Columns[3].Width = 80;

        }

        private void btnAddRepairType_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxRepairTypeName.Text) || 
                string.IsNullOrWhiteSpace(tbxDesc.Text) || 
                string.IsNullOrWhiteSpace(tbxCharges.Text))
            {
                MyDialog.Show("Error...!", "Please fill all fields");
            }
            else
            {
                if (Validator.IsValidName(tbxRepairTypeName.Text))
                {
                    if (Validator.IsValidCharges(tbxCharges.Text))
                        addNewRepairType();
                    else
                        MyDialog.Show("Error...!", "Invalid charges");
                }
                else
                {
                    MyDialog.Show("Error...!", "Repair Type Name is invalid");
                }
            }
        }

        private void addNewRepairType()
        {
            string query = "INSERT INTO repair_types VALUES('" + tbxRepairTypeName.Text + "','" + tbxDesc.Text + "','" + tbxCharges.Text + "')";
            Database db = new Database();
            db.sqlQuery(query);
            if (db.nonQuery())
            {
                MyDialog.Show("Success...!", "New Repair Type Added");
                resetFields();
                BindGridView(null);
            }
            else
            {
                MyDialog.Show("Error...!", "Fail to create new repair type");
            }
            db.getConnection().Close();
        }

        private void resetFields()
        {
            try
            {
                bunifuCustomDataGrid1.ClearSelection();
            }catch(Exception e)
            {
                Console.Write(e.Message);
            }
            tbxRepairTypeName.Text = string.Empty;
            tbxDesc.Text = string.Empty;
            tbxCharges.Text = string.Empty;
            enableButtons(false);
        }

        private void enableButtons(bool b)
        {
            btnRemove.Enabled = b;
            btnUpdate.Enabled = b;
            btnAddRepairType.Enabled = !b;

            btnAddRepairType.Cursor = (!b) ? Cursors.Hand : Cursors.Default;
            btnRemove.Cursor = (b) ? Cursors.Hand : Cursors.Default;
            btnUpdate.Cursor = (b) ? Cursors.Hand : Cursors.Default;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        private void bunifuCustomDataGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            loadTexts(selectedRow);
            enableButtons(true);
        }

        public void loadTexts(DataGridViewRow selectedRow)
        {
            tbxRepairTypeName.Text = Convert.ToString(selectedRow.Cells[1].Value);
            tbxDesc.Text = Convert.ToString(selectedRow.Cells[2].Value);
            tbxCharges.Text = Convert.ToString(selectedRow.Cells[3].Value);
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
                string query = "DELETE FROM repair_types WHERE rtid = '" + id + "'";
                Database db = new Database();
                db.sqlQuery(query);
                db.nonQuery();
                db.getConnection().Close();
                BindGridView(null);
                resetFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            String id = Convert.ToString(selectedRow.Cells[0].Value);

            if (Validator.IsValidName(tbxRepairTypeName.Text))
            {
                if (Validator.IsValidCharges(tbxCharges.Text))
                {
                    string query = "UPDATE repair_types SET name = '" + tbxRepairTypeName.Text + "', description = '" + tbxDesc.Text + "', charges = '" + tbxCharges.Text + "' WHERE rtid = '" + id + "'";
                    Database db = new Database();
                    db.sqlQuery(query);
                    if (db.nonQuery())
                    {
                        MyDialog.Show("Success...!", "Repair Type Updated");
                        BindGridView(null);
                        resetFields();
                    }
                    else
                    {
                        MyDialog.Show("Error...!", "Fail to update repair type");
                    }
                    db.getConnection().Close();
                }
                else
                    MyDialog.Show("Error...!", "Invalid charges");
            }
            else
            {
                MyDialog.Show("Error...!", "Repair Type Name is invalid");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BindGridView(tbxSearch.Text);
        }

        private void bunifuMaterialTextbox4_KeyUp(object sender, KeyEventArgs e)
        {
            BindGridView(tbxSearch.Text);
        }
    }
}

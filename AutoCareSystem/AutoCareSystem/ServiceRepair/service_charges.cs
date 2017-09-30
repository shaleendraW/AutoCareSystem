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
    public partial class service_charges : UserControl
    {
        public service_charges()
        {
            InitializeComponent();
        }

        private void service_charges_Load(object sender, EventArgs e)
        {
            BindGridView(null);
            tbxServiceName.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Cursor = Cursors.Default;
        }

        private void BindGridView(String skey)
        {
            try
            {
                String query;
                if (string.IsNullOrWhiteSpace(skey))
                    query = "SELECT stid AS ID, name AS Name,description AS Description, charges AS Charges FROM service_types";
                else
                    query = "SELECT stid AS ID, name AS Name,description AS Description, charges AS Charges FROM service_types WHERE name LIKE '%" + skey + "%'";

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
            bunifuCustomDataGrid1.Columns[0].Width = 30;
            bunifuCustomDataGrid1.Columns[1].Width = 200;
            bunifuCustomDataGrid1.Columns[2].Width = 300;
            bunifuCustomDataGrid1.Columns[3].Width = 80;
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnUpdate.Cursor = Cursors.Hand;
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            tbxServiceName.Text = Convert.ToString(selectedRow.Cells[1].Value);
            tbxCharges.Text = Convert.ToString(selectedRow.Cells[3].Value);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            string id = Convert.ToString(selectedRow.Cells[0].Value);
            string charges = tbxCharges.Text;
            if (Validator.IsValidCharges(charges))
            {
                string query = "UPDATE service_types SET charges = '" + charges + "' WHERE stid = '" + id + "'";
                Database db = new Database();
                db.sqlQuery(query);
                if (db.nonQuery())
                {
                    MyDialog.Show("Success...!", "Service Charges updated");
                    BindGridView(null);
                    resetFields();
                }
                else
                {
                    MyDialog.Show("Error...!", "Service Charges not updated");
                }
                db.getConnection().Close();  
            }
            else
            {
                MyDialog.Show("Error...!", "Invalid Charges");
            }
        }

        private void resetFields()
        {
            btnUpdate.Enabled = false;
            btnUpdate.Cursor = Cursors.Default;
            tbxServiceName.Text = String.Empty;
            tbxCharges.Text = String.Empty;
            bunifuCustomDataGrid1.ClearSelection();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BindGridView(tbxSearch.Text);
        }

        private void tbxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            BindGridView(tbxSearch.Text);
        }
    }
}

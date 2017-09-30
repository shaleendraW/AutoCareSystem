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
    public partial class service_details : UserControl
    {

        public service_details()
        {
            InitializeComponent();
        }

        private void service_details_Load(object sender, EventArgs e)
        {
            btnRemove.Enabled = false;
            btnRemove.Cursor = Cursors.Default;
            BindGridView(null);
        }

        private void BindGridView(String skey)
        {
            try
            {
                String query;
                if (string.IsNullOrWhiteSpace(skey))
                    query = "SELECT s.s_code AS ID, v.vehicle_number AS 'Vehicle Number', s.odo_meter AS 'ODO Meter', s.enter_date AS 'Service Date', s.next_date AS 'Next Date' FROM services s LEFT OUTER JOIN vehicles v ON s.v_code = v.v_code";
                else
                    query = "SELECT s.s_code AS ID, v.vehicle_number AS 'Vehicle Number', s.odo_meter AS 'ODO Meter', s.enter_date AS 'Service Date', s.next_date AS 'Next Date' FROM services s LEFT OUTER JOIN vehicles v ON s.v_code = v.v_code WHERE v.vehicle_number LIKE '%" + skey + "%'";


                Database db = new Database();
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

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRemove.Enabled = true;
            btnRemove.Cursor = Cursors.Hand;
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            lblVehicleNo.Text = Convert.ToString(selectedRow.Cells[1].Value);
            loadProvidedServices(Convert.ToString(selectedRow.Cells[0].Value));
        }

        private void loadProvidedServices(String s_code)
        {
            try
            {
                Database db = new Database();
                string query = "SELECT st.name,ps.charges FROM provided_services ps LEFT OUTER JOIN service_types st ON ps.stid = st.stid WHERE ps.s_code = '" + s_code + "'";
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                bunifuCustomDataGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bunifuCustomDataGrid2.DataSource = dt;
                db.getConnection().Close();
                lblTotalServices.Text = bunifuCustomDataGrid2.Rows.Count.ToString();
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
                string query = "DELETE FROM services WHERE s_code = '" + id + "'";
                Database db = new Database();
                db.sqlQuery(query);     //pass query to sql query method 
                db.nonQuery();          //pass the cmd to nonQuery method(for Insert)
                db.getConnection().Close();
                BindGridView(null);         //reload table
                bunifuCustomDataGrid2.DataSource = null;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(Validator.IsValidVehicleNumber(tbxSearch.Text))
                BindGridView(tbxSearch.Text);
            else
                MyDialog.Show("Error...!", "Invalid Vehicle Number");
        }

        private void bunifuMaterialTextbox1_KeyUp(object sender, KeyEventArgs e)
        {
            BindGridView(tbxSearch.Text);
        }

        private void tbxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void service_details_DoubleClick(object sender, EventArgs e)
        {
            BindGridView(null);
        }
    }
}

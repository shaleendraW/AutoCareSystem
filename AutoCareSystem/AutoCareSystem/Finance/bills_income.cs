using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AutoCareSystem
{
    public partial class bills_income : UserControl
    {
        public bills_income()
        {
            InitializeComponent();
            bunifuCustomDataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bunifuCustomDataGrid1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cmb_source.SelectedIndex = 5;

            string query = "SELECT CONCAT('IN000', i_id) AS 'Income ID', CONCAT('C000', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_id BETWEEN 0 AND 9 UNION SELECT CONCAT('IN00', i_id) AS 'Income ID', CONCAT('C00', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_id BETWEEN 10 AND 99 UNION SELECT CONCAT('IN0', i_id) AS 'Income ID', CONCAT('C0', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_id BETWEEN 100 AND 999 UNION SELECT CONCAT('IN', i_id) AS 'Income ID', CONCAT('C', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_id BETWEEN 1000 AND 9999";
            BindGridView(query);
        }

        public void BindGridView(string query)
        {
            try
            {
                Database db = new Database();
                SqlConnection conn = db.getConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = table;
                bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bunifuCustomDataGrid1.DataSource = bsource;
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
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
        }

        private void cmb_source_SelectedIndexChanged(object sender, EventArgs e)
        {
            string source = cmb_source.Text;

            switch (source)
            {
                case "All Sources":
                    BindGridView("SELECT CONCAT('IN000', i_id) AS 'Income ID', CONCAT('C000', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_id BETWEEN 0 AND 9 UNION SELECT CONCAT('IN00', i_id) AS 'Income ID', CONCAT('C00', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_id BETWEEN 10 AND 99 UNION SELECT CONCAT('IN0', i_id) AS 'Income ID', CONCAT('C0', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_id BETWEEN 100 AND 999 UNION SELECT CONCAT('IN', i_id) AS 'Income ID', CONCAT('C', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_id BETWEEN 1000 AND 9999");
                    break;
                case "Sales Outlet":
                    BindGridView("SELECT CONCAT('IN000', i_id) AS 'Income ID', CONCAT('C000', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 0 AND 9 UNION SELECT CONCAT('IN00', i_id) AS 'Income ID', CONCAT('C00', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 10 AND 99 UNION SELECT CONCAT('IN0', i_id) AS 'Income ID', CONCAT('C0', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 100 AND 999 UNION SELECT CONCAT('IN', i_id) AS 'Income ID', CONCAT('C', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 1000 AND 9999");
                    break;
                case "Service":
                    BindGridView("SELECT CONCAT('IN000', i_id) AS 'Income ID', CONCAT('C000', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 0 AND 9 UNION SELECT CONCAT('IN00', i_id) AS 'Income ID', CONCAT('C00', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 10 AND 99 UNION SELECT CONCAT('IN0', i_id) AS 'Income ID', CONCAT('C0', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 100 AND 999 UNION SELECT CONCAT('IN', i_id) AS 'Income ID', CONCAT('C', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 1000 AND 9999");
                    break;
                case "Repair":
                    BindGridView("SELECT CONCAT('IN000', i_id) AS 'Income ID', CONCAT('C000', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 0 AND 9 UNION SELECT CONCAT('IN00', i_id) AS 'Income ID', CONCAT('C00', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 10 AND 99 UNION SELECT CONCAT('IN0', i_id) AS 'Income ID', CONCAT('C0', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 100 AND 999 UNION SELECT CONCAT('IN', i_id) AS 'Income ID', CONCAT('C', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 1000 AND 9999");
                    break;
                case "Rental Service":
                    BindGridView("SELECT CONCAT('IN000', i_id) AS 'Income ID', CONCAT('C000', i_cus_id) AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 0 AND 9 UNION SELECT CONCAT('IN00', i_id) AS 'Income ID', CONCAT('C00', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 10 AND 99 UNION SELECT CONCAT('IN0', i_id) AS 'Income ID', CONCAT('C0', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 100 AND 999 UNION SELECT CONCAT('IN', i_id) AS 'Income ID', CONCAT('C', i_cus_id)  AS 'Customer ID', i_cus_name AS 'Customer Name', i_amount AS 'Amount', i_type AS 'Source', i_date AS 'Date' FROM income WHERE i_type = '" + source + "' AND i_id BETWEEN 1000 AND 9999");
                    break;
            }
        }
    }
}

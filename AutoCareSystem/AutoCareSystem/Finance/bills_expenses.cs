using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AutoCareSystem
{
    public partial class bills_expenses : UserControl
    {
        

        public bills_expenses()
        {
            InitializeComponent();
            bunifuCustomDataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bunifuCustomDataGrid1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cmb_source.SelectedIndex = 4;
            
            string query = "SELECT CONCAT('EX000', e_id) AS 'Expenses ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_id BETWEEN 0 AND 9 UNION SELECT CONCAT('EX00', e_id) AS 'Expenses ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_id BETWEEN 10 AND 99 UNION SELECT CONCAT('EX0', e_id) AS 'Expenses ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_id BETWEEN 100 AND 999 UNION SELECT CONCAT('EX', e_id) AS 'Expenses ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_id BETWEEN 1000 AND 9999";
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
                    BindGridView("SELECT CONCAT('EX000', e_id) AS 'Expenses ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_id BETWEEN 0 AND 9 UNION SELECT CONCAT('EX00', e_id) AS 'Expenses ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_id BETWEEN 10 AND 99 UNION SELECT CONCAT('EX0', e_id) AS 'Expenses ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_id BETWEEN 100 AND 999 UNION SELECT CONCAT('EX', e_id) AS 'Expenses ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_id BETWEEN 1000 AND 9999");
                    break;
                case "Maintenance":
                    BindGridView("SELECT  CONCAT('EX000', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Maintenance' AND e_id BETWEEN 0 AND 9 UNION SELECT CONCAT('EX00', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Maintenance' AND e_id BETWEEN 10 AND 99 UNION SELECT CONCAT('EX0', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Maintenance' AND e_id BETWEEN 100 AND 999 UNION SELECT CONCAT('EX', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Maintenance' AND e_id BETWEEN 1000 AND 9999");
                    break;
                case "Other":
                    BindGridView("SELECT  CONCAT('EX000', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Other' AND e_id BETWEEN 0 AND 9 UNION SELECT CONCAT('EX00', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Other' AND e_id BETWEEN 10 AND 99 UNION SELECT CONCAT('EX0', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Other' AND e_id BETWEEN 100 AND 999 UNION SELECT CONCAT('EX', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Other' AND e_id BETWEEN 1000 AND 9999");
                    break;
                case "Order":
                    BindGridView("SELECT  CONCAT('EX000', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Order' AND e_id BETWEEN 0 AND 9 UNION SELECT CONCAT('EX00', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Order' AND e_id BETWEEN 10 AND 99 UNION SELECT CONCAT('EX0', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Order' AND e_id BETWEEN 100 AND 999 UNION SELECT CONCAT('EX', e_id) AS 'Expense ID', e_amount AS 'Amount', e_type AS 'Type', e_date AS 'Date' FROM expenses WHERE e_type = 'Order' AND e_id BETWEEN 1000 AND 9999");
                    break;
            }
        }
    }
}

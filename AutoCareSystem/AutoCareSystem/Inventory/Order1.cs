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
    public partial class Order1 : UserControl
    {
        public Order1()
        {
            InitializeComponent();
        }

        private void Order1_Load(object sender, EventArgs e)
        {
            initialization();
            BindGridView(null);

            rbReceived.Checked = false;
            rbNotReceived.Checked = false;
            rbReceived.Enabled = false;
            rbNotReceived.Enabled = false;
            btnUpdate.Enabled = false;

        }

        private void initialization()
        {
            //code here
        }

        private void BindGridView(String skey)
        {
            try
            {
                String query;
                if (string.IsNullOrWhiteSpace(skey))
                    query = "SELECT o.order_code  AS 'Order Code' ,s.full_name AS 'Supplier Name', o.order_date AS 'Order Date', o.status AS 'Status ' FROM orders o LEFT OUTER JOIN suppliers s ON s.sup_code  = o.sup_code";
                else
                    query = "SELECT o.order_code  AS 'Order Code' ,s.full_name AS 'Supplier Name', o.order_date AS 'Order Date', o.status  AS 'Status ' FROM orders o LEFT OUTER JOIN suppliers s ON s.sup_code  = o.sup_code  WHERE  o.order_code LIKE '%" + skey + "%'";

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

        private void bunifuCustomDataGrid1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRemove.Enabled = true;
            btnRemove.Cursor = Cursors.Hand;
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            loadOrderedItems(Convert.ToString(selectedRow.Cells[0].Value));
            if (Convert.ToString(selectedRow.Cells[3].Value) == "Received")
            {
                rbReceived.Enabled = false;
                rbNotReceived.Enabled = false;
                rbReceived.Checked = true;
                rbNotReceived.Checked = false;
                btnUpdate.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
                rbReceived.Enabled = true;
                rbNotReceived.Enabled = true;
                rbReceived.Checked = false;
                rbNotReceived.Checked = true;
            }
        }

        private void loadOrderedItems(String id)
        {
            try
            {
                Database db = new Database();
                string query = "SELECT st.item_code AS 'Item Code', st.name AS 'Item Name', oi.quantity AS Quantity , oi.amount AS 'Amount(Rs.)' FROM ordered_items oi LEFT OUTER JOIN stocks st ON oi.item_code  = st.item_code  WHERE oi.order_code = '" + id + "'";
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

        private void tbxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            BindGridView(tbxSearch.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            String order_code = Convert.ToString(selectedRow.Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM orders WHERE order_code = '" + order_code + "'";
                Database db = new Database();
                db.sqlQuery(query);     //pass query to sql query method 
                db.nonQuery();          //pass the cmd to nonQuery method(for Insert)
                db.getConnection().Close();
                BindGridView(null);         //reload table
                bunifuCustomDataGrid1.DataSource = null;
            }
        }
       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            String status = (rbReceived.Checked) ? "Received" : "Not Received";
            String order_code = Convert.ToString(selectedRow.Cells[0].Value);

            Database db = new Database();
            String query01 = "UPDATE orders SET status = '" + status + "' WHERE order_code = '" + order_code + "'";
            db.sqlQuery(query01);
            if (db.nonQuery())
            {
                String query02 = "SELECT * FROM ordered_items WHERE order_code = '" + order_code + "'";
                db.sqlQuery(query02);
                DataTable dt = db.executeQuery();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        String item_code = Convert.ToString(row["item_code"]);
                        String quantity = Convert.ToString(row["quantity"]);
                        int balanced_count = checkForReturn(item_code, Convert.ToInt32(quantity));
                        if (balanced_count != 0)
                        {
                            int new_quantity = balanced_count + getCurrentQty(item_code);
                            String query03 = "UPDATE stocks SET quantity = '" + new_quantity + "' WHERE item_code = '" + item_code + "'";
                            db.sqlQuery(query03);
                            db.nonQuery();
                        }
                    }

                }
                BindGridView(null);
                MyDialog.Show("Success...!", "Order Received Status Updated ");
            }
            else
            {
                MyDialog.Show("Error...!", "Order Status Not Updated");
            }

            db.getConnection().Close();
        }

        private int getCurrentQty(string item_code)
        {
            String query = "SELECT quantity FROM stocks WHERE item_code = '" + item_code + "'";
            Database db = new Database();
            db.sqlQuery(query);
            return Convert.ToInt32(db.executeQuery("quantity"));
        }

        private int checkForReturn(string item_code, int quantity)
        {
            String new_count = "0";
            int return_value = 0;
            String query = "SELECT quantity FROM return_items WHERE stock_id = '" + item_code + "'";
            Database db = new Database();
            db.sqlQuery(query);
            int return_count = Convert.ToInt32(db.executeQuery("quantity"));
            if (return_count < quantity)
            {
                new_count = "0";
                return_value = (quantity - return_count);
            }
            else
            {
                new_count = Convert.ToString(return_count - quantity);
                return_value = 0;
            }
            String query01 = "UPDATE return_items SET quantity = '" + new_count + "' WHERE stock_id = '" + item_code + "'";
            db.sqlQuery(query01);
            db.nonQuery();
            db.getConnection().Close();
            return return_value;
        }

        private void Order1_DoubleClick(object sender, EventArgs e)
        {
            BindGridView(null);
        }
    }
}

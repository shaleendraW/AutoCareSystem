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
    public partial class Order2 : UserControl
    {
        private string item_name;

        public Order2()
        {
            InitializeComponent();
        }



        private void BindGridView()
        {
            try
            {
                Database db = new Database();
                string query = "SELECT TOP 12 item_code AS 'Item Code',type AS 'Type' ,name AS 'Name' ,brand AS 'Brand' ,quantity AS Quantity FROM stocks WHERE quantity < 3";

                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bunifuCustomDataGrid1.DataSource = dt;
                db.getConnection().Close();
                //calculateTotal(dt);


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

        public void loadTexts(DataGridViewRow selectedRow)
        {
            tbxCode.Text = Convert.ToString(selectedRow.Cells[0].Value);
            lblName.Text = Convert.ToString(selectedRow.Cells[1].Value);
        }

        private void Order2_Load(object sender, EventArgs e)
        {
            BindGridView();
            setSupplierName();

            enableFields(false);
            btnPrint.Enabled = false;
            btnPrint.Cursor = Cursors.Default;
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuCustomDataGrid1.SelectedCells.Count > 0)
            {
                int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

                loadTexts(selectedRow);
                enableFields(true);

            }
        }

        private void enableFields(bool b)
        {
            btnAdd.Enabled = b;
            btnAdd.Cursor = (b) ? Cursors.Hand : Cursors.Default;

            tbxQty.Enabled = b;
            tbxPrice.Enabled = b;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            if (tbxQty.Text.Length > 0 && tbxPrice.Text.Length > 0)
            {
                if (Validator.IsValidNumber(tbxQty.Text))
                {
                    if (Validator.IsValidPrice(tbxPrice.Text))
                    {

                        string code = tbxCode.Text;
                        int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
                        string name = (item_name != null) ? item_name : Convert.ToString(selectedRow.Cells[2].Value);
                        string qty = tbxQty.Text;
                        string price = tbxPrice.Text;
                        string[] row = { code, name, qty, price };
                        bunifuCustomDataGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        bunifuCustomDataGrid2.Rows.Add(row);
                        item_name = null;
                    }
                    else
                    {
                        MyDialog.Show("Error...!", "Invalid Price");
                    }
                }
                else
                {
                    MyDialog.Show("Error...!", "Invalid Quantity");
                }
            }
            else
            {
                MyDialog.Show("Error..!", "Price  && Quantity Required");
            }
        }
        
        private void setSupplierName()
        {
            try
            {
                string query = "SELECT sup_code ,full_name  FROM suppliers";
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();

                Dictionary<string, string> comboSource = new Dictionary<string, string>();

                foreach (DataRow row in dt.Rows)
                {
                    String id = Convert.ToString(row["sup_code"]);
                    String name = Convert.ToString(row["full_name"]);

                    comboSource.Add(id, name);
                }

                cmbSup.DataSource = new BindingSource(comboSource, null);
                cmbSup.DisplayMember = "Value";
                cmbSup.ValueMember = "Key";
                //enableButtons(false);
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = bunifuCustomDataGrid2.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                bunifuCustomDataGrid2.Rows.RemoveAt(bunifuCustomDataGrid2.CurrentCell.RowIndex);
            }
            else
            {
                changeSubButtons();
            }
        }

        private void tbxCode_KeyUp(object sender, KeyEventArgs e)
        {
            checkForItemCode(tbxCode.Text);
        }

        private void checkForItemCode(String skey)
        {
            try
            {
                String query = "SELECT * FROM stocks WHERE item_code = '" + skey + "'";
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                if (dt != null && dt.Rows.Count == 1)
                {
                    item_name = Convert.ToString(dt.Rows[0]["name"]);
                    lblName.Text = item_name;
                    enableFields(true);
                }
                else
                {
                    item_name = null;
                    lblName.Text = String.Empty;
                    enableFields(false);
                }
                db.getConnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void calculateTotal()
        {
            double charges = 0;
            foreach (DataGridViewRow row in bunifuCustomDataGrid2.Rows)
            {
                charges = charges + (Convert.ToInt32(row.Cells[2].Value) * Convert.ToDouble(row.Cells[3].Value));
            }

            lblTotalAmount.Text = charges.ToString("0.######");
        }


        private void bunifuCustomDataGrid2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            changeSubButtons();
            calculateTotal();
        }

        private void changeSubButtons()
        {
            btnPrint.Enabled = (bunifuCustomDataGrid2.Rows.Count > 0);
            btnPrint.Cursor = ((bunifuCustomDataGrid2.Rows.Count > 0) ? Cursors.Hand : Cursors.Default);
            btnRemove.Enabled = (bunifuCustomDataGrid2.Rows.Count > 0);
            btnRemove.Cursor = ((bunifuCustomDataGrid2.Rows.Count > 0) ? Cursors.Hand : Cursors.Default);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sup_code = ((KeyValuePair<string, string>)cmbSup.SelectedItem).Key;
            String order_date = orderDate.Value.ToString("yyyy-MM-dd");
            String order_code = CodeGenerator.generateOrderCode();
            if (Validator.IsValidPastDate(order_date))
            {
                string query = "INSERT INTO orders VALUES('" + order_code + "','" + sup_code + "','" + order_date + "','Not Received','" + DateTime.Now + "')";
                Database db = new Database();
                db.sqlQuery(query);
                if (db.nonQuery())
                {
                    MyDialog.Show("Success...!", "Order Registered");
                    addOrderItems();
                }
                else
                {
                    MyDialog.Show("Error...!", "Order Not Registered");
                }
            }
            else
            {
                MyDialog.Show("Error...!", "Invalid Order date");
            }
        }

        private void addOrderItems()
        {
            String order_code = Database.getLastInsertId("orders", "order_code");

            Database db = new Database();
            foreach (DataGridViewRow row in bunifuCustomDataGrid2.Rows)
            {
                String item_code = Convert.ToString(row.Cells[0].Value);
                if (!isOrderItemExists(order_code, item_code))
                {
                    String query = "INSERT INTO ordered_items VALUES('" + order_code + "','" + item_code + "','" + tbxQty.Text + "','" + tbxPrice.Text + "')";
                    db.sqlQuery(query);
                    db.nonQuery();
                }
            }

            db.getConnection().Close();
        }

        private bool isOrderItemExists(string order_code, string item_code)
        {
            try
            {
                String query = "SELECT * FROM ordered_items WHERE order_code = '" + order_code + "' AND item_code = '" + item_code + "'";
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                db.getConnection().Close();
                return (dt != null && dt.Rows.Count == 1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void cmbSup_Click(object sender, EventArgs e)
        {
            setSupplierName();
        }
    }
    
}

    
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoCareSystem;
using System.Data.SqlClient;
  
namespace AutoCareSystem
{
    public partial class Stock_Handle : UserControl
    {
       

        public Stock_Handle()
        {
            InitializeComponent();

        } 

     
        private void setSupplierName()
        {
            try {
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
                enableButtons(false);
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void enableButtons(bool b)
        {
            btnRemove.Enabled = b;
            btnUpdate.Enabled = b;
            btnAdd.Enabled = !b;

            btnAdd.Cursor = (!b) ? Cursors.Hand : Cursors.Default;
            btnRemove.Cursor = (b) ? Cursors.Hand : Cursors.Default;
            btnUpdate.Cursor = (b) ? Cursors.Hand : Cursors.Default;

        }
      
        private void BindGridView(String skey)
        {
            try
            {
                String query;
                if (string.IsNullOrWhiteSpace(skey))
                    query = "SELECT st.item_code AS ID, st.name AS Name, s.full_name AS 'Supplier Name', st.type AS Type , st.brand AS Brand , st.unit_price AS 'Price(Rs.)', st.quantity AS Quantity , st.description AS Description FROM stocks st LEFT OUTER JOIN suppliers s ON st.sup_code  = s.sup_code ";
                else
                    query = "SELECT st.item_code AS ID, st.name AS Name, s.full_name AS 'Supplier Name', st.type AS Type , st.brand AS Brand , st.unit_price AS 'Price(Rs.)', st.quantity AS Quantity , st.description AS Description FROM stocks st LEFT OUTER JOIN suppliers s ON st.sup_code  = s.sup_code  WHERE st.type LIKE '%" + skey + "%'";

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


        private void addNewItem()
        {
           
            string key = ((KeyValuePair<string, string>)cmbSup.SelectedItem).Key;
            string type =   cmbType.Text;
            String item_code = CodeGenerator.generateItemCode();

            string query = "INSERT INTO stocks VALUES('" + item_code + "','" + key + "','" + type + "','" + txtName.Text + "','" + txtBrand.Text + "','" + txtDescription.Text + "','" + txtQty.Text + "','" + txtPrice.Text + "','" + DateTime.Now + "')";
            Database db = new Database();
            db.sqlQuery(query);
            if (db.nonQuery())
            {
                MyDialog.Show("Success...!", "Item Registered :)");
                resetFields();
                BindGridView("");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtName.Text) ||
                 String.IsNullOrWhiteSpace(txtBrand.Text) ||
                 String.IsNullOrWhiteSpace(txtPrice.Text) ||
                 String.IsNullOrWhiteSpace(txtQty.Text) ||
                 String.IsNullOrWhiteSpace(txtDescription.Text))

                MyDialog.Show("Error...!", "Please fill all fields");

            else
            {
                
                    if (Validator.IsValidNumber(txtQty.Text))
                    {

                        if (Validator.IsValidPrice(txtPrice.Text))
                         {

                             addNewItem();
    
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
        }

        public void loadTexts(DataGridViewRow selectedRow)
        {
            txtName.Text = Convert.ToString(selectedRow.Cells[1].Value);
            txtBrand.Text = Convert.ToString(selectedRow.Cells[4].Value);
            txtPrice.Text = Convert.ToString(selectedRow.Cells[5].Value);
            txtQty.Text = Convert.ToString(selectedRow.Cells[6].Value);
            txtDescription.Text = Convert.ToString(selectedRow.Cells[7].Value);

            int index = cmbSup.FindString(Convert.ToString(selectedRow.Cells[2].Value));
            cmbSup.SelectedIndex = index;
            int index1 = cmbType.FindString(Convert.ToString(selectedRow.Cells[3].Value));
            cmbType.SelectedIndex = index1;


        }

        private void resetFields()
        {
          
            cmbType.ResetText();
            cmbSup.ResetText();
            txtName.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtDescription.Text = string.Empty;
            bunifuCustomDataGrid1.ClearSelection();
            enableButtons(false);
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
                string query = "DELETE FROM stocks WHERE item_code  = '" + id + "'";
                Database db = new Database();
                db.sqlQuery(query);     //pass query to sql query method 
                db.nonQuery();          //pass the cmd to nonQuery method(for Insert)
                db.getConnection().Close();
                BindGridView(null);         //reload table
                resetFields();          //reset all input fields
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            String id = Convert.ToString(selectedRow.Cells[0].Value);
            String type = cmbType.SelectedItem.ToString();
            String sup_name = cmbSup.SelectedItem.ToString();
            string name = txtName.Text;
            string brand = txtBrand.Text;
            string price = txtPrice.Text;
            string qty = txtQty.Text;
            string description = txtDescription.Text;

            if (Validator.IsValidNumber(txtQty.Text))
            {

                if (Validator.IsValidPrice(txtPrice.Text))
                {

                    string query = "UPDATE stocks SET name = '" + name + "',type = '" + type + "', brand  = '" + brand + "', unit_price  = '" + price + "', quantity  = '" + qty + "',description = '" + description + "' WHERE item_code  = '" + id + "'";
                    Database db = new Database();
                    db.sqlQuery(query);
                    db.nonQuery();
                    db.getConnection().Close();
                    BindGridView(null);
                    resetFields();
                    MyDialog.Show("Success...!", "Stock Updated Successfully");
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

       

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuCustomDataGrid1.SelectedCells.Count > 0)
            {
                int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

                loadTexts(selectedRow);
                enableButtons(true);

            }
        }



        private void Stock_Handle_Load(object sender, EventArgs e)
        {
            
            //setTypes();
            setSupplierName();
            BindGridView(null);
            enableButtons(false);
        }

        private void tbxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            BindGridView(tbxSearch.Text);
        }


    }
}
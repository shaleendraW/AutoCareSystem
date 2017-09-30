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
    public partial class Supplier_Handle : UserControl
    {
        

        public Supplier_Handle()
        {
            InitializeComponent();
            
        }

        private void Supplier_Handle_Load(object sender, EventArgs e)
        {
            
            BindGridView(null);
            enableButtons(false);
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
                    query = "SELECT sup_code  AS ID, full_name AS Name, address_1 AS 'Address 1' , address_2 AS 'Address 2', phone AS 'Phone Number' ,email AS Email FROM Suppliers";
                else
                    query = "SELECT sup_code  AS ID, full_name AS Name, address_1 AS 'Address 1' , address_2 AS 'Address 2', phone AS 'Phone Number' ,email AS Email FROM Suppliers WHERE full_name LIKE '%" + skey + "%'";

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


        private void addNewSupplier()
        {

            String sup_code = CodeGenerator.generateSupplierCode();
            string query = "INSERT INTO suppliers VALUES('" + sup_code + "','" + txtSupName.Text + "','" + txtAddress1.Text + "','" + txtAddress2.Text + "','" + txtphone.Text + "','" + txtEmail.Text + "','" + DateTime.Now + "')";
            Database db = new Database();
            db.sqlQuery(query);
            if (db.nonQuery())
            {
                MyDialog.Show("Success...!", "Supplier Registered");
                resetFields();
                BindGridView("");
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSupName.Text) ||
                 String.IsNullOrWhiteSpace(txtAddress1.Text) ||
                 String.IsNullOrWhiteSpace(txtAddress2.Text) ||
                 String.IsNullOrWhiteSpace(txtphone.Text) ||
                 String.IsNullOrWhiteSpace(txtEmail.Text))

                MyDialog.Show("Error...!", "Please fill all fields");

            else
            {
                if (Validator.IsValidName(txtSupName.Text))
                {
                    if (Validator.IsValidEmail(txtEmail.Text))
                    {
                        if (Validator.IsValidPhonenumber(txtphone.Text))
                        {
                            addNewSupplier();
                        }
                        else
                        {
                            MyDialog.Show("Error...!", "Invalid Telephone Number");
                        }
                    }
                    else
                    {
                        MyDialog.Show("Error...!", "Invalid Email Address");
                    }
                }
                else
                {
                    MyDialog.Show("Error...!", "Invalid Supplier Name");
                }


                
                
            } 
        }

        public void loadTexts(DataGridViewRow selectedRow)
        {
            txtSupName.Text = Convert.ToString(selectedRow.Cells[1].Value);
            txtAddress1.Text = Convert.ToString(selectedRow.Cells[2].Value);
            txtAddress2.Text = Convert.ToString(selectedRow.Cells[3].Value);
            txtphone.Text = Convert.ToString(selectedRow.Cells[4].Value);
            txtEmail.Text = Convert.ToString(selectedRow.Cells[5].Value);
           
            

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


        private void btnClear_Click(object sender, EventArgs e)
        {
            resetFields();
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
                string query = "DELETE FROM suppliers WHERE sup_code  = '" + id + "'";
                Database db = new Database();
                db.sqlQuery(query);     //pass query to sql query method 
                db.nonQuery();          //pass the cmd to nonQuery method(for Insert)
                db.getConnection().Close();
                BindGridView(null);         //reload table
                resetFields();          //reset all input fields
            }

        }


        private void resetFields()
        {
            txtSupName.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtphone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            bunifuCustomDataGrid1.ClearSelection();
            enableButtons(false);
        }

        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            String id = Convert.ToString(selectedRow.Cells[0].Value);
            string Name = txtSupName.Text;
            string address_1 = txtAddress1.Text;
            string address_2 = txtAddress2.Text;
            string phone_number = txtphone.Text;
            string email = txtEmail.Text;
            if (Validator.IsValidName(txtSupName.Text))
            {
                if (Validator.IsValidEmail(txtEmail.Text))
                {
                    if (Validator.IsValidPhonenumber(txtphone.Text))
                    {
                        string query = "UPDATE suppliers SET full_name   = '" + Name + "',  address_1  = '" + address_1 + "', address_2  = '" + address_2 + "', phone  = '" + phone_number + "', email = '" + email + "' WHERE sup_code  = '" + id + "'";
                        Database db = new Database();
                        db.sqlQuery(query);
                        db.nonQuery();
                        db.getConnection().Close();
                        BindGridView(null);
                        resetFields();


                        MyDialog.Show("Success...!", "Supplier Updated Successfully");
                    }
                    else
                    {
                        MyDialog.Show("Error...!", "Invalid Telephone Number");
                    }
                }
                else
                {
                    MyDialog.Show("Error...!", "Invalid Email Address");
                }
            }
            else
            {
                MyDialog.Show("Error...!", "Invalid Supplier Name");
            }
        }

       

        private void tbxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            BindGridView(tbxSearch.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Validator.IsValidName(tbxSearch.Text))
                BindGridView(tbxSearch.Text);
            else
                MyDialog.Show("Error...!", "Invalid Supplier Name");
        }
    }
}

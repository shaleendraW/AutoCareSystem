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
    public partial class Salesitemupdate : UserControl
    {
        public Salesitemupdate()
        {
            InitializeComponent();
            LodesalesGridView();
        }


        private void LodesalesGridView()
        {
            try
            {
                Database db = new Database();
                string query = "select sales_id AS'SalesID',item_id AS 'ItemID',cus_id AS 'CustomerID',cus_name AS'Name',cus_address AS 'Address',cus_telephone AS 'Telephone',quantity AS 'Quantity',total_price AS 'Total Price' ,discount AS 'Discount' ,price AS 'Unitprice' from Salesview";

                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                SalesdataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                SalesdataGrid.DataSource = dt;
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



        private void lodeGridViewforsalesbySearch(String searchkey)
        {
            try
            {
                Database db = new Database();
                string query = "select sales_id AS'SalesID',item_id AS 'ItemID',cus_id AS 'CustomerID',cus_name AS'Name',cus_address AS 'Address',cus_telephone AS 'Telephone',quantity AS 'Quantity',total_price AS 'Total Price' ,discount AS 'Discount' ,price AS 'Unitprice' from Salesview WHERE sales_id='" + searchkey + "'";

                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                SalesdataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                SalesdataGrid.DataSource = dt;
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


        private void resetFields()
        {
            try
            {
                SalesdataGrid.ClearSelection();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            Nametxt.Text = string.Empty;
            Quntitytxt.Text = string.Empty;
            Telephonetxt.Text = string.Empty;
            Addresstxt.Text= string.Empty;
            itemidtxt.Text = string.Empty;
             Discounttxt.Text = string.Empty;

        }




        private void SalesdataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int selectedrowindex = SalesdataGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = SalesdataGrid.Rows[selectedrowindex];

            itemidtxt.Text = Convert.ToString(selectedRow.Cells[1].Value);
            Nametxt.Text = Convert.ToString(selectedRow.Cells[3].Value);
            Addresstxt.Text = Convert.ToString(selectedRow.Cells[4].Value);
            Telephonetxt.Text = Convert.ToString(selectedRow.Cells[5].Value);
            Discounttxt.Text = Convert.ToString(selectedRow.Cells[8].Value);
            Quntitytxt.Text = Convert.ToString(selectedRow.Cells[6].Value);

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_serch.Text))
            {

                MyDialog.Show("Error...!", "Plese enter the ReciptNo");

            }
            else
            {
                string search;
                search = Convert.ToString(txt_serch.Text);
                lodeGridViewforsalesbySearch(search);
            }
        }

        private void btnRepairUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nametxt.Text) && string.IsNullOrWhiteSpace(Addresstxt.Text) && string.IsNullOrWhiteSpace(Quntitytxt.Text) && string.IsNullOrWhiteSpace(Telephonetxt.Text) && string.IsNullOrWhiteSpace(itemidtxt.Text))
            {
                MyDialog.Show("Error...!", "Plese fill all fields");
            }

            else
            {
                int selectedrowindex = SalesdataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = SalesdataGrid.Rows[selectedrowindex];

                string sid = Convert.ToString(selectedRow.Cells[0].Value);
                string Itemid = Convert.ToString(selectedRow.Cells[1].Value);
                string cusid = Convert.ToString(selectedRow.Cells[2].Value);
                float total = float.Parse((Convert.ToString(selectedRow.Cells[7].Value)));
                float Quntity = float.Parse((Convert.ToString(selectedRow.Cells[6].Value)));
                float unitprice = float.Parse((Convert.ToString(selectedRow.Cells[9].Value)));
                float discount = float.Parse((Convert.ToString(selectedRow.Cells[8].Value)));

                float tot = total - ((Quntity * unitprice) - discount);

                tot = tot + (((float.Parse(Quntitytxt.Text) * unitprice) - float.Parse(Discounttxt.Text)));


                string query = "UPDATE Salesview set cus_name='" + Nametxt + "' ,cus_address='" + Addresstxt.Text + "',cus_telephone = '" + Telephonetxt.Text + "',Quantity='" + Quntitytxt.Text + "',total_price ='" + tot + "' ,discount='" + Discounttxt.Text + "' where item_id ='" + Itemid + "' ";
                Database db = new Database();
                db.sqlQuery(query);
                if (db.nonQuery())
                {
                    MyDialog.Show("Success...!", "Sales Charges updated");
                    LodesalesGridView();
                    resetFields();

                }
                else
                {
                    MyDialog.Show("Error...!", "Sales Charges not updated");
                }
                db.getConnection().Close();

            }
        }

        private void btnRepairRemove_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(Nametxt.Text) && string.IsNullOrWhiteSpace(Addresstxt.Text) && string.IsNullOrWhiteSpace(Quntitytxt.Text) && string.IsNullOrWhiteSpace(Telephonetxt.Text) && string.IsNullOrWhiteSpace(itemidtxt.Text))
            {
                MyDialog.Show("Error...!", "Plese fill all fields");
            }

            else
            {
                int selectedrowindex = SalesdataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = SalesdataGrid.Rows[selectedrowindex];

                string sid = Convert.ToString(selectedRow.Cells[0].Value);
                string Itemid = Convert.ToString(selectedRow.Cells[1].Value);
                string cusid = Convert.ToString(selectedRow.Cells[2].Value);
                float total = float.Parse((Convert.ToString(selectedRow.Cells[7].Value)));
                float Quntity = float.Parse((Convert.ToString(selectedRow.Cells[6].Value)));
                float unitprice = float.Parse((Convert.ToString(selectedRow.Cells[9].Value)));
                float discount = float.Parse((Convert.ToString(selectedRow.Cells[8].Value)));


                float tot = total;

                var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                       "Confirm Delete!!",
                                       MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {

                    string query = "DELETE FROM Salesview WHERE item_id = '" + Itemid + "'";
                    Database db = new Database();
                    db.sqlQuery(query);
                    db.nonQuery();
                    db.getConnection().Close();
                    LodesalesGridView();
                    resetFields();
                    tot = total - Quntity * unitprice;

                }





                string query1 = "UPDATE Salesview set total_price ='" + tot + "' where item_id='" + Itemid + "' ";
                Database db1 = new Database();
                db1.sqlQuery(query1);
                if (db1.nonQuery())
                {
                    MyDialog.Show("Success...!", "Sales Charges updated");

                }
                else
                {
                    MyDialog.Show("Error...!", "Sales Charges not updated");
                }
                db1.getConnection().Close();

                LodesalesGridView();
                resetFields();




            }

        }

        private void btnRepairClear_Click(object sender, EventArgs e)
        {
            LodesalesGridView();
            resetFields();
        }

        private void Discounttxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back) || char.IsLetter(e.KeyChar);
        }

        private void Quntitytxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back) || char.IsLetter(e.KeyChar);
        }

        private void itemidtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back) || char.IsLetter(e.KeyChar);
        }

        private void Telephonetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back) || char.IsLetter(e.KeyChar);
        }

        private void Nametxt_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Nametxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) || char.IsNumber(e.KeyChar);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            new Sales_Bill().Show();
        }
    }
}

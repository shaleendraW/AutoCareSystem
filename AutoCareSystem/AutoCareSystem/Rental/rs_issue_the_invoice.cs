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
using System.Text.RegularExpressions;

namespace AutoCareSystem
{
    
    public partial class rs_issue_the_invoice : UserControl
    {
        
        public rs_issue_the_invoice()
        {
            InitializeComponent();

            loadData();


            bunifuCustomDataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bunifuCustomDataGrid1.ReadOnly = true;
            bunifuCustomDataGrid1.RowHeadersVisible = false;
            bunifuCustomDataGrid1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
        }

        public void loadData()
        {
            Database db = new Database();

            String q1 = "SELECT * FROM rental_invoice";
            db.sqlQuery(q1);
            DataTable dt = db.executeQuery();
            bunifuCustomDataGrid1.DataSource = dt;
            

            for (int i = 0; i < bunifuCustomDataGrid1.Columns.Count; i++)
            {
                bunifuCustomDataGrid1.Columns[i].Visible = false;
            }

            bunifuCustomDataGrid1.Columns[0].Visible = true;
            bunifuCustomDataGrid1.Columns[0].HeaderText = "Invoice ID";
            bunifuCustomDataGrid1.Columns[1].Visible = true;
            bunifuCustomDataGrid1.Columns[1].HeaderText = "Rent ID";
            bunifuCustomDataGrid1.Columns[2].Visible = true;
            bunifuCustomDataGrid1.Columns[2].HeaderText = "Issued Date";
            bunifuCustomDataGrid1.Columns[3].Visible = true;
            bunifuCustomDataGrid1.Columns[3].HeaderText = "Advanced Payment";

            btn_update.Visible = false;
            btn_remove.Visible = false;
            btn_add.Enabled = true;

            //get rent id  which not issued a bill, to combo box
            String q3 = "SELECT rnt_id FROM rental_details WHERE rnt_invoice_is_issued = 'no'";
            db.sqlQuery(q3);
            DataTable table1 = db.executeQuery();

            // select distinct valuves to the combo box
            IList<string> listName = new List<string>();
            foreach (DataRow dr in table1.Rows)
            {

                listName.Add("Rent ID");
                listName.Add(dr["rnt_id"].ToString());
            }

            listName = listName.Distinct().ToList();
            cmb_inv_rnt_id.DataSource = listName;


            db.getConnection().Close();

            clear();
            txt_inv_id.Text = CodeGenerator.generateRentalInvoiceCode();
            
        }
        

        private void search()
        {

            try
            {
                Database db = new Database();

                String q1 = "select* from rental_invoice where in_id like '%" + txt_search.Text + "%'";

                db.sqlQuery(q1);
                DataTable dt = db.executeQuery();
                bunifuCustomDataGrid1.DataSource = dt;
                db.getConnection().Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        public void clear()
        {
             txt_inv_id.Text = string.Empty;
             cmb_inv_rnt_id.Text = string.Empty;
             txt_search.Text = string.Empty;
             txt_inv_adv_payment.Text = string.Empty;
            datepicker_issueDate.Text = string.Empty;
            

        }

        private void btn_v_update_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                
                bool test = Validte_Data();
                if (test == true)
                {
                        if (datepicker_issueDate.Value.Date != DateTime.Today)
                        {
                            MyDialog.Show("Error...!", "Invoice Isuue Date Is Not Valid");
                        }
                        else
                        {
                            Database db = new Database();
                            string query = "INSERT INTO rental_invoice VALUES  ( '" + txt_inv_id.Text + "', '" + cmb_inv_rnt_id.Text + "', '" + datepicker_issueDate.Text + "','" + float.Parse(txt_inv_adv_payment.Text) + "' )";

                            db.sqlQuery(query);
                            db.nonQuery();

                            string query2 = "UPDATE rental_details SET rnt_invoice_is_issued = 'yes' Where rnt_id = '" + cmb_inv_rnt_id.Text + "'";
                            db.sqlQuery(query2);
                            db.nonQuery();

                            db.getConnection().Close();

                            loadData();

                            MyDialog.Show("Insert Successful..", "Invoice Was Successfully Added");
                        }


                    
                }
                

            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                

                bool test = Validte_Data();
                if (test == true)
                {
                    string query = "UPDATE rental_invoice SET in_rnt_id ='" + cmb_inv_rnt_id.Text + "',in_date ='" + datepicker_issueDate.Text + "', in_advanced_payment ='" + float.Parse(txt_inv_adv_payment.Text) + "' WHERE in_id = '" + txt_inv_id.Text + "' ";
                    Database db = new Database();
                    db.sqlQuery(query);
                    db.nonQuery();

                    string query2 = "UPDATE rental_details SET rnt_invoice_is_issued = 'yes' Where rnt_id = '" + cmb_inv_rnt_id.Text + "'";
                    db.sqlQuery(query2);
                    db.nonQuery();

                    db.getConnection().Close();

                    loadData();

                    MyDialog.Show("Update Successful..", "Invoice Record Successfully Updated");
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                string query = "DELETE FROM rental_invoice WHERE in_id = '" + txt_inv_id.Text + "' ";
                
                db.sqlQuery(query);
                
                if (MessageBox.Show("Delete?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //delete the item 
                    db.nonQuery();
                    MessageBox.Show("DELETE");
                }
                else
                {
                    //Cancel action 
                    MessageBox.Show("ABORT");
                }

                db.getConnection().Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            loadData();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Database db = new Database();

            //get all rent id's  to combo box
            String q3 = "SELECT rnt_id FROM rental_details ";
            db.sqlQuery(q3);
            DataTable table1 = db.executeQuery();

            // select distinct valuves to the combo box
            IList<string> listName = new List<string>();
            foreach (DataRow dr in table1.Rows)
            {

                listName.Add("Rent ID");
                listName.Add(dr["rnt_id"].ToString());
            }

            listName = listName.Distinct().ToList();
            cmb_inv_rnt_id.DataSource = listName;
            db.getConnection().Close();

            txt_inv_id.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            cmb_inv_rnt_id.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            datepicker_issueDate.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            txt_inv_adv_payment.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();

            btn_update.Visible = true;
            btn_remove.Visible = true;
            btn_add.Enabled = false;
        }

        private void bunifuCustomDataGrid1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rs_issue_the_invoice_Paint(object sender, PaintEventArgs e)
        {
            loadData();
        }

        private void txt_inv_adv_payment_OnValueChanged(object sender, EventArgs e)
        {

        }

        private bool Validte_Data()
        {
            Regex validate_float = new Regex("^[0-9]+(\\.[0-9][0-9]?)?$");


            if (!validate_float.IsMatch(txt_inv_adv_payment.Text))
            {
                MyDialog.Show("Error...!", "Invalid Advabced Payment");
            }
            else
            {
                return true;
            }
            return false;
        }

        private void cmb_inv_rnt_id_DropDown(object sender, EventArgs e)
        {
            Database db = new Database();

            //get rent id  which not issued a bill, to combo box
            String q3 = "SELECT rnt_id FROM rental_details WHERE rnt_invoice_is_issued = 'no'";
            db.sqlQuery(q3);
            DataTable table1 = db.executeQuery();

            // select distinct valuves to the combo box
            IList<string> listName = new List<string>();
            foreach (DataRow dr in table1.Rows)
            {

                listName.Add("Rent ID");
                listName.Add(dr["rnt_id"].ToString());
            }

            listName = listName.Distinct().ToList();
            cmb_inv_rnt_id.DataSource = listName;


            db.getConnection().Close();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            search();
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            search();
        }
    }
}

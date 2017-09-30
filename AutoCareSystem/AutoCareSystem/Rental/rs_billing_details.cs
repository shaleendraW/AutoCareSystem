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
    public partial class rs_billing_details : UserControl
    {
       
        

        public rs_billing_details()
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

        String q1 = "SELECT * FROM rental_bill_details";
        db.sqlQuery(q1);
        DataTable dt = db.executeQuery();
        bunifuCustomDataGrid1.DataSource = dt;
        db.getConnection().Close();

        for (int i = 0; i < bunifuCustomDataGrid1.Columns.Count; i++)
        {
            bunifuCustomDataGrid1.Columns[i].Visible = false;
        }
            try
            { 
                bunifuCustomDataGrid1.Columns[0].Visible = true;
                bunifuCustomDataGrid1.Columns[0].HeaderText = "Bill ID";
                bunifuCustomDataGrid1.Columns[1].Visible = true;
                bunifuCustomDataGrid1.Columns[1].HeaderText = "Rent ID";
                bunifuCustomDataGrid1.Columns[2].Visible = true;
                bunifuCustomDataGrid1.Columns[2].HeaderText = "Bill Date";
                bunifuCustomDataGrid1.Columns[3].Visible = true;
                bunifuCustomDataGrid1.Columns[3].HeaderText = "Total Amount";
                bunifuCustomDataGrid1.Columns[4].Visible = true;
                bunifuCustomDataGrid1.Columns[4].HeaderText = "Final Millage";
                bunifuCustomDataGrid1.Columns[5].Visible = true;
                bunifuCustomDataGrid1.Columns[5].HeaderText = "Damage Amount";

            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            //get rent id  which not issued a bill, to combo box
            String q3 = "SELECT rnt_id FROM rental_details WHERE rnt_bill_is_issued = 'no'";
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
            cmb_bill_rent_id.DataSource = listName;


            btn_update.Visible = false;
            btn_remove.Visible = false;
            btn_add.Enabled = true;

            clear();

            txt_bill_id.Text = CodeGenerator.generateRentalBillCode();
    }

    

    private void search()
    {

        try
        {
            Database db = new Database();

            String q1 = "select * from rental_bill_details where bill_id like '%" + txt_search.Text + "%' ";

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
            txt_bill_id.Text = string.Empty;
            cmb_bill_rent_id.Text = string.Empty;
            txt_bill_total_amount.Text = string.Empty;
            txt_bill_final_millage.Text = string.Empty;
            txt_search.Text = string.Empty;
            datepicker_bill_date.Text = string.Empty;
            txt_bill_damage_amount.Text = string.Empty;

            

        }

        private void rs_billing_details_Load(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();

                bool test = Validte_Data();
                if (test == true)
                {
                    if (datepicker_bill_date.Value.Date != DateTime.Today)
                    {
                        MyDialog.Show("Error...!", "Bill Date Is Not Valid");
                    }
                    else
                    {
                        string query = "INSERT INTO rental_bill_details VALUES  ( '" + txt_bill_id.Text + "','" + cmb_bill_rent_id.Text + "' ,'" + datepicker_bill_date.Text + "', '" + float.Parse(txt_bill_total_amount.Text) + "', '" + Convert.ToInt32(txt_bill_final_millage.Text) + "', '" + float.Parse(txt_bill_damage_amount.Text) + "')";

                        db.sqlQuery(query);
                        db.nonQuery();

                        string query2 = "UPDATE rental_details SET rnt_bill_is_issued = 'yes' Where rnt_id = '" + cmb_bill_rent_id.Text + "'";
                        db.sqlQuery(query2);
                        db.nonQuery();

                        db.getConnection().Close();

                        loadData();

                        MyDialog.Show("Insert Successful..", "Bill Was Successfully Added");
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
                        string query = "UPDATE rental_bill_details SET bill_rnt_id ='" + cmb_bill_rent_id.Text + "',bill_date ='" + datepicker_bill_date.Text + "', bill_tot_amount ='" + float.Parse(txt_bill_total_amount.Text) + "',bill_final_millage ='" + Convert.ToInt32(txt_bill_final_millage.Text) + "',bill_damage_amount ='" + float.Parse(txt_bill_damage_amount.Text) + "' WHERE bill_id = '" + txt_bill_id.Text + "' ";
                        Database db = new Database();
                        db.sqlQuery(query);
                        db.nonQuery();

                        string query2 = "UPDATE rental_details SET rnt_bill_is_issued = 'yes' Where rnt_id = '" + cmb_bill_rent_id.Text + "'";
                        db.sqlQuery(query2);
                        db.nonQuery();

                        db.getConnection().Close();

                        loadData();

                        MyDialog.Show("Update Successful..", "Bill Record Successfully Updated");
                    
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                string query = "DELETE FROM rental_bill_details WHERE bill_id = '" + txt_bill_id.Text+ "' ";


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
            cmb_bill_rent_id.DataSource = listName;
            db.getConnection().Close();

            txt_bill_id.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            cmb_bill_rent_id.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            datepicker_bill_date.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            txt_bill_total_amount.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            txt_bill_final_millage.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            txt_bill_damage_amount.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();

            

            btn_update.Visible = true;
            btn_remove.Visible = true;
            btn_add.Enabled = false;

        }

        private void rs_billing_details_Paint(object sender, PaintEventArgs e)
        {
            loadData();
        }
        

        private void btn_search_Click(object sender, EventArgs e)
        {
            search();
        }

        private bool Validte_Data()
        {
            Regex validate_number = new Regex("[0-9]+$");
            Regex validate_float = new Regex("^[0-9]+(\\.[0-9][0-9]?)?$");

            
                if (!validate_number.IsMatch(txt_bill_final_millage.Text))
                {
                    MyDialog.Show("Error...!", "Invalid Final Millage");
                }
                else
                {
                    if (!validate_float.IsMatch(txt_bill_damage_amount.Text))
                    {
                        MyDialog.Show("Error...!", "Invalid Damage Amount");
                    }
                    else
                    {
                        if (!validate_float.IsMatch(txt_bill_total_amount.Text))
                        {
                            MyDialog.Show("Error...!", "Invalid Total Amount");
                        }
                        else
                        {
                            return true;
                        }
                    
                        return false;
                    }
                    return false;
                }
                return false;
        }

        private void cmb_bill_rent_id_DropDown(object sender, EventArgs e)
        {
            Database db = new Database();
            //get rent id  which not issued a bill, to combo box
            String q3 = "SELECT rnt_id FROM rental_details WHERE rnt_bill_is_issued = 'no'";
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
            cmb_bill_rent_id.DataSource = listName;

            db.getConnection().Close();
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            search();
        }
    }
    

}
                    /*  if (datepicker_bill_date.Value.Date<DateTime.Today)
                        {
                            MessageBox.Show("Date is Not Valid");
                        }
                        else
                        {
                           
                            return false;
                        }   */
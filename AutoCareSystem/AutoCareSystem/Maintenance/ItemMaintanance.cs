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
    public partial class ItemMaintanance : UserControl
    {
        public ItemMaintanance()
        {
            InitializeComponent();
        }

        private void BindGridView(String skey)
        {
            try
            {
                String query;
                if (string.IsNullOrWhiteSpace(skey))
                    query = "SELECT  e.item_code, e.item_name FROM equipments e ";
                else
                    query = "SELECT  e.item_code, e.item_name FROM equipments e WHERE e.item_name LIKE '%" + skey + "%'";
                Database db = new Database();
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
        private void ItemMaintanance_Load(object sender, EventArgs e)
        {
            BindGridView(null);
            resetFields();
            txtname.Enabled = false;
            txtcode.Enabled = false;
        }


        public void loadTexts(DataGridViewRow selectedRow)
        {
            txtcode.Text = Convert.ToString(selectedRow.Cells[0].Value);
            txtname.Text = Convert.ToString(selectedRow.Cells[1].Value);
            txtrepairinfo.Text = string.Empty;
            txtinvoiceid.Text = string.Empty;
            txtprice.Text = string.Empty;
            maintanancedate.Value = DateTime.Now;
        }


        private void bunifuCustomDataGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = bunifuCustomDataGrid2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid2.Rows[selectedrowindex];
            loadTexts(selectedRow);
            //load provided repairs
            BindGridView1(Convert.ToString(selectedRow.Cells[0].Value));
        }

        private void tbxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            BindGridView(((tbxSearch.Text.Length >= 1) ? tbxSearch.Text : null));
        }

        private void BindGridView1(string eq_id)
        {
            try
            {
                string query1 = "SELECT er.eq_repair_id, er.info, er.invoice_id, er.amount, er.maintanance_date FROM equipment_repair er WHERE er.item_code = '" + eq_id + "' ";
                Database db = new Database();
                db.sqlQuery(query1);
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
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
            loadServices(selectedRow);
        }

        public void loadServices(DataGridViewRow selectedRow)
        {
            txtrepairinfo.Text = Convert.ToString(selectedRow.Cells[1].Value);
            txtinvoiceid.Text = Convert.ToString(selectedRow.Cells[2].Value);
            txtprice.Text = Convert.ToString(selectedRow.Cells[3].Value);
            maintanancedate.Value = DateTime.Parse(Convert.ToString(selectedRow.Cells[4].Value));
        }

        private void resetFields()
        {
            txtcode.Text = string.Empty;
            txtname.Text = string.Empty;
            txtrepairinfo.Text = string.Empty;
            txtinvoiceid.Text = string.Empty;
            txtprice.Text = string.Empty;
            maintanancedate.Value = DateTime.Now;
            tbxSearch.Text = null;
            BindGridView(null);
            bunifuCustomDataGrid1.DataSource = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        private void addItemRepair()
        {
            String itemreid = CodeGenerator.generateItemRepairCode();
            int selectedrowindex = bunifuCustomDataGrid2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid2.Rows[selectedrowindex];
            string eqid = Convert.ToString(selectedRow.Cells[0].Value);
            string maintain_date = maintanancedate.Value.ToString("yyyy-MM-dd");
            string query = "INSERT INTO equipment_repair VALUES('" + itemreid + "','" + eqid + "','" + txtrepairinfo.Text + "','" + txtinvoiceid.Text + "','" + txtprice.Text + "','" + maintain_date + "')";
            Database db = new Database();
            db.sqlQuery(query);
            if (db.nonQuery())
            {
                MyDialog.Show("Success...!", "Equipment Repair Added.");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool emptyFields = isEmptyFields();
            if (emptyFields == false)
            {
                MyDialog.Show("Error...!", "Plese fill all fields");
            }
            else
            {
                if (Validator.IsValidDescription(txtrepairinfo.Text))
                {
                    if (Validator.IsValidIntNumber(txtinvoiceid.Text))
                    {
                        if (Validator.IsValidPrice(txtprice.Text))
                        {
                            if (Validator.IsValidBeforeOrTodayDate(maintanancedate.Value))
                            {
                                addItemRepair();
                                resetFields();
                            }
                            else
                            {
                                MyDialog.Show("Error...!", "Plese enter correct service date!");
                            }
                        }
                        else
                        {
                            MyDialog.Show("Error...!", "Plese enter correct price!");
                        }
                    }
                    else
                    {
                        MyDialog.Show("Error...!", "Plese enter correct invoiceID!");
                    }
                }
                else
                {
                    MyDialog.Show("Error...!", "Plese enter correct info!");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool emptyFields = isEmptyFields();
            if (emptyFields == false)
            {
                MyDialog.Show("Error...!", "Plese fill all fields");
            }
            else
            {
                if (Validator.IsValidDescription(txtrepairinfo.Text))
                {
                    if (Validator.IsValidIntNumber(txtinvoiceid.Text))
                    {
                        if (Validator.IsValidPrice(txtprice.Text))
                        {
                            if (Validator.IsValidBeforeOrTodayDate(maintanancedate.Value))
                            {
                                int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
                                DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];
                                string eq_re_id = Convert.ToString(selectedRow.Cells[0].Value);
                                string maintain_date = maintanancedate.Value.ToString("yyyy-MM-dd");
                                //DateTime maintain_date = maintanancedate.Value;
                                string query = "UPDATE equipment_repair SET  info = '" + txtrepairinfo.Text + "', invoice_id = '" + txtinvoiceid.Text + "', amount = '" + txtprice.Text + "', maintanance_date = '" + maintain_date + "' WHERE eq_repair_id = '" + eq_re_id + "'";
                                Database db = new Database();
                                db.sqlQuery(query);
                                if (db.nonQuery())
                                {
                                    MyDialog.Show("Success...!", "Equipment Repair Updated.");
                                }
                            }
                            else
                            {
                                MyDialog.Show("Error...!", "Plese enter correct service date!");
                            }
                        }
                        else
                        {
                            MyDialog.Show("Error...!", "Plese enter correct price!");
                        }
                    }
                    else
                    {
                        MyDialog.Show("Error...!", "Plese enter correct invoiceID!");
                    }
                }
                else
                {
                    MyDialog.Show("Error...!", "Plese enter correct info!");
                }
            }

            txtrepairinfo.Text = string.Empty;
            txtinvoiceid.Text = string.Empty;
            txtprice.Text = string.Empty;
            maintanancedate.Value = DateTime.Now;

            int selectedrowindex2 = bunifuCustomDataGrid2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow2 = bunifuCustomDataGrid2.Rows[selectedrowindex2];
            string eqid = Convert.ToString(selectedRow2.Cells[0].Value);
            BindGridView1(eqid);
        }

        private bool isEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(txtcode.Text) || string.IsNullOrWhiteSpace(txtname.Text) || string.IsNullOrWhiteSpace(txtrepairinfo.Text) || string.IsNullOrWhiteSpace(txtinvoiceid.Text) || string.IsNullOrWhiteSpace(txtprice.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

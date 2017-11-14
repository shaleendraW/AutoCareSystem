using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace AutoCareSystem
{
    public partial class Employee_registration : UserControl
    {
        public Employee_registration()
        {
            InitializeComponent();
            CodeGenerator cd = new CodeGenerator();
            string EmpID = CodeGenerator.generateEmployeeID();
            txtEID.Text = EmpID;
        }


        public void resetFields() {
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtEID.Text = string.Empty;
            dpDOB.Text = string.Empty;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtPhone.Text = string.Empty;
            cmbPosition.SelectedIndex = 0;
            txtCID.Text = string.Empty;
            txtHoli.Text = string.Empty;


        }
        public void resetFieldsforInsert()
        {
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            dpDOB.Text = string.Empty;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtPhone.Text = string.Empty;
            cmbPosition.SelectedIndex = 0;
            txtCID.Text = string.Empty;
            txtHoli.Text = string.Empty;


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Employee_registration_Load(object sender, EventArgs e)
        {

        }

        private void materialLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnRepairAdd_Click(object sender, EventArgs e)
        {
            byte[] image = null;
            FileStream streem = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            image = brs.ReadBytes((int)streem.Length);

            string gender = "";
            if (rbMale.Checked)
            {
                gender = "Male";


            }
            else if (rbFemale.Checked)
            {

                gender = "Female";


            }
            Database db = new Database();
            SqlConnection conn = db.getConnection();
            SqlCommand cmd = conn.CreateCommand();
            string query = "INSERT INTO employee ( e_code,fname, lname, b_date, gender, add_line_01, add_line_02, city, nic, tel_phone, position, acpt_holidays, card_id,profile_pic) VALUES('" + txtEID.Text + "','" + txtFName.Text + "','" + txtLName.Text + "','" + dpDOB.Text +"','" + gender+"','" +txtAddress1.Text +"','" +txtAddress2.Text +"','" +txtCity.Text +"','" +txtNIC.Text +"','" +txtPhone.Text +"','" + cmbPosition.Text+"','" +txtHoli.Text +"','" +txtCID.Text + "','"+ image + "')";
            cmd.Parameters.Add(new SqlParameter("@image1", image));
            //  Database db = new Database();

            db.sqlQuery(query);
            if (db.nonQuery())
            {
                MyDialog.Show("Success...!", "Employee Registered :)");
                resetFields();
                CodeGenerator cd = new CodeGenerator();
                string EmpID = CodeGenerator.generateEmployeeID();
                txtEID.Text = EmpID;

            }

        }

        private void btnRepairClear_Click(object sender, EventArgs e)
        {
            resetFields();
            CodeGenerator cd = new CodeGenerator();
            string EmpID = CodeGenerator.generateEmployeeID();
            txtEID.Text = EmpID;


        }

        private void txtFName_OnValueChanged(object sender, EventArgs e)
        {

        }
        string imageLocation = "";
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imageLocation;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace AutoCareSystem
{
    public partial class add_service : UserControl
    {

        private String DATE_FORMAT = "yyyy-MM-dd";

        public add_service()
        {
            InitializeComponent();
            initialization();
        }

        private void initialization()
        {
            enableButtons(false);
            EnableControls(groupBox1, false);
            EnableControls(groupBox2, false);
            EnableControls(groupBox3, false);
            serviceDate.Enabled = false;
            nextServiceDate.Enabled = false;
            tbxOdoMeter.Enabled = false;
        }

        private void EnableControls(Control con, bool b)
        {
            foreach (Control c in con.Controls)
            {
                if (c is CheckBox)
                    EnableControls(c, b);  
            }
            if (con is CheckBox)
                con.Enabled = b;
            
        }

        private void tbxVehicleNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (isFound( tbxVehicleNumber.Text))
            {
                enableButtons(true);
                EnableControls(groupBox1, true);
                EnableControls(groupBox2, true);
                EnableControls(groupBox3, true);
                serviceDate.Enabled = true;
                nextServiceDate.Enabled = true;
                tbxOdoMeter.Enabled = true;
            }
            else
            {
                enableButtons(false);
                EnableControls(groupBox1, false);
                EnableControls(groupBox2, false);
                EnableControls(groupBox3, false);
                serviceDate.Enabled = false;
                nextServiceDate.Enabled = false;
                tbxOdoMeter.Enabled = false;
            }
        }

        private void enableButtons(bool b)
        {
            btnAdd.Enabled = b;
            btnAdd.Cursor = (b) ? Cursors.Hand : Cursors.Default;
        }


        private bool isFound(String skey)
        {
            try
            {
                String query = "SELECT COUNT(*) AS vcount FROM vehicles WHERE vehicle_number = '" + skey + "'";
                Database db = new Database();
                db.sqlQuery(query);
                String vcount = db.executeQuery("vcount");
                db.getConnection().Close();
                return vcount.Equals("1");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                return false;
            }
        }

        private void tbxVehicleNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validator.IsValidPastDate(serviceDate.Value.ToString(DATE_FORMAT)))
            {
                if (Validator.IsValidNumber(tbxOdoMeter.Text))
                {
                    if (Validator.IsValidFutureDate(nextServiceDate.Value.ToString(DATE_FORMAT)))

                        addNewService();
                    else
                        MyDialog.Show("Error...!", "Next Service Date is invalid");
                }
                else
                    MyDialog.Show("Error...!", "ODO Meter is invalid");
            }
            else
                MyDialog.Show("Error...!", "Service Date is invalid");

        }

        private void addNewService()
        {
            try
            {
                String vehicleid = getVehicleId(tbxVehicleNumber.Text);
                String service_date = serviceDate.Value.ToString(DATE_FORMAT);
                string odo_meter = tbxOdoMeter.Text;
                String next_service_date = nextServiceDate.Value.ToString(DATE_FORMAT);
                String s_code = CodeGenerator.generateServiceCode();
                string query = "INSERT INTO services VALUES('" + s_code + "','" + vehicleid + "','" + service_date + "','" + odo_meter + "','" + next_service_date + "')";
                Database db = new Database();
                db.sqlQuery(query);
                if (db.nonQuery())
                {
                    MyDialog.Show("Success...!", "New Service Registered");
                    addProvidedServices();
                    resetFields();
                }
                else
                {
                    MyDialog.Show("Error...!", "New Service Not Registered");
                }
                db.getConnection().Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void resetFields()
        {
            uncheckCheckBox();
            tbxVehicleNumber.Text = String.Empty;
            tbxOdoMeter.Text = String.Empty;
        }

        private void uncheckCheckBox()
        {
            cbxEngineOilTest.Checked = false;
            cbxTransmissionOilTest.Checked = false;
            cbxBreakFluidTest.Checked = false;
            cbxReplaceBreakFluid.Checked = false;
            cbxInverterCoolentTest.Checked = false;
            cbxRadiatorCoolentTest.Checked = false;

            cbxOilFilter.Checked = false;
            cbxAirFilter.Checked = false;
            cbxAcFilter.Checked = false;

            cbxEngineTuneup.Checked = false;
            cbxSparkPlugChange.Checked = false;
            cbxHvBattery.Checked = false;
            cbxHvBatteryCooling.Checked = false;
            cbxBreakService.Checked = false;
            cbxRepalceBreakPad.Checked = false;
            cbxEngineScanning.Checked = false;
            cbxBatteryUsable.Checked = false;
        }

        private string getVehicleId(string key)
        {
            string query = "SELECT v_code FROM vehicles WHERE vehicle_number = '" + key + "'";
            Database db = new Database();
            db.sqlQuery(query);
            DataTable dt = db.executeQuery();
            return db.executeQuery("v_code");
        }

        private void addProvidedServices()
        {
            Database db = new Database();
            String s_code = getLastInsertServiceId();
            List<int>  checkedList = getCheckedList();

            foreach (int typeId in checkedList)
            {
                String charges = getServiceCharge(typeId);
                System.Console.WriteLine(typeId+" | "+charges);
                string query = "INSERT INTO provided_services VALUES('" + s_code + "','" + typeId + "','" + charges + "','" + DateTime.Now + "')";
                db.sqlQuery(query);
                db.nonQuery();
            }
            db.getConnection().Close();
        }

        private List<int> getCheckedList()
        {
            List<int> checkedList = new List<int>();

            if (cbxEngineOilTest.Checked)
                checkedList.Add(1);
                
            if (cbxTransmissionOilTest.Checked)
                checkedList.Add(2);
            
            if (cbxBreakFluidTest.Checked)
                checkedList.Add(3);
            
            if (cbxReplaceBreakFluid.Checked)
                checkedList.Add(4);
           
            if (cbxInverterCoolentTest.Checked)
                checkedList.Add(5);
            
            if (cbxRadiatorCoolentTest.Checked)
                checkedList.Add(6);
            
            if (cbxOilFilter.Checked) //filter
                checkedList.Add(7);
            
            if (cbxAirFilter.Checked)
                checkedList.Add(8);
            
            if (cbxAcFilter.Checked)
                checkedList.Add(9);
            
            if (cbxEngineTuneup.Checked) //other service
                checkedList.Add(10);
            
            if (cbxSparkPlugChange.Checked)
                checkedList.Add(11);
            
            if (cbxHvBattery.Checked)
                checkedList.Add(12);
            
            if (cbxHvBatteryCooling.Checked)
                checkedList.Add(13);
            
            if (cbxBreakService.Checked)
                checkedList.Add(14);
            
            if (cbxRepalceBreakPad.Checked)
                checkedList.Add(15);
            
            if (cbxEngineScanning.Checked)
                checkedList.Add(16);
            
            if (cbxBatteryUsable.Checked)
                checkedList.Add(17);
            

            return checkedList;
        }

        private String getLastInsertServiceId()
        {
            String query = "SELECT TOP 1 s_code FROM services ORDER BY s_code DESC";
            Database db = new Database();
            db.sqlQuery(query);
            return db.executeQuery("s_code");
        }

        private String getServiceCharge(int stid)
        {
            String query = "SELECT charges FROM service_types WHERE stid = '" + stid + "'";
            Database db = new Database();
            db.sqlQuery(query);
            return String.Format("{0:C0}", db.executeQuery("charges"));
        }
    }
}

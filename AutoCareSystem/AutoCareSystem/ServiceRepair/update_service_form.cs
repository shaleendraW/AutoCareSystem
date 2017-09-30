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
using System.Globalization;

namespace AutoCareSystem
{
    public partial class update_service_form : UserControl
    {

        private String DATE_FORMAT = "yyyy-MM-dd";

        public update_service_form()
        {
            InitializeComponent();
        }

        private void tbxVehicleNumber_KeyUp(object sender, KeyEventArgs e)
        {
            uncheckCheckBox();
            loadBasicDetails(tbxServiceCode.Text);
            loadProvidedServices(tbxServiceCode.Text);
        }

        private void loadBasicDetails(String skey)
        {
            try
            {
                String query = "SELECT v.vehicle_number,s.enter_date,s.odo_meter,s.next_date FROM services s LEFT OUTER JOIN vehicles v ON s.v_code = v.v_code WHERE s.s_code = '" + skey + "'";
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                db.getConnection().Close();
                if (dt != null && dt.Rows.Count > 0)
                {
                    enableButtons(true);
                    EnableControls(groupBox1, true);
                    EnableControls(groupBox2, true);
                    EnableControls(groupBox3, true);
                    tbxVehicleNo.Text = getValue(dt, "vehicle_number");
                    tbxOdoMeter.Text = getValue(dt, "odo_meter");
                    serviceDate.Value = DateTime.Parse(getValue(dt, "enter_date"));
                    nextServiceDate.Value = DateTime.Parse(getValue(dt, "next_date"));
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
                    tbxVehicleNo.Text = String.Empty;
                    tbxOdoMeter.Text = String.Empty;
                    serviceDate.Value = DateTime.Today.AddDays(0);
                    nextServiceDate.Value = DateTime.Today.AddDays(0);
                    serviceDate.Enabled = false;
                    nextServiceDate.Enabled = false;
                    tbxOdoMeter.Enabled = false;
                }

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

        private void loadProvidedServices(String skey)
        {
            try
            {
                String query = "SELECT stid FROM provided_services WHERE s_code = '" + skey + "'";
                Database db = new Database();
                db.sqlQuery(query);
                DataTable dt = db.executeQuery();
                db.getConnection().Close();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        switch (Convert.ToString(row["stid"]))
                        {
                            case "1":
                                cbxEngineOilTest.Checked = true;
                                break;
                            case "2":
                                cbxTransmissionOilTest.Checked = true;
                                break;
                            case "3":
                                cbxBreakFluidTest.Checked = true;
                                break;
                            case "4":
                                cbxReplaceBreakFluid.Checked = true;
                                break;
                            case "5":
                                cbxInverterCoolentTest.Checked = true;
                                break;
                            case "6":
                                cbxRadiatorCoolentTest.Checked = true;
                                break;
                            case "7":
                                cbxOilFilter.Checked = true;
                                break;
                            case "8":
                                cbxAirFilter.Checked = true;
                                break;
                            case "9":
                                cbxAcFilter.Checked = true;
                                break;
                            case "10":
                                cbxEngineTuneup.Checked = true;
                                break;
                            case "11":
                                cbxSparkPlugChange.Checked = true;
                                break;
                            case "12":
                                cbxHvBattery.Checked = true;
                                break;
                            case "13":
                                cbxHvBatteryCooling.Checked = true;
                                break;
                            case "14":
                                cbxBreakService.Checked = true;
                                break;
                            case "15":
                                cbxRepalceBreakPad.Checked = true;
                                break;
                            case "16":
                                cbxEngineScanning.Checked = true;
                                break;
                            case "17":
                                cbxBatteryUsable.Checked = true;
                                break;
                        }
                    }
                }
                else
                {
                    uncheckCheckBox();
                }

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
            tbxServiceCode.Text = String.Empty;
            tbxVehicleNo.Text = String.Empty;
            tbxOdoMeter.Text = String.Empty;
            serviceDate.Value = DateTime.Today.AddDays(0);
            nextServiceDate.Value = DateTime.Today.AddDays(0);
            uncheckCheckBox();
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

        private String getValue(DataTable dt, String para)
        {
            return Convert.ToString(dt.Rows[0][para]);
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

        private void enableButtons(bool b)
        {
            btnUpdate.Enabled = b;
            btnUpdate.Cursor = (b) ? Cursors.Hand : Cursors.Default;
        }

        private void tbxVehicleNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private void update_service_form_Load(object sender, EventArgs e)
        {
            tbxVehicleNo.Enabled = false;
            enableButtons(false);
            EnableControls(groupBox1, false);
            EnableControls(groupBox2, false);
            EnableControls(groupBox3, false);
            serviceDate.Enabled = false;
            nextServiceDate.Enabled = false;
            tbxOdoMeter.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String s_code = tbxServiceCode.Text;
            if (Validator.IsValidPrimaryCode(s_code, "S"))
            {

                String v_code = getVehicleCode(tbxVehicleNo.Text);
                String service_date = serviceDate.Value.ToString(DATE_FORMAT);
                String odo_meter = tbxOdoMeter.Text;
                String next_service_date = nextServiceDate.Value.ToString(DATE_FORMAT);
                if (Validator.IsValidPastDate(serviceDate.Value.ToString(DATE_FORMAT)))
                {
                    //if (Validator.IsValidFutureDate(nextServiceDate.Value.ToString(DATE_FORMAT)))
                    //{
                        if (Validator.IsValidNumber(tbxOdoMeter.Text))
                        {

                            String query01 = "UPDATE services SET v_code = '" + v_code + "', enter_date = '" + service_date + "', odo_meter = '" + odo_meter + "', next_date = '" + next_service_date + "' WHERE s_code = '" + s_code + "'";
                            Database db = new Database();
                            db.sqlQuery(query01);
                            db.nonQuery();

                            String query02 = "DELETE FROM provided_services WHERE s_code = '" + s_code + "'";
                            db.sqlQuery(query02);
                            db.nonQuery();

                            List<int> checkedList = getCheckedList();

                            foreach (int typeId in checkedList)
                            {
                                String charges = getServiceCharge(typeId);
                                String query03 = "INSERT INTO provided_services VALUES('" + s_code + "','" + typeId + "','" + charges + "','" + DateTime.Now + "')";
                                db.sqlQuery(query03);
                                db.nonQuery();
                            }
                            db.getConnection().Close();
                            MyDialog.Show("Success...!", "Service Updated");
                            resetFields();
                        }
                        else
                            MyDialog.Show("Error...!", "ODO Meter is invalid");
                    //}
                    //else
                       // MyDialog.Show("Error...!", "Next Service Date is invalid");
                }
                else
                    MyDialog.Show("Error...!", "Service Date is invalid");
            }
            else
                MyDialog.Show("Error...!", "Invalid Service Code");
        }

        private string getVehicleCode(string key)
        {
            string query = "SELECT v_code FROM vehicles WHERE vehicle_number = '" + key + "'";
            Database db = new Database();
            db.sqlQuery(query);
            DataTable dt = db.executeQuery();
            return db.executeQuery("v_code");
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

        private string getServiceCharge(int stid)
        {
            string query = "SELECT charges FROM service_types WHERE stid = '" + stid + "'";
            Database db = new Database();
            db.sqlQuery(query);
            return String.Format("{0:C0}", db.executeQuery("charges"));
        }
    }
}

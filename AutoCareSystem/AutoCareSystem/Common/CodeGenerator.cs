using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoCareSystem
{
    class CodeGenerator
    {
        private static String NUMBER_FORMAT = "{0:D4}";

        public static String generateVehicleCode()
        {
            String number = getLastInsertId("vehicles", "v_code").Substring(1);
            return ("V" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateRepairCode()
        {
            String number = getLastInsertId("repairs", "r_code").Substring(1);
            return ("R" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateServiceCode()
        {
            String number = getLastInsertId("services", "s_code").Substring(1);
            return ("S" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }




        //Ishara
        public static String generateSupplierCode()
        {
            String number = getLastInsertId("suppliers", "sup_code").Substring(2);
            return ("SP" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateItemCode()
        {
            String number = getLastInsertId("stocks", "item_code").Substring(1);
            return ("I" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateOrderCode()
        {
            String number = getLastInsertId("orders", "order_code").Substring(2);
            return ("OD" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }


        //Lahiru
        public static string generateEquipmentsCode()
        {
            String number = getLastInsertId("equipments", "item_code").Substring(2);
            return ("EQ" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateItemRepairCode()
        {
            String number = getLastInsertId("equipment_repair", "eq_repair_id").Substring(3);
            return ("EQR" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static string generateRentVehicleRenewId()
        {
            String number = getLastInsertId("rental_vehicle_renew", "renew_id").Substring(3);
            return ("RVR" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static string generateRentVehicleRRepaiServiceId()
        {
            String number = getLastInsertId("rental_vehicle_repair_service", "maintanance_id").Substring(4);
            return ("RVRS" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }


        //Sajith
        public static String generateRentalVehicleCode()
        {
            String number = getLastInsertId("rental_vehicle", "rv_id").Substring(2);
            return ("RV" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateRentalDetailsCode()
        {
            String number = getLastInsertId("rental_details", "rnt_id").Substring(2);
            return ("RD" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateCustomerCode()
        {
            String number = getLastInsertId("customers", "c_code").Substring(1);
            return ("C" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateRentalBillCode()
        {
            String number = getLastInsertId("rental_bill_details", "bill_id").Substring(2);
            return ("RB" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateRentalInvoiceCode()
        {
            String number = getLastInsertId("rental_invoice", "in_id").Substring(2);
            return ("IN" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }


        //Shaleendra

        public String generateReturnItemCode()
        {
            String number = getLastInsertId("return_items", "return_id").Substring(2);
            return ("RI" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateSalesItemCode()
        {
            String number = getLastInsertId("sales_items", "item_id").Substring(2);
            return ("SI" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateSalescode()
        {
            String number = getLastInsertId("sales", "sales_id").Substring(2);
            return ("SA" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateSalescustomercode()
        {
            String number = getLastInsertId("salescustomer", "cus_id").Substring(2);
            return ("SC" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }


        //Sachin
        public static String generateCustomerID()
        {
            String number = getLastInsertId("customers", "c_code").Substring(1);
            return ("C" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateAppointmentID()
        {
            String number = getLastInsertId("appointment", "appointment_id").Substring(1);
            return ("A" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }

        public static String generateSlotID()
        {
            String number = getLastInsertId("slots", "slot_id").Substring(1);
            return ("SL" + String.Format(NUMBER_FORMAT, (Convert.ToInt32(number) + 1)));
        }


        public static String getLastInsertId(String tbl_name, String clm_name)
        {
            try
            {
                String query = "SELECT TOP 1 " + clm_name + " FROM " + tbl_name + " ORDER BY " + clm_name + " DESC";
                Database db = new Database();
                db.sqlQuery(query);
                String id = db.executeQuery(clm_name);
                db.getConnection().Close();
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}

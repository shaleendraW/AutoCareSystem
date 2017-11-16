using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace AutoCareSystem
{
    class Database
    {
        private static String conString = @"Data Source=LAPTOP-6C9FJ2FB\SQLEXPRESS;Initial Catalog=next123;Integrated Security=True";
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;

        // Constructor
        public Database()
        {
            try
            {
                con = new SqlConnection(conString);
                //con.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public String getConnectionString()
        {
            return conString;
        }

        public SqlConnection getConnection()
        {
            return con;
        }

        // Create the command from the query and the command
        public void sqlQuery(String query)
        {
            try
            {
                cmd = new SqlCommand(query, con);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 
        public DataTable executeQuery()
        {
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String executeQuery(String para)
        {
            try
            {
                DataTable dt = executeQuery();
                return Convert.ToString(dt.Rows[0][para]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public SqlDataReader getData()
        {
            try
            {
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool nonQuery()
        {
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
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

        public string getDataByScaller()
        {
            try
            {
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


    }
}

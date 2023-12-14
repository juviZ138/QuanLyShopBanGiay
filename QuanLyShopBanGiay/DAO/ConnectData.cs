using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class SqlConnectionData
    {
        public static SqlConnection Connect()
        {
            string strcon = @"Data Source=HIEUD;Initial Catalog=abc;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);
            try
            {
                conn.Open();
                Console.WriteLine("ket noi thanh cong!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ket noi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return conn;
        }
    }

}


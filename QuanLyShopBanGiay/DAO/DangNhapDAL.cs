
using QuanLyShopBanGiay.DAO;
using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class DangNhapDAL
    {
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public Users getTaiKhoan(string tenTK, string MatKhau)
        {
            Users user = null;
            string query = "Select * from dbo.tbl_user where user_id='" + tenTK + "'and password='" + MatKhau + "' ";
            using (SqlConnection sqlConnection = SqlConnectionData.Connect())
            {

                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Users u = new Users(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7),dataReader.GetString(8), dataReader.GetInt32(9), dataReader.GetInt32(10));
                    user = u;
                }

                sqlConnection.Close();

            }
            return user;

        }
        public DangNhapDAL() { }
    }
}

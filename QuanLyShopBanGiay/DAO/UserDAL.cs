
using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class UserDAL
    {
        public UserDAL() { }
        SqlCommand sqlCommand;
        SqlDataReader dataReader;

        public static DataTable GetAllUser()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                connection.Open();
                string query = @"select * from dbo.tbl_user";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }
        public List<Users> getListUser()
        {
            string query = "Select * from dbo.tbl_user";

            List<Users> us = new List<Users>();

            using (SqlConnection sqlConnection = SqlConnectionData.Connect())
            {

                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    us.Add(new Users(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetString(8), dataReader.GetInt32(9), dataReader.GetInt32(10)));
                }

                sqlConnection.Close();
            }

            return us;
        }
        public List<Users> getListUserTimKiem(string timkiem)
        {
            string query = "Select *from dbo.tbl_user WHERE user_id = '" + timkiem + "'; ";

            List<Users> userTimKiems = new List<Users>();
            try
            {
                using (SqlConnection sqlConnection = SqlConnectionData.Connect())
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        userTimKiems.Add(new Users(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetString(8), dataReader.GetInt32(9), dataReader.GetInt32(10)));
                    }

                    sqlConnection.Close();
                }
            }
            catch
            {
                userTimKiems = null;
            }

            return userTimKiems;
        }

        public Boolean themUser(Users user)
        {
            Boolean flag = false;
            try
            {
                string query = "INSERT INTO dbo.tbl_user(user_id, password, full_name, email,phone,cccd,gender,year_birth,address" +
               ",role_id,isDeleted)\r\nVALUES (N'" + user.user_id + "',N'" + user.password + "',N'" + user.full_name + "',N'" + user.email + "'" +
            ",N'" + user.phone + "',N'" + user.cccd + "',N'" + user.gender + "',N'" + user.year_birth + "',N'" + user.address + "',N'" + user.role_id + "','" + user.isDeleted + "');\r\n\r\n";
                using (SqlConnection sqlConnection = SqlConnectionData.Connect())
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();

                    flag = true;
                    sqlConnection.Close();

                }
            }
            catch
            {
                flag = false;
            }

            return flag;
        }

        public Boolean suaUser(Users user)
        {
            Boolean flag = false;
            try
            {

                string query = $"UPDATE dbo.tbl_user SET [user_id] = '{user.user_id}' ,[password] = N'{user.password}',[full_name] = '{user.full_name}', [email] = '{user.email}', [phone] = '{user.phone}', [cccd] = '{user.cccd}', [gender] = '{user.gender}', [year_birth] = '{user.year_birth}', [address] = '{user.address}', [role_id] = {user.role_id}, [isDeleted] = {user.isDeleted} WHERE user_id = '{user.user_id}'";

                using (SqlConnection sqlConnection = SqlConnectionData.Connect())
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();

                    flag = true;
                    sqlConnection.Close();

                }
            }
            catch
            {
                flag = false;
            }

            return flag;
        }

        public Boolean xoaUser(string userid)
        {
            Boolean flag = false;
            try
            {
                string query = "DELETE FROM dbo.tbl_user WHERE user_id = '" + userid + "' ;";
                using (SqlConnection sqlConnection = SqlConnectionData.Connect())
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();

                    flag = true;
                    sqlConnection.Close();

                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

    }
}

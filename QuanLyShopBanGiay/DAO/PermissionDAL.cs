using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyShopBanGiay.DTO;

namespace QuanLyShopBanGiay.DAO
{
    public class PermissionDAL
    {
        public PermissionDAL() { }
        SqlCommand sqlCommand;
        SqlDataReader dataReader;

        public List<Permission> getListPermission()
        {
            string query = "Select *from dbo.tbl_permission";

            List<Permission> prm = new List<Permission>();

            using (SqlConnection sqlConnection = SqlConnectionData.Connect())
            {

                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    prm.Add(new Permission(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetInt32(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetInt32(6), dataReader.GetInt32(7), dataReader.GetInt32(8), dataReader.GetInt32(9)));

                }

                sqlConnection.Close();
            }

            return prm;
        }
        public Boolean themPermission(Permission prm)
        {
            Boolean flag = false;
            try
            {
                // id,tenquyen,isSale,isBill,isProduct,isUser,isReceive,isPromo,isCustomer,isPermission
                string query1 = "INSERT INTO  dbo.tbl_role(role_id,role_name)\r\nVALUES (" + prm.id + ",N'" + prm.tenquyen + "')";

                string query = "INSERT INTO  tbl_permission(id,tenquyen,isSale,isBill,isProduct,isUser,isReceive,isPromo,isCustomer,isPermission) VALUES('" + prm.id + "', N'" + prm.tenquyen + "'" +
               ", " + prm.isSale + "," + prm.isBill + "," + prm.isProduct + "," + prm.isUser + ", " + prm.isReceive + ", " + prm.isPromo + ", " + prm.isCustomer + ", " + prm.isPermission + ");\r\n\r\n";
                using (SqlConnection sqlConnection = SqlConnectionData.Connect())
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();

                    flag = true;
                    sqlConnection.Close();

                }
                using (SqlConnection sqlConnection = SqlConnectionData.Connect())
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(query1, sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();

                    flag = true;
                    sqlConnection.Close();

                }
            }
            catch
            {
                return false;
            }

            return flag;
        }

        public Boolean suaPermission(Permission prm)
        {
            Boolean flag = false;
            try
            {
                // id,tenquyen,isSale,isBill,isProduct,isUser,isReceive,isPromo,isCustomer,isPermission
                string query = "UPDATE tbl_permission\r\n" +
                 "SET tenquyen = N'" + prm.tenquyen + "',isSale = " + prm.isSale + ",isBill = " + prm.isBill + "," +
                 "isProduct = " + prm.isProduct + ",isUser = " + prm.isUser + ",isReceive = " + prm.isReceive + ",isPromo = " + prm.isPromo + "," +
                 "isCustomer = " + prm.isCustomer + ", " + "isPermission = " + prm.isPermission + " " +
                 "\r\nWHERE id = " + prm.id + ";";

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
                return false;
            }

            return flag;
        }

        public Boolean xoaPermission(int id)
        {
            Boolean flag = false;
            try
            {
                string query = "DELETE FROM dbo.tbl_permission WHERE id = '" + id + "' ;";
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

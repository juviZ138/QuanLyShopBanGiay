using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using QuanLyShopBanGiay.DTO;

namespace QuanLyShopBanGiay.DAO
{
    public class RoleDAL
    {
        SqlCommand sqlCommand;
        SqlDataReader dataReader;

        public List<Role> getListRole()
        {
            string query = "Select *from dbo.tbl_role";
            List<Role> role = new List<Role>();
            using (SqlConnection sqlConnection = SqlConnectionData.Connect())
            {

                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    role.Add(new Role(dataReader.GetInt32(0), dataReader.GetString(1)));

                }

                sqlConnection.Close();
            }

            return role;
        }
    }
}

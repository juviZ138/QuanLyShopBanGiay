using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    public class CategoryDAO
    {
        Modify modify = new Modify();

        public CategoryDAO()
        {

        }


        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetDataTable()
        {
            String sql = "SELECT * from Category";

            return modify.Table(sql);
        }

        public List<Category> GetList()
        {
            List<Category> listCategory = new List<Category>();

            DataTable dataTable = this.GetDataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                Category newCategory = new Category
                {
                    CategoryId = row["id"].ToString(),
                    CategoryName = row["name"].ToString(),
                    status = int.Parse(row["status"].ToString()),

                };

                listCategory.Add(newCategory);
            }

            return listCategory;
        }


        public void Add(Category Category)
        {
            string sql = $"INSERT INTO category VALUES('{Category.CategoryId}',N'{Category.CategoryName}','{Category.status}')";
            modify.Command(sql);
        }

        public void Edit(Category Category, string CategoryId)
        {
            string sql = $"UPDATE category SET [id] = '{Category.CategoryId}' ,[name] = N'{Category.CategoryName}',[status] = {Category.status}  WHERE id = '{CategoryId}'";
            modify.Command(sql);
        }


        public void Delete(string CategoryId)
        {
            string sql = $"DELETE FROM category WHERE id = '{CategoryId}'";
            modify.Command(sql);
        }
    }
}

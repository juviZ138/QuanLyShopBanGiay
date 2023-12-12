using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyShopBanGiay.DAO
{
    public class BrandDAO
    {
        Modify modify = new Modify();

        public BrandDAO()
        {

        }

        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetDataTable()
        {
            String sql = "SELECT * from brand";

            return modify.Table(sql);
        }

        public List<Brand> GetList()
        {
            List<Brand> listBrand = new List<Brand>();

            DataTable dataTable = this.GetDataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                Brand newBrand = new Brand
                {
                    BrandId = row["id"].ToString(),
                    BrandName = row["Name"].ToString(),
                    status = int.Parse(row["status"].ToString()),
                    
                };

                listBrand.Add(newBrand); 
            }

            return listBrand;
        }


        public void Add(Brand brand)
        {
            string sql = $"INSERT INTO brand VALUES( '{brand.BrandId}','{brand.BrandName}','{brand.status}')";
            modify.Command(sql);
        }

        public void Edit(Brand brand, string brandId)
        {
            string sql = $"UPDATE brand SET [id] = '{brand.BrandId}' ,[name] = '{brand.BrandName}',[status] = {brand.status}  WHERE id = '{brandId}'";
            modify.Command(sql);
        }


        public void Delete(string brandId)
        {
            string sql = $"DELETE FROM brand WHERE id = '{brandId}'";
            modify.Command(sql);
        }
    }
}

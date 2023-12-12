using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DAO
{
    internal class ProductSizeDAO
    {
        Modify modify = new Modify();

        public ProductSizeDAO()
        {

        }

        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetAllBrands()
        {
            String sql = "SELECT * from product_size";

            return modify.Table(sql);

        }


        //public void Add(string size,int quantity)
        //{
        //    string sql = "INSERT INTO brand (name) VALUES( '" + brandName + "')";

        //    modify.Command(sql);
        //}


        public void Delete(int brandId)
        {
            string sql = "DELETE FROM brand WHERE id = " + brandId.ToString();
            modify.Command(sql);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyShopBanGiay.DTO;

namespace QuanLyShopBanGiay.DAO
{
    public class ProductDAO
    {
        Modify modify = new Modify();

        public ProductDAO()
        {

        }

        // Phương thức để lấy danh sách tất cả các thương hiệu
        public DataTable GetAllProduct()
        {
            String sql = "SELECT * from product";

            return modify.Table(sql);

        }

        public List<Product> GetProduct()
        {
            List<Product> listProduct = new List<Product>();

            DataTable dataTable = this.GetAllProduct();

            foreach (DataRow row in dataTable.Rows)
            {
                Product newProduct = new Product
                {
                    ProductId = row["id"].ToString(),
                    ProductName = row["name"].ToString(),
                    CategoryId = row["category"].ToString(),
                    BrandId = row["brand"].ToString(),
                    GiaNhap = float.Parse(row["GiaNhap"].ToString()),
                    LoiNhuan = int.Parse(row["LoiNhuan"].ToString()),
                    GiaBan = float.Parse(row["GiaBan"].ToString()),
                    KhuyenMai = int.Parse(row["KhuyenMai"].ToString()),
                    img_url = row["img"].ToString(),
                    status = int.Parse(row["status"].ToString()),

                };

                listProduct.Add(newProduct);
            }

            return listProduct;
        }



        public void Add(Product product)
        {
            string sql = $"INSERT INTO product VALUES('{product.ProductId}',N'{product.ProductName}',N'{product.CategoryId}',N'{product.BrandId}',{product.GiaNhap},{product.LoiNhuan},{product.GiaBan},{product.KhuyenMai},'{product.img_url}',{product.status})";

            modify.Command(sql);
        }

        public void Edit(Product product, string productID)
        {
            string sql = $"UPDATE product SET [id] = N'{product.ProductId}' ,[name] = N'{product.ProductName}'," +
                $"[category] = '{product.CategoryId}', [brand] = '{product.BrandId}', [GiaNhap] = {product.GiaNhap}, [LoiNhuan] = {product.LoiNhuan}, " +
                $"[GiaBan] = {product.GiaBan}, [KhuyenMai] = {product.KhuyenMai}, [img] = '{product.img_url}', " +
                $"[status] = {product.status} WHERE id = '{productID}'";


            modify.Command(sql);
        }


        public void Delete(string productID)
        {
            string sql = $"DELETE FROM product WHERE id = '{productID}'";
            modify.Command(sql);
        }

    }
}

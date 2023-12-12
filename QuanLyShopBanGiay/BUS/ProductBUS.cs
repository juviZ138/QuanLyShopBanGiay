using QuanLyShopBanGiay.DAO;
using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.BUS
{
    public class ProductBUS
    {
        private List<Product> listProduct;
        private ProductDAO ProductDAO = new ProductDAO();

        public ProductBUS()
        {
            listProduct = ProductDAO.GetProduct();
        }

        public DataTable GetAllProducts()
        {
            return ProductDAO.GetAllProduct();
        }

        public List<Product> GetProducts()
        {
            listProduct = ProductDAO.GetProduct();
            return listProduct;
        }

        public int CheckID(string ID)
        {
            Product checkID = this.GetByID(ID);
            if (checkID != null)
            {
                return 0;
            }
            return 1;
        }

        public int CheckName(string Name)
        {
            Product newProduct = listProduct.Find(s => s.ProductName == Name);
            if (newProduct == null)
            {
                return 1;
            }
            return 0;
        }

        public Product GetByID(string ProductID)
        {
            foreach (Product x in listProduct)
            {
                if (x.ProductId == ProductID)
                    return x;
            }
            return null;
        }

        public void AddProduct(Product newProduct)
        {
            listProduct.Add(newProduct);
            ProductDAO.Add(newProduct);
        }

        public void UpdateProduct(Product editProduct, string ID)
        {
            Product newProduct = listProduct.Find(s => s.ProductId == ID);
            if (newProduct != null)
            {
                newProduct = editProduct;
            }
     


            ProductDAO.Edit(editProduct, ID);
        }


        public void DeleteProduct(string ProductId)
        {
            listProduct.Remove(GetByID(ProductId));
            ProductDAO.Delete(ProductId);
        }
    }
}

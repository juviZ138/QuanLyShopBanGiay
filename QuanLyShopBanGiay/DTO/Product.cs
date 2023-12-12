
using System.Collections.Generic;

namespace QuanLyShopBanGiay.DTO
{
    public class Product
    {
        public string ProductId  { get; set; }
        public string ProductName { get; set; }
        public string CategoryId {  get; set; }
        public string BrandId { get; set; }
        public float GiaNhap { get; set; }
        public float LoiNhuan { get; set; }
        public float GiaBan {  get; set; }
        public int KhuyenMai {  get; set; }
        public string img_url { get; set; }
        public int status { get; set; }
        public Product()
        {
        }

        public Product(string productId, string productName, string category, 
            string brand, float giaNhap, float loiNhuan, float giaBan, int khuyenMai, 
            string img_url, int status)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = category;
            BrandId = brand;
            GiaNhap = giaNhap;
            LoiNhuan = loiNhuan;
            GiaBan = giaBan;
            KhuyenMai = khuyenMai;
            this.img_url = img_url;
            this.status = status;
        }
    }
}

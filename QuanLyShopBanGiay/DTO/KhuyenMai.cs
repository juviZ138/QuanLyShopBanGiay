using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class KhuyenMai
    {
        public string MaKM { get; set; }
        public string TenKM { get; set; }
        public float PhanTramGiam { get; set; }
        public float value { get; set; }
        public int status {  get; set; }
        public KhuyenMai() { } 
        public KhuyenMai(string maKM, string tenKM, float phanTramGiam, float value)
        {
            MaKM = maKM;
            TenKM = tenKM;
            PhanTramGiam = phanTramGiam;
            this.value = value;
            status = 1;
        }
    }
}

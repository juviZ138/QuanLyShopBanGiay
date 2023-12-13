using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public float total {  get; set; }
        public int point { get; set; }

        public KhachHang() { }
        public KhachHang(string maKH, string tenKH, string sDT, float total, int point)
        {
            MaKH = maKH;
            TenKH = tenKH;
            SDT = sDT;
            this.total = total;
            this.point = point;
        }
    }
}

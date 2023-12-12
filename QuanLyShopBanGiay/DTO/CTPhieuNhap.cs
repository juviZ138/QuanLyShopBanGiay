using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class CTPhieuNhap
    {
        public string MaPhieuNhap { get; set; } 
        public string MaSP { get; set; }
        public string MaSize { get; set; }
        public float GiaNhap { get; set; }
        public int soLuong { get; set; }

        public CTPhieuNhap() { }

        public CTPhieuNhap(string maPhieuNhap, string maSP, string maSize, float giaNhap, int soLuong)
        {
            MaPhieuNhap = maPhieuNhap;
            MaSP = maSP;
            MaSize = maSize;
            GiaNhap = giaNhap;
            this.soLuong = soLuong;
        }
    }
}

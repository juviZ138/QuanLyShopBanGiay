using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class CTHoaDon
    {
        public string MaHoaDon { get; set; }
        public string MaSP { get; set; }
        public string MaSize { get; set; }
        public float GiaBan { get; set; }
        public int soLuong { get; set; }

        public CTHoaDon() { }

        public CTHoaDon(string maPhieuNhap, string maSP, string maSize, float giaNhap, int soLuong)
        {
            MaHoaDon = maPhieuNhap;
            MaSP = maSP;
            MaSize = maSize;
            GiaBan = giaNhap;
            this.soLuong = soLuong;
        }
    }
}

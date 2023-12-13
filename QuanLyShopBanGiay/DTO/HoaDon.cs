using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class HoaDon
    {
        public string MaHoaDon { get; set; }
        public string MaNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public DateTime date { get; set; }
        public string MaKhuyenMai {  get; set; }
        public float TongCong { get; set; }
        public int status { get; set; }

        public HoaDon(string maHoaDon, string maNhanVien, string MaKH,DateTime date, string maKM, float tongCong, int status)
        {
            MaHoaDon = maHoaDon;
            MaNhanVien = maNhanVien;
            MaKhachHang = MaKH;
            this.date = date;
            MaKhuyenMai = maKM;
            TongCong = tongCong;
            this.status = status;
        }

        public HoaDon() { }
    }
}

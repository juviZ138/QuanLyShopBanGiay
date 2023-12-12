using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class PhieuNhap
    {
        public string MaPhieuNhap {  get; set; }
        public string MaNhanVien { get; set; }
        public DateTime date {  get; set; }
        public float TongCong { get; set; }
        public int status { get; set; }

        public PhieuNhap(string maPhieuNhap, string maNhanVien, DateTime date, float tongCong, int status)
        {
            MaPhieuNhap = maPhieuNhap;
            MaNhanVien = maNhanVien;
            this.date = date;
            TongCong = tongCong;
            this.status = status;
        }

        public PhieuNhap() { }
    }
}

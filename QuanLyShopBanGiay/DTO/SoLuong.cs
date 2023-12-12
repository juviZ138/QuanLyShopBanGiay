using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class SoLuong
    {
        public string MaSP { get; set; }
        public string MaSize { get; set; }
        public int soLuong { get; set; }

        public SoLuong() { }

        public SoLuong(string maSP,string size, int Quantity) {
            this.MaSP = maSP;
            this.MaSize = size;
            this.soLuong = Quantity;
        }
    }
}

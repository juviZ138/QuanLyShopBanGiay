using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class KhuyenMaiSP
    {
        public string KhuyenMaiId { get; set; }
        public string KhuyenMaiName { get; set; }
        public int PhanTramGiam {  get; set; }
        public KhuyenMaiSP(string KhuyenMaiId, string KhuyenMaiName, int PhanTramGiam)
        {
            this.KhuyenMaiId = KhuyenMaiId;
            this.KhuyenMaiName = KhuyenMaiName;
            this.PhanTramGiam = PhanTramGiam;
        }

        public KhuyenMaiSP() { }
    }
}

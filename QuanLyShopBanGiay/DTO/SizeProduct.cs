using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class SizeProduct 
    { 
        public string SizeId { get; set; }
        public string SizeName { get; set; }
        public int status {  get; set; }

        public SizeProduct() { }
        public SizeProduct(string sizeID, string sizeName, int status)
        {
            SizeId = sizeID;
            SizeName = sizeName;
            this.status = status;
        }

      

    }
}

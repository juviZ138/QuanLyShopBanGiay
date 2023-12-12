using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class Brand
    {
        public string BrandId { get; set; }
        public string BrandName { get; set; }

        public int status { get; set; }
        public Brand(string brandId, string brandName, int status)
        {
            BrandId = brandId;
            BrandName = brandName;
            this.status = status;
        }

        public Brand() { }

    }
}

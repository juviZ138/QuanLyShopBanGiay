using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class Category
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int status { get; set; }
        public Category(string id, string name, int status)
        {
            CategoryId = id;
            CategoryName = name;
            this.status = status;
        }

        public Category() { }

    }
}

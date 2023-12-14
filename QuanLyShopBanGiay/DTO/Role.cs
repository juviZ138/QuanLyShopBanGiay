using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class Role
    {
        public Role() { }
        public int role_id { get; set; }
        public string role_name { get; set; }
        public Role(int role_id, string role_name)
        {
            this.role_id = role_id;
            this.role_name = role_name;
        }
    }
}

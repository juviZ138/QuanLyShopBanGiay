using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class Users
    {
        public string getMa()
        {
            Random rd = new Random();
            int ma = rd.Next(1000, 9999);
            string a = "NV" + ma + "";
            return a;
        }
        public string user_id { get; set; }
        public string password { get; set; }
        public string full_name { get; set; }
        public string email {  get; set; } 
        public string phone { get; set; }
        public string cccd { get; set; }
        public string gender { get; set; }
        public string year_birth { get; set; }
        public string address { get; set; }
        public int role_id {  get; set; }
        public int isDeleted { get; set; }

        public Users(string user_id, string password, string full_name, string email, string phone, string cccd, string gender, string year_birth, string address, int role_id, int isDeleted)
        {
            this.user_id = user_id;
            this.password = password;
            this.full_name = full_name;
            this.email = email;
            this.phone = phone;
            this.cccd = cccd;
            this.gender = gender;
            this.year_birth = year_birth;
            this.address = address;
            this.role_id = role_id;
            this.isDeleted = isDeleted;
        }

        public Users() { }
    }

}



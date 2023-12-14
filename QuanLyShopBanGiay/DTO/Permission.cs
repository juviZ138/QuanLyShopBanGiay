using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.DTO
{
    public class Permission
    {
        public int id { get; set; }
        public string tenquyen { get; set; }
        public int isSale { get; set; }
        public int isBill { get; set; }
        public int isProduct { get; set; }
        public int isUser { get; set; }
        public int isReceive { get; set; }
        public int isPromo { get; set; }
        public int isCustomer { get; set; }
        public int isPermission { get; set; }

        public Permission(int id, string tenquyen, int isSale, int isBill, int isProduct, int isUser, int isReceive, int isPromo, int isCustomer, int isPermission) 
        { 
            this.id = id;
            this.tenquyen = tenquyen;
            this.isSale = isSale;
            this.isBill = isBill;
            this.isProduct = isProduct;
            this.isUser = isUser;
            this.isReceive = isReceive;
            this.isPromo = isPromo;
            this.isCustomer = isCustomer;
            this.isPermission = isPermission;
        }

        public Permission()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyShopBanGiay.DAO;
using QuanLyShopBanGiay.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QuanLyShopBanGiay.BUS
{
    public class RoleBLL
    {
        public RoleBLL() { }

        public List<Role> getRole()
        {

            RoleDAL roleDAL = new RoleDAL();
            List<Role> role = new List<Role>();
            role = roleDAL.getListRole();

            return role;
        }
    }
}

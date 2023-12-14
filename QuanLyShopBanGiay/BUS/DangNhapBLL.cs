using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLyShopBanGiay.DTO;

namespace QuanLyShopBanGiay.BUS
{
    public class DangNhapBLL
    {
        public static Users taiKhoanLogin = null;
        public Users getLogin(string TenTK, string MatKhau)
        {


            DangNhapDAL dangNhapDAL = new DangNhapDAL();
            taiKhoanLogin = dangNhapDAL.getTaiKhoan(TenTK, MatKhau);

            if (taiKhoanLogin == null)
            {
                return null;
            }
            else
            {
                return taiKhoanLogin;
            }


        }
    }
}

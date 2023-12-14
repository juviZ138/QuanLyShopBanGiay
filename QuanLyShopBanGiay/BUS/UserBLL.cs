using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyShopBanGiay.DTO;
using QuanLyShopBanGiay.DAO;

namespace QuanLyShopBanGiay.BUS
{
    public class UserBLL
    {
        public List<Users> listUser;
        public DataTable GetAllUser()
        {

            return UserDAL.GetAllUser();
        }
        public List<Users> getListUser()
        {
            UserDAL userDAL = new UserDAL();
            listUser = userDAL.getListUser();
            if (listUser != null)
            {
                return listUser;
            }
            else return listUser;
        }

        public List<Users> getListTimKiem0(string timkiem)
        {
            List<Users> listUserTimKiem = new List<Users>();
            UserDAL userDAL = new UserDAL();
            listUserTimKiem = userDAL.getListUserTimKiem(timkiem);

            if (listUserTimKiem != null)
            {
                return listUserTimKiem;
            }
            else return listUserTimKiem;
        }

        public List<Users> getListTimKiem(string timkiem)
        {
            List<Users> listUserTimKiem = new List<Users>();
            UserDAL userDAL = new UserDAL();
            List<Users> listUser1 = new List<Users>();
            listUser1 = userDAL.getListUser();
            for (int i = 0; i < listUser1.Count; i++)
            {
                if (listUser1[i].user_id.ToUpper().Contains(timkiem.ToUpper()))
                {
                    if (listUser1[i] != null)
                    {
                        listUserTimKiem.Add(listUser1[i]);
                    }


                }
                else if (listUser1[i].full_name.ToUpper().Contains(timkiem.ToUpper()))
                {
                    Users us1 = new Users();
                    us1 = listUser1[i];
                    listUserTimKiem.Add(us1);

                }

            }
            if (listUserTimKiem != null)
            {
                return listUserTimKiem;
            }
            else return listUserTimKiem;
        }

        public Boolean themUser(Users user)
        {

            UserDAL userDAL = new UserDAL();
            Boolean kt = userDAL.themUser(user);
            return kt;
        }

        public Boolean suaUser(Users user)
        {

            UserDAL userDAL = new UserDAL();
            Boolean kt = userDAL.suaUser(user);

            if (kt)
            {
                return kt;
            }
            return false;
        }

        public Boolean xoaUser(string userid)
        {

            UserDAL userDAL = new UserDAL();
            Boolean kt = userDAL.xoaUser(userid);

            if (kt)
            {
                return kt;
            }
            return false;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyShopBanGiay.DAO;
using QuanLyShopBanGiay.DTO;


namespace QuanLyShopBanGiay.BUS
{
    public class PermissionBLL
    {
        public static List<Permission> listPermission = null;

        public List<Permission> getListPermission()
        {
            PermissionDAL permissionDAL = new PermissionDAL();
            listPermission = permissionDAL.getListPermission();
            if (listPermission != null)
            {
                return listPermission;
            }
            else return listPermission;
        }

        public Boolean themQuyen(Permission prm)
        {

            PermissionDAL permissionDAL = new PermissionDAL();
            Boolean kt = permissionDAL.themPermission(prm);
            return kt;
        }

        public Boolean suaPermission(Permission prm)
        {

            PermissionDAL permissionDAL = new PermissionDAL();
            Boolean kt = permissionDAL.suaPermission(prm);
            return kt;
        }

        public Boolean xoaPermission(int id)
        {

            PermissionDAL permissionDAL = new PermissionDAL();
            Boolean kt = permissionDAL.xoaPermission(id);

            if (kt)
            {
                return kt;
            }
            return false;
        }
        public Permission GetItemPermission(int id)
        {
            PermissionDAL permissionDAL = new PermissionDAL();
            listPermission = permissionDAL.getListPermission();
            //List<int> result = new List<int>();
            Permission permissionItem = new Permission();
            for (int i = 0; i < listPermission.Count; i++)
            {
                if (listPermission[i].id == id)
                {
                    permissionItem = listPermission[i];
                }
            }
            return permissionItem;
        }
    }
}

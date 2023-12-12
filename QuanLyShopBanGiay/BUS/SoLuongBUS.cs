using QuanLyShopBanGiay.DAO;
using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShopBanGiay.BUS
{
    public class SoLuongBUS
    {
        private List<SoLuong> listSoLuong;
        private SoLuongDAO DAO = new SoLuongDAO();

        public SoLuongBUS()
        {
            listSoLuong = DAO.GetList();
        }

        public DataTable GetAllSoLuong()
        {
            return DAO.GetDataTable();
        }

        public List<SoLuong> GetSoLuong(string productID)
        {
            listSoLuong = DAO.GetList().FindAll(item => item.MaSP == productID);
            return listSoLuong;
        }

        public int CheckID(string ID)
        {
            SoLuong checkID = this.GetByID(ID);
            if (checkID != null)
            {
                return 0;
            }
            return 1;
        }

        public int CheckName(string Name)
        {
            SoLuong newCate = listSoLuong.Find(s => s.MaSP == Name);
            if (newCate == null)
            {
                return 1;
            }
            return 0;
        }

        public SoLuong GetByID(string brandID)
        {
            foreach (SoLuong x in listSoLuong)
            {
                if (x.MaSP == brandID)
                    return x;
            }
            return null;
        }

        public void AddSoLuong(SoLuong newCate)
        {
            listSoLuong.Add(newCate);
            DAO.Add(newCate);
        }

        public void UpdateSoLuong(SoLuong editCate, string ID)
        {
            SoLuong newCate = listSoLuong.Find(s => s.MaSP == ID);
            if (newCate != null)
            {
                newCate = editCate;
            }


            DAO.Edit(editCate, ID);
        }

        public int checkSoLuong(SoLuong ex,int SoLuong)
        {
            if(ex.soLuong >= SoLuong)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public void DeleteSoLuong(string cateID)
        {
            listSoLuong.Remove(GetByID(cateID));
            DAO.Delete(cateID);
        }
    }
 }

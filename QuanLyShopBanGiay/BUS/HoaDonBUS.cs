using QuanLyShopBanGiay.DAO;
using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanGiay.BUS
{
    public class HoaDonBUS
    {
        private List<HoaDon> listHoaDon;
        private HoaDonDAO HoaDonDAO = new HoaDonDAO();

        public HoaDonBUS()
        {
            listHoaDon = HoaDonDAO.GetList();
        }

        public DataTable GetAllHoaDon()
        {
            return HoaDonDAO.GetDataTable();
        }

        public List<HoaDon> GetHoaDon()
        {
            listHoaDon = HoaDonDAO.GetList();
            return listHoaDon;
        }

        public int CheckID(string ID)
        {
            HoaDon checkID = this.GetByID(ID);
            if (checkID != null)
            {
                return 0;
            }
            return 1;
        }

        //public int CheckName(string Name)
        //{
        //    HoaDon newHoaDon = listHoaDon.Find(s => s.HoaDonName == Name);
        //    if (newHoaDon == null)
        //    {
        //        return 1;
        //    }
        //    return 0;
        //}

        public HoaDon GetByID(string HoaDonID)
        {
            foreach (HoaDon x in listHoaDon)
            {
                if (x.MaHoaDon == HoaDonID)
                    return x;
            }
            return null;
        }

        public void AddHoaDon(HoaDon newHoaDon)
        {
            listHoaDon.Add(newHoaDon);
            HoaDonDAO.Add(newHoaDon);
        }

        public void UpdateHoaDon(HoaDon editHoaDon, string ID)
        {
            HoaDon newHoaDon = listHoaDon.Find(s => s.MaHoaDon == ID);
            if (newHoaDon != null)
            {

                newHoaDon = editHoaDon;
            }


            HoaDonDAO.Edit(editHoaDon, ID);
        }
    }


}
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
    public class CTHoaDonBUS
    {
        private List<CTHoaDon> listCTHoaDon;
        private CTHoaDonDAO DAO = new CTHoaDonDAO();

        public CTHoaDonBUS()
        {
            listCTHoaDon = DAO.GetList();
        }

        public DataTable GetAllCTHoaDon()
        {
            return DAO.GetDataTable();
        }

        public List<CTHoaDon> GetCTHoaDon(string productID)
        {
            listCTHoaDon = DAO.GetList().FindAll(item => item.MaHoaDon == productID);
            return listCTHoaDon;
        }

        public int CheckID(string ID)
        {
            CTHoaDon checkID = this.GetByID(ID);
            if (checkID != null)
            {
                return 0;
            }
            return 1;
        }


        public CTHoaDon GetByID(string brandID)
        {
            foreach (CTHoaDon x in listCTHoaDon)
            {
                if (x.MaHoaDon == brandID)
                    return x;
            }
            return null;
        }

        public void AddCTHoaDon(CTHoaDon ct)
        {
            listCTHoaDon.Add(ct);
            DAO.Add(ct);

            SoLuongBUS soLuongBUS = new SoLuongBUS();

            SoLuong sl = new SoLuong();
            sl.MaSP = ct.MaSP;
            sl.MaSize = ct.MaSize;
            sl.soLuong = ct.soLuong;

            SoLuong ex = soLuongBUS.GetSoLuong(sl.MaSP).Find(item => (item.MaSP == sl.MaSP) && (item.MaSize == sl.MaSize));
            
            sl.soLuong = ex.soLuong - ct.soLuong;
            soLuongBUS.UpdateSoLuong(sl, sl.MaSP);
        }

    }
}

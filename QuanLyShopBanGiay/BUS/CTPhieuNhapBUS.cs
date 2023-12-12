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
    public class CTPhieuNhapBUS
    {
        private List<CTPhieuNhap> listCTPhieuNhap;
        private CTPhieuNhapDAO DAO = new CTPhieuNhapDAO();

        public CTPhieuNhapBUS()
        {
            listCTPhieuNhap = DAO.GetList();
        }

        public DataTable GetAllCTPhieuNhap()
        {
            return DAO.GetDataTable();
        }

        public List<CTPhieuNhap> GetCTPhieuNhap(string productID)
        {
            listCTPhieuNhap = DAO.GetList().FindAll(item => item.MaPhieuNhap == productID);
            return listCTPhieuNhap;
        }

        public int CheckID(string ID)
        {
            CTPhieuNhap checkID = this.GetByID(ID);
            if (checkID != null)
            {
                return 0;
            }
            return 1;
        }


        public CTPhieuNhap GetByID(string brandID)
        {
            foreach (CTPhieuNhap x in listCTPhieuNhap)
            {
                if (x.MaPhieuNhap == brandID)
                    return x;
            }
            return null;
        }

        public void AddCTPhieuNhap(CTPhieuNhap ct)
        {
            listCTPhieuNhap.Add(ct);
            DAO.Add(ct);

            SoLuongBUS soLuongBUS = new SoLuongBUS();

            SoLuong sl = new SoLuong();
            sl.MaSP = ct.MaSP;
            sl.MaSize = ct.MaSize;
            sl.soLuong = ct.soLuong;

            SoLuong ex = soLuongBUS.GetSoLuong(sl.MaSP).Find(item => (item.MaSP == sl.MaSP) && (item.MaSize == sl.MaSize));
            if (ex == null)
            {
                soLuongBUS.AddSoLuong(sl);
                //MessageBox.Show("Sản Phẩm này ko  có");
            }
            else
            {
                sl.soLuong = ct.soLuong + ex.soLuong;
                soLuongBUS.UpdateSoLuong(sl, sl.MaSP);
                //MessageBox.Show("Sản Phẩm này đã  có");
            }
        }

    }
}

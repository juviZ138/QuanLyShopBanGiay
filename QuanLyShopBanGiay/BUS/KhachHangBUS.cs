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
    public class KhachHangBUS
    {
        private List<KhachHang> listKhachHang;
        private KhachHangDAO KhachHangDAO = new KhachHangDAO();

        public KhachHangBUS()
        {
            listKhachHang = KhachHangDAO.GetList();
        }

        public DataTable GetAllKhachHangs()
        {
            KhachHangDAO.GetDataTable();
            return KhachHangDAO.GetDataTable();
        }

        public List<KhachHang> GetKhachHangs()
        {
            listKhachHang = KhachHangDAO.GetList();
            return listKhachHang;
        }

        public int CheckID(string ID)
        {
            KhachHang checkID = this.GetByID(ID);
            if (checkID != null)
            {
                return 0;
            }
            return 1;
        }

        public int CheckPhone(string Phone)
        {
            KhachHang newKhachHang = listKhachHang.Find(s => s.SDT == Phone);
            if (newKhachHang == null)
            {
                return 1;
            }
            return 0;
        }

        public KhachHang GetByID(string KhachHangID)
        {
            foreach (KhachHang x in listKhachHang)
            {
                if (x.MaKH == KhachHangID)
                    return x;
            }
            return null;
        }

        public void AddKhachHang(KhachHang newKhachHang)
        {
            listKhachHang.Add(newKhachHang);
            KhachHangDAO.Add(newKhachHang);
        }

        public void UpdateKhachHang(KhachHang editKhachHang, string ID)
        {
            KhachHang newKhachHang = listKhachHang.Find(s => s.MaKH == ID);
            if (newKhachHang != null)
            {
                newKhachHang = editKhachHang;
            }


            KhachHangDAO.Edit(editKhachHang, ID);
        }
    }
}

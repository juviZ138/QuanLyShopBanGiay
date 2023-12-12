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
    public class PhieuNhapBUS
    {
        private List<PhieuNhap> listPhieuNhap;
        private PhieuNhapDAO PhieuNhapDAO = new PhieuNhapDAO();

        public PhieuNhapBUS()
        {
            listPhieuNhap = PhieuNhapDAO.GetList();
        }

        public DataTable GetAllPhieuNhap()
        {
            return PhieuNhapDAO.GetDataTable();
        }

        public List<PhieuNhap> GetPhieuNhap()
        {
            listPhieuNhap = PhieuNhapDAO.GetList();
            return listPhieuNhap;
        }

        public int CheckID(string ID)
        {
            PhieuNhap checkID = this.GetByID(ID);
            if (checkID != null)
            {
                return 0;
            }
            return 1;
        }

        //public int CheckName(string Name)
        //{
        //    PhieuNhap newPhieuNhap = listPhieuNhap.Find(s => s.PhieuNhapName == Name);
        //    if (newPhieuNhap == null)
        //    {
        //        return 1;
        //    }
        //    return 0;
        //}

        public PhieuNhap GetByID(string PhieuNhapID)
        {
            foreach (PhieuNhap x in listPhieuNhap)
            {
                if (x.MaPhieuNhap == PhieuNhapID)
                    return x;
            }
            return null;
        }

        public void AddPhieuNhap(PhieuNhap newPhieuNhap)
        {
            listPhieuNhap.Add(newPhieuNhap);
            PhieuNhapDAO.Add(newPhieuNhap);
        }

        public void UpdatePhieuNhap(PhieuNhap editPhieuNhap, string ID)
        {
            PhieuNhap newPhieuNhap = listPhieuNhap.Find(s => s.MaPhieuNhap == ID);
            if (newPhieuNhap != null)
            {

                newPhieuNhap = editPhieuNhap;
            }


            PhieuNhapDAO.Edit(editPhieuNhap, ID);
        }
    }
    
}


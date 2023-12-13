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
    public class KhuyenMaiBUS
    {
        private List<KhuyenMai> listKhuyenMai;
        private KhuyenMaiDAO KhuyenMaiDAO = new KhuyenMaiDAO();

        public KhuyenMaiBUS()
        {
            listKhuyenMai = KhuyenMaiDAO.GetList();
        }

        public DataTable GetAllKhuyenMai()
        {
            return KhuyenMaiDAO.GetDataTable();
        }

        public List<KhuyenMai> GetKhuyenMai()
        {
            listKhuyenMai = KhuyenMaiDAO.GetList();
            return listKhuyenMai;
        }

        public int CheckID(string ID)
        {
            KhuyenMai checkID = this.GetByID(ID);
            if (checkID != null)
            {
                return 0;
            }
            return 1;
        }

        public int CheckName(string Name)
        {
            KhuyenMai newKhuyenMai = listKhuyenMai.Find(s => s.TenKM == Name);
            if (newKhuyenMai == null)
            {
                return 1;
            }
            return 0;
        }

        public KhuyenMai GetByID(string KhuyenMaiID)
        {
            foreach (KhuyenMai x in listKhuyenMai)
            {
                if (x.MaKM == KhuyenMaiID)
                    return x;
            }
            return null;
        }

        public void AddKhuyenMai(KhuyenMai newKhuyenMai)
        {
            listKhuyenMai.Add(newKhuyenMai);
            KhuyenMaiDAO.Add(newKhuyenMai);
        }

        public void UpdateKhuyenMai(KhuyenMai editKhuyenMai, string ID)
        {
            KhuyenMai newKhuyenMai = listKhuyenMai.Find(s => s.MaKM == ID);
            if (newKhuyenMai != null)
            {
                newKhuyenMai = editKhuyenMai;
            }


            KhuyenMaiDAO.Edit(editKhuyenMai, ID);
        }


        public void DeleteKhuyenMai(string KhuyenMaiId)
        {
            listKhuyenMai.Remove(GetByID(KhuyenMaiId));
            KhuyenMaiDAO.Delete(KhuyenMaiId);
        }
    }
}

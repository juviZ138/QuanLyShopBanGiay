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
    public class SizeBUS
    {
        private List<SizeProduct> listSize;
        private SizeDAO cateDAO = new SizeDAO();

        public SizeBUS()
        {
            listSize = cateDAO.GetList();
        }

        public DataTable GetAllSize()
        {
            return cateDAO.GetDataTable();
        }

        public List<SizeProduct> GetSize()
        {
            listSize = cateDAO.GetList();
            return listSize;
        }

        public int CheckID(string ID)
        {
            SizeProduct checkID = this.GetByID(ID);
            if (checkID != null)
            {
                return 0;
            }
            return 1;
        }

        public int CheckName(string Name)
        {
            SizeProduct newCate = listSize.Find(s => s.SizeName == Name);
            if (newCate == null)
            {
                return 1;
            }
            return 0;
        }

        public SizeProduct GetByID(string brandID)
        {
            foreach (SizeProduct x in listSize)
            {
                if (x.SizeId == brandID)
                    return x;
            }
            return null;
        }

        public void AddSize(SizeProduct newCate)
        {
            listSize.Add(newCate);
            cateDAO.Add(newCate);
        }

        public void UpdateSize(SizeProduct editCate, string ID)
        {
            SizeProduct newCate = listSize.Find(s => s.SizeId == ID);
            if (newCate != null)
            {
                newCate.SizeId = editCate.SizeId;
                newCate.SizeName = editCate.SizeName;
            }


            cateDAO.Edit(editCate, ID);
        }


        public void DeleteSize(string cateID)
        {
            listSize.Remove(GetByID(cateID));
            cateDAO.Delete(cateID);
        }
    }
}


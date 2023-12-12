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
    public class CategoryBUS
    {
        private List<Category> listCategory;
        private CategoryDAO cateDAO = new CategoryDAO();

        public CategoryBUS()
        {
            listCategory = cateDAO.GetList();
        }

        public DataTable GetAllCategory()
        {
            return cateDAO.GetDataTable();
        }

        public List<Category> GetCategory()
        {
            listCategory = cateDAO.GetList();
            return listCategory;
        }

        public int CheckID(string ID)
        {
            Category checkID = this.GetByID(ID);
            if (checkID != null)
            {
                return 0;
            }
            return 1;
        }

        public int CheckName(string Name)
        {
            Category newCate = listCategory.Find(s => s.CategoryName == Name);
            if (newCate == null)
            {
                return 1;
            }
            return 0;
        }

        public Category GetByID(string brandID)
        {
            foreach (Category x in listCategory)
            {
                if (x.CategoryId == brandID)
                    return x;
            }
            return null;
        }

        public void AddCategory(Category newCate)
        {
            listCategory.Add(newCate);
            cateDAO.Add(newCate);
        }

        public void UpdateCategory(Category editCate, string ID)
        {
            Category newCate = listCategory.Find(s => s.CategoryId == ID);
            if (newCate != null)
            {
                newCate.CategoryId = editCate.CategoryId;
                newCate.CategoryName = editCate.CategoryName;
            }


            cateDAO.Edit(editCate,ID);
        }


        public void DeleteCategory(string cateID)
        {
            listCategory.Remove(GetByID(cateID));
            cateDAO.Delete(cateID);
        }
    }
}
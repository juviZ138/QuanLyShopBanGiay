using QuanLyShopBanGiay.DAO;
using QuanLyShopBanGiay.DTO;
using System.Collections.Generic;
using System.Data;


namespace QuanLyShopBanGiay.BUS
{
    public class BrandBUS
    {
        private List<Brand> listBrand;
        private BrandDAO brandDAO = new BrandDAO();

        public BrandBUS()
        {
            listBrand = brandDAO.GetList();
        }

        public DataTable GetAllBrands()
        {
            return brandDAO.GetDataTable();
        }
        
        public List<Brand> GetBrands() {
            listBrand = brandDAO.GetList();
            return listBrand;
        }

        public int CheckID(string ID)
        {
            Brand checkID = this.GetByID(ID);
            if(checkID != null)
            {
                return 0;
            }
            return 1;
        }

        public int CheckName(string Name)
        {
            Brand newBrand = listBrand.Find(s => s.BrandName == Name);
            if(newBrand == null)
            {
                return 1;
            }
            return 0;
        }

        public Brand GetByID(string brandID)
        {
            foreach(Brand x in listBrand)
            {
                if (x.BrandId == brandID)
                    return x;
            }
            return null;
        }

        public void AddBrand(Brand newBrand)
        {
           listBrand.Add(newBrand);
           brandDAO.Add(newBrand);
        }

        public void UpdateBrand(Brand editBrand,string ID)
        {   
            Brand newBrand = listBrand.Find(s => s.BrandId == ID);
            if(newBrand != null)
            {
                newBrand.BrandId = editBrand.BrandId;
                newBrand.BrandName = editBrand.BrandName;
            }


            brandDAO.Edit(editBrand,ID);
        }


        public void DeleteBrand(string brandId)
        {
            listBrand.Remove(GetByID(brandId));
            brandDAO.Delete(brandId);
        }
    }
}

using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShopBanGiay.GUI
{
    public partial class formTaoHoaDon : Form
    {
        ProductBUS productBUS = new ProductBUS();
        HoaDonBUS hoaDonBUS = new HoaDonBUS();
        CTHoaDonBUS chiTietBUS = new CTHoaDonBUS();
        SoLuongBUS soLuongBUS = new SoLuongBUS();
        CategoryBUS cateBUS = new CategoryBUS();
        BrandBUS brandBUS = new BrandBUS();
        public formTaoHoaDon()
        {
            InitializeComponent();
            LoadProduct();
        }

        public void LoadProduct()
        {
            panelProduct.Controls.Clear();

            List<Product> list = productBUS.GetProducts();

            foreach (Product product in list)
            {
                if (product.status != 0)
                {
                    ListItem item = new ListItem();
                    item.setMaSP(product.ProductId);
                    item.setName(product.ProductName);
                    string nameCate = cateBUS.GetByID(product.CategoryId).CategoryName;
                    item.setCate(nameCate);
                    string nameBrand = brandBUS.GetByID(product.BrandId).BrandName;
                    item.setThuongHieu(nameBrand);
                    item.setGiaNhap(product.GiaNhap.ToString());
                    item.setGiaBan(product.GiaBan.ToString());
                    item.setKM((product.GiaBan - product.GiaBan * product.KhuyenMai / 100).ToString());
                    item.LoadIMG(product.img_url);

                    item.ControlClicked += MyUserControl_ControlClicked;

                    panelProduct.Controls.Add(item);
                }

            }
        }

        public void LoadProduct(List<Product> listProduct)
        {
            panelProduct.Controls.Clear();

            // List<Product> list = productBUS.GetProducts();

            foreach (Product product in listProduct)
            {
                if (product.status != 0)
                {
                    ListItem item = new ListItem();
                    item.setMaSP(product.ProductId);
                    item.setName(product.ProductName);
                    string nameCate = cateBUS.GetByID(product.CategoryId).CategoryName;
                    item.setCate(nameCate);
                    string nameBrand = brandBUS.GetByID(product.BrandId).BrandName;
                    item.setThuongHieu(nameBrand);
                    item.setGiaNhap(product.GiaNhap.ToString());
                    item.setGiaBan(product.GiaBan.ToString());
                    item.setKM((product.GiaBan - product.GiaBan * product.KhuyenMai / 100).ToString());
                    item.LoadIMG(product.img_url);

                    item.ControlClicked += MyUserControl_ControlClicked;

                    panelProduct.Controls.Add(item);
                }

            }
        }

        public void MyUserControl_ControlClicked(object sender, string productID)
        {
            SoLuongBUS slBUS = new SoLuongBUS();
            SizeBUS sizeBUS = new SizeBUS();

            string ProductID = productID;

            List<SoLuong> list = slBUS.GetSoLuong(ProductID);

            Product currentProduct = productBUS.GetByID(ProductID);

            txtTenSP.Text = currentProduct.ProductName;
            txtGiaBan.Text = currentProduct.GiaBan.ToString();

            lvSoLuong.Items.Clear();
            foreach (SoLuong item in list)
            {

                SizeProduct SizeName = sizeBUS.GetByID(item.MaSize.ToString());

                ListViewItem sl = new ListViewItem(SizeName.SizeName.ToString());
                sl.SubItems.Add(item.soLuong.ToString());
                lvSoLuong.Items.Add(sl);
            }

            MessageBox.Show("Đã Chọn Sản Phẩm: " + txtTenSP.Text);
        }

        public void AutoID()
        {
            DataTable dt = hoaDonBUS.GetAllHoaDon();

            string s = "";
            if (dt.Rows.Count <= 0)
            {
                s = "HD001";
            }
            else
            {
                int k;
                s = "HD";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    s = s + "00";
                }
                else if (k < 100)
                {
                    s = s + "0";
                }
                s = s + k.ToString();
            }
            txtMaHD.Text = s;

        }



    }
}

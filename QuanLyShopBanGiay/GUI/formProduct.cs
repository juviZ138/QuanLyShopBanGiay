using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DAO;
using QuanLyShopBanGiay.DTO;
using QuanLyShopBanGiay.GUI.subForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyShopBanGiay.GUI
{
    public partial class formProduct : Form
    {
        private ProductBUS productBUS = new ProductBUS();
        string imagePath;
        private List<Product> ListProduct = new List<Product>();
        private List<Product> FilterDM;

        public formProduct()
        {    
            InitializeComponent();
            viewProduct();
            loadBrand(cbThuongHieu); loadBrand(cbFilterTH);
            loadCate(cbDanhMuc); loadCate(cbFilterDM);
            cbTimKiem.SelectedIndex = 0;
            cbSapXep.SelectedIndex = 0;
            cbFilter.SelectedIndex = 0;
        }



        string checkLogic()
        {
            string str = "";
            int i = 1;
            float x;
            if (txtTenSP.Text == "" || txtGiaNhap.Text == "" || txtKM.Text == "" || txtLoiNhuan.Text == "" || pictureBox1.Image == null)
            {
                str += "\nVui lòng nhập đầy đủ dữ liệu !!!!";
                return str;
            }

            if (!float.TryParse(txtGiaBan.Text, out x))
            {
                str += "\nGiá Bán Phải là con số !!!";
                return str;
            }
            if (!float.TryParse(txtGiaNhap.Text, out x))
            {
                str += "\nGiá Nhập Phải là con số !!!";
                return str;
            }
            if (!int.TryParse(txtLoiNhuan.Text, out i))
            {
                str += "\nLợi nhuận Phải là con số !!!";
                return str;
            }
            if (!int.TryParse(txtKM.Text, out i))
            {
                str += "\nKhuyến mãi Phải là con số !!!";
                return str;
            }
            if (int.Parse(txtLoiNhuan.Text) < 0)
            {
                str += "\nLợi nhuận phải lớn hoặc bằng 0 !!!";
                return str;
            }
            if (float.Parse(textBox1.Text) < float.Parse(txtGiaNhap.Text))
            {
                str += "\nGiá Bán Thấp hơn giá nhập!!!";
                return str;
            }

            return str;
        }

        private void loadBrand(System.Windows.Forms.ComboBox cb)
        {
            cb.DataSource = null;
            BrandBUS brandBUS = new BrandBUS();

            DataTable allBrands = brandBUS.GetAllBrands();

            DataTable filteredBrands = allBrands.AsEnumerable()
                .Where(row => row.Field<int>("status") != 0)
                .CopyToDataTable();

            cb.DataSource = filteredBrands;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
        }

        private void loadCate(System.Windows.Forms.ComboBox cb)
        {
            cb.DataSource = null;
            CategoryBUS categoryBUS = new CategoryBUS();


            DataTable allCate = categoryBUS.GetAllCategory();

            DataTable filteredBrands = allCate.AsEnumerable()
                .Where(row => row.Field<int>("status") != 0)
                .CopyToDataTable();

            cb.DataSource = filteredBrands;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
        }

        public void viewProduct()
        {
            lvProduct.Items.Clear();
            foreach (Product product in ListProduct = productBUS.GetProducts())
            {
                ListViewItem item = new ListViewItem(product.ProductId);
                item.SubItems.Add(product.ProductName);
                item.SubItems.Add(product.CategoryId);
                item.SubItems.Add(product.BrandId);
                item.SubItems.Add(product.GiaNhap.ToString());
                item.SubItems.Add(product.LoiNhuan.ToString());
                item.SubItems.Add(product.GiaBan.ToString());
                item.SubItems.Add(product.KhuyenMai.ToString());
                item.SubItems.Add(product.img_url.ToString());
                if (product.status == 0)
                {
                    item.SubItems.Add("Ngừng Kinh Doanh");
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.SubItems.Add("Đang Kinh Doanh");
                }

                lvProduct.Items.Add(item);
            }
        }

        public void filterViewProduct(List<Product> items)
        {
            lvProduct.Items.Clear();
            foreach (Product product in items)
            {
                ListViewItem item = new ListViewItem(product.ProductId);
                item.SubItems.Add(product.ProductName);
                item.SubItems.Add(product.CategoryId);
                item.SubItems.Add(product.BrandId);
                item.SubItems.Add(product.GiaNhap.ToString());
                item.SubItems.Add(product.LoiNhuan.ToString());
                item.SubItems.Add(product.GiaBan.ToString());
                item.SubItems.Add(product.KhuyenMai.ToString());
                item.SubItems.Add(product.img_url.ToString());
                if (product.status == 0)
                {
                    item.SubItems.Add("Ngừng Kinh Doanh");
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.SubItems.Add("Đang Kinh Doanh");
                }

                lvProduct.Items.Add(item);
            }
        }



        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            addProduct addForm = new addProduct();
            addForm.Show();
        }



        public void LoadProductSize()
        {
            SoLuongBUS slBUS = new SoLuongBUS();
            SizeBUS sizeBUS = new SizeBUS();


            if(lvProduct.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvProduct.SelectedItems[0];
                string ProductID = selectedItem.SubItems[0].Text;

                List<SoLuong> list = slBUS.GetSoLuong(ProductID) ;

                lvSoLuong.Items.Clear();
                foreach (SoLuong item in list)
                {

                   SizeProduct SizeName = sizeBUS.GetByID(item.MaSize.ToString());

                   ListViewItem sl = new ListViewItem(SizeName.SizeName.ToString());
                   sl.SubItems.Add(item.soLuong.ToString()); 
                   lvSoLuong.Items.Add(sl);
                }
            }
        }


        private void listProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProduct.SelectedItems.Count > 0)
            {
                LoadProductSize();
                ListViewItem selectedItem = lvProduct.SelectedItems[0];
                txtMaSP.Text = selectedItem.SubItems[0].Text;
                txtTenSP.Text = selectedItem.SubItems[1].Text;
                cbDanhMuc.SelectedValue = selectedItem.SubItems[2].Text;
                cbThuongHieu.SelectedValue = selectedItem.SubItems[3].Text;
                txtGiaNhap.Text = selectedItem.SubItems[4].Text;
                txtLoiNhuan.Text = selectedItem.SubItems[5].Text;
                txtGiaBan.Text = selectedItem.SubItems[6].Text;
                txtKM.Text = selectedItem.SubItems[7].Text;
                // btnSua.Enabled = true;
            }
            else
            {
                // btnSua.Enabled = false;
            }

            try
            {
                string imgPath = lvProduct.SelectedItems[0].SubItems[8].Text;
                pictureBox1.Image = new Bitmap(imgPath);
                imagePath = imgPath;
            }
            catch (ArgumentException)
            {

            }
        }


        private void formProduct_Load(object sender, EventArgs e)
        {

        }



        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                // Lấy đường dẫn của ảnh đã chọn
                imagePath = openFileDialog1.FileName;
                try
                {
                    // Tải ảnh lên PictureBox
                    pictureBox1.Image = new System.Drawing.Bitmap(imagePath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                }
            }
        }

      

        private void button2_Click_1(object sender, EventArgs e)
        {
            string validate = checkLogic();

            if (validate != "")
            {
                MessageBox.Show(validate);
                return;
            }


            try
            {
                if (lvProduct.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvProduct.SelectedItems[0];
                    string ID = item.SubItems[0].Text;
                    Product editProduct = new Product(txtMaSP.Text, txtTenSP.Text, cbDanhMuc.SelectedValue.ToString(), cbThuongHieu.SelectedValue.ToString()
                    , float.Parse(txtGiaNhap.Text), float.Parse(txtLoiNhuan.Text), float.Parse(txtGiaBan.Text), int.Parse(txtKM.Text), imagePath,
                    1);
                    productBUS.UpdateProduct(editProduct, ID);
                    MessageBox.Show("Sửa thành công");
                    viewProduct();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng cần sửa");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công ");
                }
            };
        }

        private void txtGiaNhap_TextChanged_1(object sender, EventArgs e)
        {
            updateGiaBan();
            updateKM();
        }

        private void txtLoiNhuan_TextChanged_1(object sender, EventArgs e)
        {
            updateGiaBan();
            updateKM();
        }

        private void txtKM_TextChanged_1(object sender, EventArgs e)
        {
            updateKM();
        }


        private void btnDeleteBrand_Click_1(object sender, EventArgs e)
        {
            if (lvProduct.SelectedItems[0].BackColor != Color.Red)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn ngừng kinh doanh sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra kết quả từ hộp thoại
                if (result == DialogResult.Yes)
                {

                    if (lvProduct.SelectedItems.Count > 0)
                    {
                        ListViewItem item = lvProduct.SelectedItems[0];
                        string ID = item.SubItems[0].Text;
                        Product editProduct = new Product(txtMaSP.Text, txtTenSP.Text, cbDanhMuc.SelectedValue.ToString(), cbThuongHieu.SelectedValue.ToString()
                        , float.Parse(txtGiaNhap.Text), float.Parse(txtLoiNhuan.Text), float.Parse(txtGiaBan.Text), int.Parse(txtKM.Text), imagePath,
                        0);

                        productBUS.UpdateProduct(editProduct, ID);
                        viewProduct();
                        MessageBox.Show("Đã ngừng kinh doanh mục này");
                        
        

                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn dòng cần thực hiện");
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn tiếp tục kinh doanh mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra kết quả từ hộp thoại
                if (result == DialogResult.Yes)
                {

                    if (lvProduct.SelectedItems.Count > 0)
                    {
                        ListViewItem item = lvProduct.SelectedItems[0];
                        string ID = item.SubItems[0].Text;
                        Product editProduct = new Product(txtMaSP.Text, txtTenSP.Text, cbDanhMuc.SelectedValue.ToString(), cbThuongHieu.SelectedValue.ToString()
                        , float.Parse(txtGiaNhap.Text), float.Parse(txtLoiNhuan.Text), float.Parse(txtGiaBan.Text), int.Parse(txtKM.Text), imagePath,
                        1);

                        productBUS.UpdateProduct(editProduct, ID);
                        viewProduct();
                        MessageBox.Show("Đã tiếp tục kinh doanh mục này");
                        
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn dòng cần thực hiện");
                    }
                }
            }
        }


        void updateGiaBan()
        {
            try
            {
                if (txtGiaNhap.Text == "" || txtLoiNhuan.Text == "")
                {

                }
                else
                {
                    float a = float.Parse(txtGiaNhap.Text);
                    int b = int.Parse(txtLoiNhuan.Text);
                    float c = a + (a * b / 100);
                    txtGiaBan.Text = c.ToString();
                }
            }
            catch (Exception ex)
            {

            }

        }

        void updateKM()
        {
            try
            {
                if (txtKM.Text == "" || txtGiaBan.Text == "")
                {

                }
                else
                {
                    float a = float.Parse(txtGiaBan.Text);
                    int b = int.Parse(txtKM.Text);
                    float c = a - (a * b / 100);
                    textBox1.Text = c.ToString();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }


        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            updateGiaBan();
            updateKM();
        }

        private void txtLoiNhuan_TextChanged(object sender, EventArgs e)
        {
            updateGiaBan();
            updateKM();
        }

        private void txtKM_TextChanged(object sender, EventArgs e)
        {
            updateKM();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fromBrand f = new fromBrand();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formCate f = new formCate();
            f.ShowDialog();
        }

        private void formProduct_Click(object sender, EventArgs e)
        {
            //viewProduct();
            loadBrand(cbThuongHieu);
            loadCate(cbDanhMuc);
        }
      

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 0)
            {
                ListProduct = productBUS.GetProducts();
                filterViewProduct(ListProduct);
            }

            if(cbFilter.SelectedIndex == 1)
            {
                ListProduct = productBUS.GetProducts().FindAll(item => item.status == 1);

                // Hiển thị dữ liệu lọc
                filterViewProduct(ListProduct);
            }


            if (cbFilter.SelectedIndex == 2)
            {
                ListProduct = productBUS.GetProducts().FindAll(item => item.status == 0);

                // Hiển thị dữ liệu lọc
                filterViewProduct(ListProduct);
            }


        }

        private void cbFilterDM_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        public void Filtering()
        {
            if(checkBox1.Checked && !checkBox2.Checked)
            {
                FilterDM = ListProduct.FindAll(item => item.CategoryId == cbFilterDM.SelectedValue.ToString());
            }else if(!checkBox1.Checked && checkBox2.Checked)
            {
                FilterDM = ListProduct.FindAll(item => item.BrandId == cbFilterTH.SelectedValue.ToString());
            }
            else
            {
                FilterDM = ListProduct.FindAll(item => item.CategoryId == cbFilterDM.SelectedValue.ToString() && item.BrandId == cbFilterTH.SelectedValue.ToString());
            }
      
            
            if(FilterDM.Count > 0) {
                filterViewProduct(FilterDM);
            }
            else
            {
                lvProduct.Items.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Filtering();
        }


        public class productIDComaper : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                return x.ProductId.CompareTo(y.ProductId);
            }
        }

        public class productNameComaper : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                return x.ProductName.CompareTo(y.ProductName);
            }
        }

        public class productGiaNhapComaper : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                return x.GiaNhap.CompareTo(y.GiaNhap);
            }
        }

        public class productGiaBanComaper : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                return x.GiaBan.CompareTo(y.GiaBan);
            }
        }


        private void cbSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Product> ListSorting = getCurrentList();
            
            if(cbTimKiem.SelectedIndex == 0) {
                ListSorting.Sort(new productIDComaper());
            }
            else if (cbTimKiem.SelectedIndex == 1)
            {
                ListSorting.Sort(new productNameComaper());
            }else if(cbTimKiem.SelectedIndex == 2)
            {
                ListSorting.Sort(new productGiaNhapComaper());
            }
            else
            {
                ListSorting.Sort(new productGiaBanComaper());
            }




            if (cbSapXep.SelectedIndex == 1)
            {
                ListSorting.Reverse();
                filterViewProduct(ListSorting);
                
            }
            else
            {
                filterViewProduct(ListSorting);
            }


        }


        public List<Product> getCurrentList()
        {
            List<Product> list = new List<Product>();

            foreach(ListViewItem item in lvProduct.Items)
            {
                Product newProduct = new Product(item.SubItems[0].Text,
                    item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, float.Parse(item.SubItems[4].Text),
                    float.Parse(item.SubItems[5].Text), float.Parse(item.SubItems[6].Text),
                    int.Parse(item.SubItems[7].Text), item.SubItems[8].Text, 1);
                if (item.BackColor == Color.Red)
                {
                    newProduct.status = 0;
                }
                list.Add(newProduct);
            }


            return list;
        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            if (txtBrand.Text == "")
            {
                viewProduct();
            }
            string filterCategory = txtBrand.Text;
            if (cbTimKiem.SelectedIndex == 0)
            {

                List<Product> filteredItems = getCurrentList().FindAll(item => item.ProductId.ToUpper().Contains(filterCategory.ToUpper()));

                // Hiển thị dữ liệu lọc
                filterViewProduct(filteredItems);
            }
            else
            {
                List<Product> filteredItems = getCurrentList().FindAll(item => item.ProductName.ToUpper().Contains(filterCategory.ToUpper()));

                // Hiển thị dữ liệu lọc
                filterViewProduct(filteredItems);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cbFilterDM.Enabled = true;
            }
            else
            {
                cbFilterDM.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                cbFilterTH.Enabled = true;
            }
            else
            {
                cbFilterTH.Enabled = false;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewProduct();
            loadBrand(cbThuongHieu); loadBrand(cbFilterTH);
            loadCate(cbDanhMuc); loadCate(cbFilterDM);
            cbTimKiem.SelectedIndex = 0;
            cbSapXep.SelectedIndex = 0;
            cbFilter.SelectedIndex = 0;
        }
    }
}

using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DTO;
using QuanLyShopBanGiay.GUI.subForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        KhuyenMaiBUS khuyenMaiBUS = new KhuyenMaiBUS();
        KhachHangBUS khachHangBUS = new KhachHangBUS();
        public formTaoHoaDon()
        {
            InitializeComponent();
            LoadProduct();
            loadSize();
            AutoID();
            loadBrand(cbFilterTH);
            loadCate(cbFilterDM);
            cbTimKiem.SelectedIndex = 0;
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

        public void MyUserControl_ControlClicked(object sender, string productID)
        {
            SoLuongBUS slBUS = new SoLuongBUS();
            SizeBUS sizeBUS = new SizeBUS();

            string ProductID = productID;

            List<SoLuong> list = slBUS.GetSoLuong(ProductID);

            Product currentProduct = productBUS.GetByID(ProductID);

            txtMaSP.Text = currentProduct.ProductId;
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
            Users users = formMain.user;

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
            txtMaNV.Text = users.user_id;
        }

        private void loadSize()
        {
            SizeBUS categoryBUS = new SizeBUS();

            cbSize.DataSource = categoryBUS.GetAllSize().DefaultView;
            cbSize.DisplayMember = "name";
            cbSize.ValueMember = "id";
            cbSize.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {

                foreach (ListViewItem ex in listView1.Items)
                {
                    if (ex.SubItems[0].Text == txtMaSP.Text && ex.SubItems[1].Text == cbSize.SelectedValue.ToString())
                    {
                        MessageBox.Show("Đã có trong phiếu Nhập");
                        return;
                    }
                }

            }

            if (txtSoLuong.Value <= 0)
            {
                MessageBox.Show("Số Lượng Phải Lớn Hơn 0");
                txtSoLuong.Focus();
                return;
            }

            SoLuong sl = new SoLuong();
            sl.MaSP = txtMaSP.Text;
            sl.MaSize = cbSize.SelectedValue.ToString();
            sl.soLuong = int.Parse(txtSoLuong.Value.ToString());

            SoLuong check = soLuongBUS.GetSoLuong(sl.MaSP).Find(i => (i.MaSP == sl.MaSP) && (i.MaSize == sl.MaSize));

            if (check == null)
            {
                MessageBox.Show("Sản Phẩm này ko có Size Này");
                return;
            }
            
            if(soLuongBUS.checkSoLuong(check,sl.soLuong) == 0)
            {
                MessageBox.Show("Vượt quá số lượng có trong kho");
                return;
            }

            ListViewItem item = new ListViewItem(txtMaSP.Text);
            item.SubItems.Add(cbSize.SelectedValue.ToString());
            item.SubItems.Add(txtGiaBan.Text);
            item.SubItems.Add(txtSoLuong.Text);
            item.SubItems.Add((int.Parse(txtSoLuong.Text.ToString()) * float.Parse(txtGiaBan.Text.ToString())).ToString());

            listView1.Items.Add(item);

            txtSoLuong.Value = 0;
            updateTongCong();


        }
        public void updateTongCong()
        {
            int tong = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                tong += int.Parse(item.SubItems[4].Text);
            }
            txtTotal.Text = tong.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                if (txtSoLuong.Value < 0)
                {
                    MessageBox.Show("Số Lượng phải lớn hơn 0");
                    return;
                }

                if (txtSoLuong.Text == item.SubItems[2].Text)
                {
                    MessageBox.Show("Vui lòng thay đổi số lượng");
                    return;
                }

                SoLuong sl = new SoLuong();
                sl.MaSP = txtMaSP.Text;
                sl.MaSize = cbSize.SelectedValue.ToString();
                sl.soLuong = int.Parse(txtSoLuong.Value.ToString());

                SoLuong check = soLuongBUS.GetSoLuong(sl.MaSP).Find(i => (i.MaSP == sl.MaSP) && (i.MaSize == sl.MaSize));

                if (check == null)
                {
                    MessageBox.Show("Sản Phẩm này ko có Size Này");
                    return;
                }

                if (soLuongBUS.checkSoLuong(check, sl.soLuong) == 0)
                {
                    MessageBox.Show("Vượt quá số lượng có trong kho");
                    return;
                }

                item.SubItems[2].Text = txtSoLuong.Text;
                item.SubItems[4].Text = ((int.Parse(txtSoLuong.Text.ToString()) * float.Parse(txtGiaBan.Text.ToString())).ToString());
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa ");
            }

            chkBPoint.Checked = false;
            updateTongCong();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];

                Product product = productBUS.GetByID(item.SubItems[0].Text);

                txtTenSP.Text = product.ProductName;
                txtMaSP.Text = product.ProductId;
                txtGiaBan.Text = product.GiaNhap.ToString();

                cbSize.SelectedValue = item.SubItems[1].Text;
                txtSoLuong.Value = int.Parse(item.SubItems[3].Text);



            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices.Count - 1);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa");
            }

            updateTongCong();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if(txtSDT.Text != "")
            {
                KhachHangBUS khachHangBUS = new KhachHangBUS();

                KhachHang x = khachHangBUS.GetKhachHangs().Find(i => i.SDT == txtSDT.Text);            

                if(x != null)
                {
                     txtTenKH.Text = x.TenKH;
                     txtPoint.Text = x.point.ToString();
                }
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(txtTenKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Khách hàng");
                txtSDT.Focus();
                return;

            }


            if(chkBPoint.Checked)
            {
                float c = float.Parse(txtThanhTien.Text) - float.Parse(txtPoint.Text)*1000;
                if (c <= 0)
                    txtThanhTien.Text = "0";
                else txtThanhTien.Text = c.ToString();
                //txtPoint.Enabled = true;
            }
            else
            {
                //txtPoint.Enabled = false;
                UpdateDiscount();
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text = txtTotal.Text;
            UpdateDiscount();
        }

        private void UpdateDiscount()
        {
            // Get the entered amount from the TextBox
            if (float.TryParse(txtTotal.Text, out float enteredAmount))
            {
                // Find the highest applicable promotion
                KhuyenMai highestPromotion = khuyenMaiBUS.GetKhuyenMai()
                    .Where(promotion => enteredAmount >= promotion.value)
                    .OrderByDescending(promotion => promotion.PhanTramGiam)
                    .FirstOrDefault();

                // Calculate the discounted amount
                float discountedAmount = enteredAmount - (enteredAmount * highestPromotion.PhanTramGiam/ 100);

                // Display the discounted amount in another TextBox
                txtThanhTien.Text = discountedAmount.ToString();
                txtMaKM.Text = highestPromotion.MaKM;
                txtTenKM.Text = highestPromotion.TenKM;
            }
            else
            {
                // Handle invalid input (non-numeric)
                txtThanhTien.Text = "Invalid Input";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng");
                txtSDT.Focus();
                return; 
            }

            if(listView1.Items.Count <= 0)
            {
                MessageBox.Show("Giỏ hàng trống");
                return;
            }


            DialogResult result = MessageBox.Show("Xác nhận tạo hóa đơn", "Thông báo", MessageBoxButtons.YesNo);

            // Kiểm tra kết quả
            if (result == DialogResult.No)
            {
                return;
            }

          


            HoaDon hd = new HoaDon();
            hd.MaHoaDon = txtMaHD.Text;
            hd.MaNhanVien = txtMaNV.Text;
            hd.MaKhachHang = khachHangBUS.GetKhachHangs().Find(i => i.SDT == txtSDT.Text).MaKH;
            hd.date = DateTime.Now;
            hd.MaKhuyenMai = txtMaKM.Text;
            hd.TongCong = float.Parse(txtThanhTien.Text);
            hd.status = 1;

            hoaDonBUS.AddHoaDon(hd);

            KhachHang kh =  khachHangBUS.GetByID(hd.MaKhachHang);
            if (chkBPoint.Checked)
            {
                kh.point = 0;
            }

            kh.point = kh.point + (int)(hd.TongCong/10000);
            
            kh.total += hd.TongCong;
            khachHangBUS.UpdateKhachHang(kh, kh.MaKH);


            foreach (ListViewItem item in listView1.Items)
            {
                CTHoaDon ct = new CTHoaDon();
                ct.MaHoaDon = hd.MaHoaDon;
                ct.MaSP = item.SubItems[0].Text;
                ct.MaSize = item.SubItems[1].Text;
                ct.soLuong = int.Parse(item.SubItems[2].Text);
                ct.GiaBan = float.Parse(item.SubItems[3].Text);

                chiTietBUS.AddCTHoaDon(ct);
            }


            DialogResult result2 = MessageBox.Show("Xác nhận in hóa đơn", "Thông báo", MessageBoxButtons.YesNo);

            // Kiểm tra kết quả
            if (result2 == DialogResult.No)
            {
                ResetForm();
                return;

            }
            else
            {
                printPDF(hd, chiTietBUS.GetCTHoaDon(txtMaHD.Text));
                ResetForm();
            }


        }

    


        private void printPDF(HoaDon pn, List<CTHoaDon> ListCT)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (PdfWriter writer = new PdfWriter(stream, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        byte[] fontData = File.ReadAllBytes("C:\\Users\\Admin\\Desktop\\Do_An_C#\\QuanLyShopBanGiay\\QuanLyShopBanGiay\\vuArial.ttf");
                        PdfFont font = PdfFontFactory.CreateFont(fontData, PdfEncodings.IDENTITY_H);


                        Document document = new Document(pdf);
                        document.SetFont(font);

                        KhachHang kh = khachHangBUS.GetByID(pn.MaKhachHang);

                        // Thêm thông tin hóa đơn vào tài liệu PDF
                        document.Add(new Paragraph($"Mã Hóa Đơnp: {pn.MaHoaDon}"));
                        document.Add(new Paragraph($"Mã Nhân Viên Nhập: {pn.MaNhanVien}"));
                        document.Add(new Paragraph($"Khách Hàng: {kh.MaKH} SĐT: {kh.SDT}"));
                        document.Add(new Paragraph($"Ngày Nhập: {pn.date}"));
                        document.Add(new Paragraph($"Giá Ban Đầu: {txtTotal.Text}"));
                        document.Add(new Paragraph($"Khuyến Mãi: {txtTenKM.Text} + Điểm Thưởng: {txtPoint.Text}"));
                        document.Add(new Paragraph($"Tổng Tiền:{pn.TongCong}"));
                        document.Add(new Paragraph("-----------------------------"));
                        document.Add(new Paragraph("Danh Sách Sản Phẩm: "));
                        // Thêm bảng cho chi tiết hóa đơn
                        Table table = new Table(5);
                        table.AddHeaderCell("Mã Sản Phẩm");
                        table.AddHeaderCell("Mã Size");
                        table.AddHeaderCell("Số Lượng");
                        table.AddHeaderCell("Đơn Giá");
                        table.AddHeaderCell("Thành Tiền");

                        foreach (CTHoaDon ct in ListCT)
                        {
                            table.AddCell(ct.MaSP);
                            table.AddCell(ct.MaSize);
                            table.AddCell(ct.soLuong.ToString());
                            table.AddCell(ct.GiaBan.ToString());
                            float c = ct.soLuong * ct.GiaBan;
                            table.AddCell(c.ToString());
                        }

                        document.Add(table);
                    }


                }


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = pn.MaHoaDon + ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lưu trữ dữ liệu PDF từ MemoryStream vào tệp tin đã chọn
                    File.WriteAllBytes(saveFileDialog.FileName, stream.ToArray());
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                cbFilterDM.Enabled = true;
            }
            else
            {
                cbFilterDM.Enabled = false;
            }
            Filtering();
        }

        public void Filtering()
        {
            List<Product> FilterDM = new List<Product>();
            List<Product> ListProduct = productBUS.GetProducts().Where(item => item.status != 0).ToList();

            if (cbFilterDM.Enabled == false && cbFilterTH.Enabled == false)
            {
                LoadProduct();
                return;
            }


            if (checkBox1.Checked && !checkBox2.Checked)
            {
                FilterDM = ListProduct.FindAll(item => item.CategoryId == cbFilterDM.SelectedValue.ToString());
            }
            else if (!checkBox1.Checked && checkBox2.Checked)
            {
                FilterDM = ListProduct.FindAll(item => item.BrandId == cbFilterTH.SelectedValue.ToString());
            }
            else
            {
                FilterDM = ListProduct.FindAll(item => item.CategoryId == cbFilterDM.SelectedValue.ToString() && item.BrandId == cbFilterTH.SelectedValue.ToString());
            }


            if (FilterDM.Count > 0)
            {
                LoadProduct(FilterDM);
            }
            else
            {
                panelProduct.Controls.Clear();
                // LoadProduct();
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
            Filtering();

        }

        private void cbFilterDM_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void cbFilterTH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetForm();
            
        }

        void ResetForm()
        {
            LoadProduct();
            loadSize();
            AutoID();
            cbTimKiem.SelectedIndex = 0;
            listView1.Items.Clear();
            lvSoLuong.Items.Clear();
            txtMaSP.Text = "";
            txtSoLuong.Text = "";
            txtGiaBan.Text = "";
            txtTenSP.Text = "";
            txtTotal.Text = "Tổng Tiền";
            txtThanhTien.Text = "Thành Tiền";
            txtSDT.Text = "";
            txtTenKH.Text = "";
            txtMaKM.Text = "";
            txtTenKM.Text = "";
        }

        private void chkBPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Khách hàng");
                txtSDT.Focus();
                return;

            }


            if (chkBPoint.Checked)
            {
                UpdateDiscount();
                if(txtPoint.Text  == "0")
                {
                    MessageBox.Show("Không có điểm thưởng");
                    chkBPoint.Checked = false;
                    return;
                }
                float c = float.Parse(txtThanhTien.Text) - float.Parse(txtPoint.Text) * 1000;
                if (c <= 0)
                    txtThanhTien.Text = "0";
                else txtThanhTien.Text = c.ToString();
                //txtPoint.Enabled = true;
            }
            else
            {
                //txtPoint.Enabled = false;
                UpdateDiscount();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addCustomer f = new addCustomer();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtBrand.Text == "")
            {
                LoadProduct();
            }
            string filterCategory = txtBrand.Text;
            if (cbTimKiem.SelectedIndex == 0)
            {

                List<Product> filteredItems = productBUS.GetProducts().FindAll(item => item.ProductId.ToUpper().Contains(filterCategory.ToUpper()));

                // Hiển thị dữ liệu lọc
                LoadProduct(filteredItems);
            }
            else
            {
                List<Product> filteredItems = productBUS.GetProducts().FindAll(item => item.ProductName.ToUpper().Contains(filterCategory.ToUpper()));

                // Hiển thị dữ liệu lọc
                LoadProduct(filteredItems);
            }
        }
    }
  

}

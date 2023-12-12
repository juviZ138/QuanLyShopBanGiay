using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;

using System.Data;


using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

using iText.IO.Font;
using iText.Kernel.Font;
using System.IO;
using QuanLyShopBanGiay.GUI.subForm;
using System.Linq;

namespace QuanLyShopBanGiay.GUI
{
    public partial class formNhapHang : Form
    {
        ProductBUS productBUS = new ProductBUS();
        PhieuNhapBUS phieuNhapBUS = new PhieuNhapBUS();
        CTPhieuNhapBUS chiTietBUS = new CTPhieuNhapBUS();
        SoLuongBUS soLuongBUS = new SoLuongBUS();
        CategoryBUS cateBUS = new CategoryBUS();
        BrandBUS brandBUS = new BrandBUS();

        public formNhapHang()
        {
            InitializeComponent();
            LoadProduct();
            loadSize();
            AutoID();
            loadBrand(cbFilterTH);
            loadCate(cbFilterDM);
        }

        public void LoadProduct()
        {
            panelProduct.Controls.Clear();

            List<Product> list = productBUS.GetProducts();

            foreach (Product product in list)
            {
                if(product.status != 0)
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


        public void AutoID()
        {
            DataTable dt = phieuNhapBUS.GetAllPhieuNhap();

            string s = "";
            if (dt.Rows.Count <= 0)
            {
                s = "PN001";
            }
            else
            {
                int k;
                s = "PN";
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
            txtMaPN.Text = s;

        }

        private void loadSize()
        {
            SizeBUS categoryBUS = new SizeBUS();

            cbSize.DataSource = categoryBUS.GetAllSize().DefaultView;
            cbSize.DisplayMember = "name";
            cbSize.ValueMember = "id";
            cbSize.SelectedIndex = 0;
        }

        public void MyUserControl_ControlClicked(object sender, string productID)
        {
            SoLuongBUS slBUS = new SoLuongBUS();
            SizeBUS sizeBUS = new SizeBUS();

            string ProductID = productID;

            List<SoLuong> list = slBUS.GetSoLuong(ProductID);

            Product currentProduct = productBUS.GetByID(ProductID);

            txtTenSP.Text = currentProduct.ProductName;
            txtMaSP.Text = currentProduct.ProductId;
            txtGiaNhap.Text = currentProduct.GiaNhap.ToString();

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

        private void lvSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void formNhapHang_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CTPhieuNhap ct = new CTPhieuNhap();
            //ct.MaPhieuNhap = txtMaPN.Text;
            //ct.MaSP = txtMaSP.Text;
            //ct.MaSize = cbSize.SelectedValue.ToString();
            //ct.GiaNhap = float.Parse(txtGiaNhap.Text);
            //ct.soLuong = int.Parse(txtSoLuong.Text);


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

            if(txtSoLuong.Value <= 0)
            {
                MessageBox.Show("Số Lượng Phải Lớn Hơn 0");
                txtSoLuong.Focus();
                return;
            }




            ListViewItem item = new ListViewItem(txtMaSP.Text);
            item.SubItems.Add(cbSize.SelectedValue.ToString());
            item.SubItems.Add(txtSoLuong.Text);
            item.SubItems.Add(txtGiaNhap.Text);
            item.SubItems.Add((int.Parse(txtSoLuong.Text.ToString()) * float.Parse(txtGiaNhap.Text.ToString())).ToString());

            listView1.Items.Add(item);

            txtSoLuong.Value = 0;
            updateTongCong();
        }

        public void updateTongCong()
        {
            int tong = 0;
            foreach(ListViewItem item in listView1.Items)
            {
                tong += int.Parse(item.SubItems[4].Text);
            }
            txtTongCong.Text = tong.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices.Count - 1);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa");
            }

            updateTongCong();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];

                Product product = productBUS.GetByID(item.SubItems[0].Text);

                txtTenSP.Text = product.ProductName;
                txtMaSP.Text = product.ProductId;
                txtGiaNhap.Text = product.GiaNhap.ToString();

                cbSize.SelectedValue = item.SubItems[1].Text;
                txtSoLuong.Value = int.Parse(item.SubItems[2].Text);
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                if (txtSoLuong.Value < 0)
                {
                    MessageBox.Show("Số Lượng phải lớn hơn 0");
                    return;
                }

                if(txtSoLuong.Text == item.SubItems[2].Text)
                {
                    MessageBox.Show("Vui lòng thay đổi số lượng");
                    return;
                }

                item.SubItems[2].Text = txtSoLuong.Text;
                item.SubItems[4].Text = ((int.Parse(txtSoLuong.Text.ToString()) * float.Parse(txtGiaNhap.Text.ToString())).ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa ");
            }

            updateTongCong();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count == 0)
            {
                MessageBox.Show("Phiếu Nhập đang trống !!!");
                return;
            }



            DialogResult result = MessageBox.Show("Xác nhận tạo phiếu nhập", "Thông báo", MessageBoxButtons.YesNo);

            // Kiểm tra kết quả
            if (result == DialogResult.No)
            {
                return;
            }


            PhieuNhap pn = new PhieuNhap();
            pn.MaPhieuNhap = txtMaPN.Text;
            pn.MaNhanVien = txtMaNhanVien.Text;
            pn.date = txtNgayNhap.Value;
            pn.TongCong = int.Parse(txtTongCong.Text);
            pn.status = 1;

            phieuNhapBUS.AddPhieuNhap(pn);

            foreach(ListViewItem item in listView1.Items)
            {
                CTPhieuNhap ct = new CTPhieuNhap();
                ct.MaPhieuNhap = txtMaPN.Text;
                ct.MaSP = item.SubItems[0].Text;
                ct.MaSize = item.SubItems[1].Text;
                ct.soLuong = int.Parse(item.SubItems[2].Text);
                ct.GiaNhap = float.Parse(item.SubItems[3].Text);

                chiTietBUS.AddCTPhieuNhap(ct);
            }

            //foreach (CTPhieuNhap ct in chiTietBUS.GetCTPhieuNhap(txtMaPN.Text))
            //{
            //    SoLuong sl = new SoLuong();
            //    sl.MaSP = ct.MaSP;
            //    sl.MaSize = ct.MaSize;
            //    sl.soLuong = ct.soLuong;

            //    SoLuong ex = soLuongBUS.GetSoLuong(sl.MaSP).Find(item => (item.MaSP == sl.MaSP) && (item.MaSize == sl.MaSize));
            //    if (ex == null)
            //    {
            //        soLuongBUS.AddSoLuong(sl);
            //        //MessageBox.Show("Sản Phẩm này ko  có");
            //    }
            //    else
            //    {
            //        sl.soLuong = ct.soLuong + ex.soLuong;
            //        soLuongBUS.UpdateSoLuong(sl, sl.MaSP);
            //        //MessageBox.Show("Sản Phẩm này đã  có");
            //    }
            //}

            DialogResult result2 = MessageBox.Show("Xác nhận in phiếu nhập", "Thông báo", MessageBoxButtons.YesNo);

            // Kiểm tra kết quả
            if (result2 == DialogResult.No)
            {
                ResetForm();
                return;
               
            }
            else
            {
                printPDF(pn, chiTietBUS.GetCTPhieuNhap(txtMaPN.Text));
                ResetForm();
            }


        }

        private void printPDF(PhieuNhap pn, List<CTPhieuNhap> ListCT)
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
                       

                        // Thêm thông tin hóa đơn vào tài liệu PDF
                        document.Add(new Paragraph($"Mã Phiếu Nhập: {pn.MaPhieuNhap}"));
                        document.Add(new Paragraph($"Mã Nhân Viên Nhập: {pn.MaNhanVien}"));
                        document.Add(new Paragraph($"Ngày Nhập: {pn.date}"));
                        document.Add(new Paragraph($"Tổng Tiền: {pn.TongCong}"));
                        document.Add(new Paragraph("-----------------------------"));
                        document.Add(new Paragraph("Danh Sách Sản Phẩm: "));
                        // Thêm bảng cho chi tiết hóa đơn
                        Table table = new Table(5);
                        table.AddHeaderCell("Mã Sản Phẩm");
                        table.AddHeaderCell("Mã Size");
                        table.AddHeaderCell("Số Lượng");
                        table.AddHeaderCell("Đơn Giá");
                        table.AddHeaderCell("Thành Tiền");

                        foreach (CTPhieuNhap ct in ListCT)
                        {
                            table.AddCell(ct.MaSP);
                            table.AddCell(ct.MaSize);
                            table.AddCell(ct.soLuong.ToString());
                            table.AddCell(ct.GiaNhap.ToString());
                            float c = ct.soLuong * ct.GiaNhap;
                            table.AddCell(c.ToString());
                        }

                        document.Add(table);
                    }

                
                    }


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = pn.MaPhieuNhap + ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lưu trữ dữ liệu PDF từ MemoryStream vào tệp tin đã chọn
                    File.WriteAllBytes(saveFileDialog.FileName, stream.ToArray());
                }
            }
        
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            formSize f = new formSize();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addProduct f = new addProduct();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        void ResetForm()
        {
            LoadProduct();
            loadSize();
            AutoID();
            listView1.Items.Clear();
            lvSoLuong.Items.Clear();
            txtMaSP.Text = "";
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtTenSP.Text = "";
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
            Filtering();
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


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
using OfficeOpenXml;
using System.IO;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;
using static SkiaSharp.HarfBuzz.SKShaper;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace QuanLyShopBanGiay.GUI
{
    public partial class formXemPhieuNhap : Form
    {
        PhieuNhapBUS PhieuNhapBUS = new PhieuNhapBUS();
        CTPhieuNhapBUS ChiTietBUS = new CTPhieuNhapBUS();
        private string pathFile = "";//save path of file excel 
        public formXemPhieuNhap()
        {
            InitializeComponent();
            LoadPhieuNhap();
        }

        public void LoadPhieuNhap()
        {
            lvPhieuNhap.Items.Clear();
            foreach (PhieuNhap pn in PhieuNhapBUS.GetPhieuNhap())
            {
                ListViewItem item = new ListViewItem(pn.MaPhieuNhap);
                item.SubItems.Add(pn.MaNhanVien);
                item.SubItems.Add(pn.date.ToString());
                item.SubItems.Add(pn.TongCong.ToString());
                if (pn.status == 0)
                {
                    item.SubItems.Add("Đang ẩn");
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.SubItems.Add("Đang Kinh Doanh");
                }

                lvPhieuNhap.Items.Add(item);
            }
        }

        public void LoadPhieuNhap(List<PhieuNhap> listPN)
        {
            lvPhieuNhap.Items.Clear();
            foreach (PhieuNhap pn in listPN)
            {
                ListViewItem item = new ListViewItem(pn.MaPhieuNhap);
                item.SubItems.Add(pn.MaNhanVien);
                item.SubItems.Add(pn.date.ToString());
                item.SubItems.Add(pn.TongCong.ToString());
                if (pn.status == 0)
                {
                    item.SubItems.Add("Đang ẩn");
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.SubItems.Add("Đang Kinh Doanh");
                }

                lvPhieuNhap.Items.Add(item);
            }
        }


        public void LoadChiTiet()
        {
            lvChiTiet.Items.Clear();
            foreach (CTPhieuNhap ct in ChiTietBUS.GetCTPhieuNhap(txtMaPhieu.Text))
            {
                ListViewItem item = new ListViewItem(ct.MaSP);
                item.SubItems.Add(ct.MaSize);
                item.SubItems.Add(ct.soLuong.ToString());
                item.SubItems.Add(ct.GiaNhap.ToString());
                item.SubItems.Add((ct.GiaNhap * ct.soLuong).ToString());
                lvChiTiet.Items.Add(item);

            }

        }


        private void lvPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPhieuNhap.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = lvPhieuNhap.SelectedItems[0];
                txtMaPhieu.Text = listViewItem.SubItems[0].Text;
                txtNhanVien.Text = listViewItem.SubItems[1].Text;
                txtTien.Text = listViewItem.SubItems[3].Text;
                LoadChiTiet();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formNhapHang f = new formNhapHang();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Just file *.xlsx|*.xlsx";
            choofdlog.FilterIndex = 1;
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                pathFile = choofdlog.FileName;
                readExcel(pathFile);
            }

            else
                pathFile = string.Empty;
        }

        void readExcel(string excelFilePath)
        {
            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                // Lấy ra sheet đầu tiên từ file Excel
                var worksheet = package.Workbook.Worksheets[0];

                ProductBUS productBUS = new ProductBUS();

                // Lấy ra số dòng và số cột trong sheet
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                PhieuNhap pn = new PhieuNhap();
                pn.MaPhieuNhap = AutoID();
                pn.MaNhanVien = "NV001";
                pn.date = DateTime.Now;
                pn.status = 1;

                float TongTien = 0;

                List<CTPhieuNhap> listCT = new List<CTPhieuNhap>();

                // Đọc dữ liệu từ sheet và hiển thị ra màn hình
                for (int row = 2; row <= rowCount; row++)
                {
                    CTPhieuNhap ct = new CTPhieuNhap();
                    ct.MaPhieuNhap = pn.MaPhieuNhap;
                    ct.MaSP = worksheet.Cells[row, 1].Value.ToString();
                    ct.MaSize = worksheet.Cells[row, 2].Value.ToString();
                    ct.GiaNhap = productBUS.GetByID(ct.MaSP).GiaNhap;
                    ct.soLuong = int.Parse(worksheet.Cells[row, 3].Value.ToString());

                    TongTien += ct.GiaNhap * ct.soLuong;

                    listCT.Add(ct);
                
                }

                pn.TongCong = TongTien;

                PhieuNhapBUS.AddPhieuNhap(pn);

                foreach (CTPhieuNhap ct in listCT)
                {
                    ChiTietBUS.AddCTPhieuNhap(ct);

                }

            }


            MessageBox.Show("Nhập Thành Công");


        }

        public string AutoID()
        {

            DataTable dt = PhieuNhapBUS.GetAllPhieuNhap();

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
            return s;

        }

        private void lvChiTiet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(lvPhieuNhap.SelectedItems.Count > 0)
            {
                DialogResult result2 = MessageBox.Show("Xác nhận in phiếu nhập", "Thông báo", MessageBoxButtons.YesNo);

                // Kiểm tra kết quả
                if (result2 == DialogResult.No)
                {
                    return;
                }
                else
                {
                    PhieuNhap pn = PhieuNhapBUS.GetByID(txtMaPhieu.Text);
                    printPDF(pn, ChiTietBUS.GetCTPhieuNhap(pn.MaPhieuNhap));
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu cần in");
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
                    Process.Start(saveFileDialog.FileName);
                }
            }
           

        }

        private void txtNhanVien_TextChanged(object sender, EventArgs e)
        {
            
        }

        public List<PhieuNhap> getCurrentList()
        {
            List<PhieuNhap> list = new List<PhieuNhap>();

            foreach (ListViewItem item in lvPhieuNhap.Items)
            {
                PhieuNhap pn = PhieuNhapBUS.GetByID(item.SubItems[0].Text); 
                list.Add(pn);
            }
            return list;
        }

        void DisplayInvoicesWithinTimeFrame(List<PhieuNhap> listPN, DateTime startDate, DateTime endDate)
        {
            var filteredInvoices = listPN.Where(i => i.date >= startDate && i.date <= endDate).ToList();

            // Hiển thị kết quả
            
            LoadPhieuNhap(filteredInvoices);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<PhieuNhap> listPN = PhieuNhapBUS.GetPhieuNhap();

            if (rad1.Checked)
            {
                if (cbTheoKhoang.SelectedIndex == 0)
                {
                    DisplayInvoicesWithinTimeFrame(listPN, DateTime.Now.AddMonths(-1), DateTime.Now);
                }

                if (cbTheoKhoang.SelectedIndex == 1)
                {
                    DisplayInvoicesWithinTimeFrame(listPN, DateTime.Now.AddMonths(-3), DateTime.Now);
                }

                if (cbTheoKhoang.SelectedIndex == 2)
                {
                    DisplayInvoicesWithinTimeFrame(listPN, DateTime.Now.AddMonths(-6), DateTime.Now);
                }

                if (cbTheoKhoang.SelectedIndex == 3)
                {
                    DisplayInvoicesWithinTimeFrame(listPN, DateTime.Now.AddYears(-1), DateTime.Now);
                }

                if (cbTheoKhoang.SelectedIndex == 4)
                {
                    LoadPhieuNhap();
                }
            }
            else if (rad2.Checked){
                var filteredInvoices = listPN.Where(i => i.date.Month == int.Parse(cbThang.Text)  && i.date.Year <= int.Parse(cbNam.Text)).ToList();

                // Hiển thị kết quả

                LoadPhieuNhap(filteredInvoices);
            }
            else
            {
                var filteredInvoices = listPN.Where(i => i.date == dateTimePicker1.Value.Date ).ToList();

                // Hiển thị kết quả

                LoadPhieuNhap(filteredInvoices);
            }

           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cbTheoKhoang.Enabled = true;
            cbThang.Enabled = false;
            cbNam.Enabled = false;
            dateTimePicker1.Enabled = false;

        }

        private void cbThang_CheckedChanged(object sender, EventArgs e)
        {
            cbTheoKhoang.Enabled = false;
            dateTimePicker1.Enabled = false;
            cbThang.Enabled = true;
            cbNam.Enabled = true;
        }

        private void cbCuThe_CheckedChanged(object sender, EventArgs e)
        {
            cbTheoKhoang.Enabled = false;
            dateTimePicker1.Enabled = true;
            cbThang.Enabled = false;
            cbNam.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var list = PhieuNhapBUS.GetPhieuNhap();

            if (textBox1.Text == "")
            {
                LoadPhieuNhap(list);
            }
            else
            {
                var filteredInvoices = list.Where(i => i.MaPhieuNhap.ToLower().Contains(textBox1.Text.ToLower())).ToList();

                // Hiển thị kết quả

                LoadPhieuNhap(filteredInvoices);
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadPhieuNhap();
            lvChiTiet.Items.Clear();
            txtMaPhieu.Text = "";
            txtNhanVien.Text = "";
            txtTien.Text = "";
        }
    }
}

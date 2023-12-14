using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas.Parser.ClipperLib;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DTO;
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
using iText.Layout;

namespace QuanLyShopBanGiay.GUI
{
    public partial class formXemHoaDon : Form
    {
        HoaDonBUS HoaDonBUS = new HoaDonBUS();
        CTHoaDonBUS ChiTietBUS = new CTHoaDonBUS();
        KhachHangBUS khachHangBUS = new KhachHangBUS();
        public formXemHoaDon()
        {
            InitializeComponent();
            LoadHoaDon();
        }

        public void LoadHoaDon()
        {
            lvHoaDon.Items.Clear();
            foreach (HoaDon pn in HoaDonBUS.GetHoaDon())
            {
                ListViewItem item = new ListViewItem(pn.MaHoaDon);
                item.SubItems.Add(pn.MaNhanVien);
                item.SubItems.Add(pn.MaKhachHang);
                item.SubItems.Add(pn.date.ToString());
                item.SubItems.Add(pn.MaKhuyenMai);
                item.SubItems.Add(pn.TongCong.ToString());

                lvHoaDon.Items.Add(item);
            }

        }

        public void LoadHoaDon(List<HoaDon> listPN)
        {
            lvHoaDon.Items.Clear();
            foreach (HoaDon pn in listPN)
            {
                ListViewItem item = new ListViewItem(pn.MaHoaDon);
                item.SubItems.Add(pn.MaNhanVien);
                item.SubItems.Add(pn.MaKhachHang);
                item.SubItems.Add(pn.date.ToString());
                item.SubItems.Add(pn.MaKhuyenMai);
                item.SubItems.Add(pn.TongCong.ToString());

                lvHoaDon.Items.Add(item);
            }

        }

        public void LoadChiTiet()
        {
            lvChiTiet.Items.Clear();
            foreach (CTHoaDon ct in ChiTietBUS.GetCTHoaDon(txtMaPhieu.Text))
            {
                ListViewItem item = new ListViewItem(ct.MaSP);
                item.SubItems.Add(ct.MaSize);
                item.SubItems.Add(ct.soLuong.ToString());
                item.SubItems.Add(ct.GiaBan.ToString());
                item.SubItems.Add((ct.GiaBan * ct.soLuong).ToString());
                lvChiTiet.Items.Add(item);

            }

        }

        private void lvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHoaDon.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = lvHoaDon.SelectedItems[0];
                txtMaPhieu.Text = listViewItem.SubItems[0].Text;
                txtNhanVien.Text = listViewItem.SubItems[1].Text;
                txtTien.Text = listViewItem.SubItems[4].Text;
                txtKH.Text = listViewItem.SubItems[2].Text;
                LoadChiTiet();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvHoaDon.SelectedItems.Count > 0)
            {
                DialogResult result2 = MessageBox.Show("Xác nhận in Hoá Đơn", "Thông báo", MessageBoxButtons.YesNo);

                // Kiểm tra kết quả
                if (result2 == DialogResult.No)
                {
                    return;
                }
                else
                {
                    HoaDon pn = HoaDonBUS.GetByID(txtMaPhieu.Text);
                    printPDF(pn, ChiTietBUS.GetCTHoaDon(pn.MaHoaDon));
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu cần in");
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
                        KhuyenMai km = new KhuyenMaiBUS().GetByID(pn.MaKhuyenMai);

                        // Thêm thông tin hóa đơn vào tài liệu PDF
                        document.Add(new Paragraph($"Mã Hóa Đơnp: {pn.MaHoaDon}"));
                        document.Add(new Paragraph($"Mã Nhân Viên Nhập: {pn.MaNhanVien}"));
                        document.Add(new Paragraph($"Khách Hàng: {kh.MaKH} SĐT: {kh.SDT}"));
                        document.Add(new Paragraph($"Ngày Nhập: {pn.date}"));
                        document.Add(new Paragraph($" Khuyến Mãi : {km.TenKM}"));
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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
            lvChiTiet.Items.Clear();
            txtKH.Text = "";
            txtMaPhieu.Text = "";
            txtNhanVien.Text = "";
            txtTien.Text = "";
        }

        void DisplayInvoicesWithinTimeFrame(List<HoaDon> listPN, DateTime startDate, DateTime endDate)
        {
            var filteredInvoices = listPN.Where(i => i.date >= startDate && i.date <= endDate).ToList();

            // Hiển thị kết quả

            LoadHoaDon(filteredInvoices);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<HoaDon> listPN = HoaDonBUS.GetHoaDon();

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
                    LoadHoaDon();
                }
            }
            else if (rad2.Checked)
            {
                var filteredInvoices = listPN.Where(i => i.date.Month == int.Parse(cbThang.Text) && i.date.Year <= int.Parse(cbNam.Text)).ToList();

                // Hiển thị kết quả

                LoadHoaDon(filteredInvoices);
            }
            else
            {
                var filteredInvoices = listPN.Where(i => i.date == dateTimePicker1.Value.Date).ToList();

                // Hiển thị kết quả

                LoadHoaDon(filteredInvoices);
            }
        }

        private void rad1_CheckedChanged(object sender, EventArgs e)
        {
            cbTheoKhoang.Enabled = true;
            cbThang.Enabled = false;
            cbNam.Enabled = false;
            dateTimePicker1.Enabled = false;
        }

        private void rad2_CheckedChanged(object sender, EventArgs e)
        {
            cbTheoKhoang.Enabled = false;

            cbThang.Enabled = true;
            cbNam.Enabled = true;
        }

        private void rad3_CheckedChanged(object sender, EventArgs e)
        {
            cbTheoKhoang.Enabled = false;
            dateTimePicker1.Enabled = true;
            cbThang.Enabled = false;
            cbNam.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var list = HoaDonBUS.GetHoaDon();

            if (textBox1.Text == "")
            {
                LoadHoaDon(list);
            }
            else
            {
                var filteredInvoices = list.Where(i => i.MaHoaDon.ToLower().Contains(textBox1.Text.ToLower())).ToList();

                // Hiển thị kết quả

                LoadHoaDon(filteredInvoices);
            }
        }
    }
}

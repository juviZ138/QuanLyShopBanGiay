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
    public partial class formXemHoaDon : Form
    {
        HoaDonBUS HoaDonBUS = new HoaDonBUS();
        CTHoaDonBUS ChiTietBUS = new CTHoaDonBUS();
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
    }
}

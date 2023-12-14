using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DTO;
using QuanLyShopBanGiay.GUI.subForm;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyShopBanGiay.GUI
{
    public partial class formCustomer : Form
    {
        KhachHangBUS khachHangBUS = new KhachHangBUS();
        public formCustomer()
        {
            InitializeComponent();
            viewKhachHang();
            cbSort.SelectedIndex = 0;
            cbTimKiem.SelectedIndex = 1;
            rad1.Checked = true;
        }

        public void viewKhachHang()
        {
            listView1.Items.Clear();
            foreach (KhachHang brand in khachHangBUS.GetKhachHangs())
            {
                ListViewItem item = new ListViewItem(brand.MaKH);
                item.SubItems.Add(brand.TenKH);
                item.SubItems.Add(brand.SDT);
                item.SubItems.Add(brand.total.ToString());
                item.SubItems.Add(brand.point.ToString());
                listView1.Items.Add(item);
            }
        }

        public void viewKhachHang(List<KhachHang> list)
        {
            listView1.Items.Clear();
            foreach (KhachHang brand in list)
            {
                ListViewItem item = new ListViewItem(brand.MaKH);
                item.SubItems.Add(brand.TenKH);
                item.SubItems.Add(brand.SDT);
                item.SubItems.Add(brand.total.ToString());
                item.SubItems.Add(brand.point.ToString());
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addCustomer f = new addCustomer();
            f.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];

                txtMaKH.Text = item.SubItems[0].Text;
                txtTenKH.Text = item.SubItems[1].Text;
                txtPhone.Text = item.SubItems[2].Text;
                txtTotal.Text = item.SubItems[3].Text;
                txtPoint.Text = item.SubItems[4].Text;

                LoadHoaDon();
            }
        }

        HoaDonBUS hoaDonBUS = new HoaDonBUS();
        public void LoadHoaDon()
        {
            List<HoaDon> list = hoaDonBUS.GetHoaDon().Where(i => i.MaKhachHang == txtMaKH.Text).ToList();

            listView2.Items.Clear();
            foreach(HoaDon hoaDon in list)
            {
                ListViewItem item = new ListViewItem(hoaDon.MaHoaDon);
                item.SubItems.Add(hoaDon.date.ToString());
                item.SubItems.Add(hoaDon.TongCong.ToString());

                listView2.Items.Add(item);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                KhachHang edit = khachHangBUS.GetByID(txtMaKH.Text);
                edit.TenKH = txtTenKH.Text;

                khachHangBUS.UpdateKhachHang(edit, edit.MaKH);

                viewKhachHang();
                MessageBox.Show("Cập Nhật Thành Công");

                
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viewKhachHang();
            cbSort.SelectedIndex = 0;
            cbTimKiem.SelectedIndex = 1;
            rad1.Checked = true;

            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtPhone.Text = "";
            txtTotal.Text = "";
            txtPoint.Text = "";
        }

        public class tongChiTieuComaper : IComparer<KhachHang>
        {
            public int Compare(KhachHang x, KhachHang y)
            {
                return x.total.CompareTo(y.total);
            }
        }

        public class pointComaper : IComparer<KhachHang>
        {
            public int Compare(KhachHang x, KhachHang y)
            {
                return x.point.CompareTo(y.point);
            }
        }

        public void Sorting()
        {
            List<KhachHang> list = khachHangBUS.GetKhachHangs();

            if(cbSort.SelectedIndex == 0)
            {
                list.Sort(new tongChiTieuComaper());
            }
            else
            {
                list.Sort(new pointComaper());
            }

            if (rad2.Checked) {
                list.Reverse();
            }

            viewKhachHang(list);
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sorting();
        }

        private void rad1_CheckedChanged(object sender, EventArgs e)
        {
            Sorting();
        }

        private void rad2_CheckedChanged(object sender, EventArgs e)
        {
            Sorting();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                viewKhachHang();
            }
            else
            {

                Searching();
            }
        }
        
        public void Searching()
        {
            if (cbTimKiem.SelectedIndex == 0)
            {
                string filterCategory = txtTimKiem.Text;
                List<KhachHang> filteredItems = khachHangBUS.GetKhachHangs().FindAll(item => item.TenKH.ToUpper().Contains(filterCategory.ToUpper()));

                // Hiển thị dữ liệu lọc
                viewKhachHang(filteredItems);
            }
            else
            {
                string filterCategory = txtTimKiem.Text;
                List<KhachHang> filteredItems = khachHangBUS.GetKhachHangs().FindAll(item => item.SDT.ToUpper().Contains(filterCategory.ToUpper()));


                // Hiển thị dữ liệu lọc
                viewKhachHang(filteredItems);
            }
        }

    }
}

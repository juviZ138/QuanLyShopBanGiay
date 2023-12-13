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
using static QuanLyShopBanGiay.GUI.formCustomer;

namespace QuanLyShopBanGiay.GUI
{
    public partial class formKhuyenMai : Form
    {
        KhuyenMaiBUS khuyenMaiBUS = new KhuyenMaiBUS();
        public formKhuyenMai()
        {
            InitializeComponent();
            viewKhuyenMai();
            rad1.Checked = true;
            cbSort.SelectedIndex = 0;
            cbTimKiem.SelectedIndex = 0;
        }

        public void viewKhuyenMai()
        {
            listView1.Items.Clear();
            foreach (KhuyenMai KhuyenMai in khuyenMaiBUS.GetKhuyenMai())
            {
                ListViewItem item = new ListViewItem(KhuyenMai.MaKM);
                item.SubItems.Add(KhuyenMai.TenKM);
                item.SubItems.Add(KhuyenMai.PhanTramGiam.ToString());
                item.SubItems.Add(KhuyenMai.value.ToString());
                if (KhuyenMai.status == 0)
                {
                    item.SubItems.Add("Đã ngừng");
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.SubItems.Add("Đang chạy");
                }

                listView1.Items.Add(item);
            }
        }

        public void viewKhuyenMai(List<KhuyenMai> list)
        {
            listView1.Items.Clear();
            foreach (KhuyenMai KhuyenMai in list)
            {
                ListViewItem item = new ListViewItem(KhuyenMai.MaKM);
                item.SubItems.Add(KhuyenMai.TenKM);
                item.SubItems.Add(KhuyenMai.PhanTramGiam.ToString());
                item.SubItems.Add(KhuyenMai.value.ToString());
                if (KhuyenMai.status == 0)
                {
                    item.SubItems.Add("Đã ngừng");
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.SubItems.Add("Đang chạy");
                }

                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtMaKM.Text = item.SubItems[0].Text;
                txtTenKM.Text = item.SubItems[1].Text;
                txtPhanTramGiam.Text = item.SubItems[2].Text;
                txtValue.Text = item.SubItems[3].Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addKhuyenMai f = new addKhuyenMai();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                KhuyenMai edit = khuyenMaiBUS.GetByID(txtMaKM.Text);
                edit.TenKM = txtTenKM.Text;
                edit.PhanTramGiam = float.Parse(txtPhanTramGiam.Text);
                edit.value = float.Parse(txtValue.Text);


                khuyenMaiBUS.UpdateKhuyenMai(edit, edit.MaKM);
                viewKhuyenMai();
                MessageBox.Show("Cập Nhật Thành Công");

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].BackColor != Color.Red)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn ngừng chương trình này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra kết quả từ hộp thoại
                if (result == DialogResult.Yes)
                {

                    if (listView1.SelectedItems.Count > 0)
                    {
                        ListViewItem item = listView1.SelectedItems[0];
                        string ID = item.SubItems[0].Text;
                        KhuyenMai km = khuyenMaiBUS.GetByID(ID);
                        km.status = 0;
                        khuyenMaiBUS.UpdateKhuyenMai(km, km.MaKM);
                        MessageBox.Show("Đã ngừng chương trình này");
                        viewKhuyenMai();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn dòng");
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn tiếp tục kinh doanh mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra kết quả từ hộp thoại
                if (result == DialogResult.Yes)
                {

                    if (listView1.SelectedItems.Count > 0)
                    {
                        ListViewItem item = listView1.SelectedItems[0];
                        string ID = item.SubItems[0].Text;
                        KhuyenMai km = khuyenMaiBUS.GetByID(ID);
                        km.status = 1;
                        khuyenMaiBUS.UpdateKhuyenMai(km, km.MaKM);
                        MessageBox.Show("Đã ngừng chương trình này");
                        viewKhuyenMai();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn dòng");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viewKhuyenMai();
            txtMaKM.Text = "";
            txtTenKM.Text = "";
            txtPhanTramGiam.Text = "";
            txtValue.Text = "";
            rad1.Checked = true;
            cbSort.SelectedIndex = 0;
            cbTimKiem.SelectedIndex = 0;
        }
        public class PhanTramGiamComaper : IComparer<KhuyenMai>
        {
            public int Compare(KhuyenMai x, KhuyenMai y)
            {
                return x.PhanTramGiam.CompareTo(y.PhanTramGiam);
            }
        }

        public class valueComaper : IComparer<KhuyenMai>
        {
            public int Compare(KhuyenMai x, KhuyenMai y)
            {
                return x.value.CompareTo(y.value);
            }
        }

        public void Sorting()
        {
            List<KhuyenMai> list = khuyenMaiBUS.GetKhuyenMai();

            if (cbSort.SelectedIndex == 0)
            {
                list.Sort(new PhanTramGiamComaper());
            }
            else
            {
                list.Sort(new valueComaper());
            }

            if (rad2.Checked)
            {
                list.Reverse();
            }

            viewKhuyenMai(list);
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            Searching();
        }

        public void Searching()
        {
            if (cbTimKiem.SelectedIndex == 0)
            {
                string filterCategory = txtTimKiem.Text;
                List<KhuyenMai> filteredItems = khuyenMaiBUS.GetKhuyenMai().FindAll(item => item.MaKM.ToUpper().Contains(filterCategory.ToUpper()));

                // Hiển thị dữ liệu lọc
                viewKhuyenMai(filteredItems);
            }
            else
            {
                string filterCategory = txtTimKiem.Text;
                List<KhuyenMai> filteredItems = khuyenMaiBUS.GetKhuyenMai().FindAll(item => item.TenKM.ToUpper().Contains(filterCategory.ToUpper()));

                // Hiển thị dữ liệu lọc
                viewKhuyenMai(filteredItems);
            }
        }
    }
}

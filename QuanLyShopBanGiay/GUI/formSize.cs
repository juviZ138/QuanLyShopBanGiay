using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShopBanGiay.GUI
{
    public partial class formSize : Form
    {
        SizeBUS sizeBUS = new SizeBUS();
        public formSize()
        {
            InitializeComponent();
            viewCate();
            comboBox1.SelectedIndex = 0;
        }

        public void viewCate()
        {
            listView1.Items.Clear();
            foreach (SizeProduct cate in sizeBUS.GetSize()) 
            {
                ListViewItem item = new ListViewItem(cate.SizeId);
                item.SubItems.Add(cate.SizeName);
                if (cate.status == 0)
                {
                    item.SubItems.Add("Ngừng Kinh Doanh");
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.SubItems.Add("Đang Kinh Doanh");
                }

                listView1.Items.Add(item);
            }
        }

        public void filterViewSize(List<SizeProduct> items)
        {
            listView1.Items.Clear();
            foreach (SizeProduct Size in items)
            {
                ListViewItem item = new ListViewItem(Size.SizeId);
                item.SubItems.Add(Size.SizeName);
                if (Size.status == 0)
                {
                    item.SubItems.Add("Ngừng Kinh Doanh");
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.SubItems.Add("Đang Kinh Doanh");
                }

                listView1.Items.Add(item);
            }
        }

        public void EnableEdit()
        {

            if ((txtMaDanhMuc.Text != "" && txtTenDanhMuc.Text != "") && listView1.SelectedItems.Count > 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }

        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDanhMuc.Text == "" || txtTenDanhMuc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!!");
                return;
            }



            SizeProduct newCategory = new SizeProduct(txtMaDanhMuc.Text, txtTenDanhMuc.Text, 1);
            if (sizeBUS.CheckID(txtMaDanhMuc.Text) == 0)
            {
                MessageBox.Show("Trùng Danh Mục");
                return;
            }
            else if (sizeBUS.CheckName(txtTenDanhMuc.Text) == 0)
            {
                MessageBox.Show("Trùng Tên !!!");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra kết quả từ hộp thoại
                if (result == DialogResult.Yes)
                {
                    sizeBUS.AddSize(newCategory);
                    MessageBox.Show("Thêm thành công");
                    viewCate();
                }
                else
                {
                    MessageBox.Show("Đã hủy thêm");

                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaDanhMuc.Text = "";
            txtTenDanhMuc.Text = "";
            textBox3.Text = "";
            EnableEdit();
            viewCate();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView1.SelectedItems[0];
                    string ID = item.SubItems[0].Text;
                    SizeProduct editCategory = new SizeProduct(txtMaDanhMuc.Text, txtTenDanhMuc.Text, 1);
                    sizeBUS.UpdateSize(editCategory, ID);
                    MessageBox.Show("Sửa thành công");
                    viewCate();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].BackColor != Color.Red)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn ngừng kinh doanh mục này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra kết quả từ hộp thoại
                if (result == DialogResult.Yes)
                {

                    if (listView1.SelectedItems.Count > 0)
                    {
                        ListViewItem item = listView1.SelectedItems[0];
                        string ID = item.SubItems[0].Text;
                        SizeProduct editCategory = new SizeProduct(txtMaDanhMuc.Text, txtTenDanhMuc.Text, 0);
                        sizeBUS.UpdateSize(editCategory, ID);
                        MessageBox.Show("Đã ngừng kinh doanh mục này");
                        viewCate();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn dòng cần sửa");
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
                        SizeProduct editCategory = new SizeProduct(txtMaDanhMuc.Text, txtTenDanhMuc.Text, 1);
                        sizeBUS.UpdateSize(editCategory, ID);
                        MessageBox.Show("Đã tiếp tục kinh doanh mục này");
                        viewCate();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn dòng cần sửa");
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableEdit();
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                txtMaDanhMuc.Text = selectedItem.SubItems[0].Text;
                txtTenDanhMuc.Text = selectedItem.SubItems[1].Text;
                // btnSua.Enabled = true;
            }
            else
            {
                // btnSua.Enabled = false;
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            EnableEdit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                viewCate();
            }

            if (comboBox1.SelectedIndex == 0)
            {
                string filterCategory = textBox3.Text;
                List<SizeProduct> filteredItems = sizeBUS.GetSize().FindAll(item => item.SizeId.ToUpper().Contains(filterCategory.ToUpper()));

                // Hiển thị dữ liệu lọc
                filterViewSize(filteredItems);
            }
            else
            {
                string filterCategory = textBox3.Text;
                List<SizeProduct> filteredItems = sizeBUS.GetSize().FindAll(item => item.SizeName.ToUpper().Contains(filterCategory.ToUpper()));

                // Hiển thị dữ liệu lọc
                filterViewSize(filteredItems);
            }
        }
    }
}

using QuanLyShopBanGiay.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyShopBanGiay.DTO;
using System.Data.SqlClient;
using System.Data.Linq;


namespace QuanLyShopBanGiay.GUI
{
    public partial class FormBrand : Form
    {
        BrandBUS brandBUS = new BrandBUS();
        public FormBrand()
        {
            InitializeComponent();
            viewBrand();
            comboBox1.SelectedIndex = 0;

//             EnableEdit();       
        }

        public void viewBrand()
        {
            listView1.Items.Clear();
            foreach(Brand brand in brandBUS.GetBrands())
            {
                ListViewItem item = new ListViewItem(brand.BrandId);
                item.SubItems.Add(brand.BrandName);
                if (brand.status == 0)
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

        public void filterViewBrand(List<Brand> items)
        {
            listView1.Items.Clear();
            foreach (Brand brand in items)
            {
                ListViewItem item = new ListViewItem(brand.BrandId);
                item.SubItems.Add(brand.BrandName);
                if (brand.status == 0)
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
           
            if ((txtMaThuongHieu.Text != "" && txtTenThuongHieu.Text != "") && listView1.SelectedItems.Count > 0)
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

        private void button5_Click(object sender, EventArgs e)  
        {
            txtMaThuongHieu.Text = "";
            txtTenThuongHieu.Text = "";
            EnableEdit();
            viewBrand();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtMaThuongHieu.Text == "" || txtTenThuongHieu.Text == "") {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!!");
                return;
            }
            


            Brand newBrand = new Brand(txtMaThuongHieu.Text, txtTenThuongHieu.Text,1);
            if(brandBUS.CheckID(txtMaThuongHieu.Text) == 0)
            {
                MessageBox.Show("Trùng Mã Thương Hiệu");
                return;
            }
            else if(brandBUS.CheckName(txtTenThuongHieu.Text) == 0)
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
                    brandBUS.AddBrand(newBrand);
                    MessageBox.Show("Thêm thành công");
                    viewBrand();
                } else
                {
                    MessageBox.Show("Đã hủy thêm");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView1.SelectedItems[0];
                    string ID = item.SubItems[0].Text;
                    Brand editBrand = new Brand(txtMaThuongHieu.Text, txtTenThuongHieu.Text,1);
                    brandBUS.UpdateBrand(editBrand, ID);
                    MessageBox.Show("Sửa thành công");
                    viewBrand();
                } else {
                    MessageBox.Show("Vui lòng chọn dòng cần sửa");
                }
            } catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu");
                } else
                {
                    MessageBox.Show("Sửa không thành công ");
                }
            };
            
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EnableEdit();
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                txtMaThuongHieu.Text = selectedItem.SubItems[0].Text;
                txtTenThuongHieu.Text = selectedItem.SubItems[1].Text;
                // btnSua.Enabled = true;
            }
            else
            {
                // btnSua.Enabled = false;
            }
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
                        Brand editBrand = new Brand(txtMaThuongHieu.Text, txtTenThuongHieu.Text, 0);
                        brandBUS.UpdateBrand(editBrand, ID);
                        MessageBox.Show("Đã ngừng kinh doanh mục này");
                        viewBrand();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn dòng cần sửa");
                    }
                }
            } else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn tiếp tục kinh doanh mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra kết quả từ hộp thoại
                if (result == DialogResult.Yes)
                {

                    if (listView1.SelectedItems.Count > 0)
                    {
                        ListViewItem item = listView1.SelectedItems[0];
                        string ID = item.SubItems[0].Text;
                        Brand editBrand = new Brand(txtMaThuongHieu.Text, txtTenThuongHieu.Text, 1);
                        brandBUS.UpdateBrand(editBrand, ID);
                        MessageBox.Show("Đã tiếp tục kinh doanh mục này");
                        viewBrand();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn dòng cần sửa");
                    }
                }
            }
        }

        private void txtMaThuongHieu_Enter(object sender, EventArgs e)
        {

        }

        private void FormBrand_Click(object sender, EventArgs e)
        {
            EnableEdit();
        }

        private void listView1_Click_1(object sender, EventArgs e)
        {
            EnableEdit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                viewBrand();
            }

            if (comboBox1.SelectedIndex == 0)
            {
                    string filterCategory = textBox3.Text;
                    List<Brand> filteredItems = brandBUS.GetBrands().FindAll(item => item.BrandId.Contains(filterCategory.ToUpper()));

                    // Hiển thị dữ liệu lọc
                    filterViewBrand(filteredItems);
            } else
            {
                    string filterCategory = textBox3.Text;
                    List<Brand> filteredItems = brandBUS.GetBrands().FindAll(item => item.BrandName.ToUpper().Contains(filterCategory.ToUpper()));

                    // Hiển thị dữ liệu lọc
                    filterViewBrand(filteredItems);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string filterCategory =  textBox3.Text;
            List<Brand> filteredItems = brandBUS.GetBrands().FindAll(item => item.BrandId.Equals(filterCategory));

            // Hiển thị dữ liệu lọc
            filterViewBrand(filteredItems);
        }
    }
}

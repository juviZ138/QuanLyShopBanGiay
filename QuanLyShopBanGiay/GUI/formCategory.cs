using QuanLyShopBanGiay.BUS;
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

namespace QuanLyShopBanGiay.GUI
{
    public partial class formCategory : Form
    {
        BrandBUS brandBUS = new BrandBUS();
        CategoryBUS categoryBUS = new CategoryBUS();
        SizeBUS sizeBUS = new SizeBUS();
        public formCategory()
        {
            InitializeComponent();
            loadBrand();
            //loadCategory();
            loadSize();
        }

        private void loadBrand()
        {
            gridBrand.DataSource = brandBUS.GetAllBrands();
        }

        //private void loadCategory()
        //{
        //    gridCate.DataSource = categoryBUS.GetAllBrands();
        //}

        private void loadSize()
        {
            gridSize.DataSource = sizeBUS.GetAllSize();
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            addBrand test1 = new addBrand();
            test1.Show();
            test1.FormClosing += Test1_FormClosing;
        }

        private void Test1_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadBrand();
        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtBrand.Text;

            // Xóa bộ lọc trước đó
            (gridBrand.DataSource as DataTable).DefaultView.RowFilter = "";

            if (!string.IsNullOrEmpty(searchText))
            {
                // Áp dụng bộ lọc mới với điều kiện tìm kiếm
                (gridBrand.DataSource as DataTable).DefaultView.RowFilter = $"name LIKE '%{searchText}%'"; // Thay "ColumnName" bằng tên cột cần tìm kiếm
                gridBrand.Refresh();
            }
        }

        private void btnDeleteBrand_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có muốn xóa dòng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, thực hiện xóa
            //if (result == DialogResult.Yes)
            //{
            //    int id = Convert.ToInt32(gridBrand.CurrentRow.Cells["id"].Value);
            //    brandBUS.DeleteBrand(id);
            //    loadBrand();
            //}
        }

        private void txtBrand_Click(object sender, EventArgs e)
        {
            txtBrand.Text = "";
        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            addCate test1 = new addCate();
            test1.Show();
            test1.FormClosing += Addcate_FormClosing;
        }

        private void Addcate_FormClosing(object sender, FormClosingEventArgs e)
        {
            //loadCategory();
        }

        private void btnDelCate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa dòng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, thực hiện xóa
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(gridCate.CurrentRow.Cells["id"].Value);
                //categoryBUS.DeleteBrand(id);
                //loadCategory();
            }
        }

        private void txtCate_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtCate.Text;

            // Xóa bộ lọc trước đó
            (gridCate.DataSource as DataTable).DefaultView.RowFilter = "";

            if (!string.IsNullOrEmpty(searchText))
            {
                // Áp dụng bộ lọc mới với điều kiện tìm kiếm
                (gridCate.DataSource as DataTable).DefaultView.RowFilter = $"name LIKE '%{searchText}%'"; // Thay "ColumnName" bằng tên cột cần tìm kiếm
                gridCate.Refresh();
            }
        }

        private void txtCate_Click(object sender, EventArgs e)
        {
            txtCate.Text = "";
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {
            addSize test1 = new addSize();
            test1.Show();
            test1.FormClosing += AddSize_FormClosing;
        }

        private void AddSize_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadSize();
        }
    }
}

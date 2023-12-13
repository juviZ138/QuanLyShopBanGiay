using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DAO;
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

namespace QuanLyShopBanGiay.GUI.subForm
{
    public partial class addProduct : Form
    {

        ProductBUS productBUS = new ProductBUS();

        public addProduct()
        {
            InitializeComponent();
            loadBrand();
            loadCate();
            loadSize();
            AutoID();
        }

        private void loadBrand(){
            BrandBUS brandBUS = new BrandBUS();
            cbBrand.DataSource = brandBUS.GetAllBrands().DefaultView;
            cbBrand.DisplayMember = "name";
            cbBrand.ValueMember = "id";
            cbBrand.SelectedIndex = 0;
        }


        private void loadCate()
        {
            CategoryBUS categoryBUS = new CategoryBUS();

            cbCate.DataSource = categoryBUS.GetAllCategory().DefaultView;
            cbCate.DisplayMember = "name";
            cbCate.ValueMember = "id";
            cbCate.SelectedIndex = 0;
        }

        private void loadSize()
        {
            SizeBUS sizeBUS = new SizeBUS();

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {


        }

        public void AutoID()
        {
            DataTable dt = productBUS.GetAllProducts();

            string s = "";
            if(dt.Rows.Count <= 0)
            {
                s = "SP001";
            }
            else
            {
                int k;
                s = "SP";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    s = s + "00";
                } else if (k < 100)
                {
                    s = s + "0";
                }
                s = s + k.ToString();
            }
            txtMaSP.Text = s;
            
        }


        string checkLogic()
        {

            string str = "";
            int i = 1;
            float x;
            if (txtTenSP.Text == "" || txtGiaNhap.Text == "" || txtKM.Text == "" || txtLoiNhuan.Text == "" || pictureBox1.Image == null)
            {
                str += "\nVui lòng nhập đầy đủ dữ liệu !!!!";
                return str;
            }

            if (!float.TryParse(txtGiaBan.Text, out x))
            {
                str += "\nGiá Bán Phải là con số !!!";
                return str;
            }
            if (!float.TryParse(txtGiaNhap.Text, out x))
            {
                str += "\nGiá Nhập Phải là con số !!!";
                return str;
            }
            if (!int.TryParse(txtLoiNhuan.Text, out i))
            {
                str += "\nLợi nhuận Phải là con số !!!";
                return str;
            }
            if (!int.TryParse(txtKM.Text, out i))
            {
                str += "\nKhuyến mãi Phải là con số !!!";
                return str;
            }
            if(int.Parse(txtLoiNhuan.Text) < 0)
            {
                str += "\nLợi nhuận phải lớn hoặc bằng 0 !!!";
                return str;
            }
            if (float.Parse(textBox1.Text) < float.Parse(txtGiaNhap.Text))
            {
                str += "\nGiá Bán Thấp hơn giá nhập!!!";
                return str;
            }

            return str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string validate = checkLogic();

            if (validate != "")
            {
                MessageBox.Show(validate);
                return;
            }
           
            Product newBrand = new Product(txtMaSP.Text, txtTenSP.Text,cbCate.SelectedValue.ToString(),cbBrand.SelectedValue.ToString()
                , float.Parse(txtGiaNhap.Text),float.Parse(txtLoiNhuan.Text),float.Parse(txtGiaBan.Text),int.Parse(txtKM.Text),txtIMG.Text,1);
            if (productBUS.CheckID(txtMaSP.Text) == 0)
            {
                MessageBox.Show("Trùng Mã Thương Hiệu");
                return;
            }
            else if (productBUS.CheckName(txtTenSP.Text) == 0)
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
                    productBUS.AddProduct(newBrand);
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Đã hủy thêm");

                }
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                // Lấy đường dẫn của ảnh đã chọn
                string imagePath = openFileDialog1.FileName;
                txtIMG.Text = imagePath;
                try
                {
                    // Tải ảnh lên PictureBox
                    pictureBox1.Image = new System.Drawing.Bitmap(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                }
            }
        }

        private void cbCate_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            updateGiaBan();
            updateKM();

        }

        void updateGiaBan()
        {
            try
            {
                if (txtGiaNhap.Text == "" || txtLoiNhuan.Text == "")
                {

                }
                else
                {
                    float a = float.Parse(txtGiaNhap.Text);
                    int b = int.Parse(txtLoiNhuan.Text);
                    float c = a + (a * b / 100);
                    txtGiaBan.Text = c.ToString();
                }
            } catch (Exception ex)
            {

            }

        }

        void updateKM()
        {
            try
            {
                if (txtKM.Text == "" || txtGiaBan.Text == "")
                {

                }
                else
                {
                    float a = float.Parse(txtGiaBan.Text);
                    int b = int.Parse(txtKM.Text);
                    float c = a - (a * b / 100);
                    textBox1.Text = c.ToString();
                }
            } catch (Exception ex) {
               // MessageBox.Show(ex.Message);
            }


        }


        private void txtLoiNhuan_TextChanged(object sender, EventArgs e)
        {
            updateGiaBan();
            updateKM();
        }

        private void txtKM_TextChanged(object sender, EventArgs e)
        {
            updateKM();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIMG_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            formCate f = new formCate();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fromBrand f = new fromBrand();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // InitializeComponent();
            ResetForm();
        }

        void ResetForm()
        {
            txtTenSP.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtLoiNhuan.Text = "";
            txtKM.Text = "";
            textBox1.Text = "";
            pictureBox1.Image = null;
            loadBrand();
            loadCate();
            loadSize();
            AutoID();
        }

    }
}

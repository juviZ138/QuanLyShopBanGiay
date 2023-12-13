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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyShopBanGiay.GUI.subForm
{
    public partial class addKhuyenMai : Form
    {
        KhuyenMaiBUS KhuyenMaiBUS = new KhuyenMaiBUS();
        public addKhuyenMai()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTenKM.Text == "" || txtPhanTramGiam.Text == "" || txtValue.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu");
                txtTenKM.Focus();
                return;
            }

            if (txtPhanTramGiam.Value < 0)
            {
                MessageBox.Show("Phần Trăm Phải Lớn Hơn Hoặc Bằng 0");
                txtPhanTramGiam.Focus();
                return;
            }

            if (txtValue.Value < 0)
            {
                MessageBox.Show("Số Tiền Tối Thiểu Phải Lớn Hơn Hoặc Bằng 0");
                txtValue.Focus();
                return;
            }


            KhuyenMai km= new KhuyenMai();
            km.MaKM = AutoID();
            km.TenKM = txtTenKM.Text;
            km.PhanTramGiam = float.Parse(txtPhanTramGiam.Text);
            km.value = float.Parse(txtValue.Text);



            DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả từ hộp thoại
            if (result == DialogResult.Yes)
            {
                KhuyenMaiBUS.AddKhuyenMai(km);
                MessageBox.Show("Thêm thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã hủy thêm");

            }
        }

        public string AutoID()
        {
            DataTable dt = KhuyenMaiBUS.GetAllKhuyenMai();

            string s = "";
            if (dt.Rows.Count <= 0)
            {
                s = "KM001";
            }
            else
            {
                int k;
                s = "KM";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

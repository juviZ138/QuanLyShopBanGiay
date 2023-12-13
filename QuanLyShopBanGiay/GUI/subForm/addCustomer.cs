using iText.StyledXmlParser.Jsoup.Helper;
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
using System.Text.RegularExpressions;

namespace QuanLyShopBanGiay.GUI.subForm
{
    public partial class addCustomer : Form
    {
        KhachHangBUS khachHangBUS = new KhachHangBUS();
        public addCustomer()
        {
            InitializeComponent();
        }

        static bool IsPhoneNumber(string input)
        {
            // Sử dụng biểu thức chính quy để kiểm tra định dạng số điện thoại
            // Đây là một biểu thức chính quy đơn giản, bạn có thể điều chỉnh nó tùy thuộc vào yêu cầu cụ thể của bạn
            string phoneNumberPattern = @"^(0[1-9][0-9]{8})$";

            Regex regex = new Regex(phoneNumberPattern);

            return regex.IsMatch(input);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu");
                return;
            }

            if (!IsPhoneNumber(textBox2.Text))
            {
                MessageBox.Show("Số Điện Thoại Ko Hợp Lệ");
                textBox2.Focus();
                return;
            }

            if (khachHangBUS.CheckPhone(textBox2.Text) == 0)
            {
                MessageBox.Show("Đã Có Số Điện Thoại Này Trong Hệ Thống");
                textBox2.Focus();
                return;
            }


            KhachHang khachHang = new KhachHang();
            khachHang.MaKH = AutoID();
            khachHang.TenKH = textBox1.Text;
            khachHang.SDT = textBox2.Text;
            khachHang.total = 0;
            khachHang.point = 0;


            DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả từ hộp thoại
            if (result == DialogResult.Yes)
            {
                khachHangBUS.AddKhachHang(khachHang);
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
            DataTable dt = khachHangBUS.GetAllKhachHangs();

            string s = "";
            if (dt.Rows.Count <= 0)
            {
                s = "KH001";
            }
            else
            {
                int k;
                s = "KH";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

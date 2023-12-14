

using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DTO;
using QuanLyShopBanGiay.GUI;
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
    public partial class Login : Form
    {
        public Users user;
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "Close");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox1, "Minimize");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxShow_Click(object sender, EventArgs e)
        {
            pictureBoxShow.Hide();
            txtPass.UseSystemPasswordChar = true;
            pictureBoxHide.Show();
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            pictureBoxHide.Hide();
            txtPass.UseSystemPasswordChar = false;
            pictureBoxShow.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenTK = txtUser.Text;
            string MatKhau = txtPass.Text;
            if (tenTK.Trim() == "") { MessageBox.Show("Vui lòng nhập tên tài khoản "); }
            else if (MatKhau.Trim() == "") { MessageBox.Show("Vui lòng nhập Mật Khẩu "); }

            else
            {
                DangNhapBLL dangNhapBLL = new DangNhapBLL();
                user = dangNhapBLL.getLogin(tenTK, MatKhau);
                if (user == null)
                {
                    MessageBox.Show("Nhập sai tên tài khoản hoặc mật khẩu");

                }
                else
                {
                    if (user.isDeleted == 0)
                    {
                        MessageBox.Show("Tài Khoản đã bị khóa ! Vui lòng liên hệ admin để mở ! ");
                        return;
                    }
                    MessageBox.Show("đăng nhập thành công");
                    this.Hide();
                    //Form1 form1 = new Form1();
                    formMain form1 = new formMain();
/*                    Form1.phanquyen(NhanVien);
                    Form1.setNhanVien(NhanVien);
                    Form1.StartPosition = FormStartPosition.CenterScreen;*/
                    form1.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using Shoes_Management.BUS;
using QuanLyShopBanGiay.BUS;
using QuanLyShopBanGiay.DTO;

namespace QuanLyShopBanGiay.GUI
{

    public partial class UserGUI : Form
    {
        public static List<Users> listUser;

        public static List<Role> listRole;

        Users user = null;
        public UserGUI()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Load1();
        }

        public void GetRole(Users us)
        {
            if (us != null)
            {
                user = us;
            }
        }
        private List<string> getRole()
        {
            RoleBLL roleBLL = new RoleBLL();
            List<string> role = new List<string>();
            listRole = roleBLL.getRole();
            if (listRole != null)
            {
                for (int i = 0; i < listRole.Count(); i++)
                {
                    role.Add(listRole[i].role_name);
                }

            }

            return role;
        }

        private List<string> getGioiTinh()
        {
            List<string> s = new List<string>() { "Nam", "Nữ" };
            return s;
        }

        private void Load1()
        {
            comboBoxGioitinh.DataSource = getGioiTinh();
            comboBoxChucvu.DataSource = getRole();
            UserBLL userBLL = new UserBLL();
            listUser = userBLL.getListUser();
            if (listUser.Count > 0)
            {
                dataGridView1.DataSource = listUser;

            }

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a;
            txtMatk.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPass.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtHoten.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtSdt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtCCCD.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBoxGioitinh.SelectedItem = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtNamsinh.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtDiachi.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            try
            {
                int indexChucVu = (int)dataGridView1.CurrentRow.Cells[9].Value;

                if (listRole != null)
                {
                    for (int i = 0; i < listRole.Count(); i++)
                    {
                        if (listRole[i].role_id == indexChucVu)
                        {
                            comboBoxChucvu.SelectedIndex = i;
                        }
                    }
                }
            }
            catch
            {
                txtPass.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBoxChucvu.SelectedIndex = -1;
            }
            try
            {
                a = (int)dataGridView1.CurrentRow.Cells[10].Value;
                if (a == 1)
                {
                    radioTrangThai.Checked = true;
                }
                else radioTrangThai.Checked = false;
            }
            catch
            {
                radioTrangThai.Checked = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maChucVu = 0;
            if (listRole != null)
            {
                for (int i = 0; i < listRole.Count(); i++)
                {
                    if (comboBoxChucvu.SelectedIndex == i)
                    {
                        maChucVu = listRole[i].role_id;
                    }
                }
            }

            int trangThaiTaiKhoan = 0;

            if (radioTrangThai.Checked == false)
            {
                trangThaiTaiKhoan = 0;
            }
            else
            {
                trangThaiTaiKhoan = 1;
            }
            Users us1 = new Users(txtMatk.Text, txtPass.Text, txtHoten.Text, txtEmail.Text, txtSdt.Text, txtCCCD.Text, comboBoxGioitinh.SelectedItem.ToString(), txtNamsinh.Text, txtDiachi.Text, maChucVu, trangThaiTaiKhoan);


            UserBLL userBLL = new UserBLL();
            Boolean ktra = userBLL.suaUser(us1);
            if (ktra)
            {
                MessageBox.Show("Sửa Thành công");
                Load1();
            }
            else
            {
                MessageBox.Show("Sửa không thành công");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string password = txtPass.Text;
            string full_name = txtHoten.Text;
            string email = txtEmail.Text;
            string phone = txtSdt.Text;
            string cccd = txtCCCD.Text;
            string gender = comboBoxGioitinh.SelectedItem.ToString();
            string year_birth = txtNamsinh.Text;
            string address = txtDiachi.Text;
            int ChucVu = comboBoxChucvu.SelectedIndex;


            if (full_name.Trim() == "") { MessageBox.Show("Vui lòng nhập Họ Và Tên "); }
            else if (year_birth == null) { MessageBox.Show("Vui lòng chọn ngày sinh "); }
            else if (password.Trim() == "") { MessageBox.Show("Vui lòng nhập Mật Khẩu "); }
            else if (phone.Trim() == "") { MessageBox.Show("Vui lòng nhập số điênh thoại "); }

            else
            {
                int maChucVu = 0;
                if (listRole != null)
                {
                    for (int i = 0; i < listRole.Count(); i++)
                    {
                        if (comboBoxChucvu.SelectedIndex == i)
                        {
                            maChucVu = listRole[i].role_id;
                        }
                    }
                }

                int trangThaiTaiKhoan = 0;

                if (radioTrangThai.Checked == false)
                {
                    trangThaiTaiKhoan = 0;
                }
                else
                {
                    trangThaiTaiKhoan = 1;
                }
                Users getma = new Users();
                string mauser = getma.getMa();
                Users nv = new Users(txtMatk.Text, txtPass.Text, txtHoten.Text, txtEmail.Text, txtSdt.Text, txtCCCD.Text, comboBoxGioitinh.SelectedItem.ToString(), txtNamsinh.Text, txtDiachi.Text, maChucVu, trangThaiTaiKhoan);


                UserBLL nhanVienBLL = new UserBLL();
                Boolean ktra = nhanVienBLL.themUser(nv);
                if (ktra)
                {
                    MessageBox.Show("Thêm Thành công");
                    Load1();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");

                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Boolean ktra = false;
            string manhanvien = txtMatk.Text;
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn xóa nhân viên " + manhanvien, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                UserBLL nhanVienBLL = new UserBLL();
                ktra = nhanVienBLL.xoaUser(manhanvien);

                if (ktra)
                {
                    MessageBox.Show("Xóa Thành Công");
                    Load1();
                }
                else
                {
                    MessageBox.Show("Xóa Không Thành Công");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMatk.Text = null;
            txtHoten.Text = null;
            comboBoxGioitinh.SelectedItem = 1;
            txtEmail.Text = null;
            txtCCCD.Text = null;
            txtNamsinh.Text = null;
            txtDiachi.Text = null;
            txtSdt.Text = null;
            txtPass.Text = null;
            comboBoxChucvu.SelectedIndex = 0;
            radioTrangThai.Checked = false;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string stringtimkiem = txtTimkiem.Text;
            UserBLL nhanVienBLL = new UserBLL();

            dataGridView1.DataSource = nhanVienBLL.getListTimKiem(stringtimkiem);
        }

    }
}

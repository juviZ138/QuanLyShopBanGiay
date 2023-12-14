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

namespace QuanLyShopBanGiay.GUI {

    public partial class UserGUI : Form
    {
        public static List<Users> listUser = null;

        public static List<Role> listRole = null;

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
                

            }

            listView1.Items.Clear();
            foreach (Users User in userBLL.getListUser())
            {
                ListViewItem item = new ListViewItem(User.user_id);
                item.SubItems.Add(User.password);
                item.SubItems.Add(User.full_name);
                item.SubItems.Add(User.email);
                item.SubItems.Add(User.phone);
                item.SubItems.Add(User.cccd);
                item.SubItems.Add(User.gender);
                item.SubItems.Add(User.year_birth);
                item.SubItems.Add(User.address);
                item.SubItems.Add(User.role_id.ToString());
                item.SubItems.Add(User.isDeleted.ToString());



                listView1.Items.Add(item);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                
            }
        }
    }
}

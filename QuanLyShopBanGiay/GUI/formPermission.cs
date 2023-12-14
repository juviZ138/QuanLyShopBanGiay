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
using QuanLyShopBanGiay.BUS;
namespace QuanLyShopBanGiay.GUI
{
    public partial class formPermission : Form
    {
        public static List<Permission> listQuyen = null;
        public formPermission()
        {
            InitializeComponent();
            Load1();
        }

        private void Load1()
        {
            PermissionBLL nhanVienBLL = new PermissionBLL();
            listQuyen = nhanVienBLL.getListPermission();
            if (listQuyen.Count > 0)
            {
                dataGridView1.DataSource = listQuyen;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaquyen.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenquyen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if ((int)dataGridView1.CurrentRow.Cells[2].Value == 1)
            {
                cbBanhang.Checked = true;
            }
            else
            {
                cbBanhang.Checked = false;
            }
            if ((int)dataGridView1.CurrentRow.Cells[3].Value == 1)
            {
                cbHoadon.Checked = true;
            }
            else { cbHoadon.Checked = false; }
            if ((int)dataGridView1.CurrentRow.Cells[4].Value == 1)
            {
                cbSanpham.Checked = true;
            }
            else { cbSanpham.Checked = false; }
            if ((int)dataGridView1.CurrentRow.Cells[5].Value == 1)
            {
                cbTaikhoan.Checked = true;
            }
            else { cbTaikhoan.Checked = false; }
            if ((int)dataGridView1.CurrentRow.Cells[6].Value == 1)
            {
                cbNhaphang.Checked = true;
            }
            else { cbNhaphang.Checked = false; }
            if ((int)dataGridView1.CurrentRow.Cells[7].Value == 1)
            {
                cbKhuyenmai.Checked = true;
            }
            else { cbKhuyenmai.Checked = false; }
            if ((int)dataGridView1.CurrentRow.Cells[8].Value == 1)
            {
                cbKhachhang.Checked = true;
            }
            else { cbKhachhang.Checked = false; }
            if ((int)dataGridView1.CurrentRow.Cells[9].Value == 1)
            {
                cbQuyen.Checked = true;
            }
            else { cbQuyen.Checked = false; }
        }

        //Them
        private void button1_Click(object sender, EventArgs e)
        {
            Permission quyenDTO = new Permission();
            quyenDTO.id = int.Parse(txtMaquyen.Text);
            PermissionBLL nhanVienBLL = new PermissionBLL();
            listQuyen = nhanVienBLL.getListPermission();
            for (int i = 0; i < listQuyen.Count(); i++)
            {
                if (quyenDTO.id == listQuyen[i].id)
                {
                    MessageBox.Show("MÃ quyền đã tồn tại");
                    return;
                }
            }

            quyenDTO.tenquyen = txtTenquyen.Text;
            txtTenquyen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (cbBanhang.Checked == true)
            {
                quyenDTO.isSale = 1;
            }
            else
            {
                quyenDTO.isSale = 0;
            }
            if (cbHoadon.Checked == true)
            {
                quyenDTO.isBill = 1;
            }
            else
            {
                quyenDTO.isBill = 0;
            }
            if (cbSanpham.Checked == true)
            {
                quyenDTO.isProduct = 1;
            }
            else
            {
                quyenDTO.isProduct = 0;
            }
            if (cbTaikhoan.Checked == true)
            {
                quyenDTO.isUser = 1;
            }
            else
            {
                quyenDTO.isUser = 0;
            }
            if (cbNhaphang.Checked == true)
            {
                quyenDTO.isReceive = 1;
            }
            else
            {
                quyenDTO.isReceive = 0;
            }
            if (cbKhuyenmai.Checked == true)
            {
                quyenDTO.isPromo = 1;
            }
            else
            {
                quyenDTO.isPromo = 0;
            }
            if (cbKhachhang.Checked == true)
            {
                quyenDTO.isCustomer = 1;
            }
            else
            {
                quyenDTO.isCustomer = 0;
            }
            if (cbQuyen.Checked == true)
            {
                quyenDTO.isPermission = 1;
            }
            else
            {
                quyenDTO.isPermission = 0;
            }

            PermissionBLL quyenBLL = new PermissionBLL();
            Boolean a = quyenBLL.themQuyen(quyenDTO);

            if (a == true)
            {
                MessageBox.Show("Thêm Thành công");
                Load1();
                clear();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Permission quyenDTO = new Permission();
            quyenDTO.id = int.Parse(txtMaquyen.Text);
            PermissionBLL nhanVienBLL = new PermissionBLL();
            listQuyen = nhanVienBLL.getListPermission();


            quyenDTO.tenquyen = txtTenquyen.Text;
            txtTenquyen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (cbBanhang.Checked == true)
            {
                quyenDTO.isSale = 1;
            }
            else
            {
                quyenDTO.isSale = 0;
            }
            if (cbHoadon.Checked == true)
            {
                quyenDTO.isBill = 1;
            }
            else
            {
                quyenDTO.isBill = 0;
            }
            if (cbSanpham.Checked == true)
            {
                quyenDTO.isProduct = 1;
            }
            else
            {
                quyenDTO.isProduct = 0;
            }
            if (cbTaikhoan.Checked == true)
            {
                quyenDTO.isUser = 1;
            }
            else
            {
                quyenDTO.isUser = 0;
            }
            if (cbNhaphang.Checked == true)
            {
                quyenDTO.isReceive = 1;
            }
            else
            {
                quyenDTO.isReceive = 0;
            }
            if (cbKhuyenmai.Checked == true)
            {
                quyenDTO.isPromo = 1;
            }
            else
            {
                quyenDTO.isPromo = 0;
            }
            if (cbKhachhang.Checked == true)
            {
                quyenDTO.isCustomer = 1;
            }
            else
            {
                quyenDTO.isCustomer = 0;
            }
            if (cbQuyen.Checked == true)
            {
                quyenDTO.isPermission = 1;
            }
            else
            {
                quyenDTO.isPermission = 0;
            }

            PermissionBLL quyenBLL = new PermissionBLL();
            Boolean a = quyenBLL.suaPermission(quyenDTO);

            if (a == true)
            {
                MessageBox.Show("Sửa Thành công");
                Load1();
                clear();
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PermissionBLL quyenBLL = new PermissionBLL();
            
            int maquyen = int.Parse(txtMaquyen.Text);
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn xóa quyền " + maquyen, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Boolean kt = quyenBLL.xoaPermission(maquyen);
                
                if (kt == true)
                {
                    MessageBox.Show("Xóa Thành Công ");
                    Load1();
                    clear();

                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại ");
                    return;
                }
            }
        }

        private void clear()
        {
            txtMaquyen.Text = null;
            txtTenquyen.Text = null;
            cbKhuyenmai.Checked = false;
            cbKhachhang.Checked = false;
            cbTaikhoan.Checked = false;
            cbQuyen.Checked = false;
            cbBanhang.Checked = false;
            cbNhaphang.Checked = false;
            cbHoadon.Checked = false;
            cbSanpham.Checked = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            txtMaquyen.Text = null;
            txtTenquyen.Text = null;
            cbKhuyenmai.Checked = false;
            cbKhachhang.Checked = false;
            cbTaikhoan.Checked = false;
            cbQuyen.Checked = false;
            cbBanhang.Checked = false;
            cbNhaphang.Checked = false;
            cbHoadon.Checked = false;
            cbSanpham.Checked = false;
        }
    }
}

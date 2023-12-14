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
    public partial class formMain : Form
    {

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        public formMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formCustomer f = new formCustomer();
            f.MdiParent = formMain.ActiveForm;
            openChildForm(f);
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formTaoHoaDon f = new formTaoHoaDon();
            f.MdiParent = formMain.ActiveForm;
            openChildForm(f);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formXemHoaDon f = new formXemHoaDon();
            f.MdiParent = formMain.ActiveForm;
            openChildForm(f);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formXemPhieuNhap custom = new formXemPhieuNhap();
            custom.MdiParent = formMain.ActiveForm;
            openChildForm(custom);
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            formKhuyenMai f = new formKhuyenMai();
            f.MdiParent = formMain.ActiveForm;
            openChildForm(f);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            formProduct formProduct = new formProduct();
            formProduct.MdiParent = formMain.ActiveForm;
            openChildForm(formProduct);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserGUI f = new UserGUI();
            f.MdiParent = formMain.ActiveForm;
            openChildForm(f);
        }
    }
}

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
    public partial class frmMain : Form
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


        public frmMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormXemPhieuNhap custom = new FormXemPhieuNhap();
            custom.MdiParent = frmMain.ActiveForm;
            openChildForm(custom);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formProduct formProduct = new formProduct();
            formProduct.MdiParent = frmMain.ActiveForm;
            openChildForm(formProduct);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }
    }
}

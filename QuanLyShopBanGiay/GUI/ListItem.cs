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
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        public void setName(string str)
        {
            lbTenSP.Text = str;
        }
        public void setMaSP(string str)
        {
            lbMaSP.Text = str;
        }

        public void setGiaNhap(string str)
        {
            lbGiaNhap.Text = str;
        }

        public void setGiaBan(string str)
        {
            lbGiaBan.Text = str;
        }
        public void setKM(string str)
        {
           lbKM.Visible = true;
            txtKM.Visible = true;
            txtKM.Text = str;
        }

        public void setCate (string str)
        {
            lbCate.Text = str;
        }

        public void setThuongHieu (string str)
        {
            lbThuongHieu.Text = str;
        }

        public void LoadIMG(string img)
        {
            try
            {
              this.pictureBox1.Image = System.Drawing.Image.FromFile(img);
            } catch(Exception ex)
            {
               
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ListItem_MouseEnter(object sender, EventArgs e)
        {
          //this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ListItem_MouseLeave(object sender, EventArgs e)
        {
           //  this.BackColor = Color.White;
        }

        private void ListItem_MouseHover(object sender, EventArgs e)
        {
         //   this.BackColor = Color.Aqua;
        }
        public event EventHandler<string> ControlClicked;
        private void ListItem_Click(object sender, EventArgs e)
        {
            ControlClicked?.Invoke(this,lbMaSP.Text) ;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

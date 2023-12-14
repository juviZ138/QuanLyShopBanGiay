namespace QuanLyShopBanGiay.GUI
{
    partial class ListItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbTenSP = new System.Windows.Forms.Label();
            this.lbMaSP = new System.Windows.Forms.Label();
            this.lbGiaNhap = new System.Windows.Forms.Label();
            this.lbGiaBan = new System.Windows.Forms.Label();
            this.lbThuongHieu = new System.Windows.Forms.Label();
            this.lbCate = new System.Windows.Forms.Label();
            this.lbKM = new System.Windows.Forms.Label();
            this.txtKM = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(16, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbTenSP
            // 
            this.lbTenSP.AutoSize = true;
            this.lbTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSP.ForeColor = System.Drawing.Color.Red;
            this.lbTenSP.Location = new System.Drawing.Point(133, 10);
            this.lbTenSP.Name = "lbTenSP";
            this.lbTenSP.Size = new System.Drawing.Size(156, 25);
            this.lbTenSP.TabIndex = 1;
            this.lbTenSP.Text = "Tên Sản Phẩm";
            this.lbTenSP.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbMaSP
            // 
            this.lbMaSP.AutoSize = true;
            this.lbMaSP.Location = new System.Drawing.Point(143, 35);
            this.lbMaSP.Name = "lbMaSP";
            this.lbMaSP.Size = new System.Drawing.Size(109, 20);
            this.lbMaSP.TabIndex = 2;
            this.lbMaSP.Text = "Mã Sản Phẩm";
            this.lbMaSP.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbGiaNhap
            // 
            this.lbGiaNhap.AutoSize = true;
            this.lbGiaNhap.ForeColor = System.Drawing.Color.MediumBlue;
            this.lbGiaNhap.Location = new System.Drawing.Point(143, 95);
            this.lbGiaNhap.Name = "lbGiaNhap";
            this.lbGiaNhap.Size = new System.Drawing.Size(76, 20);
            this.lbGiaNhap.TabIndex = 3;
            this.lbGiaNhap.Text = "Giá Nhập";
            // 
            // lbGiaBan
            // 
            this.lbGiaBan.AutoSize = true;
            this.lbGiaBan.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbGiaBan.Location = new System.Drawing.Point(257, 95);
            this.lbGiaBan.Name = "lbGiaBan";
            this.lbGiaBan.Size = new System.Drawing.Size(67, 20);
            this.lbGiaBan.TabIndex = 4;
            this.lbGiaBan.Text = "Giá Bán";
            // 
            // lbThuongHieu
            // 
            this.lbThuongHieu.AutoSize = true;
            this.lbThuongHieu.Location = new System.Drawing.Point(257, 65);
            this.lbThuongHieu.Name = "lbThuongHieu";
            this.lbThuongHieu.Size = new System.Drawing.Size(52, 20);
            this.lbThuongHieu.TabIndex = 5;
            this.lbThuongHieu.Text = "Brand";
            // 
            // lbCate
            // 
            this.lbCate.AutoSize = true;
            this.lbCate.Location = new System.Drawing.Point(143, 65);
            this.lbCate.Name = "lbCate";
            this.lbCate.Size = new System.Drawing.Size(43, 20);
            this.lbCate.TabIndex = 6;
            this.lbCate.Text = "Cate";
            // 
            // lbKM
            // 
            this.lbKM.AutoSize = true;
            this.lbKM.ForeColor = System.Drawing.Color.Red;
            this.lbKM.Location = new System.Drawing.Point(143, 125);
            this.lbKM.Name = "lbKM";
            this.lbKM.Size = new System.Drawing.Size(120, 20);
            this.lbKM.TabIndex = 7;
            this.lbKM.Text = "Giá Khuyến Mãi";
            this.lbKM.Visible = false;
            this.lbKM.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtKM
            // 
            this.txtKM.AutoSize = true;
            this.txtKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKM.ForeColor = System.Drawing.Color.Red;
            this.txtKM.Location = new System.Drawing.Point(142, 145);
            this.txtKM.Name = "txtKM";
            this.txtKM.Size = new System.Drawing.Size(152, 25);
            this.txtKM.TabIndex = 8;
            this.txtKM.Text = "Giá Khuyến Mãi";
            this.txtKM.Visible = false;
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtKM);
            this.Controls.Add(this.lbKM);
            this.Controls.Add(this.lbCate);
            this.Controls.Add(this.lbThuongHieu);
            this.Controls.Add(this.lbGiaBan);
            this.Controls.Add(this.lbGiaNhap);
            this.Controls.Add(this.lbMaSP);
            this.Controls.Add(this.lbTenSP);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(377, 185);
            this.Click += new System.EventHandler(this.ListItem_Click);
            this.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            this.MouseHover += new System.EventHandler(this.ListItem_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTenSP;
        private System.Windows.Forms.Label lbMaSP;
        private System.Windows.Forms.Label lbGiaNhap;
        private System.Windows.Forms.Label lbGiaBan;
        private System.Windows.Forms.Label lbThuongHieu;
        private System.Windows.Forms.Label lbCate;
        private System.Windows.Forms.Label lbKM;
        private System.Windows.Forms.Label txtKM;
    }
}

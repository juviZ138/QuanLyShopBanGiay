namespace QuanLyShopBanGiay.GUI
{
    partial class formPermission
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaquyen = new System.Windows.Forms.TextBox();
            this.txtTenquyen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbQuyen = new System.Windows.Forms.CheckBox();
            this.cbTaikhoan = new System.Windows.Forms.CheckBox();
            this.cbKhuyenmai = new System.Windows.Forms.CheckBox();
            this.cbHoadon = new System.Windows.Forms.CheckBox();
            this.cbKhachhang = new System.Windows.Forms.CheckBox();
            this.cbSanpham = new System.Windows.Forms.CheckBox();
            this.cbNhaphang = new System.Windows.Forms.CheckBox();
            this.cbBanhang = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(428, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Quyền";
            // 
            // txtMaquyen
            // 
            this.txtMaquyen.Location = new System.Drawing.Point(185, 85);
            this.txtMaquyen.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaquyen.Name = "txtMaquyen";
            this.txtMaquyen.Size = new System.Drawing.Size(314, 34);
            this.txtMaquyen.TabIndex = 1;
            // 
            // txtTenquyen
            // 
            this.txtTenquyen.Location = new System.Drawing.Point(672, 88);
            this.txtTenquyen.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenquyen.Name = "txtTenquyen";
            this.txtTenquyen.Size = new System.Drawing.Size(428, 34);
            this.txtTenquyen.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên Quyền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 28);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mã Quyền";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(52, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 63);
            this.button1.TabIndex = 11;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.Location = new System.Drawing.Point(321, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(256, 63);
            this.button2.TabIndex = 12;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(583, 309);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(256, 63);
            this.button3.TabIndex = 13;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(844, 309);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(256, 63);
            this.button4.TabIndex = 14;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbQuyen);
            this.groupBox1.Controls.Add(this.cbTaikhoan);
            this.groupBox1.Controls.Add(this.cbKhuyenmai);
            this.groupBox1.Controls.Add(this.cbHoadon);
            this.groupBox1.Controls.Add(this.cbKhachhang);
            this.groupBox1.Controls.Add(this.cbSanpham);
            this.groupBox1.Controls.Add(this.cbNhaphang);
            this.groupBox1.Controls.Add(this.cbBanhang);
            this.groupBox1.Location = new System.Drawing.Point(53, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1047, 161);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // cbQuyen
            // 
            this.cbQuyen.AutoSize = true;
            this.cbQuyen.Location = new System.Drawing.Point(796, 52);
            this.cbQuyen.Margin = new System.Windows.Forms.Padding(4);
            this.cbQuyen.Name = "cbQuyen";
            this.cbQuyen.Size = new System.Drawing.Size(95, 32);
            this.cbQuyen.TabIndex = 16;
            this.cbQuyen.Text = "Quyền";
            this.cbQuyen.UseVisualStyleBackColor = true;
            // 
            // cbTaikhoan
            // 
            this.cbTaikhoan.AutoSize = true;
            this.cbTaikhoan.Location = new System.Drawing.Point(796, 93);
            this.cbTaikhoan.Margin = new System.Windows.Forms.Padding(4);
            this.cbTaikhoan.Name = "cbTaikhoan";
            this.cbTaikhoan.Size = new System.Drawing.Size(191, 32);
            this.cbTaikhoan.TabIndex = 15;
            this.cbTaikhoan.Text = "Quản lý tài khoản";
            this.cbTaikhoan.UseVisualStyleBackColor = true;
            // 
            // cbKhuyenmai
            // 
            this.cbKhuyenmai.AutoSize = true;
            this.cbKhuyenmai.Location = new System.Drawing.Point(308, 93);
            this.cbKhuyenmai.Margin = new System.Windows.Forms.Padding(4);
            this.cbKhuyenmai.Name = "cbKhuyenmai";
            this.cbKhuyenmai.Size = new System.Drawing.Size(216, 32);
            this.cbKhuyenmai.TabIndex = 14;
            this.cbKhuyenmai.Text = "Quản Lý Khuyến Mãi";
            this.cbKhuyenmai.UseVisualStyleBackColor = true;
            // 
            // cbHoadon
            // 
            this.cbHoadon.AutoSize = true;
            this.cbHoadon.Location = new System.Drawing.Point(42, 93);
            this.cbHoadon.Margin = new System.Windows.Forms.Padding(4);
            this.cbHoadon.Name = "cbHoadon";
            this.cbHoadon.Size = new System.Drawing.Size(191, 32);
            this.cbHoadon.TabIndex = 13;
            this.cbHoadon.Text = "Quản Lý Hóa Đơn";
            this.cbHoadon.UseVisualStyleBackColor = true;
            // 
            // cbKhachhang
            // 
            this.cbKhachhang.AutoSize = true;
            this.cbKhachhang.Location = new System.Drawing.Point(544, 52);
            this.cbKhachhang.Margin = new System.Windows.Forms.Padding(4);
            this.cbKhachhang.Name = "cbKhachhang";
            this.cbKhachhang.Size = new System.Drawing.Size(218, 32);
            this.cbKhachhang.TabIndex = 12;
            this.cbKhachhang.Text = "Quản Lý Khách Hàng";
            this.cbKhachhang.UseVisualStyleBackColor = true;
            // 
            // cbSanpham
            // 
            this.cbSanpham.AutoSize = true;
            this.cbSanpham.Location = new System.Drawing.Point(544, 93);
            this.cbSanpham.Margin = new System.Windows.Forms.Padding(4);
            this.cbSanpham.Name = "cbSanpham";
            this.cbSanpham.Size = new System.Drawing.Size(199, 32);
            this.cbSanpham.TabIndex = 11;
            this.cbSanpham.Text = "Quản Lý Sản Phẩm";
            this.cbSanpham.UseVisualStyleBackColor = true;
            // 
            // cbNhaphang
            // 
            this.cbNhaphang.AutoSize = true;
            this.cbNhaphang.Location = new System.Drawing.Point(308, 52);
            this.cbNhaphang.Margin = new System.Windows.Forms.Padding(4);
            this.cbNhaphang.Name = "cbNhaphang";
            this.cbNhaphang.Size = new System.Drawing.Size(138, 32);
            this.cbNhaphang.TabIndex = 10;
            this.cbNhaphang.Text = "Nhập Hàng";
            this.cbNhaphang.UseVisualStyleBackColor = true;
            // 
            // cbBanhang
            // 
            this.cbBanhang.AutoSize = true;
            this.cbBanhang.Location = new System.Drawing.Point(42, 52);
            this.cbBanhang.Margin = new System.Windows.Forms.Padding(4);
            this.cbBanhang.Name = "cbBanhang";
            this.cbBanhang.Size = new System.Drawing.Size(122, 32);
            this.cbBanhang.TabIndex = 9;
            this.cbBanhang.Text = "Bán Hàng";
            this.cbBanhang.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(52, 389);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1048, 350);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // formPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1160, 810);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenquyen);
            this.Controls.Add(this.txtMaquyen);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formPermission";
            this.Text = "formPermission";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaquyen;
        private System.Windows.Forms.TextBox txtTenquyen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbKhuyenmai;
        private System.Windows.Forms.CheckBox cbHoadon;
        private System.Windows.Forms.CheckBox cbKhachhang;
        private System.Windows.Forms.CheckBox cbSanpham;
        private System.Windows.Forms.CheckBox cbNhaphang;
        private System.Windows.Forms.CheckBox cbBanhang;
        private System.Windows.Forms.CheckBox cbTaikhoan;
        private System.Windows.Forms.CheckBox cbQuyen;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
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
            this.label1.Location = new System.Drawing.Point(338, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Quyền";
            // 
            // txtMaquyen
            // 
            this.txtMaquyen.Location = new System.Drawing.Point(165, 73);
            this.txtMaquyen.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaquyen.Name = "txtMaquyen";
            this.txtMaquyen.Size = new System.Drawing.Size(214, 30);
            this.txtMaquyen.TabIndex = 1;
            // 
            // txtTenquyen
            // 
            this.txtTenquyen.Location = new System.Drawing.Point(533, 76);
            this.txtTenquyen.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenquyen.Name = "txtTenquyen";
            this.txtTenquyen.Size = new System.Drawing.Size(209, 30);
            this.txtTenquyen.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên Quyền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mã Quyền";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 56);
            this.button1.TabIndex = 11;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(225, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 56);
            this.button2.TabIndex = 12;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(410, 359);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 56);
            this.button3.TabIndex = 13;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(597, 359);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 56);
            this.button4.TabIndex = 14;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
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
            this.groupBox1.Location = new System.Drawing.Point(58, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 213);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // cbQuyen
            // 
            this.cbQuyen.AutoSize = true;
            this.cbQuyen.Location = new System.Drawing.Point(294, 157);
            this.cbQuyen.Margin = new System.Windows.Forms.Padding(4);
            this.cbQuyen.Name = "cbQuyen";
            this.cbQuyen.Size = new System.Drawing.Size(97, 29);
            this.cbQuyen.TabIndex = 16;
            this.cbQuyen.Text = "Quyền";
            this.cbQuyen.UseVisualStyleBackColor = true;
            // 
            // cbTaikhoan
            // 
            this.cbTaikhoan.AutoSize = true;
            this.cbTaikhoan.Location = new System.Drawing.Point(46, 157);
            this.cbTaikhoan.Margin = new System.Windows.Forms.Padding(4);
            this.cbTaikhoan.Name = "cbTaikhoan";
            this.cbTaikhoan.Size = new System.Drawing.Size(190, 29);
            this.cbTaikhoan.TabIndex = 15;
            this.cbTaikhoan.Text = "Quản lý tài khoản";
            this.cbTaikhoan.UseVisualStyleBackColor = true;
            // 
            // cbKhuyenmai
            // 
            this.cbKhuyenmai.AutoSize = true;
            this.cbKhuyenmai.Location = new System.Drawing.Point(294, 83);
            this.cbKhuyenmai.Margin = new System.Windows.Forms.Padding(4);
            this.cbKhuyenmai.Name = "cbKhuyenmai";
            this.cbKhuyenmai.Size = new System.Drawing.Size(223, 29);
            this.cbKhuyenmai.TabIndex = 14;
            this.cbKhuyenmai.Text = "Quản Lý Khuyến Mãi";
            this.cbKhuyenmai.UseVisualStyleBackColor = true;
            // 
            // cbHoadon
            // 
            this.cbHoadon.AutoSize = true;
            this.cbHoadon.Location = new System.Drawing.Point(46, 83);
            this.cbHoadon.Margin = new System.Windows.Forms.Padding(4);
            this.cbHoadon.Name = "cbHoadon";
            this.cbHoadon.Size = new System.Drawing.Size(195, 29);
            this.cbHoadon.TabIndex = 13;
            this.cbHoadon.Text = "Quản Lý Hóa Đơn";
            this.cbHoadon.UseVisualStyleBackColor = true;
            // 
            // cbKhachhang
            // 
            this.cbKhachhang.AutoSize = true;
            this.cbKhachhang.Location = new System.Drawing.Point(294, 120);
            this.cbKhachhang.Margin = new System.Windows.Forms.Padding(4);
            this.cbKhachhang.Name = "cbKhachhang";
            this.cbKhachhang.Size = new System.Drawing.Size(227, 29);
            this.cbKhachhang.TabIndex = 12;
            this.cbKhachhang.Text = "Quản Lý Khách Hàng";
            this.cbKhachhang.UseVisualStyleBackColor = true;
            // 
            // cbSanpham
            // 
            this.cbSanpham.AutoSize = true;
            this.cbSanpham.Location = new System.Drawing.Point(46, 120);
            this.cbSanpham.Margin = new System.Windows.Forms.Padding(4);
            this.cbSanpham.Name = "cbSanpham";
            this.cbSanpham.Size = new System.Drawing.Size(210, 29);
            this.cbSanpham.TabIndex = 11;
            this.cbSanpham.Text = "Quản Lý Sản Phẩm";
            this.cbSanpham.UseVisualStyleBackColor = true;
            // 
            // cbNhaphang
            // 
            this.cbNhaphang.AutoSize = true;
            this.cbNhaphang.Location = new System.Drawing.Point(294, 46);
            this.cbNhaphang.Margin = new System.Windows.Forms.Padding(4);
            this.cbNhaphang.Name = "cbNhaphang";
            this.cbNhaphang.Size = new System.Drawing.Size(137, 29);
            this.cbNhaphang.TabIndex = 10;
            this.cbNhaphang.Text = "Nhập Hàng";
            this.cbNhaphang.UseVisualStyleBackColor = true;
            // 
            // cbBanhang
            // 
            this.cbBanhang.AutoSize = true;
            this.cbBanhang.Location = new System.Drawing.Point(46, 46);
            this.cbBanhang.Margin = new System.Windows.Forms.Padding(4);
            this.cbBanhang.Name = "cbBanhang";
            this.cbBanhang.Size = new System.Drawing.Size(125, 29);
            this.cbBanhang.TabIndex = 9;
            this.cbBanhang.Text = "Bán Hàng";
            this.cbBanhang.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(44, 499);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(715, 150);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 723);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "s";
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
﻿namespace QuanLyShopBanGiay.GUI
{
    partial class formXemPhieuNhap
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
            this.lvPhieuNhap = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTien = new System.Windows.Forms.TextBox();
            this.lvChiTiet = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbNam = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rad3 = new System.Windows.Forms.RadioButton();
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.rad2 = new System.Windows.Forms.RadioButton();
            this.rad1 = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.cbTheoKhoang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvPhieuNhap
            // 
            this.lvPhieuNhap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvPhieuNhap.FullRowSelect = true;
            this.lvPhieuNhap.HideSelection = false;
            this.lvPhieuNhap.Location = new System.Drawing.Point(30, 275);
            this.lvPhieuNhap.Name = "lvPhieuNhap";
            this.lvPhieuNhap.Size = new System.Drawing.Size(576, 300);
            this.lvPhieuNhap.TabIndex = 0;
            this.lvPhieuNhap.UseCompatibleStateImageBehavior = false;
            this.lvPhieuNhap.View = System.Windows.Forms.View.Details;
            this.lvPhieuNhap.SelectedIndexChanged += new System.EventHandler(this.lvPhieuNhap_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Phiếu Nhập";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã Nhân Viên";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngày Nhập";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng Số Tiền";
            this.columnHeader4.Width = 100;
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Enabled = false;
            this.txtNhanVien.Location = new System.Drawing.Point(149, 243);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(121, 26);
            this.txtNhanVien.TabIndex = 2;
            this.txtNhanVien.TextChanged += new System.EventHandler(this.txtNhanVien_TextChanged);
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Enabled = false;
            this.txtMaPhieu.Location = new System.Drawing.Point(30, 243);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(113, 26);
            this.txtMaPhieu.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã Phiếu Nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nhân Viên Nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(856, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tổng Số Tiền";
            // 
            // txtTien
            // 
            this.txtTien.Location = new System.Drawing.Point(967, 28);
            this.txtTien.Name = "txtTien";
            this.txtTien.Size = new System.Drawing.Size(133, 26);
            this.txtTien.TabIndex = 8;
            // 
            // lvChiTiet
            // 
            this.lvChiTiet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvChiTiet.FullRowSelect = true;
            this.lvChiTiet.HideSelection = false;
            this.lvChiTiet.Location = new System.Drawing.Point(626, 70);
            this.lvChiTiet.Name = "lvChiTiet";
            this.lvChiTiet.Size = new System.Drawing.Size(474, 505);
            this.lvChiTiet.TabIndex = 9;
            this.lvChiTiet.UseCompatibleStateImageBehavior = false;
            this.lvChiTiet.View = System.Windows.Forms.View.Details;
            this.lvChiTiet.SelectedIndexChanged += new System.EventHandler(this.lvChiTiet_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mã Sản Phẩm";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Mã Size";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Số Lượng";
            this.columnHeader7.Width = 70;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Đơn Giá";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Thành Tiền";
            this.columnHeader9.Width = 150;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Image = global::QuanLyShopBanGiay.Properties.Resources.icons8_add_48;
            this.button1.Location = new System.Drawing.Point(16, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 59);
            this.button1.TabIndex = 10;
            this.button1.Text = "Tạo Phiếu Nhập";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.Image = global::QuanLyShopBanGiay.Properties.Resources.icons8_excel_48;
            this.button2.Location = new System.Drawing.Point(167, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 59);
            this.button2.TabIndex = 11;
            this.button2.Text = "Nhập Excel";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Image = global::QuanLyShopBanGiay.Properties.Resources.icons8_print_50;
            this.button3.Location = new System.Drawing.Point(318, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 59);
            this.button3.TabIndex = 12;
            this.button3.Text = "In Phiếu Nhập";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbNam);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.rad3);
            this.groupBox1.Controls.Add(this.cbThang);
            this.groupBox1.Controls.Add(this.rad2);
            this.groupBox1.Controls.Add(this.rad1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.cbTheoKhoang);
            this.groupBox1.Location = new System.Drawing.Point(30, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // cbNam
            // 
            this.cbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNam.Enabled = false;
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Items.AddRange(new object[] {
            "2023",
            "2022",
            "2021",
            "2020"});
            this.cbNam.Location = new System.Drawing.Point(478, 20);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(92, 28);
            this.cbNam.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(137, 60);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(242, 26);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // rad3
            // 
            this.rad3.AutoSize = true;
            this.rad3.Location = new System.Drawing.Point(6, 61);
            this.rad3.Name = "rad3";
            this.rad3.Size = new System.Drawing.Size(125, 24);
            this.rad3.TabIndex = 5;
            this.rad3.TabStop = true;
            this.rad3.Text = "Ngày Cụ Thể";
            this.rad3.UseVisualStyleBackColor = true;
            this.rad3.CheckedChanged += new System.EventHandler(this.cbCuThe_CheckedChanged);
            // 
            // cbThang
            // 
            this.cbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThang.Enabled = false;
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbThang.Location = new System.Drawing.Point(399, 20);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(75, 28);
            this.cbThang.TabIndex = 4;
            // 
            // rad2
            // 
            this.rad2.AutoSize = true;
            this.rad2.Location = new System.Drawing.Point(274, 24);
            this.rad2.Name = "rad2";
            this.rad2.Size = new System.Drawing.Size(119, 24);
            this.rad2.TabIndex = 3;
            this.rad2.TabStop = true;
            this.rad2.Text = "Theo Tháng";
            this.rad2.UseVisualStyleBackColor = true;
            this.rad2.CheckedChanged += new System.EventHandler(this.cbThang_CheckedChanged);
            // 
            // rad1
            // 
            this.rad1.AutoSize = true;
            this.rad1.Location = new System.Drawing.Point(6, 25);
            this.rad1.Name = "rad1";
            this.rad1.Size = new System.Drawing.Size(129, 24);
            this.rad1.TabIndex = 2;
            this.rad1.TabStop = true;
            this.rad1.Text = "Theo Khoảng";
            this.rad1.UseVisualStyleBackColor = true;
            this.rad1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(399, 54);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(171, 37);
            this.button4.TabIndex = 1;
            this.button4.Text = "Lọc Phiếu Nhập";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbTheoKhoang
            // 
            this.cbTheoKhoang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheoKhoang.Enabled = false;
            this.cbTheoKhoang.FormattingEnabled = true;
            this.cbTheoKhoang.Items.AddRange(new object[] {
            "1 Tháng ",
            "3 Tháng",
            "6 Tháng",
            "1 Năm ",
            "Tất Cả"});
            this.cbTheoKhoang.Location = new System.Drawing.Point(137, 21);
            this.cbTheoKhoang.Name = "cbTheoKhoang";
            this.cbTheoKhoang.Size = new System.Drawing.Size(121, 28);
            this.cbTheoKhoang.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(621, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Chi Tiết Phiếu Nhập";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(276, 243);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(330, 26);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tìm Kiếm Theo Mã";
            // 
            // button5
            // 
            this.button5.Image = global::QuanLyShopBanGiay.Properties.Resources.icons8_reset_30;
            this.button5.Location = new System.Drawing.Point(469, 43);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 59);
            this.button5.TabIndex = 17;
            this.button5.Text = "Reset";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // formXemPhieuNhap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1131, 616);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvChiTiet);
            this.Controls.Add(this.txtTien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaPhieu);
            this.Controls.Add(this.txtNhanVien);
            this.Controls.Add(this.lvPhieuNhap);
            this.Name = "formXemPhieuNhap";
            this.Text = "FormXemPhieuNhap";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvPhieuNhap;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTien;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvChiTiet;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTheoKhoang;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton rad1;
        private System.Windows.Forms.RadioButton rad2;
        private System.Windows.Forms.ComboBox cbThang;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rad3;
        private System.Windows.Forms.ComboBox cbNam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
    }
}
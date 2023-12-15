namespace QuanLyShopBanGiay.GUI
{
    partial class formThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.txtKH = new System.Windows.Forms.TextBox();
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.txtChiTieu = new System.Windows.Forms.TextBox();
            this.txtLoiNhuan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbLoiNhuan = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rad2 = new System.Windows.Forms.RadioButton();
            this.rad1 = new System.Windows.Forms.RadioButton();
            this.cbNam = new System.Windows.Forms.ComboBox();
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(534, 219);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Lượng Sản Phẩm Đã Bán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 261);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Lượng Khách Hàng Đã Mua";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng Doanh Thu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 267);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng Chi Tiêu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(534, 309);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số Lượng Sản Phẩm Đã Nhập";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(31, 398);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "Sản Phẩm";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1056, 242);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 309);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 28);
            this.label6.TabIndex = 7;
            this.label6.Text = "Lợi Nhuận:";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(829, 216);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(4);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(255, 34);
            this.txtProduct.TabIndex = 12;
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Location = new System.Drawing.Point(193, 219);
            this.txtDoanhThu.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(252, 34);
            this.txtDoanhThu.TabIndex = 13;
            // 
            // txtKH
            // 
            this.txtKH.Location = new System.Drawing.Point(829, 258);
            this.txtKH.Margin = new System.Windows.Forms.Padding(4);
            this.txtKH.Name = "txtKH";
            this.txtKH.Size = new System.Drawing.Size(255, 34);
            this.txtKH.TabIndex = 13;
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(829, 303);
            this.txtNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(258, 34);
            this.txtNhap.TabIndex = 14;
            // 
            // txtChiTieu
            // 
            this.txtChiTieu.Location = new System.Drawing.Point(193, 261);
            this.txtChiTieu.Margin = new System.Windows.Forms.Padding(4);
            this.txtChiTieu.Name = "txtChiTieu";
            this.txtChiTieu.Size = new System.Drawing.Size(252, 34);
            this.txtChiTieu.TabIndex = 15;
            // 
            // txtLoiNhuan
            // 
            this.txtLoiNhuan.Location = new System.Drawing.Point(191, 306);
            this.txtLoiNhuan.Margin = new System.Windows.Forms.Padding(4);
            this.txtLoiNhuan.Name = "txtLoiNhuan";
            this.txtLoiNhuan.Size = new System.Drawing.Size(159, 34);
            this.txtLoiNhuan.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(427, 366);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "Top Sản Phẩm Bán Chạy";
            // 
            // lbLoiNhuan
            // 
            this.lbLoiNhuan.AutoSize = true;
            this.lbLoiNhuan.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoiNhuan.Location = new System.Drawing.Point(358, 306);
            this.lbLoiNhuan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLoiNhuan.Name = "lbLoiNhuan";
            this.lbLoiNhuan.Size = new System.Drawing.Size(168, 38);
            this.lbLoiNhuan.TabIndex = 18;
            this.lbLoiNhuan.Text = "Lợi Nhuận:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rad2);
            this.groupBox1.Controls.Add(this.rad1);
            this.groupBox1.Controls.Add(this.cbNam);
            this.groupBox1.Controls.Add(this.cbThang);
            this.groupBox1.Location = new System.Drawing.Point(28, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1056, 144);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn Thời Gian";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.Image = global::QuanLyShopBanGiay.Properties.Resources.icons8_search_50;
            this.button1.Location = new System.Drawing.Point(579, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(458, 97);
            this.button1.TabIndex = 25;
            this.button1.Text = "Thống Kê";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rad2
            // 
            this.rad2.AutoSize = true;
            this.rad2.Location = new System.Drawing.Point(18, 95);
            this.rad2.Margin = new System.Windows.Forms.Padding(4);
            this.rad2.Name = "rad2";
            this.rad2.Size = new System.Drawing.Size(139, 32);
            this.rad2.TabIndex = 24;
            this.rad2.TabStop = true;
            this.rad2.Text = "Theo Tháng";
            this.rad2.UseVisualStyleBackColor = true;
            // 
            // rad1
            // 
            this.rad1.AutoSize = true;
            this.rad1.Location = new System.Drawing.Point(18, 34);
            this.rad1.Margin = new System.Windows.Forms.Padding(4);
            this.rad1.Name = "rad1";
            this.rad1.Size = new System.Drawing.Size(153, 32);
            this.rad1.TabIndex = 23;
            this.rad1.TabStop = true;
            this.rad1.Text = "Theo Khoảng";
            this.rad1.UseVisualStyleBackColor = true;
            this.rad1.CheckedChanged += new System.EventHandler(this.rad1_CheckedChanged);
            // 
            // cbNam
            // 
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Items.AddRange(new object[] {
            "2023",
            "2022",
            "2021",
            "2020"});
            this.cbNam.Location = new System.Drawing.Point(337, 91);
            this.cbNam.Margin = new System.Windows.Forms.Padding(4);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(191, 36);
            this.cbNam.TabIndex = 22;
            // 
            // cbThang
            // 
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
            this.cbThang.Location = new System.Drawing.Point(179, 91);
            this.cbThang.Margin = new System.Windows.Forms.Padding(4);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(147, 36);
            this.cbThang.TabIndex = 21;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(179, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(349, 34);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // formThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1154, 841);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbLoiNhuan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLoiNhuan);
            this.Controls.Add(this.txtChiTieu);
            this.Controls.Add(this.txtNhap);
            this.Controls.Add(this.txtKH);
            this.Controls.Add(this.txtDoanhThu);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formThongKe";
            this.Text = "formThongKe";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.TextBox txtKH;
        private System.Windows.Forms.TextBox txtNhap;
        private System.Windows.Forms.TextBox txtChiTieu;
        private System.Windows.Forms.TextBox txtLoiNhuan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbLoiNhuan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rad2;
        private System.Windows.Forms.RadioButton rad1;
        private System.Windows.Forms.ComboBox cbNam;
        private System.Windows.Forms.ComboBox cbThang;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
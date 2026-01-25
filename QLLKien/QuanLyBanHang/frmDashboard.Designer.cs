namespace QuanLyBanHang
{
    partial class frmDashboard
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCapNhat = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTongNCC = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTongNhanVien = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTongSanPham = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTongKhachHang = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnXemDoanhThu = new System.Windows.Forms.Button();
            this.lblDoanhThuThang = new System.Windows.Forms.Label();
            this.lblDoanhThuHomNay = new System.Windows.Forms.Label();
            this.lblSoDonHomNay = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvTopSanPham = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnXemHangTon = new System.Windows.Forms.Button();
            this.dgvHangTonThap = new System.Windows.Forms.DataGridView();
            this.lblSoCanhBao = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dgvHoatDong = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSanPham)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTonThap)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoatDong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel1.Controls.Add(this.lblCapNhat);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblCapNhat
            // 
            this.lblCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCapNhat.ForeColor = System.Drawing.Color.White;
            this.lblCapNhat.Location = new System.Drawing.Point(900, 35);
            this.lblCapNhat.Name = "lblCapNhat";
            this.lblCapNhat.Size = new System.Drawing.Size(200, 15);
            this.lblCapNhat.TabIndex = 2;
            this.lblCapNhat.Text = "Cập nhật lúc: --:--";
            this.lblCapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(1106, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 25);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "DASHBOARD";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1200, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.panel6.Controls.Add(this.lblTongNCC);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Location = new System.Drawing.Point(910, 13);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(280, 80);
            this.panel6.TabIndex = 3;
            // 
            // lblTongNCC
            // 
            this.lblTongNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTongNCC.ForeColor = System.Drawing.Color.White;
            this.lblTongNCC.Location = new System.Drawing.Point(10, 35);
            this.lblTongNCC.Name = "lblTongNCC";
            this.lblTongNCC.Size = new System.Drawing.Size(260, 37);
            this.lblTongNCC.TabIndex = 1;
            this.lblTongNCC.Text = "0";
            this.lblTongNCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(10, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(260, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "NHÀ CUNG CẤP";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panel5.Controls.Add(this.lblTongNhanVien);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(610, 13);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(280, 80);
            this.panel5.TabIndex = 2;
            // 
            // lblTongNhanVien
            // 
            this.lblTongNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTongNhanVien.ForeColor = System.Drawing.Color.White;
            this.lblTongNhanVien.Location = new System.Drawing.Point(10, 35);
            this.lblTongNhanVien.Name = "lblTongNhanVien";
            this.lblTongNhanVien.Size = new System.Drawing.Size(260, 37);
            this.lblTongNhanVien.TabIndex = 1;
            this.lblTongNhanVien.Text = "0";
            this.lblTongNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(260, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "NHÂN VIÊN";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panel4.Controls.Add(this.lblTongSanPham);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(310, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(280, 80);
            this.panel4.TabIndex = 1;
            // 
            // lblTongSanPham
            // 
            this.lblTongSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTongSanPham.ForeColor = System.Drawing.Color.White;
            this.lblTongSanPham.Location = new System.Drawing.Point(10, 35);
            this.lblTongSanPham.Name = "lblTongSanPham";
            this.lblTongSanPham.Size = new System.Drawing.Size(260, 37);
            this.lblTongSanPham.TabIndex = 1;
            this.lblTongSanPham.Text = "0";
            this.lblTongSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "SẢN PHẨM";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel3.Controls.Add(this.lblTongKhachHang);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(10, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 80);
            this.panel3.TabIndex = 0;
            // 
            // lblTongKhachHang
            // 
            this.lblTongKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTongKhachHang.ForeColor = System.Drawing.Color.White;
            this.lblTongKhachHang.Location = new System.Drawing.Point(10, 35);
            this.lblTongKhachHang.Name = "lblTongKhachHang";
            this.lblTongKhachHang.Size = new System.Drawing.Size(260, 37);
            this.lblTongKhachHang.TabIndex = 1;
            this.lblTongKhachHang.Text = "0";
            this.lblTongKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "KHÁCH HÀNG";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.btnXemDoanhThu);
            this.panel7.Controls.Add(this.lblDoanhThuThang);
            this.panel7.Controls.Add(this.lblDoanhThuHomNay);
            this.panel7.Controls.Add(this.lblSoDonHomNay);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Location = new System.Drawing.Point(10, 170);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(380, 180);
            this.panel7.TabIndex = 2;
            // 
            // btnXemDoanhThu
            // 
            this.btnXemDoanhThu.Location = new System.Drawing.Point(20, 143);
            this.btnXemDoanhThu.Name = "btnXemDoanhThu";
            this.btnXemDoanhThu.Size = new System.Drawing.Size(100, 25);
            this.btnXemDoanhThu.TabIndex = 7;
            this.btnXemDoanhThu.Text = "Xem chi tiết";
            this.btnXemDoanhThu.UseVisualStyleBackColor = true;
            this.btnXemDoanhThu.Click += new System.EventHandler(this.btnXemDoanhThu_Click);
            // 
            // lblDoanhThuThang
            // 
            this.lblDoanhThuThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuThang.ForeColor = System.Drawing.Color.Green;
            this.lblDoanhThuThang.Location = new System.Drawing.Point(190, 110);
            this.lblDoanhThuThang.Name = "lblDoanhThuThang";
            this.lblDoanhThuThang.Size = new System.Drawing.Size(170, 20);
            this.lblDoanhThuThang.TabIndex = 6;
            this.lblDoanhThuThang.Text = "0";
            this.lblDoanhThuThang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDoanhThuHomNay
            // 
            this.lblDoanhThuHomNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuHomNay.ForeColor = System.Drawing.Color.Red;
            this.lblDoanhThuHomNay.Location = new System.Drawing.Point(190, 75);
            this.lblDoanhThuHomNay.Name = "lblDoanhThuHomNay";
            this.lblDoanhThuHomNay.Size = new System.Drawing.Size(170, 23);
            this.lblDoanhThuHomNay.TabIndex = 5;
            this.lblDoanhThuHomNay.Text = "0";
            this.lblDoanhThuHomNay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSoDonHomNay
            // 
            this.lblSoDonHomNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoDonHomNay.Location = new System.Drawing.Point(190, 40);
            this.lblSoDonHomNay.Name = "lblSoDonHomNay";
            this.lblSoDonHomNay.Size = new System.Drawing.Size(170, 20);
            this.lblSoDonHomNay.TabIndex = 4;
            this.lblSoDonHomNay.Text = "0";
            this.lblSoDonHomNay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Doanh thu tháng này:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(20, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Doanh thu hôm nay:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Số đơn hôm nay:";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.label10.Size = new System.Drawing.Size(378, 27);
            this.label10.TabIndex = 0;
            this.label10.Text = "DOANH THU";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.dgvTopSanPham);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Location = new System.Drawing.Point(410, 170);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(380, 180);
            this.panel8.TabIndex = 3;
            // 
            // dgvTopSanPham
            // 
            this.dgvTopSanPham.AllowUserToAddRows = false;
            this.dgvTopSanPham.AllowUserToDeleteRows = false;
            this.dgvTopSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopSanPham.Location = new System.Drawing.Point(0, 27);
            this.dgvTopSanPham.Name = "dgvTopSanPham";
            this.dgvTopSanPham.ReadOnly = true;
            this.dgvTopSanPham.Size = new System.Drawing.Size(378, 151);
            this.dgvTopSanPham.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.label14.Size = new System.Drawing.Size(378, 27);
            this.label14.TabIndex = 0;
            this.label14.Text = "TOP 5 SẢN PHẨM BÁN CHẠY";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.btnXemHangTon);
            this.panel9.Controls.Add(this.dgvHangTonThap);
            this.panel9.Controls.Add(this.lblSoCanhBao);
            this.panel9.Controls.Add(this.label15);
            this.panel9.Location = new System.Drawing.Point(810, 170);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(380, 180);
            this.panel9.TabIndex = 4;
            // 
            // btnXemHangTon
            // 
            this.btnXemHangTon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemHangTon.Location = new System.Drawing.Point(270, 3);
            this.btnXemHangTon.Name = "btnXemHangTon";
            this.btnXemHangTon.Size = new System.Drawing.Size(100, 20);
            this.btnXemHangTon.TabIndex = 3;
            this.btnXemHangTon.Text = "Xem tất cả";
            this.btnXemHangTon.UseVisualStyleBackColor = true;
            this.btnXemHangTon.Click += new System.EventHandler(this.btnXemHangTon_Click);
            // 
            // dgvHangTonThap
            // 
            this.dgvHangTonThap.AllowUserToAddRows = false;
            this.dgvHangTonThap.AllowUserToDeleteRows = false;
            this.dgvHangTonThap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangTonThap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangTonThap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHangTonThap.Location = new System.Drawing.Point(0, 27);
            this.dgvHangTonThap.Name = "dgvHangTonThap";
            this.dgvHangTonThap.ReadOnly = true;
            this.dgvHangTonThap.Size = new System.Drawing.Size(378, 151);
            this.dgvHangTonThap.TabIndex = 2;
            // 
            // lblSoCanhBao
            // 
            this.lblSoCanhBao.BackColor = System.Drawing.Color.Red;
            this.lblSoCanhBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblSoCanhBao.ForeColor = System.Drawing.Color.White;
            this.lblSoCanhBao.Location = new System.Drawing.Point(240, 4);
            this.lblSoCanhBao.Name = "lblSoCanhBao";
            this.lblSoCanhBao.Size = new System.Drawing.Size(25, 18);
            this.lblSoCanhBao.TabIndex = 1;
            this.lblSoCanhBao.Text = "0";
            this.lblSoCanhBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.label15.Size = new System.Drawing.Size(378, 27);
            this.label15.TabIndex = 0;
            this.label15.Text = "CẢNH BÁO HÀNG TỒN THẤP";
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.dgvHoatDong);
            this.panel10.Controls.Add(this.label16);
            this.panel10.Location = new System.Drawing.Point(10, 360);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1180, 280);
            this.panel10.TabIndex = 5;
            // 
            // dgvHoatDong
            // 
            this.dgvHoatDong.AllowUserToAddRows = false;
            this.dgvHoatDong.AllowUserToDeleteRows = false;
            this.dgvHoatDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoatDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoatDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoatDong.Location = new System.Drawing.Point(0, 27);
            this.dgvHoatDong.Name = "dgvHoatDong";
            this.dgvHoatDong.ReadOnly = true;
            this.dgvHoatDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoatDong.Size = new System.Drawing.Size(1178, 251);
            this.dgvHoatDong.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.label16.Size = new System.Drawing.Size(1178, 27);
            this.label16.TabIndex = 0;
            this.label16.Text = "HOẠT ĐỘNG GẦN ĐÂY";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - Trang chủ";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSanPham)).EndInit();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTonThap)).EndInit();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoatDong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCapNhat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTongKhachHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblTongNCC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTongNhanVien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTongSanPham;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSoDonHomNay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDoanhThuHomNay;
        private System.Windows.Forms.Label lblDoanhThuThang;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgvTopSanPham;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgvHangTonThap;
        private System.Windows.Forms.Label lblSoCanhBao;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridView dgvHoatDong;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnXemDoanhThu;
        private System.Windows.Forms.Button btnXemHangTon;
        private System.Windows.Forms.Timer timerRefresh;
    }
}

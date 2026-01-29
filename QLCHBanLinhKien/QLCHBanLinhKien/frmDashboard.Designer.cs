namespace QLCHBanLinhKien
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelStat6 = new System.Windows.Forms.Panel();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panelStat5 = new System.Windows.Forms.Panel();
            this.lblDoanhThuThang = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelStat4 = new System.Windows.Forms.Panel();
            this.lblDoanhThuHomNay = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelStat3 = new System.Windows.Forms.Panel();
            this.lblHoaDonHomNay = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelStat2 = new System.Windows.Forms.Panel();
            this.lblTongKhachHang = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelStat1 = new System.Windows.Forms.Panel();
            this.lblTongSanPham = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTopSanPham = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvHoaDonGanDay = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelStat6.SuspendLayout();
            this.panelStat5.SuspendLayout();
            this.panelStat4.SuspendLayout();
            this.panelStat3.SuspendLayout();
            this.panelStat2.SuspendLayout();
            this.panelStat1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSanPham)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonGanDay)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.DarkCyan;
            this.panelTop.Controls.Add(this.btnLamMoi);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 50);
            this.panelTop.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLamMoi.Location = new System.Drawing.Point(1000, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 30);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1100, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DASHBOARD - TỔNG QUAN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.panelStat6);
            this.panelStats.Controls.Add(this.panelStat5);
            this.panelStats.Controls.Add(this.panelStat4);
            this.panelStats.Controls.Add(this.panelStat3);
            this.panelStats.Controls.Add(this.panelStat2);
            this.panelStats.Controls.Add(this.panelStat1);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 50);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(10);
            this.panelStats.Size = new System.Drawing.Size(1100, 130);
            this.panelStats.TabIndex = 1;
            // 
            // panelStat6
            // 
            this.panelStat6.BackColor = System.Drawing.Color.IndianRed;
            this.panelStat6.Controls.Add(this.lblCanhBao);
            this.panelStat6.Controls.Add(this.label12);
            this.panelStat6.Location = new System.Drawing.Point(910, 15);
            this.panelStat6.Name = "panelStat6";
            this.panelStat6.Size = new System.Drawing.Size(170, 100);
            this.panelStat6.TabIndex = 5;
            // 
            // lblCanhBao
            // 
            this.lblCanhBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCanhBao.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCanhBao.ForeColor = System.Drawing.Color.White;
            this.lblCanhBao.Location = new System.Drawing.Point(0, 30);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(170, 70);
            this.lblCanhBao.TabIndex = 1;
            this.lblCanhBao.Text = "0";
            this.lblCanhBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 30);
            this.label12.TabIndex = 0;
            this.label12.Text = "SP Sắp hết";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStat5
            // 
            this.panelStat5.BackColor = System.Drawing.Color.MediumPurple;
            this.panelStat5.Controls.Add(this.lblDoanhThuThang);
            this.panelStat5.Controls.Add(this.label10);
            this.panelStat5.Location = new System.Drawing.Point(730, 15);
            this.panelStat5.Name = "panelStat5";
            this.panelStat5.Size = new System.Drawing.Size(170, 100);
            this.panelStat5.TabIndex = 4;
            // 
            // lblDoanhThuThang
            // 
            this.lblDoanhThuThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoanhThuThang.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuThang.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuThang.Location = new System.Drawing.Point(0, 30);
            this.lblDoanhThuThang.Name = "lblDoanhThuThang";
            this.lblDoanhThuThang.Size = new System.Drawing.Size(170, 70);
            this.lblDoanhThuThang.TabIndex = 1;
            this.lblDoanhThuThang.Text = "0 VND";
            this.lblDoanhThuThang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 30);
            this.label10.TabIndex = 0;
            this.label10.Text = "Doanh thu tháng";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStat4
            // 
            this.panelStat4.BackColor = System.Drawing.Color.SeaGreen;
            this.panelStat4.Controls.Add(this.lblDoanhThuHomNay);
            this.panelStat4.Controls.Add(this.label8);
            this.panelStat4.Location = new System.Drawing.Point(550, 15);
            this.panelStat4.Name = "panelStat4";
            this.panelStat4.Size = new System.Drawing.Size(170, 100);
            this.panelStat4.TabIndex = 3;
            // 
            // lblDoanhThuHomNay
            // 
            this.lblDoanhThuHomNay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoanhThuHomNay.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuHomNay.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuHomNay.Location = new System.Drawing.Point(0, 30);
            this.lblDoanhThuHomNay.Name = "lblDoanhThuHomNay";
            this.lblDoanhThuHomNay.Size = new System.Drawing.Size(170, 70);
            this.lblDoanhThuHomNay.TabIndex = 1;
            this.lblDoanhThuHomNay.Text = "0 VND";
            this.lblDoanhThuHomNay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 30);
            this.label8.TabIndex = 0;
            this.label8.Text = "Doanh thu hôm nay";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStat3
            // 
            this.panelStat3.BackColor = System.Drawing.Color.SteelBlue;
            this.panelStat3.Controls.Add(this.lblHoaDonHomNay);
            this.panelStat3.Controls.Add(this.label6);
            this.panelStat3.Location = new System.Drawing.Point(370, 15);
            this.panelStat3.Name = "panelStat3";
            this.panelStat3.Size = new System.Drawing.Size(170, 100);
            this.panelStat3.TabIndex = 2;
            // 
            // lblHoaDonHomNay
            // 
            this.lblHoaDonHomNay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHoaDonHomNay.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHoaDonHomNay.ForeColor = System.Drawing.Color.White;
            this.lblHoaDonHomNay.Location = new System.Drawing.Point(0, 30);
            this.lblHoaDonHomNay.Name = "lblHoaDonHomNay";
            this.lblHoaDonHomNay.Size = new System.Drawing.Size(170, 70);
            this.lblHoaDonHomNay.TabIndex = 1;
            this.lblHoaDonHomNay.Text = "0";
            this.lblHoaDonHomNay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "Hóa đơn hôm nay";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStat2
            // 
            this.panelStat2.BackColor = System.Drawing.Color.Teal;
            this.panelStat2.Controls.Add(this.lblTongKhachHang);
            this.panelStat2.Controls.Add(this.label4);
            this.panelStat2.Location = new System.Drawing.Point(190, 15);
            this.panelStat2.Name = "panelStat2";
            this.panelStat2.Size = new System.Drawing.Size(170, 100);
            this.panelStat2.TabIndex = 1;
            // 
            // lblTongKhachHang
            // 
            this.lblTongKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongKhachHang.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTongKhachHang.ForeColor = System.Drawing.Color.White;
            this.lblTongKhachHang.Location = new System.Drawing.Point(0, 30);
            this.lblTongKhachHang.Name = "lblTongKhachHang";
            this.lblTongKhachHang.Size = new System.Drawing.Size(170, 70);
            this.lblTongKhachHang.TabIndex = 1;
            this.lblTongKhachHang.Text = "0";
            this.lblTongKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Khách hàng";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStat1
            // 
            this.panelStat1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelStat1.Controls.Add(this.lblTongSanPham);
            this.panelStat1.Controls.Add(this.label2);
            this.panelStat1.Location = new System.Drawing.Point(10, 15);
            this.panelStat1.Name = "panelStat1";
            this.panelStat1.Size = new System.Drawing.Size(170, 100);
            this.panelStat1.TabIndex = 0;
            // 
            // lblTongSanPham
            // 
            this.lblTongSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongSanPham.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTongSanPham.ForeColor = System.Drawing.Color.White;
            this.lblTongSanPham.Location = new System.Drawing.Point(0, 30);
            this.lblTongSanPham.Name = "lblTongSanPham";
            this.lblTongSanPham.Size = new System.Drawing.Size(170, 70);
            this.lblTongSanPham.TabIndex = 1;
            this.lblTongSanPham.Text = "0";
            this.lblTongSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sản phẩm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.groupBox2);
            this.panelBottom.Controls.Add(this.groupBox1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 180);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(10);
            this.panelBottom.Size = new System.Drawing.Size(1100, 420);
            this.panelBottom.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTopSanPham);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox2.Location = new System.Drawing.Point(560, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 400);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Top sản phẩm bán chạy";
            // 
            // dgvTopSanPham
            // 
            this.dgvTopSanPham.AllowUserToAddRows = false;
            this.dgvTopSanPham.AllowUserToDeleteRows = false;
            this.dgvTopSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopSanPham.Location = new System.Drawing.Point(3, 26);
            this.dgvTopSanPham.Name = "dgvTopSanPham";
            this.dgvTopSanPham.ReadOnly = true;
            this.dgvTopSanPham.RowHeadersWidth = 51;
            this.dgvTopSanPham.Size = new System.Drawing.Size(524, 371);
            this.dgvTopSanPham.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvHoaDonGanDay);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa đơn gần đây";
            // 
            // dgvHoaDonGanDay
            // 
            this.dgvHoaDonGanDay.AllowUserToAddRows = false;
            this.dgvHoaDonGanDay.AllowUserToDeleteRows = false;
            this.dgvHoaDonGanDay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDonGanDay.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDonGanDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonGanDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDonGanDay.Location = new System.Drawing.Point(3, 26);
            this.dgvHoaDonGanDay.Name = "dgvHoaDonGanDay";
            this.dgvHoaDonGanDay.ReadOnly = true;
            this.dgvHoaDonGanDay.RowHeadersWidth = 51;
            this.dgvHoaDonGanDay.Size = new System.Drawing.Size(544, 371);
            this.dgvHoaDonGanDay.TabIndex = 0;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelTop);
            this.Name = "frmDashboard";
            this.Text = "Dashboard - Tổng quan";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.panelTop.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelStat6.ResumeLayout(false);
            this.panelStat5.ResumeLayout(false);
            this.panelStat4.ResumeLayout(false);
            this.panelStat3.ResumeLayout(false);
            this.panelStat2.ResumeLayout(false);
            this.panelStat1.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSanPham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonGanDay)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelStat1;
        private System.Windows.Forms.Label lblTongSanPham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelStat2;
        private System.Windows.Forms.Label lblTongKhachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelStat3;
        private System.Windows.Forms.Label lblHoaDonHomNay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelStat4;
        private System.Windows.Forms.Label lblDoanhThuHomNay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelStat5;
        private System.Windows.Forms.Label lblDoanhThuThang;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelStat6;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvHoaDonGanDay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTopSanPham;
        private System.Windows.Forms.Button btnLamMoi;
    }
}

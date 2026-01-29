namespace QuanLyBanHang
{
    partial class frmMains
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMains));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCauHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChatlieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHanghoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhaCungCap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoadonban = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimkiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindHoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindKhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBCHangton = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBCDoanhthu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTopSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKeNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHientrogiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVainet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuDanhMuc,
            this.mnuHoadon,
            this.mnuTimkiem,
            this.báoCáoToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1399, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoiMatKhau,
            this.mnuCauHinh,
            this.toolStripSeparator1,
            this.mnuThoat});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(85, 24);
            this.mnuFile.Text = "&Hệ thống";
            // 
            // mnuDoiMatKhau
            // 
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Size = new System.Drawing.Size(183, 26);
            this.mnuDoiMatKhau.Text = "Đổi mật khẩu";
            this.mnuDoiMatKhau.Click += new System.EventHandler(this.mnuDoiMatKhau_Click);
            // 
            // mnuCauHinh
            // 
            this.mnuCauHinh.Name = "mnuCauHinh";
            this.mnuCauHinh.Size = new System.Drawing.Size(183, 26);
            this.mnuCauHinh.Text = "Cấu hình";
            this.mnuCauHinh.Click += new System.EventHandler(this.mnuCauHinh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Size = new System.Drawing.Size(183, 26);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChatlieu,
            this.mnuNhanvien,
            this.mnuKhachhang,
            this.mnuHanghoa,
            this.mnuNhaCungCap});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(90, 24);
            this.mnuDanhMuc.Text = "&Danh mục";
            // 
            // mnuChatlieu
            // 
            this.mnuChatlieu.Name = "mnuChatlieu";
            this.mnuChatlieu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuChatlieu.Size = new System.Drawing.Size(235, 26);
            this.mnuChatlieu.Text = "&Chất liệu";
            this.mnuChatlieu.Click += new System.EventHandler(this.mnuChatlieu_Click);
            // 
            // mnuNhanvien
            // 
            this.mnuNhanvien.Name = "mnuNhanvien";
            this.mnuNhanvien.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNhanvien.Size = new System.Drawing.Size(235, 26);
            this.mnuNhanvien.Text = "&Nhân viên";
            this.mnuNhanvien.Click += new System.EventHandler(this.mnuNhanvien_Click);
            // 
            // mnuKhachhang
            // 
            this.mnuKhachhang.Name = "mnuKhachhang";
            this.mnuKhachhang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.mnuKhachhang.Size = new System.Drawing.Size(235, 26);
            this.mnuKhachhang.Text = "&Khách hàng";
            this.mnuKhachhang.Click += new System.EventHandler(this.mnuKhachhang_Click);
            // 
            // mnuHanghoa
            // 
            this.mnuHanghoa.Name = "mnuHanghoa";
            this.mnuHanghoa.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuHanghoa.Size = new System.Drawing.Size(235, 26);
            this.mnuHanghoa.Text = "&Hàng hóa";
            this.mnuHanghoa.Click += new System.EventHandler(this.mnuHanghoa_Click);
            // 
            // mnuNhaCungCap
            // 
            this.mnuNhaCungCap.Name = "mnuNhaCungCap";
            this.mnuNhaCungCap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.mnuNhaCungCap.Size = new System.Drawing.Size(235, 26);
            this.mnuNhaCungCap.Text = "&Nhà cung cấp";
            this.mnuNhaCungCap.Click += new System.EventHandler(this.mnuNhaCungCap_Click);
            // 
            // mnuHoadon
            // 
            this.mnuHoadon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHoadonban});
            this.mnuHoadon.Name = "mnuHoadon";
            this.mnuHoadon.Size = new System.Drawing.Size(81, 24);
            this.mnuHoadon.Text = "&Hóa đơn";
            this.mnuHoadon.Click += new System.EventHandler(this.mnuHoadon_Click);
            // 
            // mnuHoadonban
            // 
            this.mnuHoadonban.Name = "mnuHoadonban";
            this.mnuHoadonban.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.mnuHoadonban.Size = new System.Drawing.Size(229, 26);
            this.mnuHoadonban.Text = "&Hóa đơn bán";
            this.mnuHoadonban.Click += new System.EventHandler(this.mnuHoadonban_Click);
            // 
            // mnuTimkiem
            // 
            this.mnuTimkiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFindHoadon,
            this.mnuFindHang,
            this.mnuFindKhachhang});
            this.mnuTimkiem.Image = ((System.Drawing.Image)(resources.GetObject("mnuTimkiem.Image")));
            this.mnuTimkiem.Name = "mnuTimkiem";
            this.mnuTimkiem.Size = new System.Drawing.Size(104, 24);
            this.mnuTimkiem.Text = "&Tìm kiếm";
            // 
            // mnuFindHoadon
            // 
            this.mnuFindHoadon.Name = "mnuFindHoadon";
            this.mnuFindHoadon.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.mnuFindHoadon.Size = new System.Drawing.Size(219, 26);
            this.mnuFindHoadon.Text = "&Hóa đơn";
            this.mnuFindHoadon.Click += new System.EventHandler(this.mnuFindHoadon_Click);
            // 
            // mnuFindHang
            // 
            this.mnuFindHang.Name = "mnuFindHang";
            this.mnuFindHang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.mnuFindHang.Size = new System.Drawing.Size(219, 26);
            this.mnuFindHang.Text = "&Hàng";
            this.mnuFindHang.Click += new System.EventHandler(this.mnuFindHang_Click);
            // 
            // mnuFindKhachhang
            // 
            this.mnuFindKhachhang.Name = "mnuFindKhachhang";
            this.mnuFindKhachhang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.mnuFindKhachhang.Size = new System.Drawing.Size(219, 26);
            this.mnuFindKhachhang.Text = "&Khách hàng";
            this.mnuFindKhachhang.Click += new System.EventHandler(this.mnuFindKhachhang_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDashboard,
            this.toolStripSeparator2,
            this.mnuBCHangton,
            this.mnuBCDoanhthu,
            this.mnuTopSanPham,
            this.mnuThongKeNhanVien});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.báoCáoToolStripMenuItem.Text = "&Báo cáo";
            this.báoCáoToolStripMenuItem.Click += new System.EventHandler(this.báoCáoToolStripMenuItem_Click);
            // 
            // mnuDashboard
            // 
            this.mnuDashboard.Name = "mnuDashboard";
            this.mnuDashboard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuDashboard.Size = new System.Drawing.Size(270, 26);
            this.mnuDashboard.Text = "&Dashboard";
            this.mnuDashboard.Click += new System.EventHandler(this.mnuDashboard_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(267, 6);
            // 
            // mnuBCHangton
            // 
            this.mnuBCHangton.Name = "mnuBCHangton";
            this.mnuBCHangton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.mnuBCHangton.Size = new System.Drawing.Size(270, 26);
            this.mnuBCHangton.Text = "&Hàng tồn";
            this.mnuBCHangton.Click += new System.EventHandler(this.mnuBCHangton_Click);
            // 
            // mnuBCDoanhthu
            // 
            this.mnuBCDoanhthu.Name = "mnuBCDoanhthu";
            this.mnuBCDoanhthu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.mnuBCDoanhthu.Size = new System.Drawing.Size(270, 26);
            this.mnuBCDoanhthu.Text = "&Doanh thu";
            this.mnuBCDoanhthu.Click += new System.EventHandler(this.mnuBCDoanhthu_Click);
            // 
            // mnuTopSanPham
            // 
            this.mnuTopSanPham.Name = "mnuTopSanPham";
            this.mnuTopSanPham.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.mnuTopSanPham.Size = new System.Drawing.Size(270, 26);
            this.mnuTopSanPham.Text = "Top &sản phẩm";
            this.mnuTopSanPham.Click += new System.EventHandler(this.mnuTopSanPham_Click);
            // 
            // mnuThongKeNhanVien
            // 
            this.mnuThongKeNhanVien.Name = "mnuThongKeNhanVien";
            this.mnuThongKeNhanVien.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D7)));
            this.mnuThongKeNhanVien.Size = new System.Drawing.Size(270, 26);
            this.mnuThongKeNhanVien.Text = "Thống kê nhân &viên";
            this.mnuThongKeNhanVien.Click += new System.EventHandler(this.mnuThongKeNhanVien_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHientrogiup,
            this.mnuVainet});
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.trợGiúpToolStripMenuItem.Text = "&Trợ giúp";
            // 
            // mnuHientrogiup
            // 
            this.mnuHientrogiup.Name = "mnuHientrogiup";
            this.mnuHientrogiup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuHientrogiup.Size = new System.Drawing.Size(197, 26);
            this.mnuHientrogiup.Text = "&Trợ giúp";
            this.mnuHientrogiup.Click += new System.EventHandler(this.mnuHientrogiup_Click);
            // 
            // mnuVainet
            // 
            this.mnuVainet.Name = "mnuVainet";
            this.mnuVainet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuVainet.Size = new System.Drawing.Size(197, 26);
            this.mnuVainet.Text = "&Vài nét";
            this.mnuVainet.Click += new System.EventHandler(this.mnuVainet_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1399, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Controls.Add(this.pictureBox1);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(0, 52);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(1399, 715);
            this.panelDesktopPane.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1399, 715);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmMains
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 767);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMains";
            this.Text = "Chương trình quản lý bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMains_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelDesktopPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuChatlieu;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanvien;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachhang;
        private System.Windows.Forms.ToolStripMenuItem mnuHanghoa;
        private System.Windows.Forms.ToolStripMenuItem mnuHoadon;
        private System.Windows.Forms.ToolStripMenuItem mnuHoadonban;
        private System.Windows.Forms.ToolStripMenuItem mnuTimkiem;
        private System.Windows.Forms.ToolStripMenuItem mnuFindHoadon;
        private System.Windows.Forms.ToolStripMenuItem mnuFindHang;
        private System.Windows.Forms.ToolStripMenuItem mnuFindKhachhang;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBCHangton;
        private System.Windows.Forms.ToolStripMenuItem mnuBCDoanhthu;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHientrogiup;
        private System.Windows.Forms.ToolStripMenuItem mnuVainet;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnuCauHinh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuNhaCungCap;
        private System.Windows.Forms.ToolStripMenuItem mnuDashboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuTopSanPham;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKeNhanVien;
    }
}


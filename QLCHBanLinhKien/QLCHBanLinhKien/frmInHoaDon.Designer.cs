namespace QLCHBanLinhKien
{
    partial class frmInHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTenCuaHang = new System.Windows.Forms.Label();
            this.lblDiaChiCuaHang = new System.Windows.Forms.Label();
            this.lblDienThoaiCuaHang = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblLabelSoHD = new System.Windows.Forms.Label();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.lblLabelNgayBan = new System.Windows.Forms.Label();
            this.lblNgayBan = new System.Windows.Forms.Label();
            this.lblLabelKhachHang = new System.Windows.Forms.Label();
            this.lblTenKhachHang = new System.Windows.Forms.Label();
            this.lblLabelNhanVien = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.lblLabelTongTien = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblLabelGiamGia = new System.Windows.Forms.Label();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.lblLabelThanhTien = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.lblLabelPhuongThuc = new System.Windows.Forms.Label();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.panelTotal.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTenCuaHang);
            this.panelHeader.Controls.Add(this.lblDiaChiCuaHang);
            this.panelHeader.Controls.Add(this.lblDienThoaiCuaHang);
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(650, 120);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTenCuaHang
            // 
            this.lblTenCuaHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenCuaHang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTenCuaHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTenCuaHang.Location = new System.Drawing.Point(0, 75);
            this.lblTenCuaHang.Name = "lblTenCuaHang";
            this.lblTenCuaHang.Size = new System.Drawing.Size(650, 35);
            this.lblTenCuaHang.TabIndex = 0;
            this.lblTenCuaHang.Text = "CỬA HÀNG LINH KIỆN ĐIỆN TỬ";
            this.lblTenCuaHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiaChiCuaHang
            // 
            this.lblDiaChiCuaHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDiaChiCuaHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiaChiCuaHang.ForeColor = System.Drawing.Color.Gray;
            this.lblDiaChiCuaHang.Location = new System.Drawing.Point(0, 55);
            this.lblDiaChiCuaHang.Name = "lblDiaChiCuaHang";
            this.lblDiaChiCuaHang.Size = new System.Drawing.Size(650, 20);
            this.lblDiaChiCuaHang.TabIndex = 1;
            this.lblDiaChiCuaHang.Text = "Địa chỉ: 123 Đường ABC, Quận XYZ, TP. HCM";
            this.lblDiaChiCuaHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDienThoaiCuaHang
            // 
            this.lblDienThoaiCuaHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDienThoaiCuaHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDienThoaiCuaHang.ForeColor = System.Drawing.Color.Gray;
            this.lblDienThoaiCuaHang.Location = new System.Drawing.Point(0, 35);
            this.lblDienThoaiCuaHang.Name = "lblDienThoaiCuaHang";
            this.lblDienThoaiCuaHang.Size = new System.Drawing.Size(650, 20);
            this.lblDienThoaiCuaHang.TabIndex = 2;
            this.lblDienThoaiCuaHang.Text = "Điện thoại: 0123 456 789";
            this.lblDienThoaiCuaHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Black;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(650, 35);
            this.lblTieuDe.TabIndex = 3;
            this.lblTieuDe.Text = "HÓA ĐƠN BÁN HÀNG";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelInfo.Controls.Add(this.lblLabelSoHD);
            this.panelInfo.Controls.Add(this.lblSoHoaDon);
            this.panelInfo.Controls.Add(this.lblLabelNgayBan);
            this.panelInfo.Controls.Add(this.lblNgayBan);
            this.panelInfo.Controls.Add(this.lblLabelKhachHang);
            this.panelInfo.Controls.Add(this.lblTenKhachHang);
            this.panelInfo.Controls.Add(this.lblLabelNhanVien);
            this.panelInfo.Controls.Add(this.lblNhanVien);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 120);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelInfo.Size = new System.Drawing.Size(650, 110);
            this.panelInfo.TabIndex = 1;
            // 
            // lblLabelSoHD
            // 
            this.lblLabelSoHD.AutoSize = true;
            this.lblLabelSoHD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLabelSoHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblLabelSoHD.Location = new System.Drawing.Point(15, 12);
            this.lblLabelSoHD.Name = "lblLabelSoHD";
            this.lblLabelSoHD.Size = new System.Drawing.Size(91, 20);
            this.lblLabelSoHD.TabIndex = 0;
            this.lblLabelSoHD.Text = "Số hóa đơn:";
            // 
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.AutoSize = true;
            this.lblSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblSoHoaDon.Location = new System.Drawing.Point(95, 12);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(15, 20);
            this.lblSoHoaDon.TabIndex = 1;
            this.lblSoHoaDon.Text = "-";
            // 
            // lblLabelNgayBan
            // 
            this.lblLabelNgayBan.AutoSize = true;
            this.lblLabelNgayBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLabelNgayBan.Location = new System.Drawing.Point(400, 12);
            this.lblLabelNgayBan.Name = "lblLabelNgayBan";
            this.lblLabelNgayBan.Size = new System.Drawing.Size(80, 20);
            this.lblLabelNgayBan.TabIndex = 2;
            this.lblLabelNgayBan.Text = "Ngày bán:";
            // 
            // lblNgayBan
            // 
            this.lblNgayBan.AutoSize = true;
            this.lblNgayBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayBan.Location = new System.Drawing.Point(470, 12);
            this.lblNgayBan.Name = "lblNgayBan";
            this.lblNgayBan.Size = new System.Drawing.Size(15, 20);
            this.lblNgayBan.TabIndex = 3;
            this.lblNgayBan.Text = "-";
            // 
            // lblLabelKhachHang
            // 
            this.lblLabelKhachHang.AutoSize = true;
            this.lblLabelKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLabelKhachHang.Location = new System.Drawing.Point(15, 35);
            this.lblLabelKhachHang.Name = "lblLabelKhachHang";
            this.lblLabelKhachHang.Size = new System.Drawing.Size(95, 20);
            this.lblLabelKhachHang.TabIndex = 4;
            this.lblLabelKhachHang.Text = "Khách hàng:";
            // 
            // lblTenKhachHang
            // 
            this.lblTenKhachHang.AutoSize = true;
            this.lblTenKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenKhachHang.Location = new System.Drawing.Point(95, 35);
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new System.Drawing.Size(15, 20);
            this.lblTenKhachHang.TabIndex = 5;
            this.lblTenKhachHang.Text = "-";
            // 
            // lblLabelNhanVien
            // 
            this.lblLabelNhanVien.AutoSize = true;
            this.lblLabelNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLabelNhanVien.Location = new System.Drawing.Point(15, 58);
            this.lblLabelNhanVien.Name = "lblLabelNhanVien";
            this.lblLabelNhanVien.Size = new System.Drawing.Size(84, 20);
            this.lblLabelNhanVien.TabIndex = 10;
            this.lblLabelNhanVien.Text = "Nhân viên:";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNhanVien.Location = new System.Drawing.Point(95, 58);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(15, 20);
            this.lblNhanVien.TabIndex = 11;
            this.lblNhanVien.Text = "-";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTiet.ColumnHeadersHeight = 35;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvChiTiet.Location = new System.Drawing.Point(0, 230);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 28;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(650, 230);
            this.dgvChiTiet.TabIndex = 2;
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelTotal.Controls.Add(this.lblLabelTongTien);
            this.panelTotal.Controls.Add(this.lblTongTien);
            this.panelTotal.Controls.Add(this.lblLabelGiamGia);
            this.panelTotal.Controls.Add(this.lblGiamGia);
            this.panelTotal.Controls.Add(this.lblLabelThanhTien);
            this.panelTotal.Controls.Add(this.lblThanhTien);
            this.panelTotal.Controls.Add(this.lblLabelPhuongThuc);
            this.panelTotal.Controls.Add(this.lblPhuongThuc);
            this.panelTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTotal.Location = new System.Drawing.Point(0, 460);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelTotal.Size = new System.Drawing.Size(650, 120);
            this.panelTotal.TabIndex = 3;
            // 
            // lblLabelTongTien
            // 
            this.lblLabelTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLabelTongTien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLabelTongTien.Location = new System.Drawing.Point(380, 10);
            this.lblLabelTongTien.Name = "lblLabelTongTien";
            this.lblLabelTongTien.Size = new System.Drawing.Size(100, 20);
            this.lblLabelTongTien.TabIndex = 0;
            this.lblLabelTongTien.Text = "Tổng tiền:";
            this.lblLabelTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongTien.Location = new System.Drawing.Point(490, 10);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(140, 20);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLabelGiamGia
            // 
            this.lblLabelGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLabelGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLabelGiamGia.ForeColor = System.Drawing.Color.Green;
            this.lblLabelGiamGia.Location = new System.Drawing.Point(380, 32);
            this.lblLabelGiamGia.Name = "lblLabelGiamGia";
            this.lblLabelGiamGia.Size = new System.Drawing.Size(100, 20);
            this.lblLabelGiamGia.TabIndex = 2;
            this.lblLabelGiamGia.Text = "Giảm giá:";
            this.lblLabelGiamGia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGiamGia.ForeColor = System.Drawing.Color.Green;
            this.lblGiamGia.Location = new System.Drawing.Point(490, 32);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(140, 20);
            this.lblGiamGia.TabIndex = 3;
            this.lblGiamGia.Text = "0 VNĐ";
            this.lblGiamGia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLabelThanhTien
            // 
            this.lblLabelThanhTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLabelThanhTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLabelThanhTien.Location = new System.Drawing.Point(350, 58);
            this.lblLabelThanhTien.Name = "lblLabelThanhTien";
            this.lblLabelThanhTien.Size = new System.Drawing.Size(130, 25);
            this.lblLabelThanhTien.TabIndex = 4;
            this.lblLabelThanhTien.Text = "THÀNH TIỀN:";
            this.lblLabelThanhTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblThanhTien.ForeColor = System.Drawing.Color.Red;
            this.lblThanhTien.Location = new System.Drawing.Point(490, 55);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(140, 30);
            this.lblThanhTien.TabIndex = 5;
            this.lblThanhTien.Text = "0 VNĐ";
            this.lblThanhTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLabelPhuongThuc
            // 
            this.lblLabelPhuongThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLabelPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLabelPhuongThuc.Location = new System.Drawing.Point(380, 90);
            this.lblLabelPhuongThuc.Name = "lblLabelPhuongThuc";
            this.lblLabelPhuongThuc.Size = new System.Drawing.Size(100, 20);
            this.lblLabelPhuongThuc.TabIndex = 6;
            this.lblLabelPhuongThuc.Text = "Thanh toán:";
            this.lblLabelPhuongThuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhuongThuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhuongThuc.ForeColor = System.Drawing.Color.White;
            this.lblPhuongThuc.Location = new System.Drawing.Point(490, 88);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(100, 24);
            this.lblPhuongThuc.TabIndex = 7;
            this.lblPhuongThuc.Text = "Tiền mặt";
            this.lblPhuongThuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelBottom.Controls.Add(this.btnXuatExcel);
            this.panelBottom.Controls.Add(this.btnDong);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 580);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(650, 60);
            this.panelBottom.TabIndex = 4;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(366, 12);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(130, 38);
            this.btnXuatExcel.TabIndex = 0;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Gray;
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(520, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 38);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmInHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 640);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xuất hóa đơn";
            this.Load += new System.EventHandler(this.frmInHoaDon_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panelTotal.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTenCuaHang;
        private System.Windows.Forms.Label lblDiaChiCuaHang;
        private System.Windows.Forms.Label lblDienThoaiCuaHang;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblLabelSoHD;
        private System.Windows.Forms.Label lblSoHoaDon;
        private System.Windows.Forms.Label lblLabelNgayBan;
        private System.Windows.Forms.Label lblNgayBan;
        private System.Windows.Forms.Label lblLabelKhachHang;
        private System.Windows.Forms.Label lblTenKhachHang;
        private System.Windows.Forms.Label lblLabelNhanVien;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Label lblLabelTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblLabelGiamGia;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblLabelThanhTien;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label lblLabelPhuongThuc;
        private System.Windows.Forms.Label lblPhuongThuc;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnDong;
    }
}

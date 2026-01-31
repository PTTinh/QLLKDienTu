namespace QLCHBanLinhKien
{
    partial class frmTopKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopKhachHang));
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblTop = new System.Windows.Forms.Label();
            this.numTop = new System.Windows.Forms.NumericUpDown();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dgvTopKhachHang = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTongHoaDonLabel = new System.Windows.Forms.Label();
            this.lblTongHoaDon = new System.Windows.Forms.Label();
            this.lblTongChiTieuLabel = new System.Windows.Forms.Label();
            this.lblTongChiTieu = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopKhachHang)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(847, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TOP KHÁCH HÀNG MUA NHIỀU";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.lblTop);
            this.panelFilter.Controls.Add(this.numTop);
            this.panelFilter.Controls.Add(this.lblTuNgay);
            this.panelFilter.Controls.Add(this.dtpTuNgay);
            this.panelFilter.Controls.Add(this.lblDenNgay);
            this.panelFilter.Controls.Add(this.dtpDenNgay);
            this.panelFilter.Controls.Add(this.btnTimKiem);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 50);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelFilter.Size = new System.Drawing.Size(850, 60);
            this.panelFilter.TabIndex = 1;
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTop.Location = new System.Drawing.Point(43, 17);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(33, 19);
            this.lblTop.TabIndex = 0;
            this.lblTop.Text = "Top:";
            // 
            // numTop
            // 
            this.numTop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTop.Location = new System.Drawing.Point(60, 15);
            this.numTop.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numTop.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numTop.Name = "numTop";
            this.numTop.Size = new System.Drawing.Size(60, 30);
            this.numTop.TabIndex = 1;
            this.numTop.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTuNgay.Location = new System.Drawing.Point(188, 15);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(60, 19);
            this.lblTuNgay.TabIndex = 2;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(285, 12);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 30);
            this.dtpTuNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDenNgay.Location = new System.Drawing.Point(447, 15);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(68, 19);
            this.lblDenNgay.TabIndex = 4;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(554, 11);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 30);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(580, 12);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 32);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Xem";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvTopKhachHang
            // 
            this.dgvTopKhachHang.AllowUserToAddRows = false;
            this.dgvTopKhachHang.AllowUserToDeleteRows = false;
            this.dgvTopKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopKhachHang.Location = new System.Drawing.Point(0, 113);
            this.dgvTopKhachHang.Name = "dgvTopKhachHang";
            this.dgvTopKhachHang.ReadOnly = true;
            this.dgvTopKhachHang.RowHeadersWidth = 30;
            this.dgvTopKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopKhachHang.Size = new System.Drawing.Size(900, 380);
            this.dgvTopKhachHang.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblTongHoaDonLabel);
            this.panelBottom.Controls.Add(this.lblTongHoaDon);
            this.panelBottom.Controls.Add(this.lblTongChiTieuLabel);
            this.panelBottom.Controls.Add(this.lblTongChiTieu);
            this.panelBottom.Controls.Add(this.btnDong);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 490);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(847, 60);
            this.panelBottom.TabIndex = 3;
            // 
            // lblTongHoaDonLabel
            // 
            this.lblTongHoaDonLabel.AutoSize = true;
            this.lblTongHoaDonLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongHoaDonLabel.Location = new System.Drawing.Point(20, 18);
            this.lblTongHoaDonLabel.Name = "lblTongHoaDonLabel";
            this.lblTongHoaDonLabel.Size = new System.Drawing.Size(111, 20);
            this.lblTongHoaDonLabel.TabIndex = 0;
            this.lblTongHoaDonLabel.Text = "Tổng hóa đơn:";
            // 
            // lblTongHoaDon
            // 
            this.lblTongHoaDon.AutoSize = true;
            this.lblTongHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTongHoaDon.Location = new System.Drawing.Point(140, 18);
            this.lblTongHoaDon.Name = "lblTongHoaDon";
            this.lblTongHoaDon.Size = new System.Drawing.Size(23, 25);
            this.lblTongHoaDon.TabIndex = 1;
            this.lblTongHoaDon.Text = "0";
            // 
            // lblTongChiTieuLabel
            // 
            this.lblTongChiTieuLabel.AutoSize = true;
            this.lblTongChiTieuLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongChiTieuLabel.Location = new System.Drawing.Point(280, 18);
            this.lblTongChiTieuLabel.Name = "lblTongChiTieuLabel";
            this.lblTongChiTieuLabel.Size = new System.Drawing.Size(108, 20);
            this.lblTongChiTieuLabel.TabIndex = 2;
            this.lblTongChiTieuLabel.Text = "Tổng chi tiêu:";
            // 
            // lblTongChiTieu
            // 
            this.lblTongChiTieu.AutoSize = true;
            this.lblTongChiTieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongChiTieu.ForeColor = System.Drawing.Color.Red;
            this.lblTongChiTieu.Location = new System.Drawing.Point(432, 15);
            this.lblTongChiTieu.Name = "lblTongChiTieu";
            this.lblTongChiTieu.Size = new System.Drawing.Size(56, 21);
            this.lblTongChiTieu.TabIndex = 3;
            this.lblTongChiTieu.Text = "0 VNĐ";
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Gray;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(730, 13);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 35);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(713, 11);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(117, 30);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Xem";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // frmTopKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(847, 550);
            this.Controls.Add(this.dgvTopKhachHang);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTopKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Top khách hàng mua nhiều";
            this.Load += new System.EventHandler(this.frmTopKhachHang_Load);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopKhachHang)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.NumericUpDown numTop;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvTopKhachHang;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTongHoaDonLabel;
        private System.Windows.Forms.Label lblTongHoaDon;
        private System.Windows.Forms.Label lblTongChiTieuLabel;
        private System.Windows.Forms.Label lblTongChiTieu;
        private System.Windows.Forms.Button btnDong;
    }
}

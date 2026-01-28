namespace QuanLyBanHang
{
    partial class frmBaoCaoExcel
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

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.panelThongKe = new System.Windows.Forms.Panel();
            this.lbThanhTien = new System.Windows.Forms.Label();
            this.lbGiamGia = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.lbTongHD = new System.Windows.Forms.Label();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();

            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.panelThongKe.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();

            // panel1
            this.panel1.Controls.Add(this.btnTaiLai);
            this.panel1.Controls.Add(this.dtpDenNgay);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpTuNgay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 60);
            this.panel1.TabIndex = 0;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày:";

            // dtpTuNgay
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(76, 15);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 20);
            this.dtpTuNgay.TabIndex = 1;

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày:";

            // dtpDenNgay
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(294, 15);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 20);
            this.dtpDenNgay.TabIndex = 3;

            // btnTaiLai
            this.btnTaiLai.Location = new System.Drawing.Point(440, 13);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(75, 23);
            this.btnTaiLai.TabIndex = 4;
            this.btnTaiLai.Text = "Tải Lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);

            // dgvHoaDon
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 60);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.Size = new System.Drawing.Size(900, 340);
            this.dgvHoaDon.TabIndex = 1;

            // panelThongKe
            this.panelThongKe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongKe.Controls.Add(this.lbThanhTien);
            this.panelThongKe.Controls.Add(this.lbGiamGia);
            this.panelThongKe.Controls.Add(this.lbTongTien);
            this.panelThongKe.Controls.Add(this.lbTongHD);
            this.panelThongKe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelThongKe.Location = new System.Drawing.Point(0, 340);
            this.panelThongKe.Name = "panelThongKe";
            this.panelThongKe.Size = new System.Drawing.Size(900, 80);
            this.panelThongKe.TabIndex = 2;

            // lbTongHD
            this.lbTongHD.AutoSize = true;
            this.lbTongHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbTongHD.Location = new System.Drawing.Point(12, 10);
            this.lbTongHD.Name = "lbTongHD";
            this.lbTongHD.Size = new System.Drawing.Size(114, 17);
            this.lbTongHD.TabIndex = 0;
            this.lbTongHD.Text = "Tổng hóa đơn: 0";

            // lbTongTien
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbTongTien.Location = new System.Drawing.Point(12, 35);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(92, 17);
            this.lbTongTien.TabIndex = 1;
            this.lbTongTien.Text = "Tổng tiền: 0";

            // lbGiamGia
            this.lbGiamGia.AutoSize = true;
            this.lbGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbGiamGia.Location = new System.Drawing.Point(300, 35);
            this.lbGiamGia.Name = "lbGiamGia";
            this.lbGiamGia.Size = new System.Drawing.Size(107, 17);
            this.lbGiamGia.TabIndex = 2;
            this.lbGiamGia.Text = "Chiết khấu: 0";

            // lbThanhTien
            this.lbThanhTien.AutoSize = true;
            this.lbThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbThanhTien.ForeColor = System.Drawing.Color.Red;
            this.lbThanhTien.Location = new System.Drawing.Point(600, 35);
            this.lbThanhTien.Name = "lbThanhTien";
            this.lbThanhTien.Size = new System.Drawing.Size(118, 17);
            this.lbThanhTien.TabIndex = 3;
            this.lbThanhTien.Text = "Thành tiền: 0";

            // panelButton
            this.panelButton.Controls.Add(this.btnDong);
            this.panelButton.Controls.Add(this.btnXuatExcel);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 420);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(900, 40);
            this.panelButton.TabIndex = 3;

            // btnXuatExcel
            this.btnXuatExcel.Location = new System.Drawing.Point(12, 8);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 23);
            this.btnXuatExcel.TabIndex = 0;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);

            // btnDong
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(813, 8);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            // frmBaoCaoExcel
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 460);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.panelThongKe);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panel1);
            this.Name = "frmBaoCaoExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Xuất Excel";
            this.Load += new System.EventHandler(this.frmBaoCaoExcel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panelThongKe.ResumeLayout(false);
            this.panelThongKe.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Panel panelThongKe;
        private System.Windows.Forms.Label lbThanhTien;
        private System.Windows.Forms.Label lbGiamGia;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label lbTongHD;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}

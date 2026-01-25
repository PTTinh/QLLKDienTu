namespace QuanLyBanHang
{
    partial class frmCanhBaoHangTon
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSapHet = new System.Windows.Forms.Label();
            this.lblHetHang = new System.Windows.Forms.Label();
            this.lblTongSP = new System.Windows.Forms.Label();
            this.dgvHangTon = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSapHet);
            this.groupBox1.Controls.Add(this.lblHetHang);
            this.groupBox1.Controls.Add(this.lblTongSP);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê";
            // 
            // lblSapHet
            // 
            this.lblSapHet.AutoSize = true;
            this.lblSapHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSapHet.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblSapHet.Location = new System.Drawing.Point(650, 35);
            this.lblSapHet.Name = "lblSapHet";
            this.lblSapHet.Size = new System.Drawing.Size(82, 17);
            this.lblSapHet.TabIndex = 2;
            this.lblSapHet.Text = "Sắp hết: 0";
            // 
            // lblHetHang
            // 
            this.lblHetHang.AutoSize = true;
            this.lblHetHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHetHang.ForeColor = System.Drawing.Color.Red;
            this.lblHetHang.Location = new System.Drawing.Point(350, 35);
            this.lblHetHang.Name = "lblHetHang";
            this.lblHetHang.Size = new System.Drawing.Size(96, 17);
            this.lblHetHang.TabIndex = 1;
            this.lblHetHang.Text = "Hết hàng: 0";
            // 
            // lblTongSP
            // 
            this.lblTongSP.AutoSize = true;
            this.lblTongSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSP.Location = new System.Drawing.Point(30, 35);
            this.lblTongSP.Name = "lblTongSP";
            this.lblTongSP.Size = new System.Drawing.Size(235, 17);
            this.lblTongSP.TabIndex = 0;
            this.lblTongSP.Text = "Tổng số sản phẩm cảnh báo: 0";
            // 
            // dgvHangTon
            // 
            this.dgvHangTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangTon.Location = new System.Drawing.Point(12, 110);
            this.dgvHangTon.Name = "dgvHangTon";
            this.dgvHangTon.Size = new System.Drawing.Size(960, 400);
            this.dgvHangTon.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(750, 520);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 30);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(870, 520);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 30);
            this.btnXuatExcel.TabIndex = 3;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // frmCanhBaoHangTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvHangTon);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCanhBaoHangTon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cảnh báo Hàng tồn kho";
            this.Load += new System.EventHandler(this.frmCanhBaoHangTon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTongSP;
        private System.Windows.Forms.Label lblHetHang;
        private System.Windows.Forms.Label lblSapHet;
        private System.Windows.Forms.DataGridView dgvHangTon;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}

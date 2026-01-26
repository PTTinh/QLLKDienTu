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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCanhBaoHangTon));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.lblSapHet = new System.Windows.Forms.Label();
            this.lblHetHang = new System.Windows.Forms.Label();
            this.lblTongSP = new System.Windows.Forms.Label();
            this.dgvHangTon = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuatfile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDanhMuc);
            this.groupBox1.Controls.Add(this.lblDanhMuc);
            this.groupBox1.Controls.Add(this.lblSapHet);
            this.groupBox1.Controls.Add(this.lblHetHang);
            this.groupBox1.Controls.Add(this.lblTongSP);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1280, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê & Lọc";
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(182, 65);
            this.cboDanhMuc.Margin = new System.Windows.Forms.Padding(4);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(225, 28);
            this.cboDanhMuc.TabIndex = 3;
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhMuc.Location = new System.Drawing.Point(40, 65);
            this.lblDanhMuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(100, 20);
            this.lblDanhMuc.TabIndex = 2;
            this.lblDanhMuc.Text = "Danh mục:";
            // 
            // lblSapHet
            // 
            this.lblSapHet.AutoSize = true;
            this.lblSapHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSapHet.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblSapHet.Location = new System.Drawing.Point(877, 36);
            this.lblSapHet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSapHet.Name = "lblSapHet";
            this.lblSapHet.Size = new System.Drawing.Size(95, 20);
            this.lblSapHet.TabIndex = 2;
            this.lblSapHet.Text = "Sắp hết: 0";
            // 
            // lblHetHang
            // 
            this.lblHetHang.AutoSize = true;
            this.lblHetHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHetHang.ForeColor = System.Drawing.Color.Red;
            this.lblHetHang.Location = new System.Drawing.Point(464, 36);
            this.lblHetHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHetHang.Name = "lblHetHang";
            this.lblHetHang.Size = new System.Drawing.Size(107, 20);
            this.lblHetHang.TabIndex = 1;
            this.lblHetHang.Text = "Hết hàng: 0";
            // 
            // lblTongSP
            // 
            this.lblTongSP.AutoSize = true;
            this.lblTongSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSP.Location = new System.Drawing.Point(39, 36);
            this.lblTongSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongSP.Name = "lblTongSP";
            this.lblTongSP.Size = new System.Drawing.Size(267, 20);
            this.lblTongSP.TabIndex = 0;
            this.lblTongSP.Text = "Tổng số sản phẩm cảnh báo: 0";
            // 
            // dgvHangTon
            // 
            this.dgvHangTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangTon.Location = new System.Drawing.Point(16, 140);
            this.dgvHangTon.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHangTon.Name = "dgvHangTon";
            this.dgvHangTon.RowHeadersWidth = 51;
            this.dgvHangTon.Size = new System.Drawing.Size(1280, 492);
            this.dgvHangTon.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Silver;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(1159, 640);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(137, 42);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXuatfile
            // 
            this.btnXuatfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnXuatfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatfile.Location = new System.Drawing.Point(981, 640);
            this.btnXuatfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuatfile.Name = "btnXuatfile";
            this.btnXuatfile.Size = new System.Drawing.Size(137, 42);
            this.btnXuatfile.TabIndex = 3;
            this.btnXuatfile.Text = "Xuất &file";
            this.btnXuatfile.UseVisualStyleBackColor = false;
            this.btnXuatfile.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // frmCanhBaoHangTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 692);
            this.Controls.Add(this.btnXuatfile);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvHangTon);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.Label lblTongSP;
        private System.Windows.Forms.Label lblHetHang;
        private System.Windows.Forms.Label lblSapHet;
        private System.Windows.Forms.DataGridView dgvHangTon;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatfile;
    }
}

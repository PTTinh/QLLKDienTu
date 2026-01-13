namespace QLLinhKienDT
{
    partial class FormTimKiemNangCao
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
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoaiTimKiem = new System.Windows.Forms.ComboBox();
            this.btnTimSanPham = new System.Windows.Forms.Button();
            this.btnTimKhachHang = new System.Windows.Forms.Button();
            this.btnTimHoaDon = new System.Windows.Forms.Button();
            this.btnXoaTimKiem = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(10, 20);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(97, 13);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Từ khóa tìm kiếm:";
            
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(150, 20);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 20);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(470, 20);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(60, 13);
            this.lblLoai.TabIndex = 2;
            this.lblLoai.Text = "Danh mục:";
            
            // 
            // cboLoaiTimKiem
            // 
            this.cboLoaiTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiTimKiem.FormattingEnabled = true;
            this.cboLoaiTimKiem.Location = new System.Drawing.Point(550, 20);
            this.cboLoaiTimKiem.Name = "cboLoaiTimKiem";
            this.cboLoaiTimKiem.Size = new System.Drawing.Size(150, 21);
            this.cboLoaiTimKiem.TabIndex = 3;
            
            // 
            // btnTimSanPham
            // 
            this.btnTimSanPham.Location = new System.Drawing.Point(10, 60);
            this.btnTimSanPham.Name = "btnTimSanPham";
            this.btnTimSanPham.Size = new System.Drawing.Size(100, 23);
            this.btnTimSanPham.TabIndex = 4;
            this.btnTimSanPham.Text = "Tìm sản phẩm";
            this.btnTimSanPham.UseVisualStyleBackColor = true;
            this.btnTimSanPham.Click += new System.EventHandler(this.btnTimSanPham_Click);
            
            // 
            // btnTimKhachHang
            // 
            this.btnTimKhachHang.Location = new System.Drawing.Point(130, 60);
            this.btnTimKhachHang.Name = "btnTimKhachHang";
            this.btnTimKhachHang.Size = new System.Drawing.Size(100, 23);
            this.btnTimKhachHang.TabIndex = 5;
            this.btnTimKhachHang.Text = "Tìm khách hàng";
            this.btnTimKhachHang.UseVisualStyleBackColor = true;
            this.btnTimKhachHang.Click += new System.EventHandler(this.btnTimKhachHang_Click);
            
            // 
            // btnTimHoaDon
            // 
            this.btnTimHoaDon.Location = new System.Drawing.Point(250, 60);
            this.btnTimHoaDon.Name = "btnTimHoaDon";
            this.btnTimHoaDon.Size = new System.Drawing.Size(100, 23);
            this.btnTimHoaDon.TabIndex = 6;
            this.btnTimHoaDon.Text = "Tìm hóa đơn";
            this.btnTimHoaDon.UseVisualStyleBackColor = true;
            this.btnTimHoaDon.Click += new System.EventHandler(this.btnTimHoaDon_Click);
            
            // 
            // btnXoaTimKiem
            // 
            this.btnXoaTimKiem.Location = new System.Drawing.Point(370, 60);
            this.btnXoaTimKiem.Name = "btnXoaTimKiem";
            this.btnXoaTimKiem.Size = new System.Drawing.Size(80, 23);
            this.btnXoaTimKiem.TabIndex = 7;
            this.btnXoaTimKiem.Text = "Xóa";
            this.btnXoaTimKiem.UseVisualStyleBackColor = true;
            this.btnXoaTimKiem.Click += new System.EventHandler(this.btnXoaTimKiem_Click);
            
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location = new System.Drawing.Point(10, 110);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.Size = new System.Drawing.Size(860, 430);
            this.dgvKetQua.TabIndex = 8;
            
            // 
            // FormTimKiemNangCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.btnXoaTimKiem);
            this.Controls.Add(this.btnTimHoaDon);
            this.Controls.Add(this.btnTimKhachHang);
            this.Controls.Add(this.btnTimSanPham);
            this.Controls.Add(this.cboLoaiTimKiem);
            this.Controls.Add(this.lblLoai);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FormTimKiemNangCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm nâng cao";
            this.Load += new System.EventHandler(this.FormTimKiemNangCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoaiTimKiem;
        private System.Windows.Forms.Button btnTimSanPham;
        private System.Windows.Forms.Button btnTimKhachHang;
        private System.Windows.Forms.Button btnTimHoaDon;
        private System.Windows.Forms.Button btnXoaTimKiem;
        private System.Windows.Forms.DataGridView dgvKetQua;
    }
}

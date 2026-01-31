namespace QLCHBanLinhKien
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.nudMucCanhBao = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHangTon = new System.Windows.Forms.DataGridView();
            this.lblTongSP = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMucCanhBao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnDong);
            this.pnlTop.Controls.Add(this.btnReport);
            this.pnlTop.Controls.Add(this.btnTimKiem);
            this.pnlTop.Controls.Add(this.nudMucCanhBao);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(850, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(770, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(70, 30);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.Green;
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(340, 12);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(90, 30);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Báo Cáo";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(250, 12);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(80, 30);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Lọc";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // nudMucCanhBao
            // 
            this.nudMucCanhBao.Location = new System.Drawing.Point(160, 17);
            this.nudMucCanhBao.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMucCanhBao.Name = "nudMucCanhBao";
            this.nudMucCanhBao.Size = new System.Drawing.Size(80, 20);
            this.nudMucCanhBao.TabIndex = 1;
            this.nudMucCanhBao.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mức cảnh báo (số lượng <=):";
            // 
            // dgvHangTon
            // 
            this.dgvHangTon.AllowUserToAddRows = false;
            this.dgvHangTon.AllowUserToDeleteRows = false;
            this.dgvHangTon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangTon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHangTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHangTon.Location = new System.Drawing.Point(0, 55);
            this.dgvHangTon.Name = "dgvHangTon";
            this.dgvHangTon.ReadOnly = true;
            this.dgvHangTon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHangTon.Size = new System.Drawing.Size(850, 375);
            this.dgvHangTon.TabIndex = 1;
            // 
            // lblTongSP
            // 
            this.lblTongSP.BackColor = System.Drawing.Color.LightCyan;
            this.lblTongSP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTongSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSP.Location = new System.Drawing.Point(0, 430);
            this.lblTongSP.Name = "lblTongSP";
            this.lblTongSP.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblTongSP.Size = new System.Drawing.Size(850, 30);
            this.lblTongSP.TabIndex = 2;
            this.lblTongSP.Text = "Tổng sản phẩm cần nhập: 0";
            this.lblTongSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCanhBaoHangTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 460);
            this.Controls.Add(this.dgvHangTon);
            this.Controls.Add(this.lblTongSP);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmCanhBaoHangTon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cảnh báo hàng tồn kho";
            this.Load += new System.EventHandler(this.frmCanhBaoHangTon_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMucCanhBao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMucCanhBao;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvHangTon;
        private System.Windows.Forms.Label lblTongSP;
    }
}

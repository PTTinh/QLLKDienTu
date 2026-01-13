namespace QLLinhKienDT
{
    partial class FormTroGiup
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHuongDan = new System.Windows.Forms.TabPage();
            this.rtbHuongDan = new System.Windows.Forms.RichTextBox();
            this.tabThongTin = new System.Windows.Forms.TabPage();
            this.txtThongTin = new System.Windows.Forms.TextBox();
            this.btnKiemTraCapNhat = new System.Windows.Forms.Button();
            this.btnVeNhom = new System.Windows.Forms.Button();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabHuongDan.SuspendLayout();
            this.tabThongTin.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabHuongDan);
            this.tabControl.Controls.Add(this.tabThongTin);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 550);
            this.tabControl.TabIndex = 0;
            
            // 
            // tabHuongDan
            // 
            this.tabHuongDan.Controls.Add(this.rtbHuongDan);
            this.tabHuongDan.Location = new System.Drawing.Point(4, 22);
            this.tabHuongDan.Name = "tabHuongDan";
            this.tabHuongDan.Padding = new System.Windows.Forms.Padding(3);
            this.tabHuongDan.Size = new System.Drawing.Size(792, 524);
            this.tabHuongDan.TabIndex = 0;
            this.tabHuongDan.Text = "Hướng dẫn";
            this.tabHuongDan.UseVisualStyleBackColor = true;
            
            // 
            // rtbHuongDan
            // 
            this.rtbHuongDan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbHuongDan.Location = new System.Drawing.Point(5, 5);
            this.rtbHuongDan.Name = "rtbHuongDan";
            this.rtbHuongDan.ReadOnly = true;
            this.rtbHuongDan.Size = new System.Drawing.Size(780, 510);
            this.rtbHuongDan.TabIndex = 0;
            this.rtbHuongDan.Text = "";
            
            // 
            // tabThongTin
            // 
            this.tabThongTin.Controls.Add(this.txtThongTin);
            this.tabThongTin.Controls.Add(this.btnKiemTraCapNhat);
            this.tabThongTin.Controls.Add(this.btnVeNhom);
            this.tabThongTin.Controls.Add(this.lblThongTin);
            this.tabThongTin.Location = new System.Drawing.Point(4, 22);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongTin.Size = new System.Drawing.Size(792, 524);
            this.tabThongTin.TabIndex = 1;
            this.tabThongTin.Text = "Thông tin";
            this.tabThongTin.UseVisualStyleBackColor = true;
            
            // 
            // lblThongTin
            // 
            this.lblThongTin.AutoSize = true;
            this.lblThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTin.Location = new System.Drawing.Point(20, 20);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(306, 20);
            this.lblThongTin.TabIndex = 0;
            this.lblThongTin.Text = "Phần mềm Quản lý Linh kiện Điện tử";
            
            // 
            // btnVeNhom
            // 
            this.btnVeNhom.Location = new System.Drawing.Point(20, 60);
            this.btnVeNhom.Name = "btnVeNhom";
            this.btnVeNhom.Size = new System.Drawing.Size(150, 25);
            this.btnVeNhom.TabIndex = 1;
            this.btnVeNhom.Text = "Thông tin về nhóm";
            this.btnVeNhom.UseVisualStyleBackColor = true;
            this.btnVeNhom.Click += new System.EventHandler(this.btnVeNhom_Click);
            
            // 
            // btnKiemTraCapNhat
            // 
            this.btnKiemTraCapNhat.Location = new System.Drawing.Point(200, 60);
            this.btnKiemTraCapNhat.Name = "btnKiemTraCapNhat";
            this.btnKiemTraCapNhat.Size = new System.Drawing.Size(150, 25);
            this.btnKiemTraCapNhat.TabIndex = 2;
            this.btnKiemTraCapNhat.Text = "Kiểm tra cập nhật";
            this.btnKiemTraCapNhat.UseVisualStyleBackColor = true;
            this.btnKiemTraCapNhat.Click += new System.EventHandler(this.btnKiemTraCapNhat_Click);
            
            // 
            // txtThongTin
            // 
            this.txtThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThongTin.Location = new System.Drawing.Point(20, 110);
            this.txtThongTin.Multiline = true;
            this.txtThongTin.Name = "txtThongTin";
            this.txtThongTin.ReadOnly = true;
            this.txtThongTin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtThongTin.Size = new System.Drawing.Size(740, 380);
            this.txtThongTin.TabIndex = 3;
            this.txtThongTin.Text = "Phần mềm Quản lý Linh kiện Điện tử\r\n\r\nPhiên bản: 1.0\r\nNgày tạo: 2026\r\n\r\nTính n" +
    "ăng chính:\r\n- Quản lý sản phẩm và danh mục\r\n- Quản lý khách hàng\r\n- Bán hàng và " +
    "tạo hóa đơn\r\n- Báo cáo doanh thu\r\n- Tìm kiếm nâng cao\r\n- Cấu hình hệ thống\r\n\r\nH" +
    "ỗ trợ kỹ thuật:\r\nEmail: support@qllienkien.com\r\nĐiện thoại: 1900-xxxx";
            
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(700, 560);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(80, 25);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            
            // 
            // FormTroGiup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabControl);
            this.Name = "FormTroGiup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trợ giúp & Hướng dẫn";
            this.Load += new System.EventHandler(this.FormTroGiup_Load);
            this.tabControl.ResumeLayout(false);
            this.tabHuongDan.ResumeLayout(false);
            this.tabThongTin.ResumeLayout(false);
            this.tabThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabHuongDan;
        private System.Windows.Forms.RichTextBox rtbHuongDan;
        private System.Windows.Forms.TabPage tabThongTin;
        private System.Windows.Forms.TextBox txtThongTin;
        private System.Windows.Forms.Button btnKiemTraCapNhat;
        private System.Windows.Forms.Button btnVeNhom;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.Button btnDong;
    }
}

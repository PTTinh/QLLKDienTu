namespace QLCHBanLinhKien
{
    partial class frmCauHinh
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.groupDatabase = new System.Windows.Forms.GroupBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.chkWindowsAuth = new System.Windows.Forms.CheckBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnTestKetNoi = new System.Windows.Forms.Button();
            this.btnLuuDatabase = new System.Windows.Forms.Button();
            this.groupBackup = new System.Windows.Forms.GroupBox();
            this.tabHeThong = new System.Windows.Forms.TabPage();
            this.groupHeThong = new System.Windows.Forms.GroupBox();
            this.lblPhienBan = new System.Windows.Forms.Label();
            this.lblDotNet = new System.Windows.Forms.Label();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.lblKetNoi = new System.Windows.Forms.Label();
            this.btnSaoLuu = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.lblBackupNote = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            this.groupDatabase.SuspendLayout();
            this.tabHeThong.SuspendLayout();
            this.groupHeThong.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(500, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CẤU HÌNH HỆ THỐNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDatabase);
            this.tabControl.Controls.Add(this.tabHeThong);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(500, 450);
            this.tabControl.TabIndex = 1;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.groupDatabase);
            this.tabDatabase.Controls.Add(this.groupBackup);
            this.tabDatabase.Location = new System.Drawing.Point(4, 26);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(10);
            this.tabDatabase.Size = new System.Drawing.Size(492, 420);
            this.tabDatabase.TabIndex = 0;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // groupDatabase
            // 
            this.groupDatabase.Controls.Add(this.lblServer);
            this.groupDatabase.Controls.Add(this.txtServer);
            this.groupDatabase.Controls.Add(this.lblDatabase);
            this.groupDatabase.Controls.Add(this.txtDatabase);
            this.groupDatabase.Controls.Add(this.chkWindowsAuth);
            this.groupDatabase.Controls.Add(this.lblUsername);
            this.groupDatabase.Controls.Add(this.txtUsername);
            this.groupDatabase.Controls.Add(this.lblPassword);
            this.groupDatabase.Controls.Add(this.txtPassword);
            this.groupDatabase.Controls.Add(this.btnTestKetNoi);
            this.groupDatabase.Controls.Add(this.btnLuuDatabase);
            this.groupDatabase.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.groupDatabase.Location = new System.Drawing.Point(13, 13);
            this.groupDatabase.Name = "groupDatabase";
            this.groupDatabase.Size = new System.Drawing.Size(466, 200);
            this.groupDatabase.TabIndex = 0;
            this.groupDatabase.TabStop = false;
            this.groupDatabase.Text = "Kết nối Database";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(20, 30);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(48, 17);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(120, 27);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(320, 24);
            this.txtServer.TabIndex = 1;
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(20, 60);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(66, 17);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(120, 57);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(320, 24);
            this.txtDatabase.TabIndex = 3;
            // 
            // chkWindowsAuth
            // 
            this.chkWindowsAuth.AutoSize = true;
            this.chkWindowsAuth.Location = new System.Drawing.Point(120, 87);
            this.chkWindowsAuth.Name = "chkWindowsAuth";
            this.chkWindowsAuth.Size = new System.Drawing.Size(166, 21);
            this.chkWindowsAuth.TabIndex = 4;
            this.chkWindowsAuth.Text = "Windows Authentication";
            this.chkWindowsAuth.UseVisualStyleBackColor = true;
            this.chkWindowsAuth.CheckedChanged += new System.EventHandler(this.chkWindowsAuth_CheckedChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(20, 115);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(70, 17);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(120, 112);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(320, 24);
            this.txtUsername.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 145);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 17);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 142);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(320, 24);
            this.txtPassword.TabIndex = 8;
            // 
            // btnTestKetNoi
            // 
            this.btnTestKetNoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.btnTestKetNoi.FlatAppearance.BorderSize = 0;
            this.btnTestKetNoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestKetNoi.ForeColor = System.Drawing.Color.White;
            this.btnTestKetNoi.Location = new System.Drawing.Point(240, 172);
            this.btnTestKetNoi.Name = "btnTestKetNoi";
            this.btnTestKetNoi.Size = new System.Drawing.Size(95, 25);
            this.btnTestKetNoi.TabIndex = 9;
            this.btnTestKetNoi.Text = "Test kết nối";
            this.btnTestKetNoi.UseVisualStyleBackColor = false;
            this.btnTestKetNoi.Click += new System.EventHandler(this.btnTestKetNoi_Click);
            // 
            // btnLuuDatabase
            // 
            this.btnLuuDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnLuuDatabase.FlatAppearance.BorderSize = 0;
            this.btnLuuDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuDatabase.ForeColor = System.Drawing.Color.White;
            this.btnLuuDatabase.Location = new System.Drawing.Point(345, 172);
            this.btnLuuDatabase.Name = "btnLuuDatabase";
            this.btnLuuDatabase.Size = new System.Drawing.Size(95, 25);
            this.btnLuuDatabase.TabIndex = 10;
            this.btnLuuDatabase.Text = "Lưu";
            this.btnLuuDatabase.UseVisualStyleBackColor = false;
            this.btnLuuDatabase.Click += new System.EventHandler(this.btnLuuDatabase_Click);
            // 
            // groupBackup
            // 
            this.groupBackup.Location = new System.Drawing.Point(0, 0);
            this.groupBackup.Name = "groupBackup";
            this.groupBackup.Size = new System.Drawing.Size(200, 100);
            this.groupBackup.TabIndex = 1;
            this.groupBackup.TabStop = false;
            // 
            // tabHeThong
            // 
            this.tabHeThong.Controls.Add(this.groupHeThong);
            this.tabHeThong.Location = new System.Drawing.Point(4, 26);
            this.tabHeThong.Name = "tabHeThong";
            this.tabHeThong.Padding = new System.Windows.Forms.Padding(10);
            this.tabHeThong.Size = new System.Drawing.Size(492, 420);
            this.tabHeThong.TabIndex = 2;
            this.tabHeThong.Text = "Thong tin he thong";
            this.tabHeThong.UseVisualStyleBackColor = true;
            // 
            // groupHeThong
            // 
            this.groupHeThong.Controls.Add(this.lblPhienBan);
            this.groupHeThong.Controls.Add(this.lblDotNet);
            this.groupHeThong.Controls.Add(this.lblOS);
            this.groupHeThong.Controls.Add(this.lblMachineName);
            this.groupHeThong.Controls.Add(this.lblKetNoi);
            this.groupHeThong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupHeThong.Location = new System.Drawing.Point(13, 13);
            this.groupHeThong.Name = "groupHeThong";
            this.groupHeThong.Size = new System.Drawing.Size(466, 180);
            this.groupHeThong.TabIndex = 0;
            this.groupHeThong.TabStop = false;
            this.groupHeThong.Text = "Thong tin he thong";
            // 
            // lblPhienBan
            // 
            this.lblPhienBan.AutoSize = true;
            this.lblPhienBan.Location = new System.Drawing.Point(20, 35);
            this.lblPhienBan.Name = "lblPhienBan";
            this.lblPhienBan.Size = new System.Drawing.Size(107, 19);
            this.lblPhienBan.TabIndex = 0;
            this.lblPhienBan.Text = "Phien ban: 1.0.0";
            // 
            // lblDotNet
            // 
            this.lblDotNet.AutoSize = true;
            this.lblDotNet.Location = new System.Drawing.Point(20, 60);
            this.lblDotNet.Name = "lblDotNet";
            this.lblDotNet.Size = new System.Drawing.Size(115, 19);
            this.lblDotNet.TabIndex = 1;
            this.lblDotNet.Text = ".NET Framework: ";
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Location = new System.Drawing.Point(20, 85);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(98, 19);
            this.lblOS.TabIndex = 2;
            this.lblOS.Text = "He dieu hanh: ";
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Location = new System.Drawing.Point(20, 110);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(67, 19);
            this.lblMachineName.TabIndex = 3;
            this.lblMachineName.Text = "Ten may: ";
            // 
            // lblKetNoi
            // 
            this.lblKetNoi.AutoSize = true;
            this.lblKetNoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKetNoi.ForeColor = System.Drawing.Color.Green;
            this.lblKetNoi.Location = new System.Drawing.Point(20, 140);
            this.lblKetNoi.Name = "lblKetNoi";
            this.lblKetNoi.Size = new System.Drawing.Size(152, 19);
            this.lblKetNoi.TabIndex = 4;
            this.lblKetNoi.Text = "Trang thai: Da ket noi";
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.Location = new System.Drawing.Point(0, 0);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.Size = new System.Drawing.Size(75, 23);
            this.btnSaoLuu.TabIndex = 0;
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Location = new System.Drawing.Point(0, 0);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(75, 23);
            this.btnPhucHoi.TabIndex = 0;
            // 
            // lblBackupNote
            // 
            this.lblBackupNote.Location = new System.Drawing.Point(0, 0);
            this.lblBackupNote.Name = "lblBackupNote";
            this.lblBackupNote.Size = new System.Drawing.Size(100, 23);
            this.lblBackupNote.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Gray;
            this.btnDong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(0, 500);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(500, 40);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Dong";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmCauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 540);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCauHinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cau hinh he thong";
            this.Load += new System.EventHandler(this.frmCauHinh_Load);
            this.panelTop.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabDatabase.ResumeLayout(false);
            this.groupDatabase.ResumeLayout(false);
            this.groupDatabase.PerformLayout();
            this.tabHeThong.ResumeLayout(false);
            this.groupHeThong.ResumeLayout(false);
            this.groupHeThong.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.GroupBox groupDatabase;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.CheckBox chkWindowsAuth;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnTestKetNoi;
        private System.Windows.Forms.Button btnLuuDatabase;
        private System.Windows.Forms.GroupBox groupBackup;
        private System.Windows.Forms.Button btnSaoLuu;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Label lblBackupNote;
        private System.Windows.Forms.TabPage tabHeThong;
        private System.Windows.Forms.GroupBox groupHeThong;
        private System.Windows.Forms.Label lblPhienBan;
        private System.Windows.Forms.Label lblDotNet;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label lblKetNoi;
        private System.Windows.Forms.Button btnDong;
    }
}

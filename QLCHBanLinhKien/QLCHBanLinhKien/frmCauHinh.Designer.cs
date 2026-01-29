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
            this.btnSaoLuu = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.lblBackupNote = new System.Windows.Forms.Label();
            this.tabCuaHang = new System.Windows.Forms.TabPage();
            this.groupCuaHang = new System.Windows.Forms.GroupBox();
            this.lblTenCuaHang = new System.Windows.Forms.Label();
            this.txtTenCuaHang = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblThueSuat = new System.Windows.Forms.Label();
            this.numThueSuat = new System.Windows.Forms.NumericUpDown();
            this.lblPercent = new System.Windows.Forms.Label();
            this.btnLuuCuaHang = new System.Windows.Forms.Button();
            this.tabHeThong = new System.Windows.Forms.TabPage();
            this.groupHeThong = new System.Windows.Forms.GroupBox();
            this.lblPhienBan = new System.Windows.Forms.Label();
            this.lblDotNet = new System.Windows.Forms.Label();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.lblKetNoi = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            this.groupDatabase.SuspendLayout();
            this.groupBackup.SuspendLayout();
            this.tabCuaHang.SuspendLayout();
            this.groupCuaHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThueSuat)).BeginInit();
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
            this.tabControl.Controls.Add(this.tabCuaHang);
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
            this.tabDatabase.Location = new System.Drawing.Point(4, 28);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(10);
            this.tabDatabase.Size = new System.Drawing.Size(492, 418);
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
            this.lblServer.Size = new System.Drawing.Size(46, 17);
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
            this.lblDatabase.Size = new System.Drawing.Size(64, 17);
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
            this.chkWindowsAuth.Size = new System.Drawing.Size(185, 21);
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
            this.lblUsername.Size = new System.Drawing.Size(74, 17);
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
            this.lblPassword.Size = new System.Drawing.Size(70, 17);
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
            this.groupBackup.Controls.Add(this.btnSaoLuu);
            this.groupBackup.Controls.Add(this.btnPhucHoi);
            this.groupBackup.Controls.Add(this.lblBackupNote);
            this.groupBackup.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.groupBackup.Location = new System.Drawing.Point(13, 220);
            this.groupBackup.Name = "groupBackup";
            this.groupBackup.Size = new System.Drawing.Size(466, 100);
            this.groupBackup.TabIndex = 1;
            this.groupBackup.TabStop = false;
            this.groupBackup.Text = "Sao luu / Phuc hoi";
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSaoLuu.FlatAppearance.BorderSize = 0;
            this.btnSaoLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaoLuu.ForeColor = System.Drawing.Color.White;
            this.btnSaoLuu.Location = new System.Drawing.Point(23, 30);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.Size = new System.Drawing.Size(120, 30);
            this.btnSaoLuu.TabIndex = 0;
            this.btnSaoLuu.Text = "Sao luu Database";
            this.btnSaoLuu.UseVisualStyleBackColor = false;
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.btnPhucHoi.FlatAppearance.BorderSize = 0;
            this.btnPhucHoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhucHoi.ForeColor = System.Drawing.Color.White;
            this.btnPhucHoi.Location = new System.Drawing.Point(153, 30);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(120, 30);
            this.btnPhucHoi.TabIndex = 1;
            this.btnPhucHoi.Text = "Phuc hoi Database";
            this.btnPhucHoi.UseVisualStyleBackColor = false;
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // lblBackupNote
            // 
            this.lblBackupNote.AutoSize = true;
            this.lblBackupNote.ForeColor = System.Drawing.Color.Gray;
            this.lblBackupNote.Location = new System.Drawing.Point(20, 70);
            this.lblBackupNote.Name = "lblBackupNote";
            this.lblBackupNote.Size = new System.Drawing.Size(329, 17);
            this.lblBackupNote.TabIndex = 2;
            this.lblBackupNote.Text = "Luu y: Sao luu thuong xuyen de tranh mat du lieu";
            // 
            // tabCuaHang
            // 
            this.tabCuaHang.Controls.Add(this.groupCuaHang);
            this.tabCuaHang.Location = new System.Drawing.Point(4, 28);
            this.tabCuaHang.Name = "tabCuaHang";
            this.tabCuaHang.Padding = new System.Windows.Forms.Padding(10);
            this.tabCuaHang.Size = new System.Drawing.Size(492, 418);
            this.tabCuaHang.TabIndex = 1;
            this.tabCuaHang.Text = "Thong tin cua hang";
            this.tabCuaHang.UseVisualStyleBackColor = true;
            // 
            // groupCuaHang
            // 
            this.groupCuaHang.Controls.Add(this.lblTenCuaHang);
            this.groupCuaHang.Controls.Add(this.txtTenCuaHang);
            this.groupCuaHang.Controls.Add(this.lblDiaChi);
            this.groupCuaHang.Controls.Add(this.txtDiaChi);
            this.groupCuaHang.Controls.Add(this.lblDienThoai);
            this.groupCuaHang.Controls.Add(this.txtDienThoai);
            this.groupCuaHang.Controls.Add(this.lblEmail);
            this.groupCuaHang.Controls.Add(this.txtEmail);
            this.groupCuaHang.Controls.Add(this.lblThueSuat);
            this.groupCuaHang.Controls.Add(this.numThueSuat);
            this.groupCuaHang.Controls.Add(this.lblPercent);
            this.groupCuaHang.Controls.Add(this.btnLuuCuaHang);
            this.groupCuaHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.groupCuaHang.Location = new System.Drawing.Point(13, 13);
            this.groupCuaHang.Name = "groupCuaHang";
            this.groupCuaHang.Size = new System.Drawing.Size(466, 250);
            this.groupCuaHang.TabIndex = 0;
            this.groupCuaHang.TabStop = false;
            this.groupCuaHang.Text = "Thong tin cua hang";
            // 
            // lblTenCuaHang
            // 
            this.lblTenCuaHang.AutoSize = true;
            this.lblTenCuaHang.Location = new System.Drawing.Point(20, 35);
            this.lblTenCuaHang.Name = "lblTenCuaHang";
            this.lblTenCuaHang.Size = new System.Drawing.Size(90, 17);
            this.lblTenCuaHang.TabIndex = 0;
            this.lblTenCuaHang.Text = "Ten cua hang:";
            // 
            // txtTenCuaHang
            // 
            this.txtTenCuaHang.Location = new System.Drawing.Point(120, 32);
            this.txtTenCuaHang.Name = "txtTenCuaHang";
            this.txtTenCuaHang.Size = new System.Drawing.Size(320, 24);
            this.txtTenCuaHang.TabIndex = 1;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(20, 70);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(49, 17);
            this.lblDiaChi.TabIndex = 2;
            this.lblDiaChi.Text = "Dia chi:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(120, 67);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(320, 50);
            this.txtDiaChi.TabIndex = 3;
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(20, 130);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(72, 17);
            this.lblDienThoai.TabIndex = 4;
            this.lblDienThoai.Text = "Dien thoai:";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(120, 127);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(200, 24);
            this.txtDienThoai.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 165);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(43, 17);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 162);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 24);
            this.txtEmail.TabIndex = 7;
            // 
            // lblThueSuat
            // 
            this.lblThueSuat.AutoSize = true;
            this.lblThueSuat.Location = new System.Drawing.Point(20, 200);
            this.lblThueSuat.Name = "lblThueSuat";
            this.lblThueSuat.Size = new System.Drawing.Size(80, 17);
            this.lblThueSuat.TabIndex = 8;
            this.lblThueSuat.Text = "Thue VAT %:";
            // 
            // numThueSuat
            // 
            this.numThueSuat.Location = new System.Drawing.Point(120, 197);
            this.numThueSuat.Name = "numThueSuat";
            this.numThueSuat.Size = new System.Drawing.Size(80, 24);
            this.numThueSuat.TabIndex = 9;
            this.numThueSuat.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(206, 200);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(21, 17);
            this.lblPercent.TabIndex = 10;
            this.lblPercent.Text = "%";
            // 
            // btnLuuCuaHang
            // 
            this.btnLuuCuaHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnLuuCuaHang.FlatAppearance.BorderSize = 0;
            this.btnLuuCuaHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuCuaHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuuCuaHang.ForeColor = System.Drawing.Color.White;
            this.btnLuuCuaHang.Location = new System.Drawing.Point(340, 192);
            this.btnLuuCuaHang.Name = "btnLuuCuaHang";
            this.btnLuuCuaHang.Size = new System.Drawing.Size(100, 35);
            this.btnLuuCuaHang.TabIndex = 11;
            this.btnLuuCuaHang.Text = "Luu";
            this.btnLuuCuaHang.UseVisualStyleBackColor = false;
            this.btnLuuCuaHang.Click += new System.EventHandler(this.btnLuuCuaHang_Click);
            // 
            // tabHeThong
            // 
            this.tabHeThong.Controls.Add(this.groupHeThong);
            this.tabHeThong.Location = new System.Drawing.Point(4, 28);
            this.tabHeThong.Name = "tabHeThong";
            this.tabHeThong.Padding = new System.Windows.Forms.Padding(10);
            this.tabHeThong.Size = new System.Drawing.Size(492, 418);
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
            this.lblPhienBan.Size = new System.Drawing.Size(108, 19);
            this.lblPhienBan.TabIndex = 0;
            this.lblPhienBan.Text = "Phien ban: 1.0.0";
            // 
            // lblDotNet
            // 
            this.lblDotNet.AutoSize = true;
            this.lblDotNet.Location = new System.Drawing.Point(20, 60);
            this.lblDotNet.Name = "lblDotNet";
            this.lblDotNet.Size = new System.Drawing.Size(119, 19);
            this.lblDotNet.TabIndex = 1;
            this.lblDotNet.Text = ".NET Framework: ";
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Location = new System.Drawing.Point(20, 85);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(102, 19);
            this.lblOS.TabIndex = 2;
            this.lblOS.Text = "He dieu hanh: ";
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Location = new System.Drawing.Point(20, 110);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(72, 19);
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
            this.lblKetNoi.Size = new System.Drawing.Size(149, 19);
            this.lblKetNoi.TabIndex = 4;
            this.lblKetNoi.Text = "Trang thai: Da ket noi";
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
            this.groupBackup.ResumeLayout(false);
            this.groupBackup.PerformLayout();
            this.tabCuaHang.ResumeLayout(false);
            this.groupCuaHang.ResumeLayout(false);
            this.groupCuaHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThueSuat)).EndInit();
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
        private System.Windows.Forms.TabPage tabCuaHang;
        private System.Windows.Forms.GroupBox groupCuaHang;
        private System.Windows.Forms.Label lblTenCuaHang;
        private System.Windows.Forms.TextBox txtTenCuaHang;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblThueSuat;
        private System.Windows.Forms.NumericUpDown numThueSuat;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Button btnLuuCuaHang;
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

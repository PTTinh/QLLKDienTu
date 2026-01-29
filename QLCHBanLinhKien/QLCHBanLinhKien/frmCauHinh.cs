using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmCauHinh : Form
    {
        private string configFilePath;

        public frmCauHinh()
        {
            InitializeComponent();
            configFilePath = Path.Combine(Application.StartupPath, "config.ini");
        }

        private void frmCauHinh_Load(object sender, EventArgs e)
        {
            LoadCauHinh();
            LoadThongTinHeThong();
        }

        private void LoadCauHinh()
        {
            // Load connection string từ Settings
            string connStr = Properties.Settings.Default.QuanLyBanHangConnectionString;
            if (!string.IsNullOrEmpty(connStr))
            {
                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connStr);
                    txtServer.Text = builder.DataSource;
                    txtDatabase.Text = builder.InitialCatalog;
                    chkWindowsAuth.Checked = builder.IntegratedSecurity;
                    txtUsername.Text = builder.UserID;
                    txtPassword.Text = builder.Password;
                }
                catch
                {
                    // Default values nếu không parse được
                    txtServer.Text = "TINH\\SQLEXPRESS";
                    txtDatabase.Text = "QLCHLinhKienDienTu";
                    chkWindowsAuth.Checked = true;
                }
            }

            txtUsername.Enabled = !chkWindowsAuth.Checked;
            txtPassword.Enabled = !chkWindowsAuth.Checked;

            // Load thông tin cửa hàng từ config file
            if (File.Exists(configFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(configFilePath);
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("TenCuaHang="))
                            txtTenCuaHang.Text = line.Substring(11);
                        else if (line.StartsWith("DiaChi="))
                            txtDiaChi.Text = line.Substring(7);
                        else if (line.StartsWith("DienThoai="))
                            txtDienThoai.Text = line.Substring(10);
                        else if (line.StartsWith("Email="))
                            txtEmail.Text = line.Substring(6);
                        else if (line.StartsWith("ThueSuat="))
                            numThueSuat.Value = Convert.ToDecimal(line.Substring(9));
                    }
                }
                catch { }
            }
            else
            {
                // Default values
                txtTenCuaHang.Text = "Cửa hàng Linh kiện Điện tử";
                txtDiaChi.Text = "123 Đường ABC, Quận XYZ, TP. HCM";
                txtDienThoai.Text = "0123 456 789";
                txtEmail.Text = "contact@linhkien.com";
                numThueSuat.Value = 10;
            }
        }

        private void LoadThongTinHeThong()
        {
            try
            {
                // Hiển thị thông tin hệ thống
                lblPhienBan.Text = "Phiên bản: 1.0.0";
                lblDotNet.Text = ".NET Framework: " + Environment.Version.ToString();
                lblOS.Text = "Hệ điều hành: " + Environment.OSVersion.ToString();
                lblMachineName.Text = "Tên máy: " + Environment.MachineName;

                // Kiểm tra kết nối database
                if (Functions.conn != null && Functions.conn.State == System.Data.ConnectionState.Open)
                {
                    lblKetNoi.Text = "Trạng thái: Đã kết nối";
                    lblKetNoi.ForeColor = Color.Green;
                }
                else
                {
                    lblKetNoi.Text = "Trạng thái: Chưa kết nối";
                    lblKetNoi.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblKetNoi.Text = "Lỗi: " + ex.Message;
                lblKetNoi.ForeColor = Color.Red;
            }
        }

        private void chkWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = !chkWindowsAuth.Checked;
            txtPassword.Enabled = !chkWindowsAuth.Checked;
        }

        private void btnTestKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString;
                if (chkWindowsAuth.Checked)
                {
                    connectionString = $"Data Source={txtServer.Text};Initial Catalog={txtDatabase.Text};Integrated Security=True";
                }
                else
                {
                    connectionString = $"Data Source={txtServer.Text};Initial Catalog={txtDatabase.Text};User ID={txtUsername.Text};Password={txtPassword.Text}";
                }

                using (SqlConnection testConn = new SqlConnection(connectionString))
                {
                    testConn.Open();
                    MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    testConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo connection string mới
                string connectionString;
                if (chkWindowsAuth.Checked)
                {
                    connectionString = $"Data Source={txtServer.Text};Initial Catalog={txtDatabase.Text};Integrated Security=True";
                }
                else
                {
                    connectionString = $"Data Source={txtServer.Text};Initial Catalog={txtDatabase.Text};User ID={txtUsername.Text};Password={txtPassword.Text}";
                }

                // Test trước khi lưu
                using (SqlConnection testConn = new SqlConnection(connectionString))
                {
                    testConn.Open();
                    testConn.Close();
                }

                // Lưu connection string vào file config riêng
                string dbConfigPath = Path.Combine(Application.StartupPath, "database.config");
                string[] dbLines = new string[]
                {
                    "Server=" + txtServer.Text,
                    "Database=" + txtDatabase.Text,
                    "WindowsAuth=" + chkWindowsAuth.Checked.ToString(),
                    "Username=" + txtUsername.Text,
                    "Password=" + txtPassword.Text,
                    "ConnectionString=" + connectionString
                };
                File.WriteAllLines(dbConfigPath, dbLines);

                MessageBox.Show("Đã lưu thông tin kết nối!\nKhởi động lại ứng dụng để áp dụng thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuCuaHang_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu thông tin cửa hàng vào file config
                string[] lines = new string[]
                {
                    "TenCuaHang=" + txtTenCuaHang.Text,
                    "DiaChi=" + txtDiaChi.Text,
                    "DienThoai=" + txtDienThoai.Text,
                    "Email=" + txtEmail.Text,
                    "ThueSuat=" + numThueSuat.Value.ToString()
                };

                File.WriteAllLines(configFilePath, lines);
                MessageBox.Show("Đã lưu thông tin cửa hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "SQL Backup Files|*.bak";
                sfd.FileName = $"Backup_{txtDatabase.Text}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string query = $"BACKUP DATABASE [{txtDatabase.Text}] TO DISK = '{sfd.FileName}'";
                    Functions.RunSQL(query);
                    MessageBox.Show("Sao lưu database thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sao lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "SQL Backup Files|*.bak";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc muốn phục hồi database từ file backup?\nDữ liệu hiện tại sẽ bị ghi đè!",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Đóng tất cả kết nối đến database
                        Functions.Disconnect();

                        // Tạo kết nối mới đến master database để thực hiện restore
                        string masterConnStr;
                        if (chkWindowsAuth.Checked)
                            masterConnStr = $"Data Source={txtServer.Text};Initial Catalog=master;Integrated Security=True";
                        else
                            masterConnStr = $"Data Source={txtServer.Text};Initial Catalog=master;User ID={txtUsername.Text};Password={txtPassword.Text}";

                        using (SqlConnection masterConn = new SqlConnection(masterConnStr))
                        {
                            masterConn.Open();

                            // Đặt database vào single user mode
                            string setSingle = $"ALTER DATABASE [{txtDatabase.Text}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                            using (SqlCommand cmd = new SqlCommand(setSingle, masterConn))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            // Restore database
                            string restore = $"RESTORE DATABASE [{txtDatabase.Text}] FROM DISK = '{ofd.FileName}' WITH REPLACE";
                            using (SqlCommand cmd = new SqlCommand(restore, masterConn))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            // Đặt lại multi user mode
                            string setMulti = $"ALTER DATABASE [{txtDatabase.Text}] SET MULTI_USER";
                            using (SqlCommand cmd = new SqlCommand(setMulti, masterConn))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            masterConn.Close();
                        }

                        // Kết nối lại
                        Functions.Connect();

                        MessageBox.Show("Phục hồi database thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phục hồi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Thử kết nối lại
                try { Functions.Connect(); } catch { }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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

        public frmCauHinh()
        {
            InitializeComponent();
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


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

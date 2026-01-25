using System;
using System.Configuration;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmCauHinh : Form
    {
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void frmCauHinh_Load(object sender, EventArgs e)
        {
            // Đọc chuỗi kết nối hiện tại
            string connString = ConfigurationManager.ConnectionStrings["QuanLyBanHang.Properties.Settings.QuanLyBanHangConnectionString"].ConnectionString;
            
            // Parse connection string
            string[] parts = connString.Split(';');
            foreach (string part in parts)
            {
                string trimmedPart = part.Trim();
                if (trimmedPart.StartsWith("Data Source="))
                {
                    txtServer.Text = trimmedPart.Replace("Data Source=", "");
                }
                else if (trimmedPart.StartsWith("Initial Catalog="))
                {
                    txtDatabase.Text = trimmedPart.Replace("Initial Catalog=", "");
                }
                else if (trimmedPart.StartsWith("Integrated Security=True"))
                {
                    chkWindowsAuth.Checked = true;
                }
            }
        }

        private void chkWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = !chkWindowsAuth.Checked;
            txtPassword.Enabled = !chkWindowsAuth.Checked;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = BuildConnectionString();
                System.Data.SqlClient.SqlConnection testConn = new System.Data.SqlClient.SqlConnection(connString);
                testConn.Open();
                testConn.Close();
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildConnectionString()
        {
            string connString;
            if (chkWindowsAuth.Checked)
            {
                connString = $"Data Source={txtServer.Text};Initial Catalog={txtDatabase.Text};Integrated Security=True;Connect Timeout=30";
            }
            else
            {
                connString = $"Data Source={txtServer.Text};Initial Catalog={txtDatabase.Text};User ID={txtUsername.Text};Password={txtPassword.Text};Connect Timeout=30";
            }
            return connString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu chuỗi kết nối vào App.config
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string connString = BuildConnectionString();
                
                config.ConnectionStrings.ConnectionStrings["QuanLyBanHang.Properties.Settings.QuanLyBanHangConnectionString"].ConnectionString = connString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("Lưu cấu hình thành công! Vui lòng khởi động lại ứng dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

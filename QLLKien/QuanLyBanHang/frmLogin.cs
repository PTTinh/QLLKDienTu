using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Functions.ConnectSilent();
            txtMatKhau.PasswordChar = '*';
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            string sql = $"SELECT MaNguoiDung, HoTen, VaiTro FROM NguoiDung WHERE TenDangNhap = N'{txtTenDangNhap.Text}' AND MatKhau = N'{txtMatKhau.Text}' AND TrangThai = 1";
            DataTable dt = Functions.GetDataToTable(sql);

            if (dt.Rows.Count > 0)
            {
                Functions.currentUserId = Convert.ToInt32(dt.Rows[0]["MaNguoiDung"]);
                Functions.currentUser = dt.Rows[0]["HoTen"].ToString();
                Functions.currentUserRole = dt.Rows[0]["VaiTro"].ToString();

                MessageBox.Show($"Đăng nhập thành công!\nXin chào {Functions.currentUser}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Hide();
                frmMains frmMain = new frmMains();
                frmMain.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtTenDangNhap.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

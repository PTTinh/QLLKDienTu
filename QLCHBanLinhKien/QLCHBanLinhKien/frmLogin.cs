using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmLogin : Form
    {
        // Static property de truy cap tu cac form khac
        public static int MaNguoiDung { get; set; }

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

            // Su dung parameterized query de tranh SQL Injection
            string sql = "SELECT MaNguoiDung, HoTen, VaiTro, TrangThai FROM NguoiDung WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDangNhap", txtTenDangNhap.Text),
                new SqlParameter("@MatKhau", txtMatKhau.Text)
            };

            DataTable dt = Functions.GetDataTable(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["TrangThai"].ToString() == "False")
                {
                    MessageBox.Show("Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Functions.currentUserId = Convert.ToInt32(dt.Rows[0]["MaNguoiDung"]);
                Functions.currentUser = dt.Rows[0]["HoTen"].ToString();
                Functions.currentUserRole = dt.Rows[0]["VaiTro"].ToString();
                MaNguoiDung = Functions.currentUserId;

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

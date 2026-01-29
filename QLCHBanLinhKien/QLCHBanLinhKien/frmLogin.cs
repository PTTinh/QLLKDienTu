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
                MessageBox.Show("Vui long nhap ten dang nhap!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui long nhap mat khau!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // Su dung parameterized query de tranh SQL Injection
            string sql = "SELECT MaNguoiDung, HoTen, VaiTro FROM NguoiDung WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau AND TrangThai = 1";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDangNhap", txtTenDangNhap.Text),
                new SqlParameter("@MatKhau", txtMatKhau.Text)
            };

            DataTable dt = Functions.GetDataTable(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                Functions.currentUserId = Convert.ToInt32(dt.Rows[0]["MaNguoiDung"]);
                Functions.currentUser = dt.Rows[0]["HoTen"].ToString();
                Functions.currentUserRole = dt.Rows[0]["VaiTro"].ToString();
                MaNguoiDung = Functions.currentUserId; // Set static property

                MessageBox.Show($"Dang nhap thanh cong!\nXin chao {Functions.currentUser}", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Hide();
                frmMains frmMain = new frmMains();
                frmMain.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ten dang nhap hoac mat khau khong dung!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

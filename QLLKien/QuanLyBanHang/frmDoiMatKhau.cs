using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauMoi.PasswordChar = '*';
            txtXacNhanMatKhau.PasswordChar = '*';
            
            // Hiển thị thông tin người dùng hiện tại
            lblTenNguoiDung.Text = Functions.currentUser;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatKhauCu.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauCu.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            // Kiểm tra mật khẩu cũ
            string sql = $"SELECT COUNT(*) FROM NguoiDung WHERE MaNguoiDung = {Functions.currentUserId} AND MatKhau = N'{txtMatKhauCu.Text}'";
            DataTable dt = Functions.GetDataToTable(sql);
            
            if (Convert.ToInt32(dt.Rows[0][0]) == 0)
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauCu.Clear();
                txtMatKhauCu.Focus();
                return;
            }

            // Cập nhật mật khẩu mới
            sql = $"UPDATE NguoiDung SET MatKhau = N'{txtMatKhauMoi.Text}' WHERE MaNguoiDung = {Functions.currentUserId}";
            Functions.RunSQL(sql);
            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

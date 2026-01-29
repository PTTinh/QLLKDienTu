using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmDoiMatKhau : Form
    {
        private int maNguoiDung;
        private string tenDangNhap;

        public frmDoiMatKhau(int maNguoiDung, string tenDangNhap)
        {
            InitializeComponent();
            this.maNguoiDung = maNguoiDung;
            this.tenDangNhap = tenDangNhap;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            lblTenDangNhap.Text = tenDangNhap;
            txtMatKhauCu.Focus();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                // Kiểm tra mật khẩu cũ
                string query = "SELECT MatKhau FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNguoiDung", maNguoiDung)
                };

                DataTable dt = Functions.GetDataTable(query, parameters);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string matKhauHienTai = dt.Rows[0]["MatKhau"].ToString();
                if (matKhauHienTai != txtMatKhauCu.Text.Trim())
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhauCu.Focus();
                    txtMatKhauCu.SelectAll();
                    return;
                }

                // Cập nhật mật khẩu mới
                string updateQuery = "UPDATE NguoiDung SET MatKhau = @MatKhauMoi WHERE MaNguoiDung = @MaNguoiDung";
                SqlParameter[] updateParams = new SqlParameter[]
                {
                    new SqlParameter("@MatKhauMoi", txtMatKhauMoi.Text.Trim()),
                    new SqlParameter("@MaNguoiDung", maNguoiDung)
                };

                bool result = Functions.RunSQL(updateQuery, updateParams);
                if (result)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauCu.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return false;
            }

            if (txtMatKhauMoi.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return false;
            }

            if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return false;
            }

            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauCu.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtMatKhauMoi.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtXacNhanMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
    }
}

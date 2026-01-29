using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmThongTinCaNhan : Form
    {
        private int maNguoiDung;

        public frmThongTinCaNhan(int maNguoiDung)
        {
            InitializeComponent();
            this.maNguoiDung = maNguoiDung;
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        private void LoadThongTin()
        {
            try
            {
                string query = @"SELECT TenDangNhap, HoTen, Email, SoDienThoai, VaiTro, TrangThai 
                                 FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNguoiDung", maNguoiDung)
                };

                DataTable dt = Functions.GetDataTable(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtTenDangNhap.Text = row["TenDangNhap"].ToString();
                    txtHoTen.Text = row["HoTen"].ToString();
                    txtEmail.Text = row["Email"].ToString();
                    txtSoDienThoai.Text = row["SoDienThoai"].ToString();
                    lblVaiTro.Text = row["VaiTro"].ToString();
                    lblTrangThai.Text = Convert.ToBoolean(row["TrangThai"]) ? "Đang hoạt động" : "Ngưng hoạt động";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string query = @"UPDATE NguoiDung 
                                 SET HoTen = @HoTen, Email = @Email, SoDienThoai = @SoDienThoai 
                                 WHERE MaNguoiDung = @MaNguoiDung";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@SoDienThoai", txtSoDienThoai.Text.Trim()),
                    new SqlParameter("@MaNguoiDung", maNguoiDung)
                };

                bool result = Functions.RunSQL(query, parameters);
                if (result)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(maNguoiDung, txtTenDangNhap.Text);
            frm.ShowDialog();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

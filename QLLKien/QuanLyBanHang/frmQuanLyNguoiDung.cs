using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmQuanLyNguoiDung : Form
    {
        DataTable tblNguoiDung;

        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetValues();
        }

        private void LoadData()
        {
            string sql = "SELECT MaNguoiDung, TenDangNhap, HoTen, Email, SoDienThoai, VaiTro, " +
                        "CASE WHEN TrangThai = 1 THEN N'Hoạt động' ELSE N'Khóa' END AS TrangThaiText, NgayTao " +
                        "FROM NguoiDung ORDER BY MaNguoiDung DESC";
            tblNguoiDung = Functions.GetDataToTable(sql);
            dgvNguoiDung.DataSource = tblNguoiDung;

            dgvNguoiDung.Columns[0].HeaderText = "Mã";
            dgvNguoiDung.Columns[1].HeaderText = "Tên đăng nhập";
            dgvNguoiDung.Columns[2].HeaderText = "Họ tên";
            dgvNguoiDung.Columns[3].HeaderText = "Email";
            dgvNguoiDung.Columns[4].HeaderText = "Số điện thoại";
            dgvNguoiDung.Columns[5].HeaderText = "Vai trò";
            dgvNguoiDung.Columns[6].HeaderText = "Trạng thái";
            dgvNguoiDung.Columns[7].HeaderText = "Ngày tạo";

            dgvNguoiDung.Columns[0].Width = 50;
            dgvNguoiDung.Columns[1].Width = 120;
            dgvNguoiDung.Columns[2].Width = 150;
            dgvNguoiDung.AllowUserToAddRows = false;
            dgvNguoiDung.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaNguoiDung.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSoDienThoai.Text = "";
            cboVaiTro.SelectedIndex = -1;
            chkTrangThai.Checked = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenDangNhap.Enabled = true;
            txtTenDangNhap.Focus();
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tblNguoiDung.Rows.Count > 0)
            {
                txtMaNguoiDung.Text = dgvNguoiDung.CurrentRow.Cells["MaNguoiDung"].Value.ToString();
                txtTenDangNhap.Text = dgvNguoiDung.CurrentRow.Cells["TenDangNhap"].Value.ToString();
                txtHoTen.Text = dgvNguoiDung.CurrentRow.Cells["HoTen"].Value.ToString();
                txtEmail.Text = dgvNguoiDung.CurrentRow.Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = dgvNguoiDung.CurrentRow.Cells["SoDienThoai"].Value.ToString();
                cboVaiTro.Text = dgvNguoiDung.CurrentRow.Cells["VaiTro"].Value.ToString();
                
                string trangThai = dgvNguoiDung.CurrentRow.Cells["TrangThaiText"].Value.ToString();
                chkTrangThai.Checked = trangThai == "Hoạt động";

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtTenDangNhap.Enabled = false;
                txtMatKhau.Text = "********";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
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

            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // Kiểm tra trùng tên đăng nhập
            string sql = $"SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = N'{txtTenDangNhap.Text}'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            sql = $"INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro, TrangThai) " +
                  $"VALUES (N'{txtTenDangNhap.Text}', N'{txtMatKhau.Text}', N'{txtHoTen.Text}', " +
                  $"N'{txtEmail.Text}', N'{txtSoDienThoai.Text}', N'{cboVaiTro.Text}', {(chkTrangThai.Checked ? 1 : 0)})";
            
            Functions.RunSQL(sql);
            LoadData();
            ResetValues();
            MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNguoiDung.Text))
            {
                MessageBox.Show("Vui lòng chọn người dùng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql;
            if (txtMatKhau.Text == "********")
            {
                // Không đổi mật khẩu
                sql = $"UPDATE NguoiDung SET HoTen = N'{txtHoTen.Text}', Email = N'{txtEmail.Text}', " +
                      $"SoDienThoai = N'{txtSoDienThoai.Text}', VaiTro = N'{cboVaiTro.Text}', " +
                      $"TrangThai = {(chkTrangThai.Checked ? 1 : 0)} WHERE MaNguoiDung = {txtMaNguoiDung.Text}";
            }
            else
            {
                // Đổi cả mật khẩu
                sql = $"UPDATE NguoiDung SET MatKhau = N'{txtMatKhau.Text}', HoTen = N'{txtHoTen.Text}', " +
                      $"Email = N'{txtEmail.Text}', SoDienThoai = N'{txtSoDienThoai.Text}', " +
                      $"VaiTro = N'{cboVaiTro.Text}', TrangThai = {(chkTrangThai.Checked ? 1 : 0)} " +
                      $"WHERE MaNguoiDung = {txtMaNguoiDung.Text}";
            }

            Functions.RunSQL(sql);
            LoadData();
            ResetValues();
            MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNguoiDung.Text))
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.Parse(txtMaNguoiDung.Text) == Functions.currentUserId)
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"DELETE FROM NguoiDung WHERE MaNguoiDung = {txtMaNguoiDung.Text}";
                Functions.RunSQL(sql);
                LoadData();
                ResetValues();
                MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadData();
        }
    }
}

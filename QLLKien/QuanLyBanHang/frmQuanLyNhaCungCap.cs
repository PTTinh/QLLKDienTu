using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmQuanLyNhaCungCap : Form
    {
        DataTable tblNCC;

        public frmQuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetValues();
        }

        private void LoadData()
        {
            string sql = "SELECT MaNCC, TenNCC, SoDienThoai, Email, DiaChi, MaSoThue FROM NhaCungCap ORDER BY MaNCC DESC";
            tblNCC = Functions.GetDataToTable(sql);
            dgvNhaCungCap.DataSource = tblNCC;

            dgvNhaCungCap.Columns[0].HeaderText = "Mã NCC";
            dgvNhaCungCap.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvNhaCungCap.Columns[2].HeaderText = "Số điện thoại";
            dgvNhaCungCap.Columns[3].HeaderText = "Email";
            dgvNhaCungCap.Columns[4].HeaderText = "Địa chỉ";
            dgvNhaCungCap.Columns[5].HeaderText = "Mã số thuế";

            dgvNhaCungCap.Columns[0].Width = 60;
            dgvNhaCungCap.Columns[1].Width = 200;
            dgvNhaCungCap.AllowUserToAddRows = false;
            dgvNhaCungCap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtMaSoThue.Clear();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenNCC.Focus();
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tblNCC.Rows.Count > 0)
            {
                txtMaNCC.Text = dgvNhaCungCap.CurrentRow.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = dgvNhaCungCap.CurrentRow.Cells["TenNCC"].Value.ToString();
                txtSoDienThoai.Text = dgvNhaCungCap.CurrentRow.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = dgvNhaCungCap.CurrentRow.Cells["Email"].Value.ToString();
                txtDiaChi.Text = dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtMaSoThue.Text = dgvNhaCungCap.CurrentRow.Cells["MaSoThue"].Value.ToString();

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }

            string sql = $@"INSERT INTO NhaCungCap (TenNCC, SoDienThoai, Email, DiaChi, MaSoThue) 
                           VALUES (N'{txtTenNCC.Text}', N'{txtSoDienThoai.Text}', N'{txtEmail.Text}', 
                           N'{txtDiaChi.Text}', N'{txtMaSoThue.Text}')";
            Functions.RunSQL(sql);
            LoadData();
            ResetValues();
            MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $@"UPDATE NhaCungCap SET TenNCC = N'{txtTenNCC.Text}', SoDienThoai = N'{txtSoDienThoai.Text}', 
                           Email = N'{txtEmail.Text}', DiaChi = N'{txtDiaChi.Text}', MaSoThue = N'{txtMaSoThue.Text}' 
                           WHERE MaNCC = {txtMaNCC.Text}";
            Functions.RunSQL(sql);
            LoadData();
            ResetValues();
            MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra có sản phẩm nào đang dùng NCC này không
            string checkSql = $"SELECT COUNT(*) FROM SanPham WHERE MaNCC = {txtMaNCC.Text}";
            if (Functions.CheckKey(checkSql))
            {
                MessageBox.Show("Không thể xóa nhà cung cấp đang có sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"DELETE FROM NhaCungCap WHERE MaNCC = {txtMaNCC.Text}";
                Functions.RunSQL(sql);
                LoadData();
                ResetValues();
                MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadData();
        }
    }
}

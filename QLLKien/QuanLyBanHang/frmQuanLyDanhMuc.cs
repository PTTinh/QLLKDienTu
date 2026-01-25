using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmQuanLyDanhMuc : Form
    {
        DataTable tblDanhMuc;

        public frmQuanLyDanhMuc()
        {
            InitializeComponent();
        }

        private void frmQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetValues();
        }

        private void LoadData()
        {
            string sql = "SELECT MaDanhMuc, TenDanhMuc, MoTa, NgayTao FROM DanhMuc ORDER BY MaDanhMuc DESC";
            tblDanhMuc = Functions.GetDataToTable(sql);
            dgvDanhMuc.DataSource = tblDanhMuc;

            dgvDanhMuc.Columns[0].HeaderText = "Mã";
            dgvDanhMuc.Columns[1].HeaderText = "Tên danh mục";
            dgvDanhMuc.Columns[2].HeaderText = "Mô tả";
            dgvDanhMuc.Columns[3].HeaderText = "Ngày tạo";

            dgvDanhMuc.Columns[0].Width = 60;
            dgvDanhMuc.Columns[1].Width = 200;
            dgvDanhMuc.Columns[2].Width = 300;
            dgvDanhMuc.AllowUserToAddRows = false;
            dgvDanhMuc.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();
            txtMoTa.Clear();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenDanhMuc.Focus();
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tblDanhMuc.Rows.Count > 0)
            {
                txtMaDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["MaDanhMuc"].Value.ToString();
                txtTenDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["TenDanhMuc"].Value.ToString();
                txtMoTa.Text = dgvDanhMuc.CurrentRow.Cells["MoTa"].Value.ToString();

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDanhMuc.Focus();
                return;
            }

            string sql = $"INSERT INTO DanhMuc (TenDanhMuc, MoTa) VALUES (N'{txtTenDanhMuc.Text}', N'{txtMoTa.Text}')";
            Functions.RunSQL(sql);
            LoadData();
            ResetValues();
            MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $"UPDATE DanhMuc SET TenDanhMuc = N'{txtTenDanhMuc.Text}', MoTa = N'{txtMoTa.Text}' WHERE MaDanhMuc = {txtMaDanhMuc.Text}";
            Functions.RunSQL(sql);
            LoadData();
            ResetValues();
            MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra có sản phẩm nào đang dùng danh mục này không
            string checkSql = $"SELECT COUNT(*) FROM SanPham WHERE MaDanhMuc = {txtMaDanhMuc.Text}";
            if (Functions.CheckKey(checkSql))
            {
                MessageBox.Show("Không thể xóa danh mục đang có sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"DELETE FROM DanhMuc WHERE MaDanhMuc = {txtMaDanhMuc.Text}";
                Functions.RunSQL(sql);
                LoadData();
                ResetValues();
                MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadData();
        }
    }
}

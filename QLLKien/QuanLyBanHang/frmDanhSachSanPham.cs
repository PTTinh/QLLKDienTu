using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmDanhSachSanPham : Form
    {
        DataTable tblSanPham;

        public frmDanhSachSanPham()
        {
            InitializeComponent();
        }

        private void frmDanhSachSanPham_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadData();
        }

        private void LoadDanhMuc()
        {
            string sql = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc";
            Functions.FillCombo(sql, cboDanhMuc, "MaDanhMuc", "TenDanhMuc");
            cboDanhMuc.SelectedIndex = -1;
        }

        private void LoadData(string where = "")
        {
            string sql = @"SELECT sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, 
                          dm.TenDanhMuc, ncc.TenNCC, sp.GiaBan, sp.GiaNhap, 
                          sp.SoLuongTon, 
                          CASE WHEN sp.TrangThai = 1 THEN N'Đang kinh doanh' ELSE N'Ngừng kinh doanh' END AS TrangThaiText
                          FROM SanPham sp
                          LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                          LEFT JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC ";

            if (!string.IsNullOrEmpty(where))
                sql += " WHERE " + where;

            sql += " ORDER BY sp.MaSanPham DESC";

            tblSanPham = Functions.GetDataToTable(sql);
            dgvSanPham.DataSource = tblSanPham;

            dgvSanPham.Columns[0].HeaderText = "Mã SP";
            dgvSanPham.Columns[1].HeaderText = "Mã số SP";
            dgvSanPham.Columns[2].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns[3].HeaderText = "Danh mục";
            dgvSanPham.Columns[4].HeaderText = "Nhà cung cấp";
            dgvSanPham.Columns[5].HeaderText = "Giá bán";
            dgvSanPham.Columns[6].HeaderText = "Giá nhập";
            dgvSanPham.Columns[7].HeaderText = "Tồn kho";
            dgvSanPham.Columns[8].HeaderText = "Trạng thái";

            dgvSanPham.Columns[0].Width = 60;
            dgvSanPham.Columns[1].Width = 100;
            dgvSanPham.Columns[2].Width = 200;
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;

            lblTongSP.Text = $"Tổng số sản phẩm: {tblSanPham.Rows.Count}";
            btnXoa.Enabled = tblSanPham.Rows.Count > 0;
        }

        private int? GetSelectedSanPhamId()
        {
            if (dgvSanPham.CurrentRow == null)
                return null;

            object value = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value;
            if (value == null || value == DBNull.Value)
                return null;

            return Convert.ToInt32(value);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string where = "1=1";

            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {
                where += $" AND (sp.TenSanPham LIKE N'%{txtTimKiem.Text}%' OR sp.MaSoSanPham LIKE '%{txtTimKiem.Text}%')";
            }

            if (cboDanhMuc.SelectedIndex >= 0)
            {
                where += $" AND sp.MaDanhMuc = {cboDanhMuc.SelectedValue}";
            }

            if (chkConHang.Checked)
            {
                where += " AND sp.SoLuongTon > 0";
            }

            LoadData(where);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboDanhMuc.SelectedIndex = -1;
            chkConHang.Checked = false;
            LoadData();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            frmCapNhatSanPham frm = new frmCapNhatSanPham();
            frm.ShowDialog();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int? maSP = GetSelectedSanPhamId();
            if (!maSP.HasValue)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenSP = dgvSanPham.CurrentRow?.Cells["TenSanPham"].Value?.ToString();
            string checkSql = $"SELECT TOP 1 1 FROM ChiTietHoaDon WHERE MaSanPham = {maSP.Value}";

            if (Functions.CheckKey(checkSql))
            {
                MessageBox.Show("Không thể xóa sản phẩm đã phát sinh hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm \"{tenSP}\"?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"DELETE FROM SanPham WHERE MaSanPham = {maSP.Value}";
                if (Functions.RunSQL(sql))
                {
                    LoadData();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maSP = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value);
                frmCapNhatSanPham frm = new frmCapNhatSanPham(maSP);
                frm.ShowDialog();
                LoadData();
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = e.RowIndex >= 0 && dgvSanPham.CurrentRow != null;
        }
    }
}

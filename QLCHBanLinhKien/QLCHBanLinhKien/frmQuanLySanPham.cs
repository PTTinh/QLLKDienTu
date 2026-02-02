using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmQuanLySanPham : Form
    {
        private int selectedId = 0;

        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadNhaCungCap();
            LoadData();
            ResetForm();
        }

        private void LoadDanhMuc()
        {
            string sql = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc";
            DataTable dt = Functions.GetDataToTable(sql);
            
            DataRow newRow = dt.NewRow();
            newRow["MaDanhMuc"] = 0;
            newRow["TenDanhMuc"] = "-- Chon danh muc --";
            dt.Rows.InsertAt(newRow, 0);
            
            cboDanhMuc.DataSource = dt;
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void LoadNhaCungCap()
        {
            string sql = "SELECT MaNCC, TenNCC FROM NhaCungCap ORDER BY TenNCC";
            DataTable dt = Functions.GetDataToTable(sql);
            
            DataRow newRow = dt.NewRow();
            newRow["MaNCC"] = 0;
            newRow["TenNCC"] = "-- Chon NCC --";
            dt.Rows.InsertAt(newRow, 0);
            
            cboNhaCungCap.DataSource = dt;
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
        }

        private void LoadData()
        {
            string sql = @"SELECT sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, 
                          dm.TenDanhMuc, ncc.TenNCC, sp.GiaBan, sp.GiaNhap, 
                          sp.SoLuongTon, sp.TrangThai
                          FROM SanPham sp
                          LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                          LEFT JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC
                          ORDER BY sp.TenSanPham";
            
            DataTable dt = Functions.GetDataToTable(sql);
            dgvSanPham.DataSource = dt;
            
            // Dinh dang cot
            if (dgvSanPham.Columns.Count > 0)
            {
                dgvSanPham.Columns["MaSanPham"].Visible = false;
                dgvSanPham.Columns["MaSoSanPham"].HeaderText = "Ma SP";
                dgvSanPham.Columns["TenSanPham"].HeaderText = "Ten san pham";
                dgvSanPham.Columns["TenDanhMuc"].HeaderText = "Danh muc";
                dgvSanPham.Columns["TenNCC"].HeaderText = "Nha cung cap";
                dgvSanPham.Columns["GiaBan"].HeaderText = "Gia ban";
                dgvSanPham.Columns["GiaNhap"].HeaderText = "Gia nhap";
                dgvSanPham.Columns["SoLuongTon"].HeaderText = "Ton kho";
                dgvSanPham.Columns["TrangThai"].HeaderText = "Trang thai";
                
                dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                dgvSanPham.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
            }
            
            lblTongSP.Text = "Tong: " + dt.Rows.Count + " san pham";
        }

        private void ResetForm()
        {
            selectedId = 0;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaBan.Text = "0";
            txtGiaNhap.Text = "0";
            txtSoLuong.Text = "0";
            txtMoTa.Text = "";
            cboDanhMuc.SelectedIndex = 0;
            cboNhaCungCap.SelectedIndex = 0;
            chkTrangThai.Checked = true;
            
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaSP.Enabled = true;
            txtMaSP.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui long nhap ma san pham!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui long nhap ten san pham!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return false;
            }
            
            if (!decimal.TryParse(txtGiaBan.Text, out decimal giaBan) || giaBan < 0)
            {
                MessageBox.Show("Gia ban khong hop le!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                return false;
            }
            
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            
            // Kiem tra ma SP trung
            string checkSql = "SELECT COUNT(*) FROM SanPham WHERE MaSoSanPham = @MaSP";
            SqlParameter[] checkParams = { new SqlParameter("@MaSP", txtMaSP.Text.Trim()) };
            object result = Functions.GetFieldValues(checkSql, checkParams);
            if (result != null && Convert.ToInt32(result) > 0)
            {
                MessageBox.Show("Ma san pham da ton tai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
                return;
            }
            
            string sql = @"INSERT INTO SanPham (MaSoSanPham, TenSanPham, MaDanhMuc, MaNCC, 
                          GiaBan, GiaNhap, SoLuongTon, MoTa, TrangThai)
                          VALUES (@MaSP, @TenSP, @MaDM, @MaNCC, @GiaBan, @GiaNhap, @SoLuong, @MoTa, @TrangThai)";
            
            SqlParameter[] parameters = {
                new SqlParameter("@MaSP", txtMaSP.Text.Trim()),
                new SqlParameter("@TenSP", txtTenSP.Text.Trim()),
                new SqlParameter("@MaDM", cboDanhMuc.SelectedValue.ToString() == "0" ? DBNull.Value : (object)cboDanhMuc.SelectedValue),
                new SqlParameter("@MaNCC", cboNhaCungCap.SelectedValue.ToString() == "0" ? DBNull.Value : (object)cboNhaCungCap.SelectedValue),
                new SqlParameter("@GiaBan", decimal.Parse(txtGiaBan.Text)),
                new SqlParameter("@GiaNhap", decimal.Parse(txtGiaNhap.Text)),
                new SqlParameter("@SoLuong", int.Parse(txtSoLuong.Text)),
                new SqlParameter("@MoTa", txtMoTa.Text.Trim()),
                new SqlParameter("@TrangThai", chkTrangThai.Checked ? 1 : 0)
            };
            
            if (Functions.RunSQL(sql, parameters))
            {
                MessageBox.Show("Them san pham thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui long chon san pham can sua!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (!ValidateInput()) return;
            
            string sql = @"UPDATE SanPham SET TenSanPham = @TenSP, MaDanhMuc = @MaDM, MaNCC = @MaNCC,
                          GiaBan = @GiaBan, GiaNhap = @GiaNhap, SoLuongTon = @SoLuong, 
                          MoTa = @MoTa, TrangThai = @TrangThai
                          WHERE MaSanPham = @MaSanPham";
            
            SqlParameter[] parameters = {
                new SqlParameter("@MaSanPham", selectedId),
                new SqlParameter("@TenSP", txtTenSP.Text.Trim()),
                new SqlParameter("@MaDM", cboDanhMuc.SelectedValue.ToString() == "0" ? DBNull.Value : (object)cboDanhMuc.SelectedValue),
                new SqlParameter("@MaNCC", cboNhaCungCap.SelectedValue.ToString() == "0" ? DBNull.Value : (object)cboNhaCungCap.SelectedValue),
                new SqlParameter("@GiaBan", decimal.Parse(txtGiaBan.Text)),
                new SqlParameter("@GiaNhap", decimal.Parse(txtGiaNhap.Text)),
                new SqlParameter("@SoLuong", int.Parse(txtSoLuong.Text)),
                new SqlParameter("@MoTa", txtMoTa.Text.Trim()),
                new SqlParameter("@TrangThai", chkTrangThai.Checked ? 1 : 0)
            };
            
            if (Functions.RunSQL(sql, parameters))
            {
                MessageBox.Show("Cap nhat san pham thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui long chon san pham can xoa!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Functions.currentUserRole != "Quản trị")
            {
                MessageBox.Show("Ban khong co quyen xoa danh muc!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Ban co chac chan muon xoa san pham nay?", "Xac nhan",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM SanPham WHERE MaSanPham = @MaSanPham";
                SqlParameter[] parameters = { new SqlParameter("@MaSanPham", selectedId) };
                
                if (Functions.RunSQL(sql, parameters))
                {
                    MessageBox.Show("Xoa san pham thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ResetForm();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["MaSanPham"].Value);
                
                txtMaSP.Text = row.Cells["MaSoSanPham"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSanPham"].Value.ToString();
                txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                txtGiaNhap.Text = row.Cells["GiaNhap"].Value?.ToString() ?? "0";
                txtSoLuong.Text = row.Cells["SoLuongTon"].Value.ToString();
                chkTrangThai.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                
                // Load chi tiet tu database
                string sql = "SELECT MaDanhMuc, MaNCC, MoTa FROM SanPham WHERE MaSanPham = @Id";
                SqlParameter[] parameters = { new SqlParameter("@Id", selectedId) };
                DataTable dt = Functions.GetDataTable(sql, parameters);
                if (dt.Rows.Count > 0)
                {
                    cboDanhMuc.SelectedValue = dt.Rows[0]["MaDanhMuc"] != DBNull.Value ? dt.Rows[0]["MaDanhMuc"] : 0;
                    cboNhaCungCap.SelectedValue = dt.Rows[0]["MaNCC"] != DBNull.Value ? dt.Rows[0]["MaNCC"] : 0;
                    txtMoTa.Text = dt.Rows[0]["MoTa"]?.ToString() ?? "";
                }
                
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaSP.Enabled = false;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }
            
            string sql = @"SELECT sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, 
                          dm.TenDanhMuc, ncc.TenNCC, sp.GiaBan, sp.GiaNhap, 
                          sp.SoLuongTon, sp.TrangThai
                          FROM SanPham sp
                          LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                          LEFT JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC
                          WHERE sp.MaSoSanPham LIKE @Keyword OR sp.TenSanPham LIKE @Keyword
                          ORDER BY sp.TenSanPham";
            
            SqlParameter[] parameters = { new SqlParameter("@Keyword", "%" + keyword + "%") };
            DataTable dt = Functions.GetDataTable(sql, parameters);
            dgvSanPham.DataSource = dt;
            lblTongSP.Text = "Tim thay: " + dt.Rows.Count + " san pham";
        }
    }
}

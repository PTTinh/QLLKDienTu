using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmQuanLyNhaCungCap : Form
    {
        private int selectedId = 0;

        public frmQuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetForm();
        }

        private void LoadData()
        {
            string sql = @"SELECT MaNCC, TenNCC, SoDienThoai, Email, DiaChi, MaSoThue 
                          FROM NhaCungCap ORDER BY TenNCC";
            
            DataTable dt = Functions.GetDataToTable(sql);
            dgvNhaCungCap.DataSource = dt;
            
            if (dgvNhaCungCap.Columns.Count > 0)
            {
                dgvNhaCungCap.Columns["MaNCC"].HeaderText = "Ma NCC";
                dgvNhaCungCap.Columns["TenNCC"].HeaderText = "Ten nha cung cap";
                dgvNhaCungCap.Columns["SoDienThoai"].HeaderText = "So dien thoai";
                dgvNhaCungCap.Columns["Email"].HeaderText = "Email";
                dgvNhaCungCap.Columns["DiaChi"].HeaderText = "Dia chi";
                dgvNhaCungCap.Columns["MaSoThue"].HeaderText = "Ma so thue";
            }
            
            lblTong.Text = "Tong: " + dt.Rows.Count + " nha cung cap";
        }

        private void ResetForm()
        {
            selectedId = 0;
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNCC.Enabled = true;
            txtMaNCC.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui long nhap ten nha cung cap!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            
            string sql = @"INSERT INTO NhaCungCap (TenNCC, SoDienThoai, Email, DiaChi)
                          VALUES (@TenNCC, @SDT, @Email, @DiaChi)";
            
            SqlParameter[] parameters = {
                new SqlParameter("@TenNCC", txtTenNCC.Text.Trim()),
                new SqlParameter("@SDT", txtSDT.Text.Trim()),
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@DiaChi", txtDiaChi.Text.Trim())
            };
            
            if (Functions.RunSQL(sql, parameters))
            {
                MessageBox.Show("Them nha cung cap thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui long chon nha cung cap can sua!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (!ValidateInput()) return;
            
            string sql = @"UPDATE NhaCungCap SET TenNCC = @TenNCC, 
                          SoDienThoai = @SDT, Email = @Email, DiaChi = @DiaChi
                          WHERE MaNCC = @MaNCC";
            
            SqlParameter[] parameters = {
                new SqlParameter("@MaNCC", selectedId),
                new SqlParameter("@TenNCC", txtTenNCC.Text.Trim()),
                new SqlParameter("@SDT", txtSDT.Text.Trim()),
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@DiaChi", txtDiaChi.Text.Trim())
            };
            
            if (Functions.RunSQL(sql, parameters))
            {
                MessageBox.Show("Cap nhat nha cung cap thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui long chon nha cung cap can xoa!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Functions.currentUserRole != "Quản trị")
            {
                MessageBox.Show("Ban khong co quyen xoa danh muc!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra co san pham nao thuoc NCC khong
            string checkSql = "SELECT COUNT(*) FROM SanPham WHERE MaNCC = @MaNCC";
            SqlParameter[] checkParams = { new SqlParameter("@MaNCC", selectedId) };
            object result = Functions.GetFieldValues(checkSql, checkParams);
            if (result != null && Convert.ToInt32(result) > 0)
            {
                MessageBox.Show("Khong the xoa nha cung cap nay vi dang co san pham su dung!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (MessageBox.Show("Ban co chac chan muon xoa nha cung cap nay?", "Xac nhan",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                SqlParameter[] parameters = { new SqlParameter("@MaNCC", selectedId) };
                
                if (Functions.RunSQL(sql, parameters))
                {
                    MessageBox.Show("Xoa nha cung cap thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["MaNCC"].Value);
                
                txtMaNCC.Text = selectedId.ToString();
                txtTenNCC.Text = row.Cells["TenNCC"].Value?.ToString() ?? "";
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
                
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaNCC.Enabled = false;
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
            
            string sql = @"SELECT MaNCC, TenNCC, SoDienThoai, Email, DiaChi, MaSoThue 
                          FROM NhaCungCap 
                          WHERE TenNCC LIKE @Keyword OR SoDienThoai LIKE @Keyword OR Email LIKE @Keyword
                          ORDER BY TenNCC";
            
            SqlParameter[] parameters = { new SqlParameter("@Keyword", "%" + keyword + "%") };
            DataTable dt = Functions.GetDataTable(sql, parameters);
            dgvNhaCungCap.DataSource = dt;
            lblTong.Text = "Tim thay: " + dt.Rows.Count + " nha cung cap";
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmQuanLyDanhMuc : Form
    {
        private int selectedId = 0;

        public frmQuanLyDanhMuc()
        {
            InitializeComponent();
        }

        private void frmQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetForm();
        }

        private void LoadData()
        {
            string sql = @"SELECT MaDanhMuc, TenDanhMuc, MoTa 
                          FROM DanhMuc ORDER BY TenDanhMuc";
            
            DataTable dt = Functions.GetDataToTable(sql);
            dgvDanhMuc.DataSource = dt;
            
            if (dgvDanhMuc.Columns.Count > 0)
            {
                dgvDanhMuc.Columns["MaDanhMuc"].HeaderText = "Ma DM";
                dgvDanhMuc.Columns["TenDanhMuc"].HeaderText = "Ten danh muc";
                dgvDanhMuc.Columns["MoTa"].HeaderText = "Mo ta";
            }
            
            lblTong.Text = "Tong: " + dt.Rows.Count + " danh muc";
        }

        private void ResetForm()
        {
            selectedId = 0;
            txtMaDM.Text = "";
            txtTenDM.Text = "";
            txtMoTa.Text = "";
            
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaDM.Enabled = true;
            txtMaDM.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenDM.Text))
            {
                MessageBox.Show("Vui long nhap ten danh muc!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDM.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            
            string sql = @"INSERT INTO DanhMuc (TenDanhMuc, MoTa)
                          VALUES (@TenDM, @MoTa)";
            
            SqlParameter[] parameters = {
                new SqlParameter("@TenDM", txtTenDM.Text.Trim()),
                new SqlParameter("@MoTa", txtMoTa.Text.Trim())
            };
            
            if (Functions.RunSQL(sql, parameters))
            {
                MessageBox.Show("Them danh muc thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui long chon danh muc can sua!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (!ValidateInput()) return;
            
            string sql = @"UPDATE DanhMuc SET TenDanhMuc = @TenDM, MoTa = @MoTa
                          WHERE MaDanhMuc = @MaDM";
            
            SqlParameter[] parameters = {
                new SqlParameter("@MaDM", selectedId),
                new SqlParameter("@TenDM", txtTenDM.Text.Trim()),
                new SqlParameter("@MoTa", txtMoTa.Text.Trim())
            };
            
            if (Functions.RunSQL(sql, parameters))
            {
                MessageBox.Show("Cap nhat danh muc thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui long chon danh muc can xoa!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(Functions.currentUserRole != "Quản trị")
            {
                MessageBox.Show("Ban khong co quyen xoa danh muc!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra co san pham nao thuoc danh muc khong
            string checkSql = "SELECT COUNT(*) FROM SanPham WHERE MaDanhMuc = @MaDM";
            SqlParameter[] checkParams = { new SqlParameter("@MaDM", selectedId) };
            object result = Functions.GetFieldValues(checkSql, checkParams);
            if (result != null && Convert.ToInt32(result) > 0)
            {
                MessageBox.Show("Khong the xoa danh muc nay vi dang co san pham su dung!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (MessageBox.Show("Ban co chac chan muon xoa danh muc nay?", "Xac nhan",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM DanhMuc WHERE MaDanhMuc = @MaDM";
                SqlParameter[] parameters = { new SqlParameter("@MaDM", selectedId) };
                
                if (Functions.RunSQL(sql, parameters))
                {
                    MessageBox.Show("Xoa danh muc thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["MaDanhMuc"].Value);
                
                txtMaDM.Text = selectedId.ToString();
                txtTenDM.Text = row.Cells["TenDanhMuc"].Value?.ToString() ?? "";
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
                
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaDM.Enabled = false;
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
            
            string sql = @"SELECT MaDanhMuc, TenDanhMuc, MoTa 
                          FROM DanhMuc 
                          WHERE TenDanhMuc LIKE @Keyword OR MoTa LIKE @Keyword
                          ORDER BY TenDanhMuc";
            
            SqlParameter[] parameters = { new SqlParameter("@Keyword", "%" + keyword + "%") };
            DataTable dt = Functions.GetDataTable(sql, parameters);
            dgvDanhMuc.DataSource = dt;
            lblTong.Text = "Tim thay: " + dt.Rows.Count + " danh muc";
        }
    }
}

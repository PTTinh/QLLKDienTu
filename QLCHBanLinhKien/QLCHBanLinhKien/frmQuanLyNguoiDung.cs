using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmQuanLyNguoiDung : Form
    {
        private int selectedId = 0;

        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadVaiTro();
            ResetForm();
        }

        private void LoadData()
        {
            string sql = @"SELECT MaNguoiDung, TenDangNhap, HoTen, Email, SoDienThoai, VaiTro,
                          CASE WHEN TrangThai = 1 THEN N'Hoat dong' ELSE N'Bi khoa' END AS TrangThaiText
                          FROM NguoiDung ORDER BY HoTen";
            
            DataTable dt = Functions.GetDataToTable(sql);
            dgvNguoiDung.DataSource = dt;
            
            if (dgvNguoiDung.Columns.Count > 0)
            {
                dgvNguoiDung.Columns["MaNguoiDung"].Visible = false;
                dgvNguoiDung.Columns["TenDangNhap"].HeaderText = "Ten dang nhap";
                dgvNguoiDung.Columns["HoTen"].HeaderText = "Ho ten";
                dgvNguoiDung.Columns["Email"].HeaderText = "Email";
                dgvNguoiDung.Columns["SoDienThoai"].HeaderText = "So dien thoai";
                dgvNguoiDung.Columns["VaiTro"].HeaderText = "Vai tro";
                dgvNguoiDung.Columns["TrangThaiText"].HeaderText = "Trang thai";
            }
            
            lblTong.Text = "Tong: " + dt.Rows.Count + " nguoi dung";
        }

        private void LoadVaiTro()
        {
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("Admin");
            cboVaiTro.Items.Add("NhanVien");
            cboVaiTro.Items.Add("QuanLy");
            cboVaiTro.SelectedIndex = 1;
        }

        private void ResetForm()
        {
            selectedId = 0;
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            cboVaiTro.SelectedIndex = 1;
            chkTrangThai.Checked = true;
            
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenDangNhap.Enabled = true;
            txtMatKhau.Enabled = true;
            txtTenDangNhap.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui long nhap ten dang nhap!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui long nhap ho ten!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            if (selectedId == 0 && string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui long nhap mat khau!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            
            // Kiem tra ten dang nhap trung
            string checkSql = "SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = @TenDN";
            SqlParameter[] checkParams = { new SqlParameter("@TenDN", txtTenDangNhap.Text.Trim()) };
            object result = Functions.GetFieldValues(checkSql, checkParams);
            if (result != null && Convert.ToInt32(result) > 0)
            {
                MessageBox.Show("Ten dang nhap da ton tai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string sql = @"INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro, TrangThai)
                          VALUES (@TenDN, @MatKhau, @HoTen, @Email, @SDT, @VaiTro, @TrangThai)";
            
            SqlParameter[] parameters = {
                new SqlParameter("@TenDN", txtTenDangNhap.Text.Trim()),
                new SqlParameter("@MatKhau", txtMatKhau.Text),
                new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@SDT", txtSDT.Text.Trim()),
                new SqlParameter("@VaiTro", cboVaiTro.Text),
                new SqlParameter("@TrangThai", chkTrangThai.Checked ? 1 : 0)
            };
            
            if (Functions.RunSQL(sql, parameters))
            {
                MessageBox.Show("Them nguoi dung thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui long chon nguoi dung can sua!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (!ValidateInput()) return;
            
            string sql;
            SqlParameter[] parameters;
            
            // Neu co nhap mat khau moi thi cap nhat ca mat khau
            if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                sql = @"UPDATE NguoiDung SET HoTen = @HoTen, MatKhau = @MatKhau, 
                       Email = @Email, SoDienThoai = @SDT, VaiTro = @VaiTro, TrangThai = @TrangThai
                       WHERE MaNguoiDung = @MaND";
                
                parameters = new SqlParameter[] {
                    new SqlParameter("@MaND", selectedId),
                    new SqlParameter("@MatKhau", txtMatKhau.Text),
                    new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@SDT", txtSDT.Text.Trim()),
                    new SqlParameter("@VaiTro", cboVaiTro.Text),
                    new SqlParameter("@TrangThai", chkTrangThai.Checked ? 1 : 0)
                };
            }
            else
            {
                sql = @"UPDATE NguoiDung SET HoTen = @HoTen, 
                       Email = @Email, SoDienThoai = @SDT, VaiTro = @VaiTro, TrangThai = @TrangThai
                       WHERE MaNguoiDung = @MaND";
                
                parameters = new SqlParameter[] {
                    new SqlParameter("@MaND", selectedId),
                    new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@SDT", txtSDT.Text.Trim()),
                    new SqlParameter("@VaiTro", cboVaiTro.Text),
                    new SqlParameter("@TrangThai", chkTrangThai.Checked ? 1 : 0)
                };
            }
            
            if (Functions.RunSQL(sql, parameters))
            {
                MessageBox.Show("Cap nhat nguoi dung thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui long chon nguoi dung can xoa!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Khong cho xoa chinh minh
            if (selectedId == Functions.currentUserId)
            {
                MessageBox.Show("Khong the xoa tai khoan dang dang nhap!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (MessageBox.Show("Ban co chac chan muon xoa nguoi dung nay?", "Xac nhan",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM NguoiDung WHERE MaNguoiDung = @MaND";
                SqlParameter[] parameters = { new SqlParameter("@MaND", selectedId) };
                
                if (Functions.RunSQL(sql, parameters))
                {
                    MessageBox.Show("Xoa nguoi dung thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguoiDung.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["MaNguoiDung"].Value);
                
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                cboVaiTro.Text = row.Cells["VaiTro"].Value?.ToString() ?? "NhanVien";
                chkTrangThai.Checked = row.Cells["TrangThaiText"].Value?.ToString() == "Hoat dong";
                txtMatKhau.Text = ""; // Khong hien mat khau
                
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtTenDangNhap.Enabled = false;
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
            
            string sql = @"SELECT MaNguoiDung, TenDangNhap, HoTen, Email, SoDienThoai, VaiTro,
                          CASE WHEN TrangThai = 1 THEN N'Hoat dong' ELSE N'Bi khoa' END AS TrangThaiText
                          FROM NguoiDung 
                          WHERE TenDangNhap LIKE @Keyword OR HoTen LIKE @Keyword
                          ORDER BY HoTen";
            
            SqlParameter[] parameters = { new SqlParameter("@Keyword", "%" + keyword + "%") };
            DataTable dt = Functions.GetDataTable(sql, parameters);
            dgvNguoiDung.DataSource = dt;
            lblTong.Text = "Tim thay: " + dt.Rows.Count + " nguoi dung";
        }
    }
}

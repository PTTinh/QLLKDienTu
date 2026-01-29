using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmQuanLyKhachHang : Form
    {
        private int selectedId = 0;

        public frmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetForm();
        }

        private void LoadData()
        {
            string sql = @"SELECT MaKhachHang, MaSoKhachHang, HoTen, SoDienThoai, 
                          Email, DiaChi, LoaiKhachHang, TongChiTieu
                          FROM KhachHang ORDER BY HoTen";
            
            DataTable dt = Functions.GetDataToTable(sql);
            dgvKhachHang.DataSource = dt;
            
            if (dgvKhachHang.Columns.Count > 0)
            {
                dgvKhachHang.Columns["MaKhachHang"].Visible = false;
                dgvKhachHang.Columns["MaSoKhachHang"].HeaderText = "Ma KH";
                dgvKhachHang.Columns["HoTen"].HeaderText = "Ho ten";
                dgvKhachHang.Columns["SoDienThoai"].HeaderText = "So dien thoai";
                dgvKhachHang.Columns["Email"].HeaderText = "Email";
                dgvKhachHang.Columns["DiaChi"].HeaderText = "Dia chi";
                dgvKhachHang.Columns["LoaiKhachHang"].HeaderText = "Loai KH";
                dgvKhachHang.Columns["TongChiTieu"].HeaderText = "Tong chi tieu";
                dgvKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
            }
            
            lblTong.Text = "Tong: " + dt.Rows.Count + " khach hang";
        }

        private void ResetForm()
        {
            selectedId = 0;
            txtMaKH.Text = "";
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            cboLoaiKH.SelectedIndex = 0;
            
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaKH.Enabled = true;
            txtMaKH.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui long nhap ho ten khach hang!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            
            // Tao ma KH tu dong neu de trong
            string maKH = txtMaKH.Text.Trim();
            if (string.IsNullOrEmpty(maKH))
            {
                maKH = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            else
            {
                // Kiem tra ma trung
                string checkSql = "SELECT COUNT(*) FROM KhachHang WHERE MaSoKhachHang = @MaKH";
                SqlParameter[] checkParams = { new SqlParameter("@MaKH", maKH) };
                object result = Functions.GetFieldValues(checkSql, checkParams);
                if (result != null && Convert.ToInt32(result) > 0)
                {
                    MessageBox.Show("Ma khach hang da ton tai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            string sql = @"INSERT INTO KhachHang (MaSoKhachHang, HoTen, SoDienThoai, Email, DiaChi, LoaiKhachHang)
                          VALUES (@MaKH, @HoTen, @SDT, @Email, @DiaChi, @LoaiKH)";
            
            SqlParameter[] parameters = {
                new SqlParameter("@MaKH", maKH),
                new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                new SqlParameter("@SDT", txtSDT.Text.Trim()),
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                new SqlParameter("@LoaiKH", cboLoaiKH.Text)
            };
            
            if (Functions.RunSQL(sql, parameters))
            {
                MessageBox.Show("Them khach hang thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui long chon khach hang can sua!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (!ValidateInput()) return;
            
            string sql = @"UPDATE KhachHang SET HoTen = @HoTen, SoDienThoai = @SDT, 
                          Email = @Email, DiaChi = @DiaChi, LoaiKhachHang = @LoaiKH
                          WHERE MaKhachHang = @MaKH";
            
            SqlParameter[] parameters = {
                new SqlParameter("@MaKH", selectedId),
                new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                new SqlParameter("@SDT", txtSDT.Text.Trim()),
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                new SqlParameter("@LoaiKH", cboLoaiKH.Text)
            };
            
            if (Functions.RunSQL(sql, parameters))
            {
                MessageBox.Show("Cap nhat khach hang thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui long chon khach hang can xoa!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (MessageBox.Show("Ban co chac chan muon xoa khach hang nay?", "Xac nhan",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKH";
                SqlParameter[] parameters = { new SqlParameter("@MaKH", selectedId) };
                
                if (Functions.RunSQL(sql, parameters))
                {
                    MessageBox.Show("Xoa khach hang thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["MaKhachHang"].Value);
                
                txtMaKH.Text = row.Cells["MaSoKhachHang"].Value?.ToString() ?? "";
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
                cboLoaiKH.Text = row.Cells["LoaiKhachHang"].Value?.ToString() ?? "Thuong";
                
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaKH.Enabled = false;
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
            
            string sql = @"SELECT MaKhachHang, MaSoKhachHang, HoTen, SoDienThoai, 
                          Email, DiaChi, LoaiKhachHang, TongChiTieu
                          FROM KhachHang 
                          WHERE MaSoKhachHang LIKE @Keyword OR HoTen LIKE @Keyword OR SoDienThoai LIKE @Keyword
                          ORDER BY HoTen";
            
            SqlParameter[] parameters = { new SqlParameter("@Keyword", "%" + keyword + "%") };
            DataTable dt = Functions.GetDataTable(sql, parameters);
            dgvKhachHang.DataSource = dt;
            lblTong.Text = "Tim thay: " + dt.Rows.Count + " khach hang";
        }
    }
}

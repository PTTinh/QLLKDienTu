using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmQuanLyKhachHang : Form
    {
        private DataTable dtKhachHang;
        private bool isAdding = false;

        public frmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboLoaiKhachHang();
            SetControlState(false);
        }

        private void LoadData()
        {
            try
            {
                string sql = @"SELECT MaKhachHang, MaSoKhachHang, HoTen, SoDienThoai, 
                              Email, DiaChi, LoaiKhachHang, TongChiTieu, NgayTao 
                              FROM KhachHang 
                              ORDER BY NgayTao DESC";
                dtKhachHang = Functions.GetDataTable(sql);
                dgvKhachHang.DataSource = dtKhachHang;

                // Tùy chỉnh cột
                dgvKhachHang.Columns["MaKhachHang"].HeaderText = "Mã KH";
                dgvKhachHang.Columns["MaSoKhachHang"].HeaderText = "Mã số";
                dgvKhachHang.Columns["HoTen"].HeaderText = "Họ tên";
                dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số ĐT";
                dgvKhachHang.Columns["Email"].HeaderText = "Email";
                dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvKhachHang.Columns["LoaiKhachHang"].HeaderText = "Loại KH";
                dgvKhachHang.Columns["TongChiTieu"].HeaderText = "Tổng chi tiêu";
                dgvKhachHang.Columns["NgayTao"].HeaderText = "Ngày tạo";

                dgvKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
                dgvKhachHang.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";

                lblTongSo.Text = "Tổng số: " + dtKhachHang.Rows.Count + " khách hàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboLoaiKhachHang()
        {
            cboLoaiKhachHang.Items.Clear();
            cboLoaiKhachHang.Items.Add("Thường");
            cboLoaiKhachHang.Items.Add("VIP");
            cboLoaiKhachHang.Items.Add("Sỉ");
            cboLoaiKhachHang.SelectedIndex = 0;
        }

        private void SetControlState(bool isEditing)
        {
            txtMaSo.Enabled = isEditing;
            txtHoTen.Enabled = isEditing;
            txtSoDienThoai.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            txtDiaChi.Enabled = isEditing;
            cboLoaiKhachHang.Enabled = isEditing;

            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing && dgvKhachHang.SelectedRows.Count > 0;
            btnXoa.Enabled = !isEditing && dgvKhachHang.SelectedRows.Count > 0;
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;
            dgvKhachHang.Enabled = !isEditing;
        }

        private void ClearInputs()
        {
            txtMaSo.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            cboLoaiKhachHang.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInputs();
            SetControlState(true);
            txtMaSo.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            DataGridViewRow row = dgvKhachHang.SelectedRows[0];
            txtMaSo.Text = row.Cells["MaSoKhachHang"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
            cboLoaiKhachHang.Text = row.Cells["LoaiKhachHang"].Value?.ToString();

            SetControlState(true);
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                int maKH = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells["MaKhachHang"].Value);
                string sql = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKH";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaKH", maKH)
                };

                if (Functions.RunSQL(sql, parameters))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // Thêm mới
                    string sql = @"INSERT INTO KhachHang (MaSoKhachHang, HoTen, SoDienThoai, 
                                  Email, DiaChi, LoaiKhachHang, NgayTao) 
                                  VALUES (@MaSo, @HoTen, @SoDienThoai, @Email, @DiaChi, 
                                  @LoaiKH, GETDATE())";

                    SqlParameter[] parameters = {
                        new SqlParameter("@MaSo", txtMaSo.Text),
                        new SqlParameter("@HoTen", txtHoTen.Text),
                        new SqlParameter("@SoDienThoai", txtSoDienThoai.Text),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@DiaChi", txtDiaChi.Text),
                        new SqlParameter("@LoaiKH", cboLoaiKhachHang.Text)
                    };

                    if (Functions.RunSQL(sql, parameters))
                    {
                        MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        SetControlState(false);
                        ClearInputs();
                    }
                }
                else
                {
                    // Sửa
                    int maKH = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells["MaKhachHang"].Value);
                    string sql = @"UPDATE KhachHang SET 
                                  MaSoKhachHang = @MaSo, HoTen = @HoTen, 
                                  SoDienThoai = @SoDienThoai, Email = @Email, 
                                  DiaChi = @DiaChi, LoaiKhachHang = @LoaiKH 
                                  WHERE MaKhachHang = @MaKH";

                    SqlParameter[] parameters = {
                        new SqlParameter("@MaSo", txtMaSo.Text),
                        new SqlParameter("@HoTen", txtHoTen.Text),
                        new SqlParameter("@SoDienThoai", txtSoDienThoai.Text),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@DiaChi", txtDiaChi.Text),
                        new SqlParameter("@LoaiKH", cboLoaiKhachHang.Text),
                        new SqlParameter("@MaKH", maKH)
                    };

                    if (Functions.RunSQL(sql, parameters))
                    {
                        MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        SetControlState(false);
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            ClearInputs();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadData();
                    return;
                }

                string sql = @"SELECT MaKhachHang, MaSoKhachHang, HoTen, SoDienThoai, 
                              Email, DiaChi, LoaiKhachHang, TongChiTieu, NgayTao 
                              FROM KhachHang 
                              WHERE HoTen LIKE @Keyword OR SoDienThoai LIKE @Keyword 
                              OR MaSoKhachHang LIKE @Keyword
                              ORDER BY NgayTao DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@Keyword", "%" + keyword + "%")
                };

                dtKhachHang = Functions.GetDataTable(sql, parameters);
                dgvKhachHang.DataSource = dtKhachHang;
                lblTongSo.Text = "Tìm thấy: " + dtKhachHang.Rows.Count + " khách hàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dgvKhachHang.SelectedRows.Count > 0;
            btnXoa.Enabled = dgvKhachHang.SelectedRows.Count > 0;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }
    }
}

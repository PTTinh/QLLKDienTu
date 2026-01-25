using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmLichSuGiaoDich : Form
    {
        private DataTable dtHoaDon;

        public frmLichSuGiaoDich()
        {
            InitializeComponent();
        }

        private void frmLichSuGiaoDich_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string sql = @"SELECT h.MaHoaDon, h.SoHoaDon, h.NgayBan, 
                              k.HoTen as TenKhachHang, k.SoDienThoai,
                              n.HoTen as TenNhanVien,
                              h.TongTien, h.GiamGia, h.ThueVAT, h.ThanhTien, 
                              h.PhuongThucThanhToan, h.TrangThai
                              FROM HoaDon h
                              LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                              LEFT JOIN NguoiDung n ON h.MaNhanVien = n.MaNguoiDung
                              WHERE h.NgayBan BETWEEN @TuNgay AND @DenNgay
                              ORDER BY h.NgayBan DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@TuNgay", dtpTuNgay.Value.Date),
                    new SqlParameter("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1))
                };

                dtHoaDon = Functions.GetDataTable(sql, parameters);
                dgvHoaDon.DataSource = dtHoaDon;

                // Tùy chỉnh cột
                dgvHoaDon.Columns["MaHoaDon"].Visible = false;
                dgvHoaDon.Columns["SoHoaDon"].HeaderText = "Số HĐ";
                dgvHoaDon.Columns["NgayBan"].HeaderText = "Ngày bán";
                dgvHoaDon.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                dgvHoaDon.Columns["SoDienThoai"].HeaderText = "Số ĐT";
                dgvHoaDon.Columns["TenNhanVien"].HeaderText = "Nhân viên";
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns["GiamGia"].HeaderText = "Giảm giá";
                dgvHoaDon.Columns["ThueVAT"].HeaderText = "Thuế";
                dgvHoaDon.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvHoaDon.Columns["PhuongThucThanhToan"].HeaderText = "PT thanh toán";
                dgvHoaDon.Columns["TrangThai"].HeaderText = "Trạng thái";

                dgvHoaDon.Columns["NgayBan"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["GiamGia"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["ThueVAT"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

                // Thống kê
                decimal tongDoanhThu = 0;
                foreach (DataRow row in dtHoaDon.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(row["ThanhTien"]);
                }

                lblThongKe.Text = $"Tổng số: {dtHoaDon.Rows.Count} hóa đơn | Tổng doanh thu: {tongDoanhThu:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xem!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value);
            frmChiTietHoaDon frm = new frmChiTietHoaDon(maHD);
            frm.ShowDialog();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value);
            frmInHoaDon frm = new frmInHoaDon(maHD);
            frm.ShowDialog();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = "LichSuGiaoDich_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Export to Excel logic here
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnXemChiTiet_Click(sender, e);
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiemNhanh();
            }
        }

        private void btnTimKiemNhanh_Click(object sender, EventArgs e)
        {
            TimKiemNhanh();
        }

        private void TimKiemNhanh()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadData();
                    return;
                }

                string sql = @"SELECT h.MaHoaDon, h.SoHoaDon, h.NgayBan, 
                              k.HoTen as TenKhachHang, k.SoDienThoai,
                              n.HoTen as TenNhanVien,
                              h.TongTien, h.GiamGia, h.ThueVAT, h.ThanhTien, 
                              h.PhuongThucThanhToan, h.TrangThai
                              FROM HoaDon h
                              LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                              LEFT JOIN NguoiDung n ON h.MaNhanVien = n.MaNguoiDung
                              WHERE (h.SoHoaDon LIKE @Keyword 
                                 OR k.HoTen LIKE @Keyword 
                                 OR k.SoDienThoai LIKE @Keyword)
                              AND h.NgayBan BETWEEN @TuNgay AND @DenNgay
                              ORDER BY h.NgayBan DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@Keyword", "%" + keyword + "%"),
                    new SqlParameter("@TuNgay", dtpTuNgay.Value.Date),
                    new SqlParameter("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1))
                };

                dtHoaDon = Functions.GetDataTable(sql, parameters);
                dgvHoaDon.DataSource = dtHoaDon;

                decimal tongDoanhThu = 0;
                foreach (DataRow row in dtHoaDon.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(row["ThanhTien"]);
                }

                lblThongKe.Text = $"Tìm thấy: {dtHoaDon.Rows.Count} hóa đơn | Tổng: {tongDoanhThu:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

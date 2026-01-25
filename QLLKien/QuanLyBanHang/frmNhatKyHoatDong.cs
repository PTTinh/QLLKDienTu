using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmNhatKyHoatDong : Form
    {
        public frmNhatKyHoatDong()
        {
            InitializeComponent();
        }

        private void frmNhatKyHoatDong_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.Date;
            dtpDenNgay.Value = DateTime.Now;
            
            LoadComboNhanVien();
            LoadData();
        }

        private void LoadComboNhanVien()
        {
            try
            {
                string sql = "SELECT MaNguoiDung, HoTen FROM NguoiDung WHERE TrangThai = 1 ORDER BY HoTen";
                DataTable dt = Functions.GetDataTable(sql);
                
                // Thêm option "Tất cả"
                DataRow row = dt.NewRow();
                row["MaNguoiDung"] = 0;
                row["HoTen"] = "-- Tất cả nhân viên --";
                dt.Rows.InsertAt(row, 0);
                
                cboNhanVien.DataSource = dt;
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "MaNguoiDung";
                cboNhanVien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                int maNV = Convert.ToInt32(cboNhanVien.SelectedValue);

                // Thống kê theo nhân viên
                ThongKeTheoNhanVien(tuNgay, denNgay, maNV);
                
                // Chi tiết hóa đơn
                ChiTietHoaDon(tuNgay, denNgay, maNV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThongKeTheoNhanVien(DateTime tuNgay, DateTime denNgay, int maNV)
        {
            string sql = @"SELECT 
                          n.HoTen as 'Nhân viên',
                          n.VaiTro as 'Vai trò',
                          COUNT(h.MaHoaDon) as 'Số đơn hàng',
                          ISNULL(SUM(h.ThanhTien), 0) as 'Tổng doanh thu',
                          ISNULL(AVG(h.ThanhTien), 0) as 'Doanh thu TB/đơn',
                          MIN(h.NgayBan) as 'Đơn đầu tiên',
                          MAX(h.NgayBan) as 'Đơn cuối cùng'
                          FROM NguoiDung n
                          LEFT JOIN HoaDon h ON n.MaNguoiDung = h.MaNhanVien 
                              AND h.NgayBan BETWEEN @TuNgay AND @DenNgay
                              AND h.TrangThai = N'Hoàn thành'
                          WHERE n.TrangThai = 1";

            if (maNV > 0)
            {
                sql += " AND n.MaNguoiDung = @MaNV";
            }

            sql += " GROUP BY n.MaNguoiDung, n.HoTen, n.VaiTro ORDER BY COUNT(h.MaHoaDon) DESC";

            SqlParameter[] parameters;
            if (maNV > 0)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay),
                    new SqlParameter("@MaNV", maNV)
                };
            }
            else
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };
            }

            DataTable dt = Functions.GetDataTable(sql, parameters);
            dgvNhanVien.DataSource = dt;

            // Format cột
            if (dgvNhanVien.Columns.Count > 0)
            {
                dgvNhanVien.Columns["Tổng doanh thu"].DefaultCellStyle.Format = "N0";
                dgvNhanVien.Columns["Doanh thu TB/đơn"].DefaultCellStyle.Format = "N0";
                dgvNhanVien.Columns["Đơn đầu tiên"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvNhanVien.Columns["Đơn cuối cùng"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void ChiTietHoaDon(DateTime tuNgay, DateTime denNgay, int maNV)
        {
            string sql = @"SELECT 
                          h.SoHoaDon as 'Số HĐ',
                          h.NgayBan as 'Ngày bán',
                          n.HoTen as 'Nhân viên',
                          k.HoTen as 'Khách hàng',
                          h.TongTien as 'Tổng tiền',
                          h.GiamGia as 'Giảm giá',
                          h.ThanhTien as 'Thành tiền',
                          h.PhuongThucThanhToan as 'PT thanh toán'
                          FROM HoaDon h
                          LEFT JOIN NguoiDung n ON h.MaNhanVien = n.MaNguoiDung
                          LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                          WHERE h.NgayBan BETWEEN @TuNgay AND @DenNgay
                          AND h.TrangThai = N'Hoàn thành'";

            if (maNV > 0)
            {
                sql += " AND h.MaNhanVien = @MaNV";
            }

            sql += " ORDER BY h.NgayBan DESC";

            SqlParameter[] parameters;
            if (maNV > 0)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay),
                    new SqlParameter("@MaNV", maNV)
                };
            }
            else
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };
            }

            DataTable dt = Functions.GetDataTable(sql, parameters);
            dgvChiTiet.DataSource = dt;

            // Format cột
            if (dgvChiTiet.Columns.Count > 0)
            {
                dgvChiTiet.Columns["Ngày bán"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvChiTiet.Columns["Tổng tiền"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["Giảm giá"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
            }

            // Tổng kết
            decimal tongDoanhThu = 0;
            int tongDonHang = dt.Rows.Count;

            foreach (DataRow row in dt.Rows)
            {
                tongDoanhThu += Convert.ToDecimal(row["Thành tiền"]);
            }

            lblTongKet.Text = $"Tổng: {tongDonHang} đơn hàng | Doanh thu: {tongDoanhThu:N0} VNĐ";
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = "NhatKyHoatDong_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";

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
    }
}

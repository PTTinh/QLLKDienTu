using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmThongKeNhanVien : Form
    {
        private DataTable dtThongKe;

        public frmThongKeNhanVien()
        {
            InitializeComponent();
        }

        private void frmThongKeNhanVien_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            LoadNhanVien();
            LoadThongKe();
        }

        private void LoadNhanVien()
        {
            try
            {
                string query = "SELECT MaNguoiDung, HoTen FROM NguoiDung WHERE TrangThai = 1 ORDER BY HoTen";
                DataTable dt = Functions.GetDataTable(query);

                DataRow newRow = dt.NewRow();
                newRow["MaNguoiDung"] = 0;
                newRow["HoTen"] = "-- Tất cả nhân viên --";
                dt.Rows.InsertAt(newRow, 0);

                cboNhanVien.DataSource = dt;
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "MaNguoiDung";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThongKe()
        {
            try
            {
                string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
                string denNgay = dtpDenNgay.Value.ToString("yyyy-MM-dd 23:59:59");
                int maNV = cboNhanVien.SelectedValue != null ? Convert.ToInt32(cboNhanVien.SelectedValue) : 0;

                // Thống kê doanh số theo nhân viên
                string query = @"SELECT n.MaNguoiDung, n.HoTen, n.TenDangNhap, n.VaiTro,
                                 COUNT(DISTINCT h.MaHoaDon) AS SoHoaDon, 
                                 ISNULL(SUM(h.ThanhTien), 0) AS TongDoanhThu, 
                                 ISNULL(AVG(h.ThanhTien), 0) AS TrungBinhHoaDon,
                                 MAX(h.NgayBan) AS LanBanCuoi
                                 FROM NguoiDung n
                                 LEFT JOIN HoaDon h ON n.MaNguoiDung = h.MaNhanVien 
                                     AND h.NgayBan >= @TuNgay AND h.NgayBan <= @DenNgay
                                 WHERE n.TrangThai = 1";

                if (maNV > 0)
                    query += " AND n.MaNguoiDung = @MaNhanVien";

                query += " GROUP BY n.MaNguoiDung, n.HoTen, n.TenDangNhap, n.VaiTro ORDER BY TongDoanhThu DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay),
                    new SqlParameter("@MaNhanVien", maNV)
                };

                DataTable dt = Functions.GetDataTable(query, parameters);
                dgvThongKe.DataSource = dt;
                dtThongKe = dt;

                // Định dạng cột
                dgvThongKe.Columns["MaNguoiDung"].HeaderText = "Mã NV";
                dgvThongKe.Columns["MaNguoiDung"].Width = 60;
                dgvThongKe.Columns["HoTen"].HeaderText = "Họ tên";
                dgvThongKe.Columns["HoTen"].Width = 150;
                dgvThongKe.Columns["TenDangNhap"].HeaderText = "Tài khoản";
                dgvThongKe.Columns["TenDangNhap"].Width = 100;
                dgvThongKe.Columns["VaiTro"].HeaderText = "Vai trò";
                dgvThongKe.Columns["VaiTro"].Width = 80;
                dgvThongKe.Columns["SoHoaDon"].HeaderText = "Số HĐ";
                dgvThongKe.Columns["SoHoaDon"].Width = 60;
                dgvThongKe.Columns["TongDoanhThu"].HeaderText = "Tổng doanh thu";
                dgvThongKe.Columns["TongDoanhThu"].Width = 130;
                dgvThongKe.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";
                dgvThongKe.Columns["TrungBinhHoaDon"].HeaderText = "TB/Hóa đơn";
                dgvThongKe.Columns["TrungBinhHoaDon"].Width = 110;
                dgvThongKe.Columns["TrungBinhHoaDon"].DefaultCellStyle.Format = "N0";
                dgvThongKe.Columns["LanBanCuoi"].HeaderText = "Lần bán cuối";
                dgvThongKe.Columns["LanBanCuoi"].Width = 130;
                dgvThongKe.Columns["LanBanCuoi"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Tính tổng
                decimal tongDoanhThu = 0;
                int tongHoaDon = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(row["TongDoanhThu"]);
                    tongHoaDon += Convert.ToInt32(row["SoHoaDon"]);
                }

                lblTongDoanhThu.Text = string.Format("Tổng doanh thu: {0:N0} VNĐ", tongDoanhThu);
                lblTongHoaDon.Text = string.Format("Tổng hóa đơn: {0:N0}", tongHoaDon);
                lblSoNhanVien.Text = string.Format("Số nhân viên: {0}", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTietNhanVien(int maNhanVien)
        {
            try
            {
                string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
                string denNgay = dtpDenNgay.Value.ToString("yyyy-MM-dd 23:59:59");

                string query = @"SELECT h.MaHoaDon, h.SoHoaDon, h.NgayBan, 
                                 ISNULL(k.HoTen, 'Khách lẻ') AS TenKhachHang,
                                 h.TongTien, h.GiamGia, h.ThueVAT, h.ThanhTien,
                                 h.PhuongThucThanhToan
                                 FROM HoaDon h
                                 LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                                 WHERE h.MaNhanVien = @MaNhanVien
                                   AND h.NgayBan >= @TuNgay AND h.NgayBan <= @DenNgay
                                 ORDER BY h.NgayBan DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNhanVien", maNhanVien),
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };

                DataTable dt = Functions.GetDataTable(query, parameters);
                dgvChiTiet.DataSource = dt;

                // Định dạng cột
                dgvChiTiet.Columns["MaHoaDon"].Visible = false;
                dgvChiTiet.Columns["SoHoaDon"].HeaderText = "Số HĐ";
                dgvChiTiet.Columns["SoHoaDon"].Width = 100;
                dgvChiTiet.Columns["NgayBan"].HeaderText = "Ngày bán";
                dgvChiTiet.Columns["NgayBan"].Width = 130;
                dgvChiTiet.Columns["NgayBan"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvChiTiet.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                dgvChiTiet.Columns["TenKhachHang"].Width = 150;
                dgvChiTiet.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvChiTiet.Columns["TongTien"].Width = 100;
                dgvChiTiet.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["GiamGia"].HeaderText = "Giảm giá";
                dgvChiTiet.Columns["GiamGia"].Width = 80;
                dgvChiTiet.Columns["GiamGia"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["ThueVAT"].HeaderText = "VAT";
                dgvChiTiet.Columns["ThueVAT"].Width = 70;
                dgvChiTiet.Columns["ThueVAT"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvChiTiet.Columns["ThanhTien"].Width = 110;
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["PhuongThucThanhToan"].HeaderText = "Thanh toán";
                dgvChiTiet.Columns["PhuongThucThanhToan"].Width = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void dgvThongKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maNhanVien = Convert.ToInt32(dgvThongKe.Rows[e.RowIndex].Cells["MaNguoiDung"].Value);
                LoadChiTietNhanVien(maNhanVien);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtThongKe == null || dtThongKe.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tính tổng
                decimal tongDoanhThu = 0;
                int tongHoaDon = 0;
                foreach (DataRow row in dtThongKe.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(row["TongDoanhThu"]);
                    tongHoaDon += Convert.ToInt32(row["SoHoaDon"]);
                }

                frmReportViewer.ShowThongKeNhanVien(dtThongKe, dtpTuNgay.Value, dtpDenNgay.Value, tongDoanhThu, tongHoaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

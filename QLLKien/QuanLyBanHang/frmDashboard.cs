using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
            
            // Tự động refresh mỗi 30 giây
            timerRefresh.Interval = 30000; // 30 seconds
            timerRefresh.Start();
        }

        private void LoadDashboard()
        {
            try
            {
                // Thống kê tổng quan
                LoadTongQuan();
                
                // Doanh thu hôm nay
                LoadDoanhThuHomNay();
                
                // Top sản phẩm bán chạy
                LoadTopSanPham();
                
                // Hàng tồn kho thấp
                LoadHangTonThap();
                
                // Hoạt động gần đây
                LoadHoatDongGanDay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải Dashboard: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTongQuan()
        {
            try
            {
                // Tổng khách hàng
                string sqlKH = "SELECT COUNT(*) FROM KhachHang";
                object resultKH = Functions.GetFieldValues(sqlKH);
                lblTongKhachHang.Text = resultKH != null ? resultKH.ToString() : "0";

                // Tổng sản phẩm
                string sqlSP = "SELECT COUNT(*) FROM SanPham WHERE TrangThai = 1";
                object resultSP = Functions.GetFieldValues(sqlSP);
                lblTongSanPham.Text = resultSP != null ? resultSP.ToString() : "0";

                // Tổng nhân viên
                string sqlNV = "SELECT COUNT(*) FROM NguoiDung WHERE TrangThai = 1";
                object resultNV = Functions.GetFieldValues(sqlNV);
                lblTongNhanVien.Text = resultNV != null ? resultNV.ToString() : "0";

                // Tổng nhà cung cấp
                string sqlNCC = "SELECT COUNT(*) FROM NhaCungCap";
                object resultNCC = Functions.GetFieldValues(sqlNCC);
                lblTongNCC.Text = resultNCC != null ? resultNCC.ToString() : "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tổng quan: " + ex.Message);
            }
        }

        private void LoadDoanhThuHomNay()
        {
            try
            {
                DateTime homNay = DateTime.Now.Date;
                DateTime ngayMai = homNay.AddDays(1);

                // Doanh thu hôm nay
                string sql = @"SELECT 
                              COUNT(MaHoaDon) as SoDon,
                              ISNULL(SUM(ThanhTien), 0) as DoanhThu
                              FROM HoaDon 
                              WHERE NgayBan >= @HomNay AND NgayBan < @NgayMai
                              AND TrangThai = N'Hoàn thành'";

                SqlParameter[] parameters = {
                    new SqlParameter("@HomNay", homNay),
                    new SqlParameter("@NgayMai", ngayMai)
                };

                DataTable dt = Functions.GetDataTable(sql, parameters);
                if (dt.Rows.Count > 0)
                {
                    lblSoDonHomNay.Text = dt.Rows[0]["SoDon"].ToString();
                    lblDoanhThuHomNay.Text = Convert.ToDecimal(dt.Rows[0]["DoanhThu"]).ToString("N0");
                }

                // Doanh thu tháng này
                DateTime dauThang = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                string sqlThang = @"SELECT ISNULL(SUM(ThanhTien), 0) 
                                   FROM HoaDon 
                                   WHERE NgayBan >= @DauThang 
                                   AND TrangThai = N'Hoàn thành'";

                SqlParameter[] paramsThang = {
                    new SqlParameter("@DauThang", dauThang)
                };

                object resultThang = Functions.GetFieldValues(sqlThang, paramsThang);
                lblDoanhThuThang.Text = resultThang != null ? Convert.ToDecimal(resultThang).ToString("N0") : "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải doanh thu: " + ex.Message);
            }
        }

        private void LoadTopSanPham()
        {
            try
            {
                DateTime homNay = DateTime.Now.Date;
                DateTime dauThang = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                string sql = @"SELECT TOP 5
                              sp.TenSanPham as 'Sản phẩm',
                              SUM(ct.SoLuong) as 'SL bán',
                              SUM(ct.ThanhTien) as 'Doanh thu'
                              FROM ChiTietHoaDon ct
                              INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                              INNER JOIN HoaDon h ON ct.MaHoaDon = h.MaHoaDon
                              WHERE h.NgayBan >= @DauThang
                              AND h.TrangThai = N'Hoàn thành'
                              GROUP BY sp.TenSanPham
                              ORDER BY SUM(ct.SoLuong) DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@DauThang", dauThang)
                };

                DataTable dt = Functions.GetDataTable(sql, parameters);
                dgvTopSanPham.DataSource = dt;

                if (dgvTopSanPham.Columns.Count > 0)
                {
                    dgvTopSanPham.Columns["Doanh thu"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải top sản phẩm: " + ex.Message);
            }
        }

        private void LoadHangTonThap()
        {
            try
            {
                string sql = @"SELECT TOP 10
                              MaSoSanPham as 'Mã SP',
                              TenSanPham as 'Tên sản phẩm',
                              SoLuongTon as 'Tồn kho',
                              TonToiThieu as 'Tồn TT'
                              FROM SanPham 
                              WHERE SoLuongTon <= TonToiThieu
                              AND TrangThai = 1
                              ORDER BY SoLuongTon ASC";

                DataTable dt = Functions.GetDataTable(sql);
                dgvHangTonThap.DataSource = dt;

                // Đếm số lượng cảnh báo
                lblSoCanhBao.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hàng tồn thấp: " + ex.Message);
            }
        }

        private void LoadHoatDongGanDay()
        {
            try
            {
                string sql = @"SELECT TOP 10
                              h.SoHoaDon as 'Số HĐ',
                              h.NgayBan as 'Thời gian',
                              k.HoTen as 'Khách hàng',
                              h.ThanhTien as 'Thành tiền'
                              FROM HoaDon h
                              LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                              WHERE h.TrangThai = N'Hoàn thành'
                              ORDER BY h.NgayBan DESC";

                DataTable dt = Functions.GetDataTable(sql);
                dgvHoatDong.DataSource = dt;

                if (dgvHoatDong.Columns.Count > 0)
                {
                    dgvHoatDong.Columns["Thời gian"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvHoatDong.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hoạt động gần đây: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
            lblCapNhat.Text = "Cập nhật lúc: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            LoadDashboard();
            lblCapNhat.Text = "Cập nhật lúc: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnXemDoanhThu_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu frm = new frmThongKeDoanhThu();
            frm.ShowDialog();
        }

        private void btnXemHangTon_Click(object sender, EventArgs e)
        {
            frmCanhBaoHangTon frm = new frmCanhBaoHangTon();
            frm.ShowDialog();
        }
    }
}

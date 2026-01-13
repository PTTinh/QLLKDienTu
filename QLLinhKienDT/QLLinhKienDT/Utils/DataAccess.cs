using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLinhKienDT.Utils
{
    public static class DataAccess
    {
        private static string ConnectionString => @"Data Source=DESKTOP-EBPD2D3\SQLEXPRESS;Initial Catalog=QLCHLinhKienDienTu;Integrated Security=True";

        private static void EnsureConnectionString()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new InvalidOperationException("Connection string 'QLLinhKienConnection' is not configured in App.config.");
        }

        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            EnsureConnectionString();
            var dt = new DataTable();
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"Database query failed: {ex.Message}", ex);
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            EnsureConnectionString();
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database non-query failed: {ex.Message}", ex);
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            EnsureConnectionString();
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database scalar query failed: {ex.Message}", ex);
            }
        }

        // ====================== REPORTING METHODS ======================

        /// <summary>
        /// Lấy dữ liệu doanh thu theo ngày/tuần/tháng
        /// </summary>
        public static DataTable GetRevenueByPeriod(string period, DateTime startDate, DateTime endDate)
        {
            string sql = "";
            if (period.ToLower() == "day")
                sql = @"SELECT CAST(NgayBan AS DATE) as Ngay, SUM(ThanhTien) as DoanhThu, COUNT(DISTINCT MaHoaDon) as SoHoaDon
                        FROM HoaDon 
                        WHERE NgayBan >= @StartDate AND NgayBan <= @EndDate
                        GROUP BY CAST(NgayBan AS DATE)
                        ORDER BY Ngay";
            else if (period.ToLower() == "week")
                sql = @"SELECT DATEPART(WEEK, NgayBan) as Tuan, YEAR(NgayBan) as Nam, 
                               SUM(ThanhTien) as DoanhThu, COUNT(DISTINCT MaHoaDon) as SoHoaDon
                        FROM HoaDon 
                        WHERE NgayBan >= @StartDate AND NgayBan <= @EndDate
                        GROUP BY DATEPART(WEEK, NgayBan), YEAR(NgayBan)
                        ORDER BY Nam, Tuan";
            else if (period.ToLower() == "month")
                sql = @"SELECT MONTH(NgayBan) as Thang, YEAR(NgayBan) as Nam, 
                               SUM(ThanhTien) as DoanhThu, COUNT(DISTINCT MaHoaDon) as SoHoaDon
                        FROM HoaDon 
                        WHERE NgayBan >= @StartDate AND NgayBan <= @EndDate
                        GROUP BY MONTH(NgayBan), YEAR(NgayBan)
                        ORDER BY Nam, Thang";

            return ExecuteQuery(sql, 
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate));
        }

        /// <summary>
        /// Lấy Top 10 sản phẩm bán chạy
        /// </summary>
        public static DataTable GetTopSellingProducts(int top = 10)
        {
            string sql = $@"SELECT TOP {top} 
                            sp.MaSanPham, sp.TenSanPham, dm.TenDanhMuc,
                            SUM(ct.SoLuong) as SoLuongBan, 
                            SUM(ct.ThanhTien) as DoanhThu,
                            COUNT(DISTINCT ct.MaHoaDon) as SoLanBan
                            FROM ChiTietHoaDon ct
                            INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                            INNER JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                            INNER JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon
                            WHERE hd.TrangThai = N'Hoàn thành'
                            GROUP BY sp.MaSanPham, sp.TenSanPham, dm.TenDanhMuc
                            ORDER BY SoLuongBan DESC";
            return ExecuteQuery(sql);
        }

        /// <summary>
        /// Lấy thống kê sản phẩm bán chạy theo danh mục
        /// </summary>
        public static DataTable GetTopSellingProductsByCategory()
        {
            string sql = @"SELECT TOP 10
                            sp.MaSanPham, sp.TenSanPham, dm.TenDanhMuc,
                            SUM(ct.SoLuong) as SoLuongBan, 
                            SUM(ct.ThanhTien) as DoanhThu
                            FROM ChiTietHoaDon ct
                            INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                            INNER JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                            INNER JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon
                            WHERE hd.TrangThai = N'Hoàn thành'
                            GROUP BY sp.MaSanPham, sp.TenSanPham, dm.TenDanhMuc
                            ORDER BY SoLuongBan DESC";
            return ExecuteQuery(sql);
        }

        /// <summary>
        /// Lấy thống kê tổng doanh thu, đơn hàng, khách hàng
        /// </summary>
        public static DataTable GetDashboardSummary(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT 
                            (SELECT SUM(ThanhTien) FROM HoaDon WHERE NgayBan >= @StartDate AND NgayBan <= @EndDate) as TongDoanhThu,
                            (SELECT COUNT(*) FROM HoaDon WHERE NgayBan >= @StartDate AND NgayBan <= @EndDate) as TongDonHang,
                            (SELECT COUNT(DISTINCT MaKhachHang) FROM HoaDon WHERE NgayBan >= @StartDate AND NgayBan <= @EndDate) as TongKhachHang";
            
            return ExecuteQuery(sql,
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate));
        }

        /// <summary>
        /// Lấy cảnh báo sản phẩm tồn kho thấp
        /// </summary>
        public static DataTable GetLowStockAlerts()
        {
            string sql = @"SELECT MaSanPham, TenSanPham, SoLuongTon, TonToiThieu, TonToiDa, MaDanhMuc
                            FROM SanPham
                            WHERE SoLuongTon <= TonToiThieu AND TrangThai = 1
                            ORDER BY SoLuongTon ASC";
            return ExecuteQuery(sql);
        }

        /// <summary>
        /// Lấy dữ liệu doanh thu theo danh mục
        /// </summary>
        public static DataTable GetRevenueByCategory(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT dm.TenDanhMuc, COUNT(DISTINCT ct.MaHoaDon) as SoHoaDon,
                            SUM(ct.SoLuong) as TongSoLuong, SUM(ct.ThanhTien) as TongDoanhThu
                            FROM ChiTietHoaDon ct
                            INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                            INNER JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                            INNER JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon
                            WHERE hd.NgayBan >= @StartDate AND hd.NgayBan <= @EndDate
                            AND hd.TrangThai = N'Hoàn thành'
                            GROUP BY dm.TenDanhMuc
                            ORDER BY TongDoanhThu DESC";
            return ExecuteQuery(sql,
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate));
        }

        /// <summary>
        /// Lấy doanh thu hôm nay
        /// </summary>
        public static decimal GetTodayRevenue()
        {
            string sql = @"SELECT ISNULL(SUM(ThanhTien), 0) 
                           FROM HoaDon 
                           WHERE CAST(NgayBan AS DATE) = CAST(GETDATE() AS DATE)
                           AND TrangThai = N'Hoàn thành'";
            object result = ExecuteScalar(sql);
            return Convert.ToDecimal(result ?? 0);
        }

        /// <summary>
        /// Lấy doanh thu tháng hiện tại
        /// </summary>
        public static decimal GetMonthRevenue()
        {
            string sql = @"SELECT ISNULL(SUM(ThanhTien), 0) 
                           FROM HoaDon 
                           WHERE MONTH(NgayBan) = MONTH(GETDATE()) 
                           AND YEAR(NgayBan) = YEAR(GETDATE())
                           AND TrangThai = N'Hoàn thành'";
            object result = ExecuteScalar(sql);
            return Convert.ToDecimal(result ?? 0);
        }

        /// <summary>
        /// Lấy tổng số khách hàng
        /// </summary>
        public static int GetTotalCustomers()
        {
            string sql = "SELECT COUNT(*) FROM KhachHang";
            object result = ExecuteScalar(sql);
            return Convert.ToInt32(result ?? 0);
        }

        /// <summary>
        /// Lấy tổng số đơn hàng
        /// </summary>
        public static int GetTotalOrders()
        {
            string sql = "SELECT COUNT(*) FROM HoaDon WHERE TrangThai = N'Hoàn thành'";
            object result = ExecuteScalar(sql);
            return Convert.ToInt32(result ?? 0);
        }
    }
}

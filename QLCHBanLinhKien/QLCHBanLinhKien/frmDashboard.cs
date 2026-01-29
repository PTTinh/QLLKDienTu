using System;
using System.Data;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            // Tong so san pham
            string sqlSP = "SELECT COUNT(*) FROM SanPham";
            object resultSP = Functions.GetFieldValues(sqlSP);
            lblTongSanPham.Text = resultSP != null ? resultSP.ToString() : "0";

            // Tong so khach hang
            string sqlKH = "SELECT COUNT(*) FROM KhachHang";
            object resultKH = Functions.GetFieldValues(sqlKH);
            lblTongKhachHang.Text = resultKH != null ? resultKH.ToString() : "0";

            // Tong so hoa don hom nay
            string sqlHD = "SELECT COUNT(*) FROM HoaDon WHERE CAST(NgayBan AS DATE) = CAST(GETDATE() AS DATE)";
            object resultHD = Functions.GetFieldValues(sqlHD);
            lblHoaDonHomNay.Text = resultHD != null ? resultHD.ToString() : "0";

            // Doanh thu hom nay
            string sqlDT = "SELECT ISNULL(SUM(ThanhTien), 0) FROM HoaDon WHERE CAST(NgayBan AS DATE) = CAST(GETDATE() AS DATE)";
            object resultDT = Functions.GetFieldValues(sqlDT);
            decimal doanhThuHomNay = resultDT != null && resultDT != DBNull.Value ? Convert.ToDecimal(resultDT) : 0;
            lblDoanhThuHomNay.Text = doanhThuHomNay.ToString("N0") + " VND";

            // Doanh thu thang nay
            string sqlDTThang = "SELECT ISNULL(SUM(ThanhTien), 0) FROM HoaDon WHERE MONTH(NgayBan) = MONTH(GETDATE()) AND YEAR(NgayBan) = YEAR(GETDATE())";
            object resultDTThang = Functions.GetFieldValues(sqlDTThang);
            decimal doanhThuThang = resultDTThang != null && resultDTThang != DBNull.Value ? Convert.ToDecimal(resultDTThang) : 0;
            lblDoanhThuThang.Text = doanhThuThang.ToString("N0") + " VND";

            // San pham sap het hang (ton < 10)
            string sqlCanhBao = "SELECT COUNT(*) FROM SanPham WHERE SoLuongTon < 10";
            object resultCB = Functions.GetFieldValues(sqlCanhBao);
            lblCanhBao.Text = resultCB != null ? resultCB.ToString() : "0";

            // Load danh sach hoa don gan day
            LoadHoaDonGanDay();
            
            // Load top san pham ban chay
            LoadTopSanPham();
        }

        private void LoadHoaDonGanDay()
        {
            string sql = @"SELECT TOP 10 h.SoHoaDon AS 'Ma HD', h.NgayBan AS 'Ngay', 
                          ISNULL(k.HoTen, 'Khach le') AS 'Khach hang', 
                          h.ThanhTien AS 'Thanh toan'
                          FROM HoaDon h
                          LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                          ORDER BY h.NgayBan DESC";
            
            DataTable dt = Functions.GetDataToTable(sql);
            dgvHoaDonGanDay.DataSource = dt;
            
            if (dgvHoaDonGanDay.Columns.Count > 0)
            {
                dgvHoaDonGanDay.Columns["Thanh toan"].DefaultCellStyle.Format = "N0";
            }
        }

        private void LoadTopSanPham()
        {
            string sql = @"SELECT TOP 10 sp.TenSanPham AS 'San pham', 
                          SUM(ct.SoLuong) AS 'SL ban',
                          SUM(ct.ThanhTien) AS 'Doanh thu'
                          FROM ChiTietHoaDon ct
                          INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                          GROUP BY sp.TenSanPham
                          ORDER BY SUM(ct.SoLuong) DESC";
            
            DataTable dt = Functions.GetDataToTable(sql);
            dgvTopSanPham.DataSource = dt;
            
            if (dgvTopSanPham.Columns.Count > 0)
            {
                dgvTopSanPham.Columns["Doanh thu"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }
    }
}

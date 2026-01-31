using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;
using Microsoft.Reporting.WinForms;

namespace QLCHBanLinhKien
{
    public partial class frmInHoaDon : Form
    {
        private int maHoaDon;
        private System.Data.DataTable dtHoaDon;
        private System.Data.DataTable dtChiTiet;

        // Thông tin cửa hàng
        private const string TEN_CUA_HANG = "CỬA HÀNG LINH KIỆN ĐIỆN TỬ";
        private const string DIA_CHI_CUA_HANG = "123 Đường ABC, Quận XYZ, TP. HCM";
        private const string DIEN_THOAI_CUA_HANG = "0123 456 789";

        public frmInHoaDon(int maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
            LoadChiTietHoaDon();
            LoadReport();
        }

        private void LoadHoaDon()
        {
            try
            {
                string query = @"SELECT h.MaHoaDon, h.SoHoaDon, h.NgayBan, h.TongTien, h.GiamGia, h.ThanhTien, h.PhuongThucThanhToan,
                                 ISNULL(k.HoTen, N'Khách lẻ') AS TenKhachHang, 
                                 ISNULL(k.SoDienThoai, '') AS SoDienThoai, 
                                 ISNULL(k.DiaChi, '') AS DiaChi,
                                 ISNULL(n.HoTen, '') AS TenNhanVien
                                 FROM HoaDon h
                                 LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                                 LEFT JOIN NguoiDung n ON h.MaNhanVien = n.MaNguoiDung
                                 WHERE h.MaHoaDon = @MaHoaDon";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaHoaDon", maHoaDon)
                };

                dtHoaDon = Functions.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTietHoaDon()
        {
            try
            {
                string query = @"SELECT sp.TenSanPham, ct.SoLuong, ct.DonGia, ct.ThanhTien
                                 FROM ChiTietHoaDon ct
                                 INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                                 WHERE ct.MaHoaDon = @MaHoaDon";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaHoaDon", maHoaDon)
                };

                dtChiTiet = Functions.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReport()
        {
            try
            {
                if (dtHoaDon == null || dtHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thiết lập đường dẫn RDLC - sử dụng embedded resource
                reportViewer1.LocalReport.ReportEmbeddedResource = "QLCHBanLinhKien.rdlcInHoaDon.rdlc";

                // Xóa data source cũ
                reportViewer1.LocalReport.DataSources.Clear();

                // Thêm data source cho hóa đơn
                ReportDataSource rdsHoaDon = new ReportDataSource("HoaDonDataSet", dtHoaDon);
                reportViewer1.LocalReport.DataSources.Add(rdsHoaDon);

                // Thêm data source cho chi tiết hóa đơn
                ReportDataSource rdsChiTiet = new ReportDataSource("ChiTietHoaDonDataSet", dtChiTiet);
                reportViewer1.LocalReport.DataSources.Add(rdsChiTiet);

                // Thiết lập parameters cho thông tin cửa hàng
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("TenCuaHang", TEN_CUA_HANG),
                    new ReportParameter("DiaChiCuaHang", DIA_CHI_CUA_HANG),
                    new ReportParameter("DienThoaiCuaHang", DIEN_THOAI_CUA_HANG)
                };
                reportViewer1.LocalReport.SetParameters(parameters);

                // Refresh báo cáo
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message + "\n\nChi tiết: " + ex.InnerException?.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

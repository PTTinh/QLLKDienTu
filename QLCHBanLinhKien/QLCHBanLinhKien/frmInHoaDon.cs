using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;
using Microsoft.Reporting.WinForms;

namespace QLCHBanLinhKien
{
    /// <summary>
    /// Form hiển thị và in hóa đơn sử dụng RDLC Report
    /// Nhận mã hóa đơn và hiển thị báo cáo tương ứng
    /// </summary>
    public partial class frmInHoaDon : Form
    {
        // Mã hóa đơn cần hiển thị
        private int maHoaDon;
        
        // DataTable lưu thông tin hóa đơn (1 dòng)
        private System.Data.DataTable dtHoaDon;
        
        // DataTable lưu chi tiết hóa đơn (nhiều dòng sản phẩm)
        private System.Data.DataTable dtChiTiet;

        // === THÔNG TIN CỬA HÀNG (có thể đổi theo yêu cầu) ===
        private const string TEN_CUA_HANG = "CỬA HÀNG LINH KIỆN ĐIỆN TỬ";
        private const string DIA_CHI_CUA_HANG = "123 Đường ABC, Quận XYZ, TP. HCM";
        private const string DIEN_THOAI_CUA_HANG = "0123 456 789";

        /// <summary>
        /// Constructor - nhận mã hóa đơn cần in
        /// </summary>
        /// <param name="maHoaDon">Mã hóa đơn trong database</param>
        public frmInHoaDon(int maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
        }

        /// <summary>
        /// Sự kiện load form
        /// Load dữ liệu hóa đơn và hiển thị báo cáo
        /// </summary>
        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();          // Load thông tin hóa đơn chính
            LoadChiTietHoaDon();   // Load danh sách sản phẩm
            LoadReport();          // Hiển thị báo cáo RDLC
        }

        /// <summary>
        /// Load thông tin hóa đơn từ database
        /// Bao gồm: thông tin hóa đơn, khách hàng, nhân viên
        /// </summary>
        private void LoadHoaDon()
        {
            try
            {
                 // Query lấy thông tin hóa đơn kèm tên khách hàng và nhân viên
                string query = @"SELECT h.MaHoaDon, h.SoHoaDon, h.NgayBan, h.TongTien, h.GiamGia, h.ThanhTien, h.PhuongThucThanhToan,
                                 ISNULL(k.HoTen, N'Khách lẻ') AS TenKhachHang,  -- Nếu NULL thì hiển thị 'Khách lẻ'
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

        /// <summary>
        /// Load danh sách sản phẩm trong hóa đơn
        /// </summary>
        private void LoadChiTietHoaDon()
        {
            try
            {
                // Query lấy chi tiết: tên sản phẩm, số lượng, đơn giá, thành tiền
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

        /// <summary>
        /// Hiển thị báo cáo RDLC trong ReportViewer
        /// Bind dữ liệu và parameters vào report
        /// </summary>
        private void LoadReport()
        {
            try
            {
                // Kiểm tra có dữ liệu hóa đơn không
                if (dtHoaDon == null || dtHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // === Thiết lập đường dẫn file RDLC ===
                // Sử dụng embedded resource (file RDLC được nhúng vào assembly)
                reportViewer1.LocalReport.ReportEmbeddedResource = "QLCHBanLinhKien.rdlcInHoaDon.rdlc";

                // Xóa các data source cũ (nếu có)
                reportViewer1.LocalReport.DataSources.Clear();

                // === Thêm Data Source cho thông tin hóa đơn ===
                // Tên "HoaDonDataSet" phải khớp với tên DataSet trong file RDLC
                ReportDataSource rdsHoaDon = new ReportDataSource("HoaDonDataSet", dtHoaDon);
                reportViewer1.LocalReport.DataSources.Add(rdsHoaDon);

                // === Thêm Data Source cho chi tiết hóa đơn ===
                // Tên "ChiTietHoaDonDataSet" phải khớp với tên DataSet trong file RDLC
                ReportDataSource rdsChiTiet = new ReportDataSource("ChiTietHoaDonDataSet", dtChiTiet);
                reportViewer1.LocalReport.DataSources.Add(rdsChiTiet);

                // === Thiết lập Parameters cho thông tin cửa hàng ===
                // Các tham số này được định nghĩa trong file RDLC
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("TenCuaHang", TEN_CUA_HANG),
                    new ReportParameter("DiaChiCuaHang", DIA_CHI_CUA_HANG),
                    new ReportParameter("DienThoaiCuaHang", DIEN_THOAI_CUA_HANG)
                };
                reportViewer1.LocalReport.SetParameters(parameters);

                // Refresh để hiển thị báo cáo
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi chi tiết để debug
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message + "\n\nChi tiết: " + ex.InnerException?.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

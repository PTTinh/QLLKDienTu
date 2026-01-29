using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmInHoaDon : Form
    {
        private int maHoaDon;
        private DataTable dtHoaDon;
        private DataTable dtChiTiet;

        public frmInHoaDon(int maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
            LoadChiTietHoaDon();
            DisplayHoaDon();
        }

        private void LoadHoaDon()
        {
            try
            {
                string query = @"SELECT h.*, k.HoTen AS TenKhachHang, k.SoDienThoai, k.DiaChi,
                                 n.HoTen AS TenNhanVien
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
                string query = @"SELECT ct.*, sp.TenSanPham, sp.MaSoSanPham
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

        private void DisplayHoaDon()
        {
            if (dtHoaDon == null || dtHoaDon.Rows.Count == 0) return;

            DataRow row = dtHoaDon.Rows[0];

            string html = $@"
<html>
<head>
<style>
    body {{ font-family: Arial, sans-serif; padding: 20px; }}
    .header {{ text-align: center; margin-bottom: 20px; }}
    .company {{ font-size: 18px; font-weight: bold; color: #0066cc; }}
    .title {{ font-size: 24px; font-weight: bold; margin: 15px 0; }}
    .info {{ margin-bottom: 15px; }}
    .info-row {{ margin: 5px 0; }}
    .label {{ font-weight: bold; display: inline-block; width: 120px; }}
    table {{ width: 100%; border-collapse: collapse; margin: 15px 0; }}
    th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
    th {{ background-color: #0066cc; color: white; }}
    .right {{ text-align: right; }}
    .total {{ font-size: 16px; font-weight: bold; margin-top: 15px; }}
    .footer {{ margin-top: 30px; text-align: center; font-style: italic; }}
</style>
</head>
<body>
    <div class='header'>
        <div class='company'>CỬA HÀNG LINH KIỆN ĐIỆN TỬ</div>
        <div>Địa chỉ: 123 Đường ABC, Quận XYZ, TP. HCM</div>
        <div>Điện thoại: 0123 456 789</div>
        <div class='title'>HÓA ĐƠN BÁN HÀNG</div>
    </div>

    <div class='info'>
        <div class='info-row'><span class='label'>Số hóa đơn:</span> {row["SoHoaDon"]}</div>
        <div class='info-row'><span class='label'>Ngày bán:</span> {Convert.ToDateTime(row["NgayBan"]).ToString("dd/MM/yyyy HH:mm")}</div>
        <div class='info-row'><span class='label'>Khách hàng:</span> {(row["TenKhachHang"] == DBNull.Value ? "Khách lẻ" : row["TenKhachHang"])}</div>
        <div class='info-row'><span class='label'>Số điện thoại:</span> {row["SoDienThoai"]}</div>
        <div class='info-row'><span class='label'>Nhân viên:</span> {row["TenNhanVien"]}</div>
    </div>

    <table>
        <tr>
            <th style='width:40px'>STT</th>
            <th>Tên sản phẩm</th>
            <th style='width:60px' class='right'>SL</th>
            <th style='width:100px' class='right'>Đơn giá</th>
            <th style='width:80px' class='right'>Giảm</th>
            <th style='width:120px' class='right'>Thành tiền</th>
        </tr>";

            int stt = 1;
            foreach (DataRow item in dtChiTiet.Rows)
            {
                html += $@"
        <tr>
            <td style='text-align:center'>{stt++}</td>
            <td>{item["TenSanPham"]}</td>
            <td class='right'>{item["SoLuong"]}</td>
            <td class='right'>{Convert.ToDecimal(item["DonGia"]).ToString("N0")}</td>
            <td class='right'>{Convert.ToDecimal(item["GiamGia"]).ToString("N0")}</td>
            <td class='right'>{Convert.ToDecimal(item["ThanhTien"]).ToString("N0")}</td>
        </tr>";
            }

            html += $@"
    </table>

    <div class='total'>
        <div class='info-row'><span class='label'>Tổng tiền:</span> {Convert.ToDecimal(row["TongTien"]).ToString("N0")} VNĐ</div>
        <div class='info-row'><span class='label'>Giảm giá:</span> {Convert.ToDecimal(row["GiamGia"]).ToString("N0")} VNĐ</div>
        <div class='info-row'><span class='label'>Thuế VAT:</span> {Convert.ToDecimal(row["ThueVAT"]).ToString("N0")} VNĐ</div>
        <div class='info-row' style='color:red; font-size:18px;'><span class='label'>THÀNH TIỀN:</span> {Convert.ToDecimal(row["ThanhTien"]).ToString("N0")} VNĐ</div>
        <div class='info-row'><span class='label'>Thanh toán:</span> {row["PhuongThucThanhToan"]}</div>
    </div>

    <div class='footer'>
        <p>Cảm ơn quý khách đã mua hàng!</p>
        <p>Hẹn gặp lại!</p>
    </div>
</body>
</html>";

            webBrowser.DocumentText = html;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            webBrowser.ShowPrintDialog();
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            webBrowser.ShowPrintPreviewDialog();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

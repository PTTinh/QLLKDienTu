using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyBanHang.Class;
namespace QuanLyBanHang
{
    public partial class frmInHoaDon : Form
    {
        private int maHoaDon;

        public frmInHoaDon()
        {
            InitializeComponent();
        }

        public frmInHoaDon(int maHD)
        {
            InitializeComponent();
            this.maHoaDon = maHD;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                LoadHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHoaDon()
        {
            DataTable dtHoaDon = new DataTable();
            DataTable dtChiTiet = new DataTable();

            // Lấy thông tin hóa đơn
            string sqlHoaDon = @"SELECT h.SoHoaDon, h.NgayBan, h.TongTien, h.GiamGia, 
                                h.ThueVAT, h.ThanhTien, h.PhuongThucThanhToan,
                                k.HoTen as TenKhachHang, k.SoDienThoai, k.DiaChi,
                                n.HoTen as TenNhanVien
                         FROM HoaDon h
                         LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                         LEFT JOIN NguoiDung n ON h.MaNhanVien = n.MaNguoiDung
                         WHERE h.MaHoaDon = @MaHoaDon";

            SqlParameter[] paramsHD = {
                new SqlParameter("@MaHoaDon", maHoaDon)
            };
            dtHoaDon = Functions.GetDataTable(sqlHoaDon, paramsHD);

            // Lấy chi tiết hóa đơn
            string sqlChiTiet = @"SELECT sp.TenSanPham, sp.MaSoSanPham,
                                 ct.SoLuong, ct.DonGia, ct.GiamGia, ct.ThanhTien
                          FROM ChiTietHoaDon ct
                          INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                          WHERE ct.MaHoaDon = @MaHoaDon";

            SqlParameter[] paramsCT = {
                new SqlParameter("@MaHoaDon", maHoaDon)
            };
            dtChiTiet = Functions.GetDataTable(sqlChiTiet, paramsCT);

            // Hiển thị báo cáo
            reportViewer1.LocalReport.ReportPath = "rptHoaDon.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            
            ReportDataSource rdsHoaDon = new ReportDataSource("dsHoaDon", dtHoaDon);
            ReportDataSource rdsChiTiet = new ReportDataSource("dsChiTiet", dtChiTiet);
            
            reportViewer1.LocalReport.DataSources.Add(rdsHoaDon);
            reportViewer1.LocalReport.DataSources.Add(rdsChiTiet);
            
            reportViewer1.RefreshReport();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.PrintDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveDialog.FileName = "HoaDon_" + maHoaDon + ".pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    byte[] bytes = reportViewer1.LocalReport.Render(
                        "PDF", null, out mimeType, out encoding,
                        out extension, out streamids, out warnings);

                    System.IO.FileStream fs = new System.IO.FileStream(
                        saveDialog.FileName, System.IO.FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                    MessageBox.Show("Đã xuất file thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

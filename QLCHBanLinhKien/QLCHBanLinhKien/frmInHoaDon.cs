
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

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

            // Thông tin cửa hàng
            lblTenCuaHang.Text = TEN_CUA_HANG;
            lblDiaChiCuaHang.Text = "Địa chỉ: " + DIA_CHI_CUA_HANG;
            lblDienThoaiCuaHang.Text = "Điện thoại: " + DIEN_THOAI_CUA_HANG;

            // Thông tin hóa đơn
            lblSoHoaDon.Text = row["SoHoaDon"]?.ToString() ?? "";
            lblNgayBan.Text = row["NgayBan"] != DBNull.Value 
                ? Convert.ToDateTime(row["NgayBan"]).ToString("dd/MM/yyyy HH:mm") : "";

            // Thông tin khách hàng
            lblTenKhachHang.Text = row["TenKhachHang"] != DBNull.Value 
                ? row["TenKhachHang"].ToString() : "Khách lẻ";
            lblNhanVien.Text = row["TenNhanVien"]?.ToString() ?? "";

            // Hiển thị chi tiết hóa đơn
            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = dtChiTiet;
            FormatDataGridView();

            // Tổng tiền
            decimal tongTien = row["TongTien"] != DBNull.Value ? Convert.ToDecimal(row["TongTien"]) : 0;
            decimal giamGia = row["GiamGia"] != DBNull.Value ? Convert.ToDecimal(row["GiamGia"]) : 0;
            decimal thanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : 0;

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            lblGiamGia.Text = giamGia.ToString("N0") + " VNĐ";
            lblThanhTien.Text = thanhTien.ToString("N0") + " VNĐ";

            // Phương thức thanh toán
            lblPhuongThuc.Text = row["PhuongThucThanhToan"]?.ToString() ?? "Tiền mặt";
        }

        private void FormatDataGridView()
        {
            if (dgvChiTiet.Columns.Count == 0) return;

            // Ẩn các cột không cần thiết
            string[] hiddenColumns = { "MaChiTiet", "MaHoaDon", "MaSanPham", "MaSoSanPham", "GiamGia" };
            foreach (string col in hiddenColumns)
            {
                if (dgvChiTiet.Columns.Contains(col))
                    dgvChiTiet.Columns[col].Visible = false;
            }

            // Đặt tên hiển thị
            if (dgvChiTiet.Columns.Contains("TenSanPham"))
            {
                dgvChiTiet.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
                dgvChiTiet.Columns["TenSanPham"].Width = 250;
            }
            if (dgvChiTiet.Columns.Contains("SoLuong"))
            {
                dgvChiTiet.Columns["SoLuong"].HeaderText = "SL";
                dgvChiTiet.Columns["SoLuong"].Width = 60;
                dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvChiTiet.Columns.Contains("DonGia"))
            {
                dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvChiTiet.Columns["DonGia"].Width = 100;
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvChiTiet.Columns.Contains("ThanhTien"))
            {
                dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvChiTiet.Columns["ThanhTien"].Width = 120;
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dtHoaDon == null || dtHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
            saveDialog.FileName = "HoaDon_" + lblSoHoaDon.Text + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            saveDialog.Title = "Lưu hóa đơn ra Excel";

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            Application excelApp = null;
            Workbook workbook = null;
            Worksheet worksheet = null;

            try
            {
                excelApp = new Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Worksheet)workbook.ActiveSheet;

                DataRow row = dtHoaDon.Rows[0];
                int currentRow = 1;

                // ===== HEADER - Thông tin cửa hàng =====
                worksheet.Cells[currentRow, 1] = TEN_CUA_HANG;
                Range titleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 5]];
                titleRange.Merge();
                titleRange.Font.Size = 16;
                titleRange.Font.Bold = true;
                titleRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 102, 204));
                titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                currentRow++;

                worksheet.Cells[currentRow, 1] = "Địa chỉ: " + DIA_CHI_CUA_HANG;
                Range addressRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 5]];
                addressRange.Merge();
                addressRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                currentRow++;

                worksheet.Cells[currentRow, 1] = "Điện thoại: " + DIEN_THOAI_CUA_HANG;
                Range phoneRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 5]];
                phoneRange.Merge();
                phoneRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ===== Tiêu đề HÓA ĐƠN =====
                worksheet.Cells[currentRow, 1] = "HÓA ĐƠN BÁN HÀNG";
                Range hdTitleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 5]];
                hdTitleRange.Merge();
                hdTitleRange.Font.Size = 18;
                hdTitleRange.Font.Bold = true;
                hdTitleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ===== Thông tin hóa đơn =====
                worksheet.Cells[currentRow, 1] = "Số hóa đơn:";
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                worksheet.Cells[currentRow, 2] = row["SoHoaDon"]?.ToString() ?? "";
                worksheet.Cells[currentRow, 4] = "Ngày bán:";
                worksheet.Cells[currentRow, 4].Font.Bold = true;
                worksheet.Cells[currentRow, 5] = row["NgayBan"] != DBNull.Value 
                    ? Convert.ToDateTime(row["NgayBan"]).ToString("dd/MM/yyyy HH:mm") : "";
                currentRow++;

                string tenKH = row["TenKhachHang"] != DBNull.Value ? row["TenKhachHang"].ToString() : "Khách lẻ";
                worksheet.Cells[currentRow, 1] = "Khách hàng:";
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                worksheet.Cells[currentRow, 2] = tenKH;
                currentRow++;

                worksheet.Cells[currentRow, 1] = "Nhân viên:";
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                worksheet.Cells[currentRow, 2] = row["TenNhanVien"]?.ToString() ?? "";
                currentRow += 2;

                // ===== Bảng chi tiết sản phẩm =====
                // Header bảng
                string[] headers = { "STT", "Tên sản phẩm", "SL", "Đơn giá", "Thành tiền" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[currentRow, i + 1] = headers[i];
                }
                Range headerRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 5]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 102, 204));
                headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                headerRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                headerRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                currentRow++;

                // Dữ liệu chi tiết
                int stt = 1;
                int dataStartRow = currentRow;
                foreach (DataRow item in dtChiTiet.Rows)
                {
                    worksheet.Cells[currentRow, 1] = stt++;
                    worksheet.Cells[currentRow, 2] = item["TenSanPham"]?.ToString() ?? "";
                    worksheet.Cells[currentRow, 3] = item["SoLuong"] != DBNull.Value ? Convert.ToInt32(item["SoLuong"]) : 0;
                    worksheet.Cells[currentRow, 4] = item["DonGia"] != DBNull.Value ? Convert.ToDecimal(item["DonGia"]) : 0;
                    worksheet.Cells[currentRow, 5] = item["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(item["ThanhTien"]) : 0;
                    currentRow++;
                }

                // Format dữ liệu
                Range dataRange = worksheet.Range[worksheet.Cells[dataStartRow, 1], worksheet.Cells[currentRow - 1, 5]];
                dataRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                
                // Căn giữa STT và SL
                worksheet.Range[worksheet.Cells[dataStartRow, 1], worksheet.Cells[currentRow - 1, 1]].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                worksheet.Range[worksheet.Cells[dataStartRow, 3], worksheet.Cells[currentRow - 1, 3]].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                
                // Căn phải và format số cho Đơn giá, Thành tiền
                Range priceRange = worksheet.Range[worksheet.Cells[dataStartRow, 4], worksheet.Cells[currentRow - 1, 5]];
                priceRange.NumberFormat = "#,##0";
                priceRange.HorizontalAlignment = XlHAlign.xlHAlignRight;

                currentRow++;

                // ===== Tổng tiền =====
                decimal tongTien = row["TongTien"] != DBNull.Value ? Convert.ToDecimal(row["TongTien"]) : 0;
                decimal giamGia = row["GiamGia"] != DBNull.Value ? Convert.ToDecimal(row["GiamGia"]) : 0;
                decimal thanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : 0;

                worksheet.Cells[currentRow, 4] = "Tổng tiền:";
                worksheet.Cells[currentRow, 4].Font.Bold = true;
                worksheet.Cells[currentRow, 5] = tongTien;
                worksheet.Cells[currentRow, 5].NumberFormat = "#,##0";
                currentRow++;

                worksheet.Cells[currentRow, 4] = "Giảm giá:";
                worksheet.Cells[currentRow, 4].Font.Bold = true;
                worksheet.Cells[currentRow, 4].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                worksheet.Cells[currentRow, 5] = giamGia;
                worksheet.Cells[currentRow, 5].NumberFormat = "#,##0";
                worksheet.Cells[currentRow, 5].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                currentRow++;

                worksheet.Cells[currentRow, 4] = "THÀNH TIỀN:";
                worksheet.Cells[currentRow, 4].Font.Bold = true;
                worksheet.Cells[currentRow, 4].Font.Size = 12;
                worksheet.Cells[currentRow, 5] = thanhTien;
                worksheet.Cells[currentRow, 5].NumberFormat = "#,##0";
                worksheet.Cells[currentRow, 5].Font.Bold = true;
                worksheet.Cells[currentRow, 5].Font.Size = 12;
                worksheet.Cells[currentRow, 5].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                currentRow++;

                string phuongThuc = row["PhuongThucThanhToan"]?.ToString() ?? "Tiền mặt";
                worksheet.Cells[currentRow, 4] = "Thanh toán:";
                worksheet.Cells[currentRow, 4].Font.Bold = true;
                worksheet.Cells[currentRow, 5] = phuongThuc;
                currentRow += 2;

                // ===== Chữ ký =====
                worksheet.Cells[currentRow, 2] = "Người mua hàng";
                worksheet.Cells[currentRow, 2].Font.Bold = true;
                worksheet.Cells[currentRow, 2].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                worksheet.Cells[currentRow, 5] = "Người bán hàng";
                worksheet.Cells[currentRow, 5].Font.Bold = true;
                worksheet.Cells[currentRow, 5].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                currentRow++;

                worksheet.Cells[currentRow, 2] = "(Ký, ghi rõ họ tên)";
                worksheet.Cells[currentRow, 2].Font.Italic = true;
                worksheet.Cells[currentRow, 2].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                worksheet.Cells[currentRow, 5] = "(Ký, ghi rõ họ tên)";
                worksheet.Cells[currentRow, 5].Font.Italic = true;
                worksheet.Cells[currentRow, 5].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                currentRow += 4;

                // ===== Footer =====
                worksheet.Cells[currentRow, 1] = "Cảm ơn quý khách đã mua hàng!";
                Range footerRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 5]];
                footerRange.Merge();
                footerRange.Font.Bold = true;
                footerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 102, 204));
                footerRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // Auto fit columns
                worksheet.Columns[1].ColumnWidth = 10;
                worksheet.Columns[2].ColumnWidth = 45;
                worksheet.Columns[3].ColumnWidth = 12;
                worksheet.Columns[4].ColumnWidth = 18;
                worksheet.Columns[5].ColumnWidth = 18;

                // Save file
                if (saveDialog.FileName.EndsWith(".xlsx"))
                    workbook.SaveAs(saveDialog.FileName, XlFileFormat.xlOpenXMLWorkbook);
                else
                    workbook.SaveAs(saveDialog.FileName, XlFileFormat.xlWorkbookNormal);

                MessageBox.Show("Xuất hóa đơn ra Excel thành công!\nFile: " + saveDialog.FileName, 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hỏi có muốn mở file không
                if (MessageBox.Show("Bạn có muốn mở file vừa xuất không?", "Xác nhận", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cleanup COM objects
                if (worksheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                    worksheet = null;
                }
                if (workbook != null)
                {
                    workbook.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

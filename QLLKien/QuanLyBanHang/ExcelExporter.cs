using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public class ExcelExporter
    {
        public static void ExportHoaDonToExcel(int maHoaDon)
        {
            try
            {
                // Lấy dữ liệu hóa đơn
                string sqlHoaDon = @"SELECT h.MaHoaDon, h.SoHoaDon, h.NgayBan, h.TongTien, h.GiamGia, 
                                h.ThueVAT, h.ThanhTien, h.PhuongThucThanhToan,
                                k.HoTen as TenKhachHang, k.SoDienThoai, k.DiaChi,
                                n.HoTen as TenNhanVien
                         FROM HoaDon h
                         LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                         LEFT JOIN NguoiDung n ON h.MaNhanVien = n.MaNguoiDung
                         WHERE h.MaHoaDon = " + maHoaDon;

                System.Data.DataTable dtHoaDon = Functions.GetDataToTable(sqlHoaDon);

                if (dtHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy chi tiết hóa đơn
                string sqlChiTiet = @"SELECT sp.TenSanPham, sp.MaSoSanPham,
                                 ct.SoLuong, ct.DonGia, ct.GiamGia, ct.ThanhTien
                          FROM ChiTietHoaDon ct
                          INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                          WHERE ct.MaHoaDon = " + maHoaDon;

                System.Data.DataTable dtChiTiet = Functions.GetDataToTable(sqlChiTiet);

                // Tạo file Excel
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;

                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Hóa Đơn";

                // Đặt font mặc định
                worksheet.Cells.Font.Name = "Arial";
                worksheet.Cells.Font.Size = 11;

                // ===== HEADER =====
                int row = 1;
                
                // Tiêu đề công ty
                worksheet.get_Range($"A{row}", $"F{row}").Merge();
                worksheet.Cells[row, 1].Value = "CỬA HÀNG LINH KIỆN ĐIỆN TỬ";
                worksheet.Cells[row, 1].Font.Size = 16;
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row++;

                // Số điện thoại cửa hàng
                worksheet.get_Range($"A{row}:F{row}").Merge();
                worksheet.Cells[row, 1].Value = "Điện thoại: (028) 1234 5678 | Email: shop@linhkien.vn";
                worksheet.Cells[row, 1].Font.Size = 10;
                worksheet.Cells[row, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row++;

                // Dòng trống
                row++;

                // ===== THÔNG TIN HÓA ĐƠN =====
                worksheet.Cells[row, 1].Value = "HÓA ĐƠN BÁN HÀNG";
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 1].Font.Size = 14;
                row++;

                row++; // Dòng trống

                // Số hóa đơn
                worksheet.Cells[row, 1].Value = "Số Hóa Đơn:";
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 2].Value = dtHoaDon.Rows[0]["SoHoaDon"].ToString();
                worksheet.Cells[row, 4].Value = "Ngày:";
                worksheet.Cells[row, 4].Font.Bold = true;
                DateTime ngayBan = Convert.ToDateTime(dtHoaDon.Rows[0]["NgayBan"]);
                worksheet.Cells[row, 5].Value = ngayBan.ToString("dd/MM/yyyy HH:mm");
                row++;

                // Thông tin khách hàng
                row++;
                worksheet.Cells[row, 1].Value = "THÔNG TIN KHÁCH HÀNG";
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 1].Font.Size = 12;
                row++;

                worksheet.Cells[row, 1].Value = "Tên KH:";
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 2].Value = dtHoaDon.Rows[0]["TenKhachHang"].ToString();
                worksheet.Cells[row, 4].Value = "SĐT:";
                worksheet.Cells[row, 4].Font.Bold = true;
                worksheet.Cells[row, 5].Value = dtHoaDon.Rows[0]["SoDienThoai"].ToString();
                row++;

                worksheet.Cells[row, 1].Value = "Địa Chỉ:";
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.get_Range($"B{row}:F{row}").Merge();
                worksheet.Cells[row, 2].Value = dtHoaDon.Rows[0]["DiaChi"].ToString();
                row++;

                // Thông tin nhân viên
                worksheet.Cells[row, 1].Value = "Nhân Viên:";
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 2].Value = dtHoaDon.Rows[0]["TenNhanVien"].ToString();
                row++;

                row++; // Dòng trống

                // ===== BẢNG CHI TIẾT =====
                row++;
                int headerRow = row;

                // Tiêu đề cột
                string[] headers = { "STT", "Mã SP", "Tên Sản Phẩm", "Số Lượng", "Đơn Giá", "Giảm Giá", "Thành Tiền" };
                for (int col = 1; col <= headers.Length; col++)
                {
                    worksheet.Cells[row, col].Value = headers[col - 1];
                    worksheet.Cells[row, col].Font.Bold = true;
                    worksheet.Cells[row, col].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    worksheet.Cells[row, col].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                    worksheet.Cells[row, col].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                }
                row++;

                // Dữ liệu chi tiết
                decimal tongTien = 0;
                int dataStartRow = row;
                for (int i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    DataRow dtRow = dtChiTiet.Rows[i];
                    worksheet.Cells[row, 1].Value = i + 1;
                    worksheet.Cells[row, 2].Value = dtRow["MaSoSanPham"].ToString();
                    worksheet.Cells[row, 3].Value = dtRow["TenSanPham"].ToString();
                    worksheet.Cells[row, 4].Value = Convert.ToInt32(dtRow["SoLuong"]);
                    worksheet.Cells[row, 4].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                    decimal donGia = Convert.ToDecimal(dtRow["DonGia"]);
                    worksheet.Cells[row, 5].Value = donGia;
                    worksheet.Cells[row, 5].NumberFormat = "#,##0";

                    decimal giamGia = Convert.ToDecimal(dtRow["GiamGia"]);
                    worksheet.Cells[row, 6].Value = giamGia;
                    worksheet.Cells[row, 6].NumberFormat = "#,##0";

                    decimal thanhTien = Convert.ToDecimal(dtRow["ThanhTien"]);
                    worksheet.Cells[row, 7].Value = thanhTien;
                    worksheet.Cells[row, 7].NumberFormat = "#,##0";

                    tongTien += thanhTien;
                    row++;
                }

                row++; // Dòng trống

                // ===== TÍNH TOÁN =====
                decimal tong = Convert.ToDecimal(dtHoaDon.Rows[0]["TongTien"]);
                decimal giamGiaHD = Convert.ToDecimal(dtHoaDon.Rows[0]["GiamGia"]);
                decimal thueVAT = Convert.ToDecimal(dtHoaDon.Rows[0]["ThueVAT"]);
                decimal thanhTienHD = Convert.ToDecimal(dtHoaDon.Rows[0]["ThanhTien"]);

                worksheet.Cells[row, 5].Value = "Tổng Tiền:";
                worksheet.Cells[row, 5].Font.Bold = true;
                worksheet.Cells[row, 5].HorizontalAlignment = XlHAlign.xlHAlignRight;
                worksheet.Cells[row, 6].Value = tong;
                worksheet.Cells[row, 6].NumberFormat = "#,##0";
                worksheet.Cells[row, 6].Font.Bold = true;
                row++;

                worksheet.Cells[row, 5].Value = "Chiết Khấu:";
                worksheet.Cells[row, 5].Font.Bold = true;
                worksheet.Cells[row, 5].HorizontalAlignment = XlHAlign.xlHAlignRight;
                worksheet.Cells[row, 6].Value = giamGiaHD;
                worksheet.Cells[row, 6].NumberFormat = "#,##0";
                worksheet.Cells[row, 6].Font.Bold = true;
                row++;

                worksheet.Cells[row, 5].Value = "Thuế VAT (10%):";
                worksheet.Cells[row, 5].Font.Bold = true;
                worksheet.Cells[row, 5].HorizontalAlignment = XlHAlign.xlHAlignRight;
                worksheet.Cells[row, 6].Value = thueVAT;
                worksheet.Cells[row, 6].NumberFormat = "#,##0";
                worksheet.Cells[row, 6].Font.Bold = true;
                row++;

                // Thành tiền cuối cùng
                worksheet.Cells[row, 5].Value = "THÀNH TIỀN:";
                worksheet.Cells[row, 5].Font.Bold = true;
                worksheet.Cells[row, 5].Font.Size = 12;
                worksheet.Cells[row, 5].HorizontalAlignment = XlHAlign.xlHAlignRight;
                worksheet.Cells[row, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                worksheet.Cells[row, 6].Value = thanhTienHD;
                worksheet.Cells[row, 6].NumberFormat = "#,##0";
                worksheet.Cells[row, 6].Font.Bold = true;
                worksheet.Cells[row, 6].Font.Size = 12;
                worksheet.Cells[row, 6].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                row++;

                row++; // Dòng trống

                // ===== PHƯƠNG THỨC THANH TOÁN =====
                worksheet.Cells[row, 1].Value = "Phương Thức Thanh Toán:";
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 2].Value = dtHoaDon.Rows[0]["PhuongThucThanhToan"].ToString();
                row++;

                row++; // Dòng trống

                // ===== FOOTER =====
                row++;
                worksheet.get_Range($"A{row}:F{row}").Merge();
                worksheet.Cells[row, 1].Value = "Cảm ơn bạn đã mua hàng!";
                worksheet.Cells[row, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                worksheet.Cells[row, 1].Font.Italic = true;
                row++;

                worksheet.get_Range($"A{row}:F{row}").Merge();
                worksheet.Cells[row, 1].Value = "Lưu ý: Hàng bán không hoàn lại ngoại trừ các lỗi kỹ thuật của nhà sản xuất.";
                worksheet.Cells[row, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                worksheet.Cells[row, 1].Font.Size = 9;
                worksheet.Cells[row, 1].Font.Italic = true;

                // ===== THÊM ĐƯỜNG VIỀN CHO BẢNG =====
                Range dataRange = worksheet.get_Range($"A{headerRow}:G{row - 10}");
                dataRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                dataRange.Borders.Weight = XlBorderWeight.xlMedium;

                // ===== ĐỊNH DẠNG CỘT =====
                worksheet.Columns[1].ColumnWidth = 12;
                worksheet.Columns[2].ColumnWidth = 18;
                worksheet.Columns[3].ColumnWidth = 40;
                worksheet.Columns[4].ColumnWidth = 18;
                worksheet.Columns[5].ColumnWidth = 22;
                worksheet.Columns[6].ColumnWidth = 22;
                worksheet.Columns[7].ColumnWidth = 25;

                // Lưu file
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = "HoaDon_" + dtHoaDon.Rows[0]["SoHoaDon"].ToString().Replace("/", "_") + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Đã xuất file Excel thành công!\n" + saveDialog.FileName, "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở file
                    if (MessageBox.Show("Bạn có muốn mở file?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }

                workbook.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExportHoaDonListToExcel(System.Data.DataTable dtHoaDon)
        {
            try
            {
                if (dtHoaDon == null || dtHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;

                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Danh Sách Hóa Đơn";

                // Header
                int row = 1;
                worksheet.get_Range($"A{row}:G{row}").Merge();
                worksheet.Cells[row, 1].Value = "DANH SÁCH HÓA ĐƠN";
                worksheet.Cells[row, 1].Font.Size = 14;
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row += 2;

                // Tiêu đề cột
                string[] headers = { "Số Hóa Đơn", "Ngày Bán", "Tên KH", "Tổng Tiền", "Chiết Khấu", "Thành Tiền", "Trạng Thái" };
                for (int col = 1; col <= headers.Length; col++)
                {
                    worksheet.Cells[row, col].Value = headers[col - 1];
                    worksheet.Cells[row, col].Font.Bold = true;
                    worksheet.Cells[row, col].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    worksheet.Cells[row, col].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                    worksheet.Cells[row, col].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                }
                row++;

                // Dữ liệu
                int dataStartRow = row;
                foreach (System.Data.DataRow dataRow in dtHoaDon.Rows)
                {
                    worksheet.Cells[row, 1].Value = dataRow["SoHoaDon"];
                    worksheet.Cells[row, 2].Value = Convert.ToDateTime(dataRow["NgayBan"]).ToString("dd/MM/yyyy HH:mm");
                    worksheet.Cells[row, 3].Value = dataRow["TenKhachHang"];
                    worksheet.Cells[row, 4].Value = Convert.ToDecimal(dataRow["TongTien"]);
                    worksheet.Cells[row, 4].NumberFormat = "#,##0";
                    worksheet.Cells[row, 5].Value = Convert.ToDecimal(dataRow["GiamGia"]);
                    worksheet.Cells[row, 5].NumberFormat = "#,##0";
                    worksheet.Cells[row, 6].Value = Convert.ToDecimal(dataRow["ThanhTien"]);
                    worksheet.Cells[row, 6].NumberFormat = "#,##0";
                    worksheet.Cells[row, 7].Value = dataRow["TrangThai"];
                    row++;
                }

                // Thêm đường viền cho bảng
                Range listRange = worksheet.get_Range($"A{dataStartRow}:G{row - 1}");
                listRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                listRange.Borders.Weight = XlBorderWeight.xlThin;

                // Định dạng cột
                worksheet.Columns[1].ColumnWidth = 25;
                worksheet.Columns[2].ColumnWidth = 30;
                worksheet.Columns[3].ColumnWidth = 30;
                worksheet.Columns[4].ColumnWidth = 22;
                worksheet.Columns[5].ColumnWidth = 22;
                worksheet.Columns[6].ColumnWidth = 22;
                worksheet.Columns[7].ColumnWidth = 22;

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = "DanhSachHoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Đã xuất file Excel thành công!\n" + saveDialog.FileName, "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Bạn có muốn mở file?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }

                workbook.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExportGioHangToExcel(System.Data.DataTable dtGioHang, string tenKhachHang, string soHoaDon, decimal tongTien, decimal giamGia, decimal thanhTien)
        {
            try
            {
                if (dtGioHang == null || dtGioHang.Rows.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;

                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Giỏ Hàng";

                // Header
                int row = 1;
                worksheet.get_Range($"A{row}:F{row}").Merge();
                worksheet.Cells[row, 1].Value = "CỬA HÀNG LINH KIỆN ĐIỆN TỬ";
                worksheet.Cells[row, 1].Font.Size = 16;
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row++;

                worksheet.get_Range($"A{row}:F{row}").Merge();
                worksheet.Cells[row, 1].Value = "PHIẾU GIỎ HÀNG";
                worksheet.Cells[row, 1].Font.Size = 14;
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row += 2;

                // Thông tin cơ bản
                worksheet.Cells[row, 1].Value = "Số Hóa Đơn:";
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.Cells[row, 2].Value = soHoaDon;
                worksheet.Cells[row, 4].Value = "Ngày:";
                worksheet.Cells[row, 4].Font.Bold = true;
                worksheet.Cells[row, 5].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                row++;

                worksheet.Cells[row, 1].Value = "Khách Hàng:";
                worksheet.Cells[row, 1].Font.Bold = true;
                worksheet.get_Range($"B{row}:F{row}").Merge();
                worksheet.Cells[row, 2].Value = tenKhachHang;
                row += 2;

                // Bảng chi tiết
                int headerRow = row;
                string[] headers = { "STT", "Tên Sản Phẩm", "Số Lượng", "Đơn Giá", "Giảm Giá", "Thành Tiền" };
                for (int col = 1; col <= headers.Length; col++)
                {
                    worksheet.Cells[row, col].Value = headers[col - 1];
                    worksheet.Cells[row, col].Font.Bold = true;
                    worksheet.Cells[row, col].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    worksheet.Cells[row, col].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                    worksheet.Cells[row, col].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                }
                row++;

                // Dữ liệu
                int dataStartRow = row;
                for (int i = 0; i < dtGioHang.Rows.Count; i++)
                {
                    System.Data.DataRow dataRow = dtGioHang.Rows[i];
                    worksheet.Cells[row, 1].Value = i + 1;
                    worksheet.Cells[row, 2].Value = dataRow["TenSanPham"];
                    worksheet.Cells[row, 3].Value = Convert.ToInt32(dataRow["SoLuong"]);
                    worksheet.Cells[row, 3].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                    decimal donGia = Convert.ToDecimal(dataRow["DonGia"]);
                    worksheet.Cells[row, 4].Value = donGia;
                    worksheet.Cells[row, 4].NumberFormat = "#,##0";

                    decimal giamGiaSP = Convert.ToDecimal(dataRow["GiamGia"]);
                    worksheet.Cells[row, 5].Value = giamGiaSP;
                    worksheet.Cells[row, 5].NumberFormat = "#,##0";

                    decimal thanhTienSP = Convert.ToDecimal(dataRow["ThanhTien"]);
                    worksheet.Cells[row, 6].Value = thanhTienSP;
                    worksheet.Cells[row, 6].NumberFormat = "#,##0";
                    row++;
                }

                // Thêm đường viền cho bảng dữ liệu
                Range gioHangRange = worksheet.get_Range($"A{headerRow}:F{row - 1}");
                gioHangRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                gioHangRange.Borders.Weight = XlBorderWeight.xlThin;

                row++;

                // Tính toán
                worksheet.Cells[row, 4].Value = "Tổng Tiền:";
                worksheet.Cells[row, 4].Font.Bold = true;
                worksheet.Cells[row, 4].HorizontalAlignment = XlHAlign.xlHAlignRight;
                worksheet.Cells[row, 5].Value = tongTien;
                worksheet.Cells[row, 5].NumberFormat = "#,##0";
                worksheet.Cells[row, 5].Font.Bold = true;
                row++;

                worksheet.Cells[row, 4].Value = "Chiết Khấu:";
                worksheet.Cells[row, 4].Font.Bold = true;
                worksheet.Cells[row, 4].HorizontalAlignment = XlHAlign.xlHAlignRight;
                worksheet.Cells[row, 5].Value = giamGia;
                worksheet.Cells[row, 5].NumberFormat = "#,##0";
                worksheet.Cells[row, 5].Font.Bold = true;
                row++;

                worksheet.Cells[row, 4].Value = "THÀNH TIỀN:";
                worksheet.Cells[row, 4].Font.Bold = true;
                worksheet.Cells[row, 4].Font.Size = 12;
                worksheet.Cells[row, 4].HorizontalAlignment = XlHAlign.xlHAlignRight;
                worksheet.Cells[row, 4].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                worksheet.Cells[row, 5].Value = thanhTien;
                worksheet.Cells[row, 5].NumberFormat = "#,##0";
                worksheet.Cells[row, 5].Font.Bold = true;
                worksheet.Cells[row, 5].Font.Size = 12;
                worksheet.Cells[row, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                // Định dạng cột
                worksheet.Columns[1].ColumnWidth = 10;
                worksheet.Columns[2].ColumnWidth = 42;
                worksheet.Columns[3].ColumnWidth = 18;
                worksheet.Columns[4].ColumnWidth = 22;
                worksheet.Columns[5].ColumnWidth = 22;
                worksheet.Columns[6].ColumnWidth = 25;

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = "GioHang_" + soHoaDon.Replace("/", "_") + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Đã xuất file Excel thành công!\n" + saveDialog.FileName, "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Bạn có muốn mở file?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }

                workbook.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

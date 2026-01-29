using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace QLCHBanLinhKien.Class
{
    /// <summary>
    /// Class ho tro xuat du lieu ra file Excel
    /// Su dung Microsoft Office Interop Excel
    /// </summary>
    public static class ExcelExporter
    {
        /// <summary>
        /// Xuat DataGridView ra file Excel
        /// </summary>
        /// <param name="dgv">DataGridView can xuat</param>
        /// <param name="reportTitle">Tieu de bao cao</param>
        /// <param name="defaultFileName">Ten file mac dinh</param>
        /// <returns>True neu xuat thanh cong</returns>
        public static bool ExportDataGridViewToExcel(DataGridView dgv, string reportTitle, string defaultFileName = "BaoCao")
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de xuat!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
            saveDialog.FileName = defaultFileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            saveDialog.Title = "Luu file Excel";

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return false;

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

                // Tieu de bao cao
                worksheet.Cells[1, 1] = reportTitle;
                Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dgv.Columns.Count]];
                titleRange.Merge();
                titleRange.Font.Size = 16;
                titleRange.Font.Bold = true;
                titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // Ngay xuat
                worksheet.Cells[2, 1] = "Ngay xuat: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Range dateRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, dgv.Columns.Count]];
                dateRange.Merge();
                dateRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                dateRange.Font.Italic = true;

                // Header
                int colIndex = 1;
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Visible)
                    {
                        worksheet.Cells[4, colIndex] = col.HeaderText;
                        colIndex++;
                    }
                }

                Range headerRange = worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, colIndex - 1]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
                headerRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                // Data rows
                int rowIndex = 5;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    colIndex = 1;
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (col.Visible)
                        {
                            object value = row.Cells[col.Index].Value;
                            worksheet.Cells[rowIndex, colIndex] = value ?? "";
                            colIndex++;
                        }
                    }
                    rowIndex++;
                }

                // Format data range
                Range dataRange = worksheet.Range[worksheet.Cells[5, 1], worksheet.Cells[rowIndex - 1, colIndex - 1]];
                dataRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                // Auto fit columns
                worksheet.Columns.AutoFit();

                // Save file
                if (saveDialog.FileName.EndsWith(".xlsx"))
                    workbook.SaveAs(saveDialog.FileName, XlFileFormat.xlOpenXMLWorkbook);
                else
                    workbook.SaveAs(saveDialog.FileName, XlFileFormat.xlWorkbookNormal);

                MessageBox.Show("Xuat file Excel thanh cong!\nFile: " + saveDialog.FileName, "Thong bao", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xuat Excel: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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

        /// <summary>
        /// Xuat DataTable ra file Excel
        /// </summary>
        /// <param name="dt">DataTable can xuat</param>
        /// <param name="reportTitle">Tieu de bao cao</param>
        /// <param name="defaultFileName">Ten file mac dinh</param>
        /// <returns>True neu xuat thanh cong</returns>
        public static bool ExportDataTableToExcel(DataTable dt, string reportTitle, string defaultFileName = "BaoCao")
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de xuat!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
            saveDialog.FileName = defaultFileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            saveDialog.Title = "Luu file Excel";

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return false;

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

                // Tieu de bao cao
                worksheet.Cells[1, 1] = reportTitle;
                Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dt.Columns.Count]];
                titleRange.Merge();
                titleRange.Font.Size = 16;
                titleRange.Font.Bold = true;
                titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // Ngay xuat
                worksheet.Cells[2, 1] = "Ngay xuat: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Range dateRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, dt.Columns.Count]];
                dateRange.Merge();
                dateRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                dateRange.Font.Italic = true;

                // Header
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[4, i + 1] = dt.Columns[i].ColumnName;
                }

                Range headerRange = worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, dt.Columns.Count]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
                headerRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                // Data rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 5, j + 1] = dt.Rows[i][j]?.ToString() ?? "";
                    }
                }

                // Format data range
                Range dataRange = worksheet.Range[worksheet.Cells[5, 1], worksheet.Cells[dt.Rows.Count + 4, dt.Columns.Count]];
                dataRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                // Auto fit columns
                worksheet.Columns.AutoFit();

                // Save file
                if (saveDialog.FileName.EndsWith(".xlsx"))
                    workbook.SaveAs(saveDialog.FileName, XlFileFormat.xlOpenXMLWorkbook);
                else
                    workbook.SaveAs(saveDialog.FileName, XlFileFormat.xlWorkbookNormal);

                MessageBox.Show("Xuat file Excel thanh cong!\nFile: " + saveDialog.FileName, "Thong bao", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xuat Excel: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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

        /// <summary>
        /// Xuat bao cao doanh thu ra Excel
        /// </summary>
        public static bool ExportDoanhThuReport(DataTable dt, DateTime tuNgay, DateTime denNgay, decimal tongDoanhThu)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de xuat!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveDialog.FileName = "BaoCaoDoanhThu_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            saveDialog.Title = "Luu bao cao doanh thu";

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return false;

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

                // Tieu de
                worksheet.Cells[1, 1] = "BAO CAO DOANH THU";
                Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dt.Columns.Count]];
                titleRange.Merge();
                titleRange.Font.Size = 18;
                titleRange.Font.Bold = true;
                titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // Thoi gian
                worksheet.Cells[2, 1] = string.Format("Tu ngay: {0} - Den ngay: {1}", 
                    tuNgay.ToString("dd/MM/yyyy"), denNgay.ToString("dd/MM/yyyy"));
                Range periodRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, dt.Columns.Count]];
                periodRange.Merge();
                periodRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // Header
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[4, i + 1] = dt.Columns[i].ColumnName;
                }
                Range headerRange = worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, dt.Columns.Count]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);
                headerRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                // Data
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 5, j + 1] = dt.Rows[i][j]?.ToString() ?? "";
                    }
                }

                // Data range
                Range dataRange = worksheet.Range[worksheet.Cells[5, 1], worksheet.Cells[dt.Rows.Count + 4, dt.Columns.Count]];
                dataRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                // Tong doanh thu
                int summaryRow = dt.Rows.Count + 6;
                worksheet.Cells[summaryRow, 1] = "TONG DOANH THU:";
                worksheet.Cells[summaryRow, 2] = tongDoanhThu.ToString("N0") + " VND";
                Range summaryRange = worksheet.Range[worksheet.Cells[summaryRow, 1], worksheet.Cells[summaryRow, 2]];
                summaryRange.Font.Bold = true;
                summaryRange.Font.Size = 14;
                summaryRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkGreen);

                worksheet.Columns.AutoFit();
                workbook.SaveAs(saveDialog.FileName, XlFileFormat.xlOpenXMLWorkbook);

                MessageBox.Show("Xuat bao cao doanh thu thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xuat Excel: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                if (workbook != null) { workbook.Close(false); System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook); }
                if (excelApp != null) { excelApp.Quit(); System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp); }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}

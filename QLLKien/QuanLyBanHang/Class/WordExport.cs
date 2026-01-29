using System;
using System.Data;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace QuanLyBanHang.Class
{
    /// <summary>
    /// Lớp tiện ích để xuất dữ liệu ra file Word
    /// Hỗ trợ xuất DataGridView và DataTable ra file Word dạng bảng
    /// </summary>
    internal class WordExport
    {
        /// <summary>
        /// Xuất DataGridView ra file Word
        /// </summary>
        /// <param name="dgv">DataGridView cần xuất</param>
        /// <param name="filePath">Đường dẫn file xuất</param>
        /// <returns>True nếu xuất thành công</returns>
        public static bool ExportDataGridViewToWord(DataGridView dgv, string filePath)
        {
            Word.Application wordApp = null;
            Word.Document doc = null;

            try
            {
                if (dgv.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Khởi tạo Word Application
                wordApp = new Word.Application();
                wordApp.Visible = false;

                // Tạo document mới
                doc = wordApp.Documents.Add();

                // Thêm tiêu đề
                Word.Paragraph title = doc.Paragraphs.Add();
                title.Range.Text = "BÁO CÁO DỮ LIỆU";
                title.Range.Font.Size = 16;
                title.Range.Font.Bold = 1;
                title.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();

                // Thêm ngày xuất
                Word.Paragraph dateInfo = doc.Paragraphs.Add();
                dateInfo.Range.Text = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                dateInfo.Range.Font.Size = 11;
                dateInfo.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                dateInfo.Range.InsertParagraphAfter();
                dateInfo.Range.InsertParagraphAfter();

                // Đếm số cột hiển thị
                int visibleColumnCount = 0;
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Visible)
                        visibleColumnCount++;
                }

                if (visibleColumnCount == 0)
                {
                    throw new Exception("Không có cột hiển thị để xuất!");
                }

                // Tạo bảng
                int rowCount = dgv.Rows.Count;
                if (dgv.AllowUserToAddRows)
                    rowCount--; // Bỏ dòng thêm mới

                Word.Table table = doc.Tables.Add(
                    doc.Paragraphs[doc.Paragraphs.Count].Range,
                    rowCount + 1, // +1 cho header
                    visibleColumnCount
                );

                // Định dạng bảng
                table.Borders.Enable = 1;
                table.Range.Font.Size = 11;
                table.Range.Font.Name = "Arial";

                // Header
                table.Rows[1].Range.Font.Bold = 1;
                table.Rows[1].Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Rows[1].HeadingFormat = -1;

                int colIndex = 1;
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (!col.Visible) continue;
                    
                    table.Cell(1, colIndex).Range.Text = col.HeaderText;
                    table.Cell(1, colIndex).Range.ParagraphFormat.Alignment = 
                        Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    colIndex++;
                }

                // Dữ liệu
                int rowIndex = 2;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    colIndex = 1;
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (!col.Visible) continue;

                        object cellValue = row.Cells[col.Index].Value;
                        string text = cellValue?.ToString() ?? "";

                        // Format số tiền và số
                        if (cellValue != null)
                        {
                            if (col.DefaultCellStyle.Format == "N0" && decimal.TryParse(text, out decimal number))
                            {
                                text = number.ToString("N0");
                            }
                            else if (col.DefaultCellStyle.Format.Contains("dd/MM/yyyy") && DateTime.TryParse(text, out DateTime date))
                            {
                                text = date.ToString("dd/MM/yyyy");
                            }
                        }

                        table.Cell(rowIndex, colIndex).Range.Text = text;
                        colIndex++;
                    }
                    rowIndex++;
                }

                // Auto fit bảng
                table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
                table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);

                // Lưu file
                doc.SaveAs2(filePath);
                doc.Close();
                wordApp.Quit();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file Word: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Cleanup
                try
                {
                    if (doc != null)
                    {
                        doc.Close(false);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                    }
                    if (wordApp != null)
                    {
                        wordApp.Quit(false);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    }
                }
                catch { }

                return false;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        /// <summary>
        /// Xuất DataTable ra file Word
        /// </summary>
        /// <param name="dt">DataTable cần xuất</param>
        /// <param name="filePath">Đường dẫn file xuất</param>
        /// <returns>True nếu xuất thành công</returns>
        public static bool ExportDataTableToWord(DataTable dt, string filePath)
        {
            Word.Application wordApp = null;
            Word.Document doc = null;

            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Khởi tạo Word Application
                wordApp = new Word.Application();
                wordApp.Visible = false;

                // Tạo document mới
                doc = wordApp.Documents.Add();

                // Thêm tiêu đề
                Word.Paragraph title = doc.Paragraphs.Add();
                title.Range.Text = "BÁO CÁO DỮ LIỆU";
                title.Range.Font.Size = 16;
                title.Range.Font.Bold = 1;
                title.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();

                // Thêm ngày xuất
                Word.Paragraph dateInfo = doc.Paragraphs.Add();
                dateInfo.Range.Text = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                dateInfo.Range.Font.Size = 11;
                dateInfo.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                dateInfo.Range.InsertParagraphAfter();
                dateInfo.Range.InsertParagraphAfter();

                // Tạo bảng
                Word.Table table = doc.Tables.Add(
                    doc.Paragraphs[doc.Paragraphs.Count].Range,
                    dt.Rows.Count + 1, // +1 cho header
                    dt.Columns.Count
                );

                // Định dạng bảng
                table.Borders.Enable = 1;
                table.Range.Font.Size = 11;
                table.Range.Font.Name = "Arial";

                // Header
                table.Rows[1].Range.Font.Bold = 1;
                table.Rows[1].Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    table.Cell(1, i + 1).Range.Text = dt.Columns[i].ColumnName;
                    table.Cell(1, i + 1).Range.ParagraphFormat.Alignment = 
                        Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                // Dữ liệu
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string text = dt.Rows[i][j]?.ToString() ?? "";
                        table.Cell(i + 2, j + 1).Range.Text = text;
                    }
                }

                // Auto fit bảng
                table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
                table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);

                // Lưu file
                doc.SaveAs2(filePath);
                doc.Close();
                wordApp.Quit();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file Word: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Cleanup
                try
                {
                    if (doc != null)
                    {
                        doc.Close(false);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                    }
                    if (wordApp != null)
                    {
                        wordApp.Quit(false);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    }
                }
                catch { }

                return false;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        /// <summary>
        /// Hiển thị dialog lưu file và xuất DataGridView
        /// </summary>
        public static void ShowSaveDialogAndExport(DataGridView dgv, string defaultFileName)
        {
            try
            {
                // Đổi extension thành .docx
                defaultFileName = System.IO.Path.ChangeExtension(defaultFileName, ".docx");

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Word Document (*.docx)|*.docx|Word 97-2003 (*.doc)|*.doc|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.RestoreDirectory = true;
                saveDialog.FileName = defaultFileName;
                saveDialog.Title = "Xuất dữ liệu ra Word";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (ExportDataGridViewToWord(dgv, saveDialog.FileName))
                    {
                        if (MessageBox.Show("Xuất Word thành công!\n\nBạn có muốn mở file không?", 
                            "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị dialog lưu file và xuất DataTable
        /// </summary>
        public static void ShowSaveDialogAndExport(DataTable dt, string defaultFileName)
        {
            try
            {
                // Đổi extension thành .docx
                defaultFileName = System.IO.Path.ChangeExtension(defaultFileName, ".docx");

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Word Document (*.docx)|*.docx|Word 97-2003 (*.doc)|*.doc|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.RestoreDirectory = true;
                saveDialog.FileName = defaultFileName;
                saveDialog.Title = "Xuất dữ liệu ra Word";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (ExportDataTableToWord(dt, saveDialog.FileName))
                    {
                        if (MessageBox.Show("Xuất Word thành công!\n\nBạn có muốn mở file không?", 
                            "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

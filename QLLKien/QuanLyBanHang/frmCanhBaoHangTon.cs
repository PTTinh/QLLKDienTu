using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using QuanLyBanHang.Class;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyBanHang
{
    public partial class frmCanhBaoHangTon : Form
    {
        DataTable tblHangTon;

        public frmCanhBaoHangTon()
        {
            InitializeComponent();
        }

        private void frmCanhBaoHangTon_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadData();
        }

        private void LoadDanhMuc()
        {
            string sql = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc";
            cboDanhMuc.SelectedIndexChanged -= cboDanhMuc_SelectedIndexChanged;
            Functions.FillCombo(sql, cboDanhMuc, "MaDanhMuc", "TenDanhMuc");
            cboDanhMuc.SelectedIndex = -1;
            cboDanhMuc.SelectedIndexChanged += cboDanhMuc_SelectedIndexChanged;
        }

        private void LoadData(string where = "")
        {
            string sql = @"SELECT sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, 
                          dm.TenDanhMuc, sp.SoLuongTon, sp.TonToiThieu, sp.TonToiDa,
                          CASE 
                              WHEN sp.SoLuongTon = 0 THEN N'Hết hàng'
                              WHEN sp.SoLuongTon <= sp.TonToiThieu THEN N'Cảnh báo'
                              ELSE N'Bình thường'
                          END AS TrangThai
                          FROM SanPham sp
                          LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                          WHERE sp.SoLuongTon <= sp.TonToiThieu AND sp.TrangThai = 1";

            if (!string.IsNullOrEmpty(where))
                sql += " AND " + where;

            sql += " ORDER BY sp.SoLuongTon ASC";

            tblHangTon = Functions.GetDataToTable(sql);
            dgvHangTon.DataSource = tblHangTon;

            dgvHangTon.Columns[0].HeaderText = "Mã SP";
            dgvHangTon.Columns[1].HeaderText = "Mã số SP";
            dgvHangTon.Columns[2].HeaderText = "Tên sản phẩm";
            dgvHangTon.Columns[3].HeaderText = "Danh mục";
            dgvHangTon.Columns[4].HeaderText = "Tồn hiện tại";
            dgvHangTon.Columns[5].HeaderText = "Tồn tối thiểu";
            dgvHangTon.Columns[6].HeaderText = "Tồn tối đa";
            dgvHangTon.Columns[7].HeaderText = "Trạng thái";

            dgvHangTon.Columns[0].Width = 60;
            dgvHangTon.Columns[1].Width = 100;
            dgvHangTon.Columns[2].Width = 250;
            dgvHangTon.Columns[3].Width = 150;
            dgvHangTon.Columns[4].Width = 100;
            dgvHangTon.Columns[5].Width = 100;
            dgvHangTon.Columns[6].Width = 100;
            dgvHangTon.Columns[7].Width = 100;

            dgvHangTon.AllowUserToAddRows = false;
            dgvHangTon.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvHangTon.CellDoubleClick += DgvHangTon_CellDoubleClick;
            dgvHangTon.CellFormatting += DgvHangTon_CellFormatting;

            // Thống kê
            int tongSP = tblHangTon.Rows.Count;
            int hetHang = 0;
            int canhBao = 0;

            foreach (DataRow row in tblHangTon.Rows)
            {
                if (Convert.ToInt32(row["SoLuongTon"]) == 0)
                    hetHang++;
                else
                    canhBao++;
            }

            lblTongSP.Text = $"Tổng số sản phẩm cảnh báo: {tongSP}";
            lblHetHang.Text = $"Hết hàng: {hetHang}";
            lblSapHet.Text = $"Sắp hết: {canhBao}";
        }

        private void DgvHangTon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tô màu cho các dòng dựa trên số lượng tồn
            if (e.RowIndex >= 0 && dgvHangTon.Rows[e.RowIndex].Cells["SoLuongTon"].Value != null)
            {
                int ton = Convert.ToInt32(dgvHangTon.Rows[e.RowIndex].Cells["SoLuongTon"].Value);
                if (ton == 0)
                    dgvHangTon.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;  // Đỏ nhạt
                else
                    dgvHangTon.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;  // Vàng nhạt
            }
        }

        private void DgvHangTon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int maSP = Convert.ToInt32(dgvHangTon.CurrentRow.Cells["MaSanPham"].Value);
                    frmCapNhatSanPham frm = new frmCapNhatSanPham(maSP);
                    frm.ShowDialog();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedIndex >= 0 && cboDanhMuc.SelectedValue != null)
            {
                try
                {
                    string maDanhMuc = cboDanhMuc.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(maDanhMuc) && maDanhMuc != "System.Data.DataRowView")
                    {
                        LoadData($"sp.MaDanhMuc = {maDanhMuc}");
                    }
                    else
                    {
                        LoadData();
                    }
                }
                catch
                {
                    LoadData();
                }
            }
            else
            {
                LoadData();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboDanhMuc.SelectedIndex = -1;
            LoadData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (tblHangTon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
                saveDialog.DefaultExt = "xlsx";
                saveDialog.FileName = "DanhSachHangTon_" + DateTime.Now.ToString("ddMMyyyyHHmmss");

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application excelApp = new Excel.Application();
                    excelApp.Visible = false;

                    try
                    {
                        Excel.Workbook workbook = excelApp.Workbooks.Add();
                        Excel.Worksheet worksheet = workbook.Sheets[1];

                        // Tiêu đề
                        worksheet.Cells[1, 1] = "BÁO CÁO DANH SÁCH HÀNG TỒN";
                        worksheet.Range["A1"].Font.Size = 14;
                        worksheet.Range["A1"].Font.Bold = true;
                        worksheet.Range["A1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        worksheet.Range["A1:E1"].Merge();

                        // Ngày xuất
                        worksheet.Cells[2, 1] = "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        worksheet.Range["A2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]].Merge();

                        // Thống kê
                        worksheet.Cells[4, 1] = lblTongSP.Text;
                        worksheet.Cells[5, 1] = lblHetHang.Text;
                        worksheet.Cells[6, 1] = lblSapHet.Text;

                        // Header cột
                        for (int col = 0; col < tblHangTon.Columns.Count; col++)
                        {
                            worksheet.Cells[8, col + 1] = tblHangTon.Columns[col].ColumnName;
                            worksheet.Cells[8, col + 1].Font.Bold = true;
                            worksheet.Cells[8, col + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                            worksheet.Cells[8, col + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        }

                        // Dữ liệu
                        for (int row = 0; row < tblHangTon.Rows.Count; row++)
                        {
                            for (int col = 0; col < tblHangTon.Columns.Count; col++)
                            {
                                object cellValue = tblHangTon.Rows[row][col];
                                worksheet.Cells[row + 9, col + 1] = cellValue != null ? cellValue.ToString() : "";
                            }
                        }

                        // Căn chỉnh cột
                        worksheet.Columns[1].ColumnWidth = 10;  // Mã SP
                        worksheet.Columns[2].ColumnWidth = 15;  // Mã số SP
                        worksheet.Columns[3].ColumnWidth = 30;  // Tên SP
                        worksheet.Columns[4].ColumnWidth = 15;  // Danh mục
                        worksheet.Columns[5].ColumnWidth = 12;  // Tồn hiện tại
                        worksheet.Columns[6].ColumnWidth = 12;  // Tồn tối thiểu
                        worksheet.Columns[7].ColumnWidth = 12;  // Tồn tối đa
                        worksheet.Columns[8].ColumnWidth = 12;  // Trạng thái

                        // Lưu file
                        workbook.SaveAs(saveDialog.FileName);
                        workbook.Close();
                        excelApp.Quit();

                        MessageBox.Show($"Xuất dữ liệu thành công!\nFile: {saveDialog.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        excelApp?.Quit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


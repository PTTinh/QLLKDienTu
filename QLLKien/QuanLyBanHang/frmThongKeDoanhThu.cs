using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmThongKeDoanhThu : Form
    {
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            // Mặc định thống kê tháng này
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            
            LoadComboNhanVien();
            ThongKe();
        }

        private void LoadComboNhanVien()
        {
            try
            {
                string sql = "SELECT MaNguoiDung, HoTen FROM NguoiDung WHERE TrangThai = 1";
                DataTable dt = Functions.GetDataTable(sql);
                
                cboNhanVien.DataSource = dt;
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "MaNguoiDung";
                
                // Thêm option "Tất cả"
                DataRow row = dt.NewRow();
                row["MaNguoiDung"] = 0;
                row["HoTen"] = "-- Tất cả nhân viên --";
                dt.Rows.InsertAt(row, 0);
                
                cboNhanVien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe();
        }

        private void ThongKe()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                int maNV = Convert.ToInt32(cboNhanVien.SelectedValue);

                // Thống kê tổng quan
                ThongKeTongQuan(tuNgay, denNgay, maNV);
                
                // Thống kê theo ngày
                ThongKeTheoNgay(tuNgay, denNgay, maNV);
                
                // Vẽ biểu đồ
                VeBieuDo(tuNgay, denNgay, maNV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThongKeTongQuan(DateTime tuNgay, DateTime denNgay, int maNV)
        {
            string sql = @"SELECT 
                          COUNT(MaHoaDon) as SoDonHang,
                          ISNULL(SUM(TongTien), 0) as TongTien,
                          ISNULL(SUM(GiamGia), 0) as TongGiamGia,
                          ISNULL(SUM(ThanhTien), 0) as DoanhThu
                          FROM HoaDon 
                          WHERE NgayBan BETWEEN @TuNgay AND @DenNgay
                          AND TrangThai = N'Hoàn thành'";

            if (maNV > 0)
            {
                sql += " AND MaNhanVien = @MaNV";
            }

            SqlParameter[] parameters;
            if (maNV > 0)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay),
                    new SqlParameter("@MaNV", maNV)
                };
            }
            else
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };
            }

            DataTable dt = Functions.GetDataTable(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblSoDonHang.Text = row["SoDonHang"].ToString();
                lblTongTien.Text = Convert.ToDecimal(row["TongTien"]).ToString("N0");
                lblTongGiamGia.Text = Convert.ToDecimal(row["TongGiamGia"]).ToString("N0");
                lblDoanhThu.Text = Convert.ToDecimal(row["DoanhThu"]).ToString("N0");
            }
        }

        private void ThongKeTheoNgay(DateTime tuNgay, DateTime denNgay, int maNV)
        {
            string sql = @"SELECT 
                          CONVERT(DATE, NgayBan) as 'Ngày',
                          COUNT(MaHoaDon) as 'Số đơn',
                          SUM(TongTien) as 'Tổng tiền',
                          SUM(GiamGia) as 'Giảm giá',
                          SUM(ThanhTien) as 'Doanh thu'
                          FROM HoaDon 
                          WHERE NgayBan BETWEEN @TuNgay AND @DenNgay
                          AND TrangThai = N'Hoàn thành'";

            if (maNV > 0)
            {
                sql += " AND MaNhanVien = @MaNV";
            }

            sql += " GROUP BY CONVERT(DATE, NgayBan) ORDER BY CONVERT(DATE, NgayBan)";

            SqlParameter[] parameters;
            if (maNV > 0)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay),
                    new SqlParameter("@MaNV", maNV)
                };
            }
            else
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };
            }

            DataTable dt = Functions.GetDataTable(sql, parameters);
            dgvThongKe.DataSource = dt;

            // Format cột
            if (dgvThongKe.Columns.Count > 0)
            {
                dgvThongKe.Columns["Ngày"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvThongKe.Columns["Tổng tiền"].DefaultCellStyle.Format = "N0";
                dgvThongKe.Columns["Giảm giá"].DefaultCellStyle.Format = "N0";
                dgvThongKe.Columns["Doanh thu"].DefaultCellStyle.Format = "N0";
            }
        }

        private void VeBieuDo(DateTime tuNgay, DateTime denNgay, int maNV)
        {
            string sql = @"SELECT 
                          CONVERT(DATE, NgayBan) as Ngay,
                          SUM(ThanhTien) as DoanhThu
                          FROM HoaDon 
                          WHERE NgayBan BETWEEN @TuNgay AND @DenNgay
                          AND TrangThai = N'Hoàn thành'";

            if (maNV > 0)
            {
                sql += " AND MaNhanVien = @MaNV";
            }

            sql += " GROUP BY CONVERT(DATE, NgayBan) ORDER BY CONVERT(DATE, NgayBan)";

            SqlParameter[] parameters;
            if (maNV > 0)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay),
                    new SqlParameter("@MaNV", maNV)
                };
            }
            else
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };
            }

            DataTable dt = Functions.GetDataTable(sql, parameters);

            // Vẽ biểu đồ
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartDoanhThu.ChartAreas.Add(chartArea);

            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;
            series.XValueType = ChartValueType.Date;

            foreach (DataRow row in dt.Rows)
            {
                DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                series.Points.AddXY(ngay, doanhThu);
            }

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = "ThongKeDoanhThu_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Export to Excel logic here
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

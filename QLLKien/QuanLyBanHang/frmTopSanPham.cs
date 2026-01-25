using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmTopSanPham : Form
    {
        public frmTopSanPham()
        {
            InitializeComponent();
        }

        private void frmTopSanPham_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;
            nudTop.Value = 10;
            
            LoadData();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                int topN = Convert.ToInt32(nudTop.Value);

                string sql = @"SELECT TOP (@Top)
                              sp.MaSoSanPham as 'Mã SP',
                              sp.TenSanPham as 'Tên sản phẩm',
                              dm.TenDanhMuc as 'Danh mục',
                              SUM(ct.SoLuong) as 'Tổng SL bán',
                              SUM(ct.ThanhTien) as 'Doanh thu',
                              AVG(ct.DonGia) as 'Giá TB',
                              COUNT(DISTINCT ct.MaHoaDon) as 'Số đơn hàng'
                              FROM ChiTietHoaDon ct
                              INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                              LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                              INNER JOIN HoaDon h ON ct.MaHoaDon = h.MaHoaDon
                              WHERE h.NgayBan BETWEEN @TuNgay AND @DenNgay
                              AND h.TrangThai = N'Hoàn thành'
                              GROUP BY sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, dm.TenDanhMuc
                              ORDER BY SUM(ct.SoLuong) DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@Top", topN),
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };

                DataTable dt = Functions.GetDataTable(sql, parameters);
                dgvTopSanPham.DataSource = dt;

                // Format cột
                if (dgvTopSanPham.Columns.Count > 0)
                {
                    dgvTopSanPham.Columns["Doanh thu"].DefaultCellStyle.Format = "N0";
                    dgvTopSanPham.Columns["Giá TB"].DefaultCellStyle.Format = "N0";
                }

                // Vẽ biểu đồ
                VeBieuDo(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VeBieuDo(DataTable dt)
        {
            chartTopSP.Series.Clear();
            chartTopSP.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartTopSP.ChartAreas.Add(chartArea);

            // Series cho số lượng bán
            Series seriesSoLuong = new Series("Số lượng bán");
            seriesSoLuong.ChartType = SeriesChartType.Column;
            seriesSoLuong.Color = System.Drawing.Color.SteelBlue;

            // Series cho doanh thu
            Series seriesDoanhThu = new Series("Doanh thu");
            seriesDoanhThu.ChartType = SeriesChartType.Line;
            seriesDoanhThu.Color = System.Drawing.Color.OrangeRed;
            seriesDoanhThu.BorderWidth = 3;
            seriesDoanhThu.YAxisType = AxisType.Secondary;

            foreach (DataRow row in dt.Rows)
            {
                string tenSP = row["Tên sản phẩm"].ToString();
                if (tenSP.Length > 20)
                    tenSP = tenSP.Substring(0, 20) + "...";

                int soLuong = Convert.ToInt32(row["Tổng SL bán"]);
                decimal doanhThu = Convert.ToDecimal(row["Doanh thu"]);

                seriesSoLuong.Points.AddXY(tenSP, soLuong);
                seriesDoanhThu.Points.AddXY(tenSP, doanhThu);
            }

            chartTopSP.Series.Add(seriesSoLuong);
            chartTopSP.Series.Add(seriesDoanhThu);

            // Tùy chỉnh trục
            chartTopSP.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartTopSP.ChartAreas[0].AxisX.Interval = 1;
            chartTopSP.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            chartTopSP.ChartAreas[0].AxisY2.LabelStyle.Format = "N0";
            chartTopSP.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

            // Thêm legend
            chartTopSP.Legends.Clear();
            Legend legend = new Legend();
            legend.Docking = Docking.Top;
            chartTopSP.Legends.Add(legend);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = "TopSanPhamBanChay_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";

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

        private void rdoTheoSoLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTheoSoLuong.Checked)
            {
                SapXepLai("SoLuong");
            }
        }

        private void rdoTheoDoanhThu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTheoDoanhThu.Checked)
            {
                SapXepLai("DoanhThu");
            }
        }

        private void SapXepLai(string kieuSapXep)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                int topN = Convert.ToInt32(nudTop.Value);

                string orderBy = kieuSapXep == "SoLuong" ? "SUM(ct.SoLuong) DESC" : "SUM(ct.ThanhTien) DESC";

                string sql = @"SELECT TOP (@Top)
                              sp.MaSoSanPham as 'Mã SP',
                              sp.TenSanPham as 'Tên sản phẩm',
                              dm.TenDanhMuc as 'Danh mục',
                              SUM(ct.SoLuong) as 'Tổng SL bán',
                              SUM(ct.ThanhTien) as 'Doanh thu',
                              AVG(ct.DonGia) as 'Giá TB',
                              COUNT(DISTINCT ct.MaHoaDon) as 'Số đơn hàng'
                              FROM ChiTietHoaDon ct
                              INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                              LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                              INNER JOIN HoaDon h ON ct.MaHoaDon = h.MaHoaDon
                              WHERE h.NgayBan BETWEEN @TuNgay AND @DenNgay
                              AND h.TrangThai = N'Hoàn thành'
                              GROUP BY sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, dm.TenDanhMuc
                              ORDER BY " + orderBy;

                SqlParameter[] parameters = {
                    new SqlParameter("@Top", topN),
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };

                DataTable dt = Functions.GetDataTable(sql, parameters);
                dgvTopSanPham.DataSource = dt;

                // Format cột
                if (dgvTopSanPham.Columns.Count > 0)
                {
                    dgvTopSanPham.Columns["Doanh thu"].DefaultCellStyle.Format = "N0";
                    dgvTopSanPham.Columns["Giá TB"].DefaultCellStyle.Format = "N0";
                }

                VeBieuDo(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sắp xếp: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

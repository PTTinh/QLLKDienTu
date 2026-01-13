using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLLinhKienDT.Utils;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace QLLinhKienDT
{
    public partial class frmBaoCaoDoanhThu : Form
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            try
            {
                // Set default date range
                dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                dtpEndDate.Value = DateTime.Now;

                // Initialize period combobox
                cboTimePeriod.Items.Add("Theo ngày");
                cboTimePeriod.Items.Add("Theo tuần");
                cboTimePeriod.Items.Add("Theo tháng");
                cboTimePeriod.SelectedIndex = 0;

                LoadRevenueData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRevenueData()
        {
            try
            {
                string period = "";
                if (cboTimePeriod.SelectedIndex == 0) period = "day";
                else if (cboTimePeriod.SelectedIndex == 1) period = "week";
                else if (cboTimePeriod.SelectedIndex == 2) period = "month";

                DataTable dt = DataAccess.GetRevenueByPeriod(period, dtpStartDate.Value, dtpEndDate.Value);
                dgvRevenueData.DataSource = dt;

                // Format columns
                if (dgvRevenueData.Columns.Count > 0)
                {
                    dgvRevenueData.Columns["DoanhThu"].DefaultCellStyle.Format = "#,##0.00 ₫";
                }

                // Create chart
                LoadRevenueChart(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRevenueChart(DataTable dt)
        {
            try
            {
                // Create chart if not exists
                if (chartRevenue == null)
                {
                    chartRevenue = new Chart();
                    chartRevenue.Dock = DockStyle.Fill;
                    pnlChart.Controls.Add(chartRevenue);
                }

                chartRevenue.Series.Clear();
                chartRevenue.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea("DefaultChartArea");
                chartRevenue.ChartAreas.Add(chartArea);

                Series series = new Series("Doanh Thu");
                series.ChartType = SeriesChartType.Column;
                series.ChartArea = "DefaultChartArea";

                foreach (DataRow row in dt.Rows)
                {
                    string label = "";
                    if (cboTimePeriod.SelectedIndex == 0)
                        label = Convert.ToDateTime(row["Ngay"]).ToString("dd/MM/yyyy");
                    else if (cboTimePeriod.SelectedIndex == 1)
                        label = $"Tuần {row["Tuan"]}/{row["Nam"]}";
                    else if (cboTimePeriod.SelectedIndex == 2)
                        label = $"Tháng {row["Thang"]}/{row["Nam"]}";

                    series.Points.AddXY(label, Convert.ToDecimal(row["DoanhThu"]));
                }

                chartRevenue.Series.Add(series);

                // Format chart
                chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0.00 ₫";
                chartRevenue.Titles.Add("Biểu đồ doanh thu");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi vẽ biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTimePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRevenueData();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            LoadRevenueData();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            LoadRevenueData();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd_HHmmss}";
                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportDataToExcel(dgvRevenueData, sfd.FileName);
                    MessageBox.Show("Xuất file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd_HHmmss}";
                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Note: Requires iTextSharp or similar library
                    MessageBox.Show("Tính năng xuất PDF cần cấu hình thêm thư viện iTextSharp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExportDataToExcel(DataGridView dgv, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Write header
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    sw.Write(dgv.Columns[i].HeaderText);
                    if (i < dgv.Columns.Count - 1) sw.Write("\t");
                }
                sw.WriteLine();

                // Write data
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        sw.Write(dgv.Rows[i].Cells[j].Value);
                        if (j < dgv.Columns.Count - 1) sw.Write("\t");
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLLinhKienDT.Utils;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLLinhKienDT
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            FormTheme.ApplyTheme(this);
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                // Load today's revenue
                decimal todayRevenue = DataAccess.GetTodayRevenue();
                lblTodayRevenue.Text = todayRevenue.ToString("#,##0.00 ₫");

                // Load month revenue
                decimal monthRevenue = DataAccess.GetMonthRevenue();
                lblMonthRevenue.Text = monthRevenue.ToString("#,##0.00 ₫");

                // Load total customers
                int totalCustomers = DataAccess.GetTotalCustomers();
                lblTotalCustomers.Text = totalCustomers.ToString();

                // Load total orders
                int totalOrders = DataAccess.GetTotalOrders();
                lblTotalOrders.Text = totalOrders.ToString();

                // Load low stock alerts
                LoadLowStockAlerts();

                // Load revenue summary chart
                LoadRevenueSummaryChart();

                // Load category revenue chart
                LoadCategoryRevenueChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dashboard: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLowStockAlerts()
        {
            try
            {
                DataTable dt = DataAccess.GetLowStockAlerts();
                dgvLowStockAlerts.DataSource = dt;

                // Format columns
                if (dgvLowStockAlerts.Columns.Count > 0)
                {
                    dgvLowStockAlerts.Columns["SoLuongTon"].DefaultCellStyle.BackColor = 
                        (dgvLowStockAlerts.Rows.Count > 0) ? Color.LightCoral : Color.White;
                }

                // Update alert count
                int alertCount = dt.Rows.Count;
                lblAlertCount.Text = alertCount.ToString();
                lblAlertMessage.Text = alertCount > 0 ? 
                    $"⚠ Có {alertCount} sản phẩm tồn kho thấp!" : 
                    "✓ Tất cả sản phẩm đều trong tình trạng bình thường";
                lblAlertMessage.ForeColor = alertCount > 0 ? Color.Red : Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải cảnh báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRevenueSummaryChart()
        {
            try
            {
                // Create chart if not exists
                if (chartRevenueSummary == null)
                {
                    chartRevenueSummary = new Chart();
                    chartRevenueSummary.Dock = DockStyle.Fill;
                    pnlRevenueSummary.Controls.Add(chartRevenueSummary);
                }

                chartRevenueSummary.Series.Clear();
                chartRevenueSummary.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea("DefaultChartArea");
                chartRevenueSummary.ChartAreas.Add(chartArea);

                Series series = new Series("Doanh thu");
                series.ChartType = SeriesChartType.Pie;
                series.ChartArea = "DefaultChartArea";

                decimal todayRevenue = DataAccess.GetTodayRevenue();
                decimal monthRevenue = DataAccess.GetMonthRevenue();

                series.Points.AddXY("Hôm nay", Convert.ToDouble(todayRevenue));
                series.Points.AddXY("Tháng này", Convert.ToDouble(monthRevenue - todayRevenue));

                chartRevenueSummary.Series.Add(series);
                chartRevenueSummary.Titles.Add("Doanh thu");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi vẽ biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategoryRevenueChart()
        {
            try
            {
                // Create chart if not exists
                if (chartCategoryRevenue == null)
                {
                    chartCategoryRevenue = new Chart();
                    chartCategoryRevenue.Dock = DockStyle.Fill;
                    pnlCategoryRevenue.Controls.Add(chartCategoryRevenue);
                }

                chartCategoryRevenue.Series.Clear();
                chartCategoryRevenue.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea("DefaultChartArea");
                chartCategoryRevenue.ChartAreas.Add(chartArea);

                Series series = new Series("Doanh thu");
                series.ChartType = SeriesChartType.Column;
                series.ChartArea = "DefaultChartArea";

                DateTime startDate = DateTime.Now.AddMonths(-1);
                DateTime endDate = DateTime.Now;

                DataTable dt = DataAccess.GetRevenueByCategory(startDate, endDate);

                foreach (DataRow row in dt.Rows)
                {
                    string categoryName = Convert.ToString(row["TenDanhMuc"]);
                    decimal revenue = Convert.ToDecimal(row["TongDoanhThu"]);
                    series.Points.AddXY(categoryName, Convert.ToDouble(revenue));
                }

                chartCategoryRevenue.Series.Add(series);
                chartCategoryRevenue.Titles.Add("Doanh thu theo danh mục");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi vẽ biểu đồ danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
            MessageBox.Show("Dashboard đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Timer event to auto-refresh
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            LoadDashboard();
        }
    }
}

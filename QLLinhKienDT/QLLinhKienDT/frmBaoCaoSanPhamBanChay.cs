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
using System.IO;

namespace QLLinhKienDT
{
    public partial class frmBaoCaoSanPhamBanChay : Form
    {
        public frmBaoCaoSanPhamBanChay()
        {
            InitializeComponent();
        }

        private void frmBaoCaoSanPhamBanChay_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            try
            {
                LoadTopSellingProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTopSellingProducts()
        {
            try
            {
                DataTable dt = DataAccess.GetTopSellingProducts(10);
                dgvTopProducts.DataSource = dt;

                // Format columns
                if (dgvTopProducts.Columns.Count > 0)
                {
                    if (dgvTopProducts.Columns.Contains("DoanhThu"))
                        dgvTopProducts.Columns["DoanhThu"].DefaultCellStyle.Format = "#,##0.00 ₫";
                    if (dgvTopProducts.Columns.Contains("SoLuongBan"))
                        dgvTopProducts.Columns["SoLuongBan"].DefaultCellStyle.Format = "#,##0";
                }

                // Create chart
                LoadTopProductsChart(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTopProductsChart(DataTable dt)
        {
            try
            {
                // Create chart if not exists
                if (chartTopProducts == null)
                {
                    chartTopProducts = new Chart();
                    chartTopProducts.Dock = DockStyle.Fill;
                    pnlChart.Controls.Add(chartTopProducts);
                }

                chartTopProducts.Series.Clear();
                chartTopProducts.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea("DefaultChartArea");
                chartTopProducts.ChartAreas.Add(chartArea);

                Series series = new Series("Số lượng bán");
                series.ChartType = SeriesChartType.Bar;
                series.ChartArea = "DefaultChartArea";

                foreach (DataRow row in dt.Rows)
                {
                    string label = Convert.ToString(row["TenSanPham"]);
                    series.Points.AddXY(label, Convert.ToInt32(row["SoLuongBan"]));
                }

                chartTopProducts.Series.Add(series);

                // Format chart
                chartTopProducts.Titles.Add("Top 10 Sản phẩm bán chạy");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi vẽ biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductsByCategory()
        {
            try
            {
                DataTable dt = DataAccess.GetTopSellingProductsByCategory();
                dgvTopProducts.DataSource = dt;

                // Format columns
                if (dgvTopProducts.Columns.Count > 0)
                {
                    if (dgvTopProducts.Columns.Contains("DoanhThu"))
                        dgvTopProducts.Columns["DoanhThu"].DefaultCellStyle.Format = "#,##0.00 ₫";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu theo danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTopProducts_Click(object sender, EventArgs e)
        {
            LoadTopSellingProducts();
        }

        private void btnByCategory_Click(object sender, EventArgs e)
        {
            LoadProductsByCategory();
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = $"BaoCaoSanPhamBanChay_{DateTime.Now:yyyyMMdd_HHmmss}";
                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportDataToExcel(dgvTopProducts, sfd.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

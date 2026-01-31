using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLCHBanLinhKien
{
    public partial class frmReportViewer : Form
    {
        private string _reportPath;
        private DataTable _dataSource;
        private string _dataSetName;
        private ReportParameter[] _parameters;

        public frmReportViewer()
        {
            InitializeComponent();
        }

        public frmReportViewer(string reportPath, DataTable dataSource, string dataSetName, string reportTitle, ReportParameter[] parameters = null)
        {
            InitializeComponent();
            _reportPath = reportPath;
            _dataSource = dataSource;
            _dataSetName = dataSetName;
            _parameters = parameters;
            this.Text = reportTitle;
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                // Kiểm tra file tồn tại
                if (!File.Exists(_reportPath))
                {
                    MessageBox.Show("Không tìm thấy file báo cáo:\n" + _reportPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reportViewer1.LocalReport.ReportPath = _reportPath;
                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource(_dataSetName, _dataSource);
                reportViewer1.LocalReport.DataSources.Add(rds);

                if (_parameters != null && _parameters.Length > 0)
                {
                    reportViewer1.LocalReport.SetParameters(_parameters);
                }

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message + "\n\nChi tiết: " + ex.InnerException?.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lấy đường dẫn file report
        /// </summary>
        private static string GetReportPath(string reportFileName)
        {
            // Thử nhiều đường dẫn khác nhau
            string[] paths = new string[]
            {
                Path.Combine(Application.StartupPath, "Reports", reportFileName),
                Path.Combine(Application.StartupPath, reportFileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", reportFileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportFileName)
            };

            foreach (string path in paths)
            {
                if (File.Exists(path))
                    return path;
            }

            // Trả về đường dẫn mặc định nếu không tìm thấy
            return paths[0];
        }

        /// <summary>
        /// Hiển thị báo cáo cảnh báo hàng tồn kho
        /// </summary>
        public static void ShowCanhBaoHangTon(DataTable data, int mucCanhBao)
        {
            string reportPath = GetReportPath("rptCanhBaoHangTon.rdlc");
            
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("MucCanhBao", mucCanhBao.ToString()),
                new ReportParameter("NgayBaoCao", DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
            };

            frmReportViewer frm = new frmReportViewer(reportPath, data, "DataSet1", "Báo cáo cảnh báo hàng tồn kho", parameters);
            frm.ShowDialog();
        }

        /// <summary>
        /// Hiển thị báo cáo doanh thu
        /// </summary>
        public static void ShowDoanhThu(DataTable data, DateTime tuNgay, DateTime denNgay, decimal tongThanhTien)
        {
            string reportPath = GetReportPath("rptDoanhThu.rdlc");
            
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("TuNgay", tuNgay.ToString("dd/MM/yyyy")),
                new ReportParameter("DenNgay", denNgay.ToString("dd/MM/yyyy")),
                new ReportParameter("TongThanhTien", tongThanhTien.ToString("N0"))
            };

            frmReportViewer frm = new frmReportViewer(reportPath, data, "DataSet1", "Báo cáo doanh thu", parameters);
            frm.ShowDialog();
        }

        /// <summary>
        /// Hiển thị báo cáo thống kê nhân viên
        /// </summary>
        public static void ShowThongKeNhanVien(DataTable data, DateTime tuNgay, DateTime denNgay, decimal tongDoanhThu, int tongHoaDon)
        {
            string reportPath = GetReportPath("rptThongKeNhanVien.rdlc");
            
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("TuNgay", tuNgay.ToString("dd/MM/yyyy")),
                new ReportParameter("DenNgay", denNgay.ToString("dd/MM/yyyy")),
                new ReportParameter("TongDoanhThu", tongDoanhThu.ToString("N0")),
                new ReportParameter("TongHoaDon", tongHoaDon.ToString("N0"))
            };

            frmReportViewer frm = new frmReportViewer(reportPath, data, "DataSet1", "Bao cao thong ke nhan vien", parameters);
            frm.ShowDialog();
        }
    }
}

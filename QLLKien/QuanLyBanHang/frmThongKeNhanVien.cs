using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmThongKeNhanVien : Form
    {
        public frmThongKeNhanVien()
        {
            InitializeComponent();
        }

        private void frmThongKeNhanVien_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            string sql = $@"SELECT 
                              nv.MaNguoiDung,
                              nv.TenDangNhap,
                              nv.HoTen,
                              COUNT(DISTINCT hd.MaHoaDon) AS SoHoaDon,
                              ISNULL(SUM(hd.ThanhTien), 0) AS TongDoanhThu,
                              ISNULL(AVG(hd.ThanhTien), 0) AS TrungBinhHoaDon
                            FROM NguoiDung nv
                            LEFT JOIN HoaDon hd ON nv.MaNguoiDung = hd.MaNhanVien 
                                AND hd.NgayBan >= '{dtpTuNgay.Value:yyyy-MM-dd}' 
                                AND hd.NgayBan < '{dtpDenNgay.Value.AddDays(1):yyyy-MM-dd}'
                            WHERE nv.VaiTro IN (N'Nhân viên', N'Quản lý')
                            GROUP BY nv.MaNguoiDung, nv.TenDangNhap, nv.HoTen
                            ORDER BY TongDoanhThu DESC";

            DataTable dt = Functions.GetDataToTable(sql);
            dgvThongKe.DataSource = dt;

            dgvThongKe.Columns[0].HeaderText = "Mã NV";
            dgvThongKe.Columns[1].HeaderText = "Tên đăng nhập";
            dgvThongKe.Columns[2].HeaderText = "Họ tên";
            dgvThongKe.Columns[3].HeaderText = "Số hóa đơn";
            dgvThongKe.Columns[4].HeaderText = "Tổng doanh thu";
            dgvThongKe.Columns[5].HeaderText = "TB hóa đơn";

            dgvThongKe.Columns[0].Width = 80;
            dgvThongKe.Columns[1].Width = 150;
            dgvThongKe.Columns[2].Width = 200;
            dgvThongKe.Columns[3].Width = 100;
            dgvThongKe.Columns[4].Width = 150;
            dgvThongKe.Columns[5].Width = 150;

            dgvThongKe.Columns[4].DefaultCellStyle.Format = "N0";
            dgvThongKe.Columns[5].DefaultCellStyle.Format = "N0";

            // Tính tổng
            decimal tongDoanhThu = 0;
            int tongHoaDon = 0;

            foreach (DataRow row in dt.Rows)
            {
                tongDoanhThu += Convert.ToDecimal(row["TongDoanhThu"]);
                tongHoaDon += Convert.ToInt32(row["SoHoaDon"]);
            }

            lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
            lblTongHoaDon.Text = tongHoaDon.ToString();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadThongKe();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveDialog.FilterIndex = 0;
            saveDialog.RestoreDirectory = true;
            saveDialog.CreatePrompt = true;
            saveDialog.FileName = $"ThongKeNhanVien_{DateTime.Now:yyyyMMdd}";
            saveDialog.Title = "Xuất báo cáo";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // TODO: Implement Excel export
                    MessageBox.Show("Chức năng xuất Excel đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

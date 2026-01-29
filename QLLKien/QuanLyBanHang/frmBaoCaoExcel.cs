using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmBaoCaoExcel : Form
    {
        public frmBaoCaoExcel()
        {
            InitializeComponent();
        }

        private void frmBaoCaoExcel_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                string sqlHoaDon = @"SELECT h.SoHoaDon, h.NgayBan, h.TongTien, h.GiamGia, 
                                    h.ThanhTien, h.TrangThai,
                                    k.HoTen as TenKhachHang
                             FROM HoaDon h
                             LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                             WHERE CONVERT(DATE, h.NgayBan) BETWEEN @TuNgay AND @DenNgay
                             ORDER BY h.NgayBan DESC";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@TuNgay", dtpTuNgay.Value.ToString("yyyy-MM-dd")),
                    new System.Data.SqlClient.SqlParameter("@DenNgay", dtpDenNgay.Value.ToString("yyyy-MM-dd"))
                };

                DataTable dtHoaDon = Functions.GetDataTable(sqlHoaDon, parameters);
                dgvHoaDon.DataSource = dtHoaDon;

                // Định dạng cột
                dgvHoaDon.Columns[0].HeaderText = "Số Hóa Đơn";
                dgvHoaDon.Columns[1].HeaderText = "Ngày Bán";
                dgvHoaDon.Columns[2].HeaderText = "Tổng Tiền";
                dgvHoaDon.Columns[3].HeaderText = "Chiết Khấu";
                dgvHoaDon.Columns[4].HeaderText = "Thành Tiền";
                dgvHoaDon.Columns[5].HeaderText = "Trạng Thái";
                dgvHoaDon.Columns[6].HeaderText = "Tên KH";

                dgvHoaDon.Columns[0].Width = 120;
                dgvHoaDon.Columns[1].Width = 150;
                dgvHoaDon.Columns[2].Width = 120;
                dgvHoaDon.Columns[3].Width = 120;
                dgvHoaDon.Columns[4].Width = 120;
                dgvHoaDon.Columns[5].Width = 100;
                dgvHoaDon.Columns[6].Width = 150;

                // Tính tổng
                decimal tongTienAll = 0;
                decimal giamGiaAll = 0;
                decimal thanhTienAll = 0;

                foreach (DataRow row in dtHoaDon.Rows)
                {
                    tongTienAll += Convert.ToDecimal(row["TongTien"]);
                    giamGiaAll += Convert.ToDecimal(row["GiamGia"]);
                    thanhTienAll += Convert.ToDecimal(row["ThanhTien"]);
                }

                lbTongHD.Text = "Tổng số hóa đơn: " + dtHoaDon.Rows.Count;
                lbTongTien.Text = "Tổng tiền: " + tongTienAll.ToString("N0");
                lbGiamGia.Text = "Chiết khấu: " + giamGiaAll.ToString("N0");
                lbThanhTien.Text = "Thành tiền: " + thanhTienAll.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.DataSource == null || dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtHoaDon = dgvHoaDon.DataSource as DataTable;
            ExcelExporter.ExportHoaDonListToExcel(dtHoaDon);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

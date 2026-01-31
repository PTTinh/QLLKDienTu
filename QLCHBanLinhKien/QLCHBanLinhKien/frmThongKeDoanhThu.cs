using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmThongKeDoanhThu : Form
    {
        private DataTable dtDoanhThu;

        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            // Mac dinh: thang hien tai
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Functions.Connect();

                string sql = @"SELECT hd.MaHoaDon, hd.NgayBan, kh.HoTen AS TenKH, hd.TongTien, hd.GiamGia, hd.ThanhTien
                               FROM HoaDon hd
                               LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                               WHERE hd.NgayBan >= @TuNgay AND hd.NgayBan <= @DenNgay
                               ORDER BY hd.NgayBan DESC";

                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtDoanhThu = new DataTable();
                da.Fill(dtDoanhThu);

                dgvDoanhThu.DataSource = dtDoanhThu;

                // Format columns
                if (dgvDoanhThu.Columns["MaHoaDon"] != null)
                    dgvDoanhThu.Columns["MaHoaDon"].HeaderText = "Ma HD";
                if (dgvDoanhThu.Columns["NgayBan"] != null)
                    dgvDoanhThu.Columns["NgayBan"].HeaderText = "Ngay ban";
                if (dgvDoanhThu.Columns["TenKH"] != null)
                    dgvDoanhThu.Columns["TenKH"].HeaderText = "Khach hang";
                if (dgvDoanhThu.Columns["TongTien"] != null)
                {
                    dgvDoanhThu.Columns["TongTien"].HeaderText = "Tong tien";
                    dgvDoanhThu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                }
                if (dgvDoanhThu.Columns["GiamGia"] != null)
                {
                    dgvDoanhThu.Columns["GiamGia"].HeaderText = "Giam gia";
                    dgvDoanhThu.Columns["GiamGia"].DefaultCellStyle.Format = "N0";
                }
                if (dgvDoanhThu.Columns["ThanhTien"] != null)
                {
                    dgvDoanhThu.Columns["ThanhTien"].HeaderText = "Thanh tien";
                    dgvDoanhThu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }

                // Tinh tong
                TinhTong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai du lieu: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Functions.Disconnect();
            }
        }

        private void TinhTong()
        {
            decimal tongDoanhThu = 0;
            decimal tongGiamGia = 0;
            decimal tongThanhTien = 0;
            int soHoaDon = dgvDoanhThu.Rows.Count;

            foreach (DataGridViewRow row in dgvDoanhThu.Rows)
            {
                if (row.Cells["TongTien"].Value != null)
                    tongDoanhThu += Convert.ToDecimal(row.Cells["TongTien"].Value);
                if (row.Cells["GiamGia"].Value != null)
                    tongGiamGia += Convert.ToDecimal(row.Cells["GiamGia"].Value);
                if (row.Cells["ThanhTien"].Value != null)
                    tongThanhTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }

            lblSoHoaDon.Text = soHoaDon.ToString("N0");
            lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VND";
            lblTongGiamGia.Text = tongGiamGia.ToString("N0") + " VND";
            lblThanhTien.Text = tongThanhTien.ToString("N0") + " VND";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngay bat dau khong the lon hon ngay ket thuc!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadData();
        }

        private void btnHomNay_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;
            LoadData();
        }

        private void btnThangNay_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }

        private void btnNamNay_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (dtDoanhThu == null || dtDoanhThu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongThanhTien = 0;
            foreach (DataGridViewRow row in dgvDoanhThu.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                    tongThanhTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }

            frmReportViewer.ShowDoanhThu(dtDoanhThu, dtpTuNgay.Value, dtpDenNgay.Value, tongThanhTien);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmTimHoaDon : Form
    {
        public frmTimHoaDon()
        {
            InitializeComponent();
        }

        private void frmTimHoaDon_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Today;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Functions.Connect();

                string sql = @"SELECT hd.MaHoaDon, hd.NgayBan, ISNULL(kh.HoTen, N'Khách lẻ') as TenKH, nd.TenDangNhap as NhanVien, 
                               hd.TongTien, hd.GiamGia, hd.ThanhTien
                               FROM HoaDon hd
                               LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                               LEFT JOIN NguoiDung nd ON hd.MaNhanVien = nd.MaNguoiDung
                               WHERE hd.NgayBan >= @TuNgay AND hd.NgayBan <= @DenNgay";

                // Tim theo ma hoa don
                if (!string.IsNullOrWhiteSpace(txtMaHD.Text))
                {
                    sql += " AND hd.MaHoaDon LIKE @MaHD";
                }

                // Tim theo ten khach hang
                if (!string.IsNullOrWhiteSpace(txtKhachHang.Text))
                {
                    sql += " AND kh.HoTen LIKE @TenKH";
                }

                sql += " ORDER BY hd.NgayBan DESC";

                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                if (!string.IsNullOrWhiteSpace(txtMaHD.Text))
                {
                    cmd.Parameters.AddWithValue("@MaHD", "%" + txtMaHD.Text.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtKhachHang.Text))
                {
                    cmd.Parameters.AddWithValue("@TenKH", "%" + txtKhachHang.Text.Trim() + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvHoaDon.DataSource = dt;

                // Format columns
                if (dgvHoaDon.Columns["MaHoaDon"] != null)
                    dgvHoaDon.Columns["MaHoaDon"].HeaderText = "Ma HD";
                if (dgvHoaDon.Columns["NgayBan"] != null)
                    dgvHoaDon.Columns["NgayBan"].HeaderText = "Ngay ban";
                if (dgvHoaDon.Columns["TenKH"] != null)
                    dgvHoaDon.Columns["TenKH"].HeaderText = "Khach hang";
                if (dgvHoaDon.Columns["NhanVien"] != null)
                    dgvHoaDon.Columns["NhanVien"].HeaderText = "Nhan vien";
                if (dgvHoaDon.Columns["TongTien"] != null)
                {
                    dgvHoaDon.Columns["TongTien"].HeaderText = "Tong tien";
                    dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                }
                if (dgvHoaDon.Columns["GiamGia"] != null)
                {
                    dgvHoaDon.Columns["GiamGia"].HeaderText = "Giam gia";
                    dgvHoaDon.Columns["GiamGia"].DefaultCellStyle.Format = "N0";
                }
                if (dgvHoaDon.Columns["ThanhTien"] != null)
                {
                    dgvHoaDon.Columns["ThanhTien"].HeaderText = "Thanh tien";
                    dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }

                lblTongHD.Text = "Tong so hoa don: " + dt.Rows.Count.ToString();
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngay bat dau khong the lon hon ngay ket thuc!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadData();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon hoa don can xem!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value);
            frmChiTietHoaDon frm = new frmChiTietHoaDon(maHD);
            frm.ShowDialog();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Clear();
            txtKhachHang.Clear();
            dtpTuNgay.Value = DateTime.Today.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Today;
            LoadData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnXemChiTiet_Click(sender, e);
            }
        }
    }
}

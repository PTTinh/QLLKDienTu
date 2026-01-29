using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmChiTietHoaDon : Form
    {
        private int _maHD;

        public frmChiTietHoaDon(int maHD)
        {
            InitializeComponent();
            _maHD = maHD;
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDonInfo();
            LoadChiTietHoaDon();
        }

        private void LoadHoaDonInfo()
        {
            try
            {
                Functions.Connect();

                string sql = @"SELECT hd.MaHoaDon, hd.SoHoaDon, hd.NgayBan, kh.HoTen as TenKH, kh.SoDienThoai as DienThoai, kh.DiaChi,
                               nd.TenDangNhap as NhanVien, hd.TongTien, hd.GiamGia, hd.ThanhTien, hd.PhuongThucThanhToan
                               FROM HoaDon hd
                               LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                               LEFT JOIN NguoiDung nd ON hd.MaNhanVien = nd.MaNguoiDung
                               WHERE hd.MaHoaDon = @MaHD";

                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                cmd.Parameters.AddWithValue("@MaHD", _maHD);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblMaHD.Text = reader["SoHoaDon"].ToString();
                    lblNgayBan.Text = Convert.ToDateTime(reader["NgayBan"]).ToString("dd/MM/yyyy HH:mm");
                    lblKhachHang.Text = reader["TenKH"]?.ToString() ?? "Khach le";
                    lblDienThoai.Text = reader["DienThoai"]?.ToString() ?? "";
                    lblDiaChi.Text = reader["DiaChi"]?.ToString() ?? "";
                    lblNhanVien.Text = reader["NhanVien"]?.ToString() ?? "";
                    lblTongTien.Text = Convert.ToDecimal(reader["TongTien"]).ToString("N0") + " VND";
                    lblGiamGia.Text = Convert.ToDecimal(reader["GiamGia"]).ToString("N0") + " VND";
                    lblThanhTien.Text = Convert.ToDecimal(reader["ThanhTien"]).ToString("N0") + " VND";
                    lblGhiChu.Text = reader["PhuongThucThanhToan"]?.ToString() ?? "";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai thong tin hoa don: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Functions.Disconnect();
            }
        }

        private void LoadChiTietHoaDon()
        {
            try
            {
                Functions.Connect();

                string sql = @"SELECT ct.MaSanPham, sp.TenSanPham as TenSP, ct.DonGia, ct.SoLuong, ct.ThanhTien
                               FROM ChiTietHoaDon ct
                               INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                               WHERE ct.MaHoaDon = @MaHD";

                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                cmd.Parameters.AddWithValue("@MaHD", _maHD);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvChiTiet.DataSource = dt;

                // Format columns
                if (dgvChiTiet.Columns["MaSanPham"] != null)
                    dgvChiTiet.Columns["MaSanPham"].HeaderText = "Ma SP";
                if (dgvChiTiet.Columns["TenSP"] != null)
                    dgvChiTiet.Columns["TenSP"].HeaderText = "Ten san pham";
                if (dgvChiTiet.Columns["DonGia"] != null)
                {
                    dgvChiTiet.Columns["DonGia"].HeaderText = "Don gia";
                    dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                }
                if (dgvChiTiet.Columns["SoLuong"] != null)
                    dgvChiTiet.Columns["SoLuong"].HeaderText = "So luong";
                if (dgvChiTiet.Columns["ThanhTien"] != null)
                {
                    dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thanh tien";
                    dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai chi tiet hoa don: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Functions.Disconnect();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chuc nang in hoa don dang phat trien!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

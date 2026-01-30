using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmChiTietHoaDon : Form
    {
        private int maHoaDon;

        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }

        public frmChiTietHoaDon(int maHD)
        {
            InitializeComponent();
            this.maHoaDon = maHD;
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadThongTinHoaDon();
            LoadChiTietHoaDon();
        }

        private void LoadThongTinHoaDon()
        {
            try
            {
                string sql = @"SELECT h.SoHoaDon, h.NgayBan, 
                              k.MaSoKhachHang, k.HoTen as TenKhachHang, 
                              k.SoDienThoai, k.DiaChi, k.LoaiKhachHang,
                              n.HoTen as TenNhanVien,
                              h.TongTien, h.GiamGia, h.ThueVAT, h.ThanhTien, 
                              h.PhuongThucThanhToan, h.TrangThai
                              FROM HoaDon h
                              LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                              LEFT JOIN NguoiDung n ON h.MaNhanVien = n.MaNguoiDung
                              WHERE h.MaHoaDon = @MaHoaDon";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaHoaDon", maHoaDon)
                };

                DataTable dt = Functions.GetDataTable(sql, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    lblSoHoaDon.Text = row["SoHoaDon"].ToString();
                    lblNgayBan.Text = Convert.ToDateTime(row["NgayBan"]).ToString("dd/MM/yyyy HH:mm:ss");
                    lblMaKH.Text = row["MaSoKhachHang"]?.ToString() ?? "---";
                    lblTenKH.Text = row["TenKhachHang"]?.ToString() ?? "Khách lẻ";
                    lblSoDienThoai.Text = row["SoDienThoai"]?.ToString() ?? "---";
                    lblDiaChi.Text = row["DiaChi"]?.ToString() ?? "---";
                    lblLoaiKH.Text = row["LoaiKhachHang"]?.ToString() ?? "---";
                    lblNhanVien.Text = row["TenNhanVien"]?.ToString() ?? "---";
                    
                    lblTongTien.Text = Convert.ToDecimal(row["TongTien"]).ToString("N0");
                    lblGiamGia.Text = Convert.ToDecimal(row["GiamGia"]).ToString("N0");
                    lblThueVAT.Text = Convert.ToDecimal(row["ThueVAT"]).ToString("N0");
                    lblThanhTien.Text = Convert.ToDecimal(row["ThanhTien"]).ToString("N0");
                    lblPhuongThuc.Text = row["PhuongThucThanhToan"]?.ToString() ?? "---";
                    lblTrangThai.Text = row["TrangThai"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin hóa đơn: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTietHoaDon()
        {
            try
            {
                string sql = @"SELECT 
                              sp.MaSoSanPham as 'Mã SP',
                              sp.TenSanPham as 'Tên sản phẩm',
                              ct.SoLuong as 'Số lượng',
                              ct.DonGia as 'Đơn giá',
                              ct.GiamGia as 'Giảm giá',
                              ct.ThanhTien as 'Thành tiền'
                              FROM ChiTietHoaDon ct
                              INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                              WHERE ct.MaHoaDon = @MaHoaDon";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaHoaDon", maHoaDon)
                };

                DataTable dt = Functions.GetDataTable(sql, parameters);
                dgvChiTiet.DataSource = dt;

                // Format cột
                dgvChiTiet.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["Giảm giá"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";

                dgvChiTiet.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInHoaDon frm = new frmInHoaDon(maHoaDon);
            frm.ShowDialog();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    /// <summary>
    /// Form hiển thị chi tiết một hóa đơn cụ thể
    /// Bao gồm: thông tin hóa đơn, khách hàng, nhân viên và danh sách sản phẩm
    /// </summary>
    public partial class frmChiTietHoaDon : Form
    {
        // Mã hóa đơn cần hiển thị
        private int _maHD;

        /// <summary>
        /// Constructor - nhận mã hóa đơn cần xem
        /// </summary>
        /// <param name="maHD">Mã hóa đơn trong database</param>
        public frmChiTietHoaDon(int maHD)
        {
            InitializeComponent();
            _maHD = maHD;
        }

        /// <summary>
        /// Sự kiện load form
        /// Load thông tin hóa đơn và chi tiết sản phẩm
        /// </summary>
        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDonInfo();    // Load thông tin chung của hóa đơn
            LoadChiTietHoaDon(); // Load danh sách sản phẩm
        }

        /// <summary>
        /// Load và hiển thị thông tin chung của hóa đơn
        /// Bao gồm: số HD, ngày bán, khách hàng, nhân viên, tổng tiền...
        /// </summary>
        private void LoadHoaDonInfo()
        {
            try
            {
                Functions.Connect();

                // Query lấy thông tin hóa đơn kèm khách hàng và nhân viên
                string sql = @"SELECT hd.MaHoaDon, hd.SoHoaDon, hd.NgayBan, 
                               kh.HoTen as TenKH, 
                               nd.HoTen as NhanVien, 
                               hd.TongTien, hd.GiamGia, hd.ThanhTien, hd.PhuongThucThanhToan
                               FROM HoaDon hd
                               LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                               LEFT JOIN NguoiDung nd ON hd.MaNhanVien = nd.MaNguoiDung
                               WHERE hd.MaHoaDon = @MaHD";

                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                cmd.Parameters.AddWithValue("@MaHD", _maHD);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    // Hiển thị thông tin lên các Label
                    lblMaHD.Text = reader["SoHoaDon"].ToString();
                    lblNgayBan.Text = Convert.ToDateTime(reader["NgayBan"]).ToString("dd/MM/yyyy HH:mm");
                    
                    lblKhachHang.Text = reader["TenKH"].ToString() ?? "";

                    lblNhanVien.Text = reader["NhanVien"].ToString() ?? "";
                    
                    // Format hiển thị số tiền
                    lblTongTien.Text = Convert.ToDecimal(reader["TongTien"]).ToString("N0") + " VND";
                    lblGiamGia.Text = Convert.ToDecimal(reader["GiamGia"]).ToString("N0") + " VND";
                    lblThanhTien.Text = Convert.ToDecimal(reader["ThanhTien"]).ToString("N0") + " VND";
                    
                    // Phương thức thanh toán (nếu có)
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

        /// <summary>
        /// Load danh sách sản phẩm trong hóa đơn
        /// </summary>
        private void LoadChiTietHoaDon()
        {
            try
            {
                Functions.Connect();

                // Query lấy chi tiết: mã SP, tên SP, đơn giá, số lượng, thành tiền
                string sql = @"SELECT ct.MaSanPham, sp.TenSanPham as TenSP, 
                               ct.DonGia, ct.SoLuong, ct.ThanhTien
                               FROM ChiTietHoaDon ct
                               INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                               WHERE ct.MaHoaDon = @MaHD";

                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                cmd.Parameters.AddWithValue("@MaHD", _maHD);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gán dữ liệu vào DataGridView
                dgvChiTiet.DataSource = dt;

                // === Format hiển thị các cột ===
                if (dgvChiTiet.Columns["MaSanPham"] != null)
                    dgvChiTiet.Columns["MaSanPham"].HeaderText = "Ma SP";
                    
                if (dgvChiTiet.Columns["TenSP"] != null)
                    dgvChiTiet.Columns["TenSP"].HeaderText = "Ten san pham";
                    
                if (dgvChiTiet.Columns["DonGia"] != null)
                {
                    dgvChiTiet.Columns["DonGia"].HeaderText = "Don gia";
                    dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0"; // Format tiền
                }
                
                if (dgvChiTiet.Columns["SoLuong"] != null)
                    dgvChiTiet.Columns["SoLuong"].HeaderText = "So luong";
                    
                if (dgvChiTiet.Columns["ThanhTien"] != null)
                {
                    dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thanh tien";
                    dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0"; // Format tiền
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

        /// <summary>
        /// Sự kiện click nút In hóa đơn
        /// Mở form in hóa đơn với RDLC Report
        /// </summary>
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở form in hóa đơn, truyền mã hóa đơn
                frmInHoaDon frm = new frmInHoaDon(_maHD);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở form in hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Sự kiện click nút Đóng
        /// </summary>
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

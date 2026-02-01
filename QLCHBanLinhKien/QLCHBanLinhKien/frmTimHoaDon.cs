using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    /// <summary>
    /// Form tìm kiếm hóa đơn theo nhiều tiêu chí:
    /// - Khoảng thời gian (từ ngày - đến ngày)
    /// - Mã hóa đơn
    /// - Tên khách hàng
    /// </summary>
    public partial class frmTimHoaDon : Form
    {
        public frmTimHoaDon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện load form
        /// Thiết lập khoảng thời gian mặc định: 1 tháng gần nhất
        /// </summary>
        private void frmTimHoaDon_Load(object sender, EventArgs e)
        {
            // Mặc định tìm hóa đơn trong 1 tháng gần nhất
            dtpTuNgay.Value = DateTime.Today.AddMonths(-1);  // Từ ngày: 1 tháng trước
            dtpDenNgay.Value = DateTime.Today;              // Đến ngày: hôm nay
            LoadData(); // Load danh sách hóa đơn
        }

        /// <summary>
        /// Load danh sách hóa đơn theo các điều kiện tìm kiếm
        /// </summary>
        private void LoadData()
        {
            try
            {
                Functions.Connect(); // Mở kết nối database

                // Câu SQL cơ bản - lấy hóa đơn trong khoảng thời gian
                string sql = @"SELECT hd.MaHoaDon, hd.NgayBan, 
                               ISNULL(kh.HoTen, N'Khách lẻ') as TenKH,
                               nd.TenDangNhap as NhanVien, 
                               hd.TongTien, hd.GiamGia, hd.ThanhTien
                               FROM HoaDon hd
                               LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                               LEFT JOIN NguoiDung nd ON hd.MaNhanVien = nd.MaNguoiDung
                               WHERE hd.NgayBan >= @TuNgay AND hd.NgayBan <= @DenNgay";

                // Thêm điều kiện tìm theo mã hóa đơn (nếu có nhập)
                if (!string.IsNullOrWhiteSpace(txtMaHD.Text))
                {
                    sql += " AND hd.MaHoaDon LIKE @MaHD";
                }

                // Thêm điều kiện tìm theo tên khách hàng (nếu có nhập)
                if (!string.IsNullOrWhiteSpace(txtKhachHang.Text))
                {
                    sql += " AND kh.HoTen LIKE @TenKH";
                }

                sql += " ORDER BY hd.NgayBan DESC"; // Sắp xếp mới nhất lên trên

                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                
                // Thêm parameter cho khoảng thời gian
                cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                // Đến cuối ngày (23:59:59) của ngày được chọn
                cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                // Thêm parameter mã hóa đơn nếu có
                if (!string.IsNullOrWhiteSpace(txtMaHD.Text))
                {
                    cmd.Parameters.AddWithValue("@MaHD", "%" + txtMaHD.Text.Trim() + "%");
                }

                // Thêm parameter tên khách hàng nếu có
                // Thêm parameter cho khoảng thời gian
                cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                // Đến cuối ngày (23:59:59) của ngày được chọn
                cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                // Thực thi query và fill vào DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gán dữ liệu vào DataGridView
                dgvHoaDon.DataSource = dt;

                // === Format hiển thị các cột ===
                if (dgvHoaDon.Columns["MaHoaDon"] != null)
                    dgvHoaDon.Columns["MaHoaDon"].HeaderText = "Ma HD";
                if (dgvHoaDon.Columns["NgayBan"] != null)
                    dgvHoaDon.Columns["NgayBan"].HeaderText = "Ngay ban";
                if (dgvHoaDon.Columns["TenKH"] != null)
                    dgvHoaDon.Columns["TenKH"].HeaderText = "Khach hang";
                if (dgvHoaDon.Columns["NhanVien"] != null)
                    dgvHoaDon.Columns["NhanVien"].HeaderText = "Nhan vien";
                    
                // Format cột tiền với dấu phân cách hàng nghìn
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

                // Hiển thị tổng số hóa đơn tìm được
                lblTongHD.Text = "Tong so hoa don: " + dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai du lieu: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Functions.Disconnect(); // Đảm bảo đóng kết nối
            }
        }

        /// <summary>
        /// Sự kiện click nút Tìm kiếm
        /// Validate ngày và load dữ liệu
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Kiểm tra ngày bắt đầu không được lớn hơn ngày kết thúc
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngay bat dau khong the lon hon ngay ket thuc!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadData();
        }

        /// <summary>
        /// Sự kiện click nút Xem chi tiết
        /// Mở form chi tiết hóa đơn
        /// </summary>
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn hóa đơn chưa
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon hoa don can xem!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã hóa đơn và mở form chi tiết
            int maHD = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value);
            frmChiTietHoaDon frm = new frmChiTietHoaDon(maHD);
            frm.ShowDialog(); // Mở dạng modal
        }

        /// <summary>
        /// Sự kiện click nút Làm mới
        /// Reset tất cả điều kiện tìm kiếm về mặc định
        /// </summary>
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Clear();                              // Xóa mã hóa đơn
            txtKhachHang.Clear();                         // Xóa tên khách hàng
            dtpTuNgay.Value = DateTime.Today.AddMonths(-1); // Reset từ ngày
            dtpDenNgay.Value = DateTime.Today;            // Reset đến ngày
            LoadData();                                   // Load lại dữ liệu
        }

        /// <summary>
        /// Sự kiện click nút Đóng
        /// </summary>
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sự kiện double-click vào hóa đơn
        /// Mở form chi tiết (giống nút Xem chi tiết)
        /// </summary>
        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo click vào dòng dữ liệu
            {
                btnXemChiTiet_Click(sender, e);
            }
        }
    }
}

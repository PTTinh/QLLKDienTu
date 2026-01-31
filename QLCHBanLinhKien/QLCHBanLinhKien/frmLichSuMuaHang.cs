using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    /// <summary>
    /// Form xem lịch sử mua hàng của khách hàng
    /// Có thể xem theo từng khách hàng hoặc tất cả
    /// Hỗ trợ lọc theo khoảng thời gian
    /// </summary>
    public partial class frmLichSuMuaHang : Form
    {
        // Mã khách hàng được truyền vào (null = xem tất cả)
        private int? maKhachHang = null;

        /// <summary>
        /// Constructor mặc định - xem lịch sử tất cả khách hàng
        /// </summary>
        public frmLichSuMuaHang()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor với mã khách hàng - xem lịch sử của 1 khách hàng cụ thể
        /// </summary>
        /// <param name="maKhachHang">Mã khách hàng cần xem</param>
        public frmLichSuMuaHang(int maKhachHang)
        {
            InitializeComponent();
            this.maKhachHang = maKhachHang;
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        private void frmLichSuMuaHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();      // Load danh sách khách hàng vào ComboBox
            SetupDataGridView();  // Thiết lập cấu trúc DataGridView

            // Nếu được truyền mã khách hàng thì tự động chọn
            if (maKhachHang.HasValue)
            {
                cmbKhachHang.SelectedValue = maKhachHang.Value;
            }

            // Mặc định hiển thị 1 tháng gần nhất
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;
        }

        /// <summary>
        /// Load danh sách khách hàng vào ComboBox
        /// Thêm option "Tất cả khách hàng" ở đầu
        /// </summary>
        private void LoadKhachHang()
        {
            try
            {
                string query = "SELECT MaKhachHang, HoTen FROM KhachHang ORDER BY HoTen";
                DataTable dt = Functions.GetDataTable(query);

                // Thêm dòng "Tất cả khách hàng" với MaKhachHang = 0
                DataRow allRow = dt.NewRow();
                allRow["MaKhachHang"] = 0;
                allRow["HoTen"] = "-- Tất cả khách hàng --";
                dt.Rows.InsertAt(allRow, 0); // Chèn vào đầu danh sách

                // Bind dữ liệu vào ComboBox
                cmbKhachHang.DataSource = dt;
                cmbKhachHang.DisplayMember = "HoTen";      // Hiển thị tên
                cmbKhachHang.ValueMember = "MaKhachHang";  // Giá trị là mã
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Thiết lập cấu trúc và format cho DataGridView
        /// Định nghĩa các cột hiển thị
        /// </summary>
        private void SetupDataGridView()
        {
            dgvLichSu.AutoGenerateColumns = false; // Không tự động tạo cột
            dgvLichSu.Columns.Clear(); // Xóa các cột cũ

            // Thêm các cột theo thứ tự mong muốn
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoHoaDon", HeaderText = "Số hóa đơn", DataPropertyName = "SoHoaDon", Width = 100 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayBan", HeaderText = "Ngày bán", DataPropertyName = "NgayBan", Width = 100 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKhachHang", HeaderText = "Khách hàng", DataPropertyName = "TenKhachHang", Width = 150 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "TongTien", HeaderText = "Tổng tiền", DataPropertyName = "TongTien", Width = 100 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiamGia", HeaderText = "Giảm giá", DataPropertyName = "GiamGia", Width = 80 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThanhTien", HeaderText = "Thành tiền", DataPropertyName = "ThanhTien", Width = 110 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "PhuongThuc", HeaderText = "Thanh toán", DataPropertyName = "PhuongThucThanhToan", Width = 100 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 100 });

            // Format hiển thị
            dgvLichSu.Columns["NgayBan"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvLichSu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvLichSu.Columns["GiamGia"].DefaultCellStyle.Format = "N0";
            dgvLichSu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            
            // Căn phải cho các cột tiền
            dgvLichSu.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLichSu.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLichSu.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Load dữ liệu lịch sử mua hàng theo điều kiện lọc
        /// </summary>
        private void LoadData()
        {
            try
            {
                // Câu SQL lấy lịch sử hóa đơn
                string query = @"SELECT h.MaHoaDon, h.SoHoaDon, h.NgayBan, 
                                 ISNULL(k.HoTen, N'Khách lẻ') AS TenKhachHang,
                                 h.TongTien, h.GiamGia, h.ThanhTien, 
                                 h.PhuongThucThanhToan, h.TrangThai
                                 FROM HoaDon h
                                 LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                                 WHERE h.NgayBan >= @TuNgay AND h.NgayBan < @DenNgay";

                // Nếu chọn khách hàng cụ thể (không phải "Tất cả")
                int selectedKH = Convert.ToInt32(cmbKhachHang.SelectedValue);
                if (selectedKH > 0)
                {
                    query += " AND h.MaKhachHang = @MaKhachHang";
                }

                query += " ORDER BY h.NgayBan DESC";

                // Xây dựng mảng parameters
                SqlParameter[] parameters;
                if (selectedKH > 0)
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TuNgay", dtpTuNgay.Value.Date),
                        new SqlParameter("@DenNgay", dtpDenNgay.Value.Date.AddDays(1)), // Đến hết ngày
                        new SqlParameter("@MaKhachHang", selectedKH)
                    };
                }
                else
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TuNgay", dtpTuNgay.Value.Date),
                        new SqlParameter("@DenNgay", dtpDenNgay.Value.Date.AddDays(1))
                    };
                }

                DataTable dt = Functions.GetDataTable(query, parameters);
                dgvLichSu.DataSource = dt;

                // === Tính tổng thống kê ===
                decimal tongTien = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
                }
                
                // Hiển thị thống kê
                lblTongHoaDon.Text = dt.Rows.Count.ToString();
                lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện click nút Tìm kiếm
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Sự kiện double-click vào hóa đơn
        /// Mở form chi tiết hóa đơn
        /// </summary>
        private void dgvLichSu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Lấy MaHoaDon từ dòng được click
                    DataRowView drv = (DataRowView)dgvLichSu.Rows[e.RowIndex].DataBoundItem;
                    int maHoaDon = Convert.ToInt32(drv["MaHoaDon"]);
                    
                    // Mở form chi tiết
                    frmChiTietHoaDon frm = new frmChiTietHoaDon(maHoaDon);
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi mở chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

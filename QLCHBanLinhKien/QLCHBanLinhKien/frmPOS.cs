using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    /// <summary>
    /// Form POS (Point of Sale) - Màn hình bán hàng chính
    /// Cho phép nhân viên chọn sản phẩm, thêm vào giỏ hàng và thanh toán
    /// </summary>
    public partial class frmPOS : Form
    {
        // DataTable lưu trữ danh sách sản phẩm trong giỏ hàng
        private DataTable dtGioHang;
        
        // Lưu mã khách hàng được chọn (0 = khách lẻ)
        private int selectedKhachHangId = 0;
        
        /// <summary>
        /// Constructor khởi tạo form
        /// </summary>
        public frmPOS()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện khi form được load
        /// Khởi tạo các thành phần và load dữ liệu ban đầu
        /// </summary>
        private void frmPOS_Load(object sender, EventArgs e)
        {
            KhoiTaoGioHang();    // Tạo cấu trúc bảng giỏ hàng
            LoadDanhMuc();        // Load danh sách danh mục sản phẩm
            LoadSanPham();        // Load danh sách sản phẩm
            LoadKhachHang();      // Load danh sách khách hàng
            ResetForm();          // Đặt lại form về trạng thái ban đầu
        }

        /// <summary>
        /// Khởi tạo cấu trúc DataTable cho giỏ hàng
        /// Định nghĩa các cột: MaSanPham, MaSoSanPham, TenSanPham, DonGia, SoLuong, ThanhTien
        /// </summary>
        private void KhoiTaoGioHang()
        {
            // Tạo DataTable mới cho giỏ hàng
            dtGioHang = new DataTable();
            
            // Định nghĩa các cột trong giỏ hàng
            dtGioHang.Columns.Add("MaSanPham", typeof(int));      // Mã sản phẩm (ẩn)
            dtGioHang.Columns.Add("MaSoSanPham", typeof(string)); // Mã số sản phẩm hiển thị
            dtGioHang.Columns.Add("TenSanPham", typeof(string));  // Tên sản phẩm
            dtGioHang.Columns.Add("DonGia", typeof(decimal));     // Đơn giá
            dtGioHang.Columns.Add("SoLuong", typeof(int));        // Số lượng mua
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal));  // Thành tiền = DonGia * SoLuong
            
            // Gán DataTable vào DataGridView
            dgvGioHang.DataSource = dtGioHang;
            
            // Ẩn cột MaSanPham vì không cần hiển thị cho người dùng
            dgvGioHang.Columns["MaSanPham"].Visible = false;
            
            // Đặt tiêu đề các cột cho dễ đọc
            dgvGioHang.Columns["MaSoSanPham"].HeaderText = "Ma SP";
            dgvGioHang.Columns["TenSanPham"].HeaderText = "Ten san pham";
            dgvGioHang.Columns["DonGia"].HeaderText = "Don gia";
            dgvGioHang.Columns["SoLuong"].HeaderText = "SL";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thanh tien";
            
            // Format hiển thị số tiền (không có số thập phân)
            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        /// <summary>
        /// Load danh sách danh mục sản phẩm vào ComboBox
        /// Thêm option "Tất cả" ở đầu danh sách
        /// </summary>
        private void LoadDanhMuc()
        {
            cboDanhMuc.Items.Clear();
            cboDanhMuc.Items.Add("-- Tat ca --"); // Option mặc định để hiển thị tất cả sản phẩm
            
            // Lấy danh sách danh mục từ database
            string sql = "SELECT TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc";
            DataTable dt = Functions.GetDataToTable(sql);
            
            // Thêm từng danh mục vào ComboBox
            foreach (DataRow row in dt.Rows)
            {
                cboDanhMuc.Items.Add(row["TenDanhMuc"].ToString());
            }
            
            // Chọn option đầu tiên (Tất cả)
            cboDanhMuc.SelectedIndex = 0;
        }

        /// <summary>
        /// Load danh sách sản phẩm từ database
        /// Có thể lọc theo danh mục và từ khóa tìm kiếm
        /// Chỉ hiển thị sản phẩm còn hàng (SoLuongTon > 0)
        /// </summary>
        /// <param name="danhMuc">Tên danh mục để lọc (null = tất cả)</param>
        /// <param name="keyword">Từ khóa tìm kiếm theo mã hoặc tên sản phẩm</param>
        private void LoadSanPham(string danhMuc = null, string keyword = null)
        {
            // Câu SQL cơ bản - chỉ lấy sản phẩm còn hàng
            string sql = @"SELECT sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, sp.GiaBan, sp.SoLuongTon,
                          dm.TenDanhMuc
                          FROM SanPham sp
                          LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                          WHERE sp.SoLuongTon > 0 ";
            
            // Thêm điều kiện lọc theo danh mục nếu có
            if (!string.IsNullOrEmpty(danhMuc) && danhMuc != "-- Tat ca --")
            {
                sql += " AND dm.TenDanhMuc = @DanhMuc";
            }
            
            // Thêm điều kiện tìm kiếm theo mã hoặc tên sản phẩm
            if (!string.IsNullOrEmpty(keyword))
            {
                sql += " AND (sp.MaSoSanPham LIKE @Keyword OR sp.TenSanPham LIKE @Keyword)";
            }
            
            sql += " ORDER BY sp.TenSanPham";
            
            // Xây dựng mảng parameters tùy theo điều kiện lọc
            SqlParameter[] parameters;
            if (!string.IsNullOrEmpty(danhMuc) && danhMuc != "-- Tat ca --" && !string.IsNullOrEmpty(keyword))
            {
                // Có cả danh mục và từ khóa
                parameters = new SqlParameter[] {
                    new SqlParameter("@DanhMuc", danhMuc),
                    new SqlParameter("@Keyword", "%" + keyword + "%")
                };
            }
            else if (!string.IsNullOrEmpty(danhMuc) && danhMuc != "-- Tat ca --")
            {
                // Chỉ có danh mục
                parameters = new SqlParameter[] { new SqlParameter("@DanhMuc", danhMuc) };
            }
            else if (!string.IsNullOrEmpty(keyword))
            {
                // Chỉ có từ khóa
                parameters = new SqlParameter[] { new SqlParameter("@Keyword", "%" + keyword + "%") };
            }
            else
            {
                // Không có điều kiện lọc
                parameters = new SqlParameter[0];
            }
            
            // Thực thi query và gán kết quả vào DataGridView
            DataTable dt = Functions.GetDataTable(sql, parameters);
            dgvSanPham.DataSource = dt;
            
            // Format hiển thị các cột
            if (dgvSanPham.Columns.Count > 0)
            {
                dgvSanPham.Columns["MaSanPham"].Visible = false;  // Ẩn cột mã nội bộ
                dgvSanPham.Columns["MaSoSanPham"].HeaderText = "Ma SP";
                dgvSanPham.Columns["TenSanPham"].HeaderText = "Ten san pham";
                dgvSanPham.Columns["GiaBan"].HeaderText = "Gia ban";
                dgvSanPham.Columns["SoLuongTon"].HeaderText = "Ton kho";
                dgvSanPham.Columns["TenDanhMuc"].HeaderText = "Danh muc";
                dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0"; // Format tiền
            }
        }

        /// <summary>
        /// Load danh sách khách hàng vào ComboBox
        /// Thêm option "Khách lẻ" ở đầu cho trường hợp không có thông tin khách
        /// </summary>
        private void LoadKhachHang()
        {
            cboKhachHang.Items.Clear();
            cboKhachHang.Items.Add("-- Chon khach hang --"); // Placeholder bắt buộc chọn
            
            // Lấy danh sách khách hàng từ database
            string sql = "SELECT MaKhachHang, HoTen, SoDienThoai FROM KhachHang ORDER BY HoTen";
            DataTable dt = Functions.GetDataToTable(sql);
            
            // Thêm từng khách hàng vào ComboBox với format: "Họ tên - SĐT"
            foreach (DataRow row in dt.Rows)
            {
                string display = row["HoTen"].ToString();
                if (row["SoDienThoai"] != DBNull.Value && !string.IsNullOrEmpty(row["SoDienThoai"].ToString()))
                {
                    display += " - " + row["SoDienThoai"].ToString();
                }
                // Sử dụng ComboBoxItem để lưu cả Value (MaKhachHang) và Text (hiển thị)
                cboKhachHang.Items.Add(new ComboBoxItem(Convert.ToInt32(row["MaKhachHang"]), display));
            }
            
            cboKhachHang.SelectedIndex = 0; // Chọn placeholder
        }

        /// <summary>
        /// Reset form về trạng thái ban đầu
        /// Xóa giỏ hàng, reset khách hàng và tính lại tổng tiền
        /// </summary>
        private void ResetForm()
        {
            dtGioHang.Rows.Clear();        // Xóa tất cả sản phẩm trong giỏ
            selectedKhachHangId = 0;        // Reset khách hàng
            cboKhachHang.SelectedIndex = 0; // Chọn placeholder
            txtGhiChu.Text = "";            // Xóa ghi chú
            numGiamGia.Value = 0;           // Reset giảm giá về 0
            cboPhuongThucThanhToan.SelectedIndex = 0; // Reset phương thức thanh toán về Tiền mặt
            TinhTongTien();                 // Cập nhật hiển thị tổng tiền
        }

        /// <summary>
        /// Tính tổng tiền giỏ hàng và cập nhật hiển thị
        /// Tổng tiền = Tổng thành tiền các sản phẩm - Giảm giá
        /// </summary>
        private void TinhTongTien()
        {
            decimal tongTien = 0;
            
            // Cộng dồn thành tiền của từng sản phẩm trong giỏ
            foreach (DataRow row in dtGioHang.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }
            
            // Lấy số tiền giảm giá
            decimal giamGia = numGiamGia.Value;
            
            // Tính số tiền phải thanh toán (không được âm)
            decimal thanhToan = tongTien - giamGia;
            if (thanhToan < 0) thanhToan = 0;
            
            // Cập nhật hiển thị trên label
            lblTongTien.Text = tongTien.ToString("N0") + " VND";
            lblThanhToan.Text = thanhToan.ToString("N0") + " VND";
        }

        /// <summary>
        /// Sự kiện double-click vào sản phẩm trong danh sách
        /// Tự động thêm sản phẩm vào giỏ hàng
        /// </summary>
        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo click vào dòng dữ liệu, không phải header
            {
                ThemVaoGioHang();
            }
        }

        /// <summary>
        /// Sự kiện click nút "Thêm vào giỏ"
        /// </summary>
        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            ThemVaoGioHang();
        }

        /// <summary>
        /// Thêm sản phẩm đang chọn vào giỏ hàng
        /// Nếu sản phẩm đã có trong giỏ thì tăng số lượng lên 1
        /// Kiểm tra số lượng tồn kho trước khi thêm
        /// </summary>
        private void ThemVaoGioHang()
        {
            // Kiểm tra có sản phẩm nào được chọn không
            if (dgvSanPham.CurrentRow == null) return;
            
            // Lấy thông tin sản phẩm từ dòng đang chọn
            int maSP = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value);
            string maSoSP = dgvSanPham.CurrentRow.Cells["MaSoSanPham"].Value?.ToString() ?? "";
            string tenSP = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value?.ToString() ?? "";
            decimal giaBan = Convert.ToDecimal(dgvSanPham.CurrentRow.Cells["GiaBan"].Value);
            int tonKho = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["SoLuongTon"].Value);
            
            // Kiểm tra sản phẩm đã có trong giỏ hàng chưa
            foreach (DataRow row in dtGioHang.Rows)
            {
                if (Convert.ToInt32(row["MaSanPham"]) == maSP)
                {
                    // Sản phẩm đã có - tăng số lượng
                    int soLuongHienTai = Convert.ToInt32(row["SoLuong"]);
                    
                    // Kiểm tra tồn kho đủ không
                    if (soLuongHienTai + 1 > tonKho)
                    {
                        MessageBox.Show("So luong trong kho khong du!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    // Cập nhật số lượng và thành tiền
                    row["SoLuong"] = soLuongHienTai + 1;
                    row["ThanhTien"] = Convert.ToDecimal(row["DonGia"]) * (soLuongHienTai + 1);
                    TinhTongTien();
                    return;
                }
            }
            
            // Sản phẩm chưa có trong giỏ - thêm mới
            DataRow newRow = dtGioHang.NewRow();
            newRow["MaSanPham"] = maSP;
            newRow["MaSoSanPham"] = maSoSP;
            newRow["TenSanPham"] = tenSP;
            newRow["DonGia"] = giaBan;
            newRow["SoLuong"] = 1;               // Số lượng mặc định = 1
            newRow["ThanhTien"] = giaBan;        // Thành tiền = đơn giá * 1
            dtGioHang.Rows.Add(newRow);
            
            TinhTongTien(); // Cập nhật tổng tiền
        }

        /// <summary>
        /// Xóa sản phẩm đang chọn khỏi giỏ hàng
        /// </summary>
        private void btnXoaKhoiGio_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null) return;
            
            int index = dgvGioHang.CurrentRow.Index;
            if (index >= 0 && index < dtGioHang.Rows.Count)
            {
                dtGioHang.Rows.RemoveAt(index); // Xóa dòng theo index
                TinhTongTien();                  // Cập nhật tổng tiền
            }
        }

        /// <summary>
        /// Xóa tất cả sản phẩm trong giỏ hàng
        /// Hiển thị xác nhận trước khi xóa
        /// </summary>
        private void btnXoaGioHang_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0) return; // Giỏ hàng đã trống
            
            // Hiển thị hộp thoại xác nhận
            if (MessageBox.Show("Xoa tat ca san pham trong gio hang?", "Xac nhan", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtGioHang.Rows.Clear(); // Xóa tất cả
                TinhTongTien();          // Cập nhật tổng tiền
            }
        }

        /// <summary>
        /// Xử lý thanh toán đơn hàng
        /// 1. Tạo hóa đơn mới
        /// 2. Thêm chi tiết hóa đơn
        /// 3. Cập nhật tồn kho
        /// 4. Cập nhật tổng chi tiêu khách hàng
        /// </summary>
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra giỏ hàng có sản phẩm không
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Gio hang trong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Kiểm tra đã chọn khách hàng chưa (bắt buộc)
            if (cboKhachHang.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui long chon khach hang!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhachHang.Focus();
                return;
            }
            
            // Lấy mã khách hàng đã chọn
            selectedKhachHangId = ((ComboBoxItem)cboKhachHang.SelectedItem).Value;
            
            // === BƯỚC 1: Tính toán tổng tiền ===
            decimal tongTien = 0;
            foreach (DataRow row in dtGioHang.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }
            decimal giamGia = numGiamGia.Value;
            decimal thanhToan = tongTien - giamGia;
            if (thanhToan < 0) thanhToan = 0;
            
            // === BƯỚC 2: Tạo mã hóa đơn theo format: HD + yyyyMMddHHmmss ===
            string maHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            
            // Lấy phương thức thanh toán
            string phuongThucThanhToan = cboPhuongThucThanhToan.SelectedItem?.ToString() ?? "Tiền mặt";
            
            // === BƯỚC 3: Insert hóa đơn vào database ===
            string sqlHoaDon = @"INSERT INTO HoaDon (SoHoaDon, NgayBan, MaKhachHang, TongTien, GiamGia, ThanhTien, MaNhanVien, PhuongThucThanhToan)
                                VALUES (@MaHD, GETDATE(), @MaKH, @TongTien, @GiamGia, @ThanhTien, @MaNV, @PhuongThuc);
                                SELECT SCOPE_IDENTITY();"; // Lấy ID vừa insert
            
            SqlParameter[] paramsHD = {
                new SqlParameter("@MaHD", maHD),
                new SqlParameter("@MaKH", selectedKhachHangId), // Luôn có khách hàng (bắt buộc)
                new SqlParameter("@TongTien", tongTien),
                new SqlParameter("@GiamGia", giamGia),
                new SqlParameter("@ThanhTien", thanhToan),
                new SqlParameter("@MaNV", frmLogin.MaNguoiDung), // Mã nhân viên đang đăng nhập
                new SqlParameter("@PhuongThuc", phuongThucThanhToan)
            };
            
            // Thực thi và lấy MaHoaDon vừa tạo
            object result = Functions.GetFieldValues(sqlHoaDon, paramsHD);
            if (result == null)
            {
                MessageBox.Show("Loi tao hoa don!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            int maHoaDon = Convert.ToInt32(result);
            
            // === BƯỚC 4: Thêm chi tiết hóa đơn và cập nhật tồn kho ===
            foreach (DataRow row in dtGioHang.Rows)
            {
                int maSP = Convert.ToInt32(row["MaSanPham"]);
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                decimal thanhTienItem = Convert.ToDecimal(row["ThanhTien"]);
                
                // Insert chi tiết hóa đơn
                string sqlCT = @"INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien)
                                VALUES (@MaHD, @MaSP, @SL, @DonGia, @ThanhTien)";
                SqlParameter[] paramsCT = {
                    new SqlParameter("@MaHD", maHoaDon),
                    new SqlParameter("@MaSP", maSP),
                    new SqlParameter("@SL", soLuong),
                    new SqlParameter("@DonGia", donGia),
                    new SqlParameter("@ThanhTien", thanhTienItem)
                };  
                Functions.RunSQL(sqlCT, paramsCT);
                
                // Trừ số lượng tồn kho
                string sqlCapNhat = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL WHERE MaSanPham = @MaSP";
                SqlParameter[] paramsCapNhat = {
                    new SqlParameter("@SL", soLuong),
                    new SqlParameter("@MaSP", maSP)
                };
                Functions.RunSQL(sqlCapNhat, paramsCapNhat);
            }
            

            // === BƯỚC 5: Cập nhật tổng chi tiêu khách hàng ===
            string sqlCapNhatKH = "UPDATE KhachHang SET TongChiTieu = TongChiTieu + @TongTien WHERE MaKhachHang = @MaKH";
            SqlParameter[] paramsKH = {
                new SqlParameter("@TongTien", thanhToan),
                new SqlParameter("@MaKH", selectedKhachHangId)
            };
            Functions.RunSQL(sqlCapNhatKH, paramsKH);
            
            // Thông báo thành công
            MessageBox.Show("Thanh toan thanh cong!\nMa hoa don: " + maHD, "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Reset form để chuẩn bị đơn hàng mới
            ResetForm();
            LoadSanPham(); // Reload danh sách sản phẩm (cập nhật tồn kho)
        }

        /// <summary>
        /// Sự kiện khi thay đổi danh mục - lọc lại danh sách sản phẩm
        /// </summary>
        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string danhMuc = cboDanhMuc.Text;
            string keyword = txtTimSanPham.Text.Trim();
            LoadSanPham(danhMuc, keyword);
        }

        /// <summary>
        /// Sự kiện khi gõ tìm kiếm - tìm sản phẩm theo mã hoặc tên
        /// </summary>
        private void txtTimSanPham_TextChanged(object sender, EventArgs e)
        {
            string danhMuc = cboDanhMuc.Text;
            string keyword = txtTimSanPham.Text.Trim();
            LoadSanPham(danhMuc, keyword);
        }

        /// <summary>
        /// Sự kiện khi thay đổi số tiền giảm giá - tính lại tổng tiền
        /// </summary>
        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        /// <summary>
        /// Sự kiện khi kết thúc sửa ô số lượng trong giỏ hàng
        /// Tự động tính lại thành tiền cho sản phẩm đó
        /// </summary>
        private void dgvGioHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Chỉ xử lý khi sửa cột số lượng
            if (e.ColumnIndex == dgvGioHang.Columns["SoLuong"].Index)
            {
                DataRow row = dtGioHang.Rows[e.RowIndex];
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                row["ThanhTien"] = soLuong * donGia; // Tính lại thành tiền
                TinhTongTien(); // Cập nhật tổng
            }
        }

        /// <summary>
        /// Sự kiện khi thay đổi khách hàng - cập nhật biến lưu mã khách hàng
        /// </summary>
        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedIndex > 0)
            {
                selectedKhachHangId = ((ComboBoxItem)cboKhachHang.SelectedItem).Value;
            }
            else
            {
                selectedKhachHangId = 0; // Chưa chọn khách hàng
            }
        }
    }

    /// <summary>
    /// Class hỗ trợ cho ComboBox - lưu cả Value và Text
    /// Dùng để lưu MaKhachHang (Value) và tên hiển thị (Text)
    /// </summary>
    public class ComboBoxItem
    {
        public int Value { get; set; }   // Giá trị thực (MaKhachHang)
        public string Text { get; set; } // Text hiển thị

        public ComboBoxItem(int value, string text)
        {
            Value = value;
            Text = text;
        }

        // Override ToString để hiển thị Text trong ComboBox
        public override string ToString()
        {
            return Text;
        }
    }
}

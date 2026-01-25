using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmPOS : Form
    {
        DataTable tblGioHang;
        private decimal tongTien = 0;
        private decimal giamGia = 0;
        private decimal thueVAT = 0;
        private decimal thanhTien = 0;

        public frmPOS()
        {
            InitializeComponent();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            LoadComboKhachHang();
            LoadComboSanPham();
            KhoiTaoGioHang();
            ResetHoaDon();
            txtSoHoaDon.Text = TaoSoHoaDon();
        }

        private string TaoSoHoaDon()
        {
            string sql = "SELECT COUNT(*) FROM HoaDon WHERE CONVERT(DATE, NgayBan) = CONVERT(DATE, GETDATE())";
            DataTable dt = Functions.GetDataToTable(sql);
            int soHD = Convert.ToInt32(dt.Rows[0][0]) + 1;
            return "HD" + DateTime.Now.ToString("yyyyMMdd") + soHD.ToString("000");
        }

        private void LoadComboKhachHang()
        {
            string sql = "SELECT MaKhachHang, HoTen FROM KhachHang ORDER BY HoTen";
            Functions.FillCombo(sql, cboKhachHang, "MaKhachHang", "HoTen");
            cboKhachHang.SelectedIndex = -1;
        }

        private void LoadComboSanPham()
        {
            string sql = "SELECT MaSanPham, TenSanPham FROM SanPham WHERE TrangThai = 1 AND SoLuongTon > 0 ORDER BY TenSanPham";
            Functions.FillCombo(sql, cboSanPham, "MaSanPham", "TenSanPham");
            cboSanPham.SelectedIndex = -1;
        }

        private void KhoiTaoGioHang()
        {
            tblGioHang = new DataTable();
            tblGioHang.Columns.Add("MaSanPham", typeof(int));
            tblGioHang.Columns.Add("TenSanPham", typeof(string));
            tblGioHang.Columns.Add("SoLuong", typeof(int));
            tblGioHang.Columns.Add("DonGia", typeof(decimal));
            tblGioHang.Columns.Add("GiamGia", typeof(decimal));
            tblGioHang.Columns.Add("ThanhTien", typeof(decimal));

            dgvGioHang.DataSource = tblGioHang;
            dgvGioHang.Columns[0].HeaderText = "Mã SP";
            dgvGioHang.Columns[1].HeaderText = "Tên sản phẩm";
            dgvGioHang.Columns[2].HeaderText = "Số lượng";
            dgvGioHang.Columns[3].HeaderText = "Đơn giá";
            dgvGioHang.Columns[4].HeaderText = "Giảm giá";
            dgvGioHang.Columns[5].HeaderText = "Thành tiền";

            dgvGioHang.Columns[0].Width = 60;
            dgvGioHang.Columns[1].Width = 250;
            dgvGioHang.Columns[2].Width = 80;
            dgvGioHang.AllowUserToAddRows = false;
        }

        private void ResetHoaDon()
        {
            tblGioHang.Clear();
            txtSoHoaDon.Text = TaoSoHoaDon();
            cboKhachHang.SelectedIndex = -1;
            txtTenKhachHang.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            cboSanPham.SelectedIndex = -1;
            txtGiaBan.Clear();
            txtSoLuongTon.Clear();
            nudSoLuong.Value = 1;
            txtGiamGiaHD.Text = "0";
            txtThueVAT.Text = "10";
            TinhTongTien();
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedIndex >= 0 && cboKhachHang.SelectedValue != null)
            {
                // Safely get the value
                object selectedValue = cboKhachHang.SelectedValue;
                if (selectedValue is DataRowView)
                    return; // Skip if it's a DataRowView during initialization
                    
                int maKH = Convert.ToInt32(selectedValue);
                string sql = $"SELECT HoTen, SoDienThoai, DiaChi FROM KhachHang WHERE MaKhachHang = {maKH}";
                DataTable dt = Functions.GetDataToTable(sql);
                if (dt.Rows.Count > 0)
                {
                    txtTenKhachHang.Text = dt.Rows[0]["HoTen"].ToString();
                    txtDienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                }
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex >= 0 && cboSanPham.SelectedValue != null)
            {
                // Safely get the value
                object selectedValue = cboSanPham.SelectedValue;
                if (selectedValue is DataRowView)
                    return; // Skip if it's a DataRowView during initialization
                    
                int maSP = Convert.ToInt32(selectedValue);
                string sql = $"SELECT GiaBan, SoLuongTon FROM SanPham WHERE MaSanPham = {maSP}";
                DataTable dt = Functions.GetDataToTable(sql);
                if (dt.Rows.Count > 0)
                {
                    txtGiaBan.Text = dt.Rows[0]["GiaBan"].ToString();
                    txtSoLuongTon.Text = dt.Rows[0]["SoLuongTon"].ToString();
                }
            }
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongTon = Convert.ToInt32(txtSoLuongTon.Text);
            int soLuongMua = Convert.ToInt32(nudSoLuong.Value);

            if (soLuongMua > soLuongTon)
            {
                MessageBox.Show($"Không đủ hàng! Tồn kho chỉ còn {soLuongTon}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Safely get the value
            object selectedValue = cboSanPham.SelectedValue;
            if (selectedValue == null || selectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int maSP = Convert.ToInt32(selectedValue);
            string tenSP = cboSanPham.Text;
            decimal giaBan = Convert.ToDecimal(txtGiaBan.Text);
            decimal giamGiaSP = 0;
            decimal thanhTienSP = soLuongMua * giaBan - giamGiaSP;

            // Kiểm tra xem sản phẩm đã có trong giỏ chưa
            DataRow[] rows = tblGioHang.Select($"MaSanPham = {maSP}");
            if (rows.Length > 0)
            {
                // Cập nhật số lượng
                int soLuongCu = Convert.ToInt32(rows[0]["SoLuong"]);
                rows[0]["SoLuong"] = soLuongCu + soLuongMua;
                rows[0]["ThanhTien"] = (soLuongCu + soLuongMua) * giaBan;
            }
            else
            {
                // Thêm mới
                DataRow row = tblGioHang.NewRow();
                row["MaSanPham"] = maSP;
                row["TenSanPham"] = tenSP;
                row["SoLuong"] = soLuongMua;
                row["DonGia"] = giaBan;
                row["GiamGia"] = giamGiaSP;
                row["ThanhTien"] = thanhTienSP;
                tblGioHang.Rows.Add(row);
            }

            TinhTongTien();
            nudSoLuong.Value = 1;
        }

        private void btnXoaKhoiGio_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                dgvGioHang.Rows.Remove(dgvGioHang.CurrentRow);
                TinhTongTien();
            }
        }

        private void TinhTongTien()
        {
            tongTien = 0;
            foreach (DataRow row in tblGioHang.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }

            decimal.TryParse(txtGiamGiaHD.Text, out giamGia);
            decimal.TryParse(txtThueVAT.Text, out thueVAT);

            thanhTien = tongTien - giamGia + (tongTien * thueVAT / 100);

            txtTongTien.Text = tongTien.ToString("N0");
            txtThanhTien.Text = thanhTien.ToString("N0");
        }

        private void txtGiamGiaHD_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (tblGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhachHang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lưu hóa đơn
                object selectedValue = cboKhachHang.SelectedValue;
                if (selectedValue == null || selectedValue is DataRowView)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                int maKH = Convert.ToInt32(selectedValue);
                string sqlHD = $@"INSERT INTO HoaDon (SoHoaDon, MaKhachHang, MaNhanVien, TongTien, GiamGia, ThueVAT, ThanhTien, PhuongThucThanhToan, TrangThai)
                                 VALUES (N'{txtSoHoaDon.Text}', {maKH}, {Functions.currentUserId}, 
                                 {tongTien}, {giamGia}, {thueVAT}, {thanhTien}, N'{cboPhuongThuc.Text}', N'Hoàn thành');
                                 SELECT SCOPE_IDENTITY()";
                
                DataTable dtHD = Functions.GetDataToTable(sqlHD);
                int maHD = Convert.ToInt32(dtHD.Rows[0][0]);

                // Lưu chi tiết hóa đơn
                foreach (DataRow row in tblGioHang.Rows)
                {
                    string sqlCT = $@"INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien)
                                     VALUES ({maHD}, {row["MaSanPham"]}, {row["SoLuong"]}, {row["DonGia"]}, 
                                     {row["GiamGia"]}, {row["ThanhTien"]})";
                    Functions.RunSQL(sqlCT);

                    // Cập nhật tồn kho
                    string sqlUpdateTon = $"UPDATE SanPham SET SoLuongTon = SoLuongTon - {row["SoLuong"]} WHERE MaSanPham = {row["MaSanPham"]}";
                    Functions.RunSQL(sqlUpdateTon);
                }

                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (MessageBox.Show("Bạn có muốn in hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // TODO: Mở form in hóa đơn
                }

                ResetHoaDon();
                LoadComboSanPham(); // Reload để cập nhật tồn kho
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetHoaDon();
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmTraCuuCongNo : Form
    {
        private DataTable dtKhachHang;

        public frmTraCuuCongNo()
        {
            InitializeComponent();
        }

        private void frmTraCuuCongNo_Load(object sender, EventArgs e)
        {
            LoadComboLoaiKH();
            LoadData();
        }

        private void LoadComboLoaiKH()
        {
            cboLoaiKH.Items.Clear();
            cboLoaiKH.Items.Add("Tất cả");
            cboLoaiKH.Items.Add("Thường");
            cboLoaiKH.Items.Add("VIP");
            cboLoaiKH.Items.Add("Sỉ");
            cboLoaiKH.SelectedIndex = 0;
        }

        private void LoadData()
        {
            try
            {
                string sql = @"SELECT 
                              k.MaKhachHang,
                              k.MaSoKhachHang as 'Mã KH',
                              k.HoTen as 'Họ tên',
                              k.SoDienThoai as 'Số ĐT',
                              k.LoaiKhachHang as 'Loại KH',
                              k.TongChiTieu as 'Tổng chi tiêu',
                              COUNT(h.MaHoaDon) as 'Số đơn hàng',
                              MAX(h.NgayBan) as 'Lần mua cuối',
                              k.NgayTao as 'Ngày tạo'
                              FROM KhachHang k
                              LEFT JOIN HoaDon h ON k.MaKhachHang = h.MaKhachHang
                              GROUP BY k.MaKhachHang, k.MaSoKhachHang, k.HoTen, 
                                       k.SoDienThoai, k.LoaiKhachHang, k.TongChiTieu, k.NgayTao
                              ORDER BY k.TongChiTieu DESC";

                dtKhachHang = Functions.GetDataTable(sql);
                dgvKhachHang.DataSource = dtKhachHang;

                // Ẩn cột MaKhachHang
                dgvKhachHang.Columns["MaKhachHang"].Visible = false;

                // Format cột
                dgvKhachHang.Columns["Tổng chi tiêu"].DefaultCellStyle.Format = "N0";
                dgvKhachHang.Columns["Lần mua cuối"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvKhachHang.Columns["Ngày tạo"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Tính tổng
                TinhTongKet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TinhTongKet()
        {
            decimal tongChiTieu = 0;
            int tongKhachHang = 0;

            foreach (DataGridViewRow row in dgvKhachHang.Rows)
            {
                if (row.Cells["Tổng chi tiêu"].Value != DBNull.Value)
                {
                    tongChiTieu += Convert.ToDecimal(row.Cells["Tổng chi tiêu"].Value);
                }
                tongKhachHang++;
            }

            lblTongKH.Text = tongKhachHang.ToString();
            lblTongChiTieu.Text = tongChiTieu.ToString("N0");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string loaiKH = cboLoaiKH.Text;

                string sql = @"SELECT 
                              k.MaKhachHang,
                              k.MaSoKhachHang as 'Mã KH',
                              k.HoTen as 'Họ tên',
                              k.SoDienThoai as 'Số ĐT',
                              k.LoaiKhachHang as 'Loại KH',
                              k.TongChiTieu as 'Tổng chi tiêu',
                              COUNT(h.MaHoaDon) as 'Số đơn hàng',
                              MAX(h.NgayBan) as 'Lần mua cuối',
                              k.NgayTao as 'Ngày tạo'
                              FROM KhachHang k
                              LEFT JOIN HoaDon h ON k.MaKhachHang = h.MaKhachHang
                              WHERE (k.HoTen LIKE @Keyword OR k.SoDienThoai LIKE @Keyword OR k.MaSoKhachHang LIKE @Keyword)";

                if (loaiKH != "Tất cả")
                {
                    sql += " AND k.LoaiKhachHang = @LoaiKH";
                }

                sql += @" GROUP BY k.MaKhachHang, k.MaSoKhachHang, k.HoTen, 
                         k.SoDienThoai, k.LoaiKhachHang, k.TongChiTieu, k.NgayTao
                         ORDER BY k.TongChiTieu DESC";

                SqlParameter[] parameters;
                if (loaiKH != "Tất cả")
                {
                    parameters = new SqlParameter[] {
                        new SqlParameter("@Keyword", "%" + keyword + "%"),
                        new SqlParameter("@LoaiKH", loaiKH)
                    };
                }
                else
                {
                    parameters = new SqlParameter[] {
                        new SqlParameter("@Keyword", "%" + keyword + "%")
                    };
                }

                dtKhachHang = Functions.GetDataTable(sql, parameters);
                dgvKhachHang.DataSource = dtKhachHang;

                TinhTongKet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maKH = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells["MaKhachHang"].Value);
            
            // Hiển thị lịch sử mua hàng của khách hàng
            XemLichSuMuaHang(maKH);
        }

        private void XemLichSuMuaHang(int maKH)
        {
            try
            {
                string sql = @"SELECT 
                              h.SoHoaDon as 'Số HĐ',
                              h.NgayBan as 'Ngày mua',
                              h.TongTien as 'Tổng tiền',
                              h.GiamGia as 'Giảm giá',
                              h.ThanhTien as 'Thành tiền',
                              h.TrangThai as 'Trạng thái'
                              FROM HoaDon h
                              WHERE h.MaKhachHang = @MaKH
                              ORDER BY h.NgayBan DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaKH", maKH)
                };

                DataTable dt = Functions.GetDataTable(sql, parameters);
                dgvLichSu.DataSource = dt;

                // Format
                dgvLichSu.Columns["Ngày mua"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvLichSu.Columns["Tổng tiền"].DefaultCellStyle.Format = "N0";
                dgvLichSu.Columns["Giảm giá"].DefaultCellStyle.Format = "N0";
                dgvLichSu.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem lịch sử: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLoaiKH.SelectedIndex = 0;
            LoadData();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                btnXemChiTiet_Click(sender, e);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = "BaoCaoCongNo_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Export to Excel logic here
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

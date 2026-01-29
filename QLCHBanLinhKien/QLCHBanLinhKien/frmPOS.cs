using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmPOS : Form
    {
        private DataTable dtGioHang;
        private int selectedKhachHangId = 0;
        
        public frmPOS()
        {
            InitializeComponent();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            KhoiTaoGioHang();
            LoadDanhMuc();
            LoadSanPham();
            LoadKhachHang();
            ResetForm();
        }

        private void KhoiTaoGioHang()
        {
            dtGioHang = new DataTable();
            dtGioHang.Columns.Add("MaSanPham", typeof(int));
            dtGioHang.Columns.Add("MaSoSanPham", typeof(string));
            dtGioHang.Columns.Add("TenSanPham", typeof(string));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal));
            
            dgvGioHang.DataSource = dtGioHang;
            
            dgvGioHang.Columns["MaSanPham"].Visible = false;
            dgvGioHang.Columns["MaSoSanPham"].HeaderText = "Ma SP";
            dgvGioHang.Columns["TenSanPham"].HeaderText = "Ten san pham";
            dgvGioHang.Columns["DonGia"].HeaderText = "Don gia";
            dgvGioHang.Columns["SoLuong"].HeaderText = "SL";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thanh tien";
            
            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void LoadDanhMuc()
        {
            cboDanhMuc.Items.Clear();
            cboDanhMuc.Items.Add("-- Tat ca --");
            
            string sql = "SELECT TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc";
            DataTable dt = Functions.GetDataToTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                cboDanhMuc.Items.Add(row["TenDanhMuc"].ToString());
            }
            cboDanhMuc.SelectedIndex = 0;
        }

        private void LoadSanPham(string danhMuc = null, string keyword = null)
        {
            string sql = @"SELECT sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, sp.GiaBan, sp.SoLuongTon,
                          dm.TenDanhMuc
                          FROM SanPham sp
                          LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                          WHERE sp.SoLuongTon > 0 ";
            
            if (!string.IsNullOrEmpty(danhMuc) && danhMuc != "-- Tat ca --")
            {
                sql += " AND dm.TenDanhMuc = @DanhMuc";
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                sql += " AND (sp.MaSoSanPham LIKE @Keyword OR sp.TenSanPham LIKE @Keyword)";
            }
            
            sql += " ORDER BY sp.TenSanPham";
            
            SqlParameter[] parameters;
            if (!string.IsNullOrEmpty(danhMuc) && danhMuc != "-- Tat ca --" && !string.IsNullOrEmpty(keyword))
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@DanhMuc", danhMuc),
                    new SqlParameter("@Keyword", "%" + keyword + "%")
                };
            }
            else if (!string.IsNullOrEmpty(danhMuc) && danhMuc != "-- Tat ca --")
            {
                parameters = new SqlParameter[] { new SqlParameter("@DanhMuc", danhMuc) };
            }
            else if (!string.IsNullOrEmpty(keyword))
            {
                parameters = new SqlParameter[] { new SqlParameter("@Keyword", "%" + keyword + "%") };
            }
            else
            {
                parameters = new SqlParameter[0];
            }
            
            DataTable dt = Functions.GetDataTable(sql, parameters);
            dgvSanPham.DataSource = dt;
            
            if (dgvSanPham.Columns.Count > 0)
            {
                dgvSanPham.Columns["MaSanPham"].Visible = false;
                dgvSanPham.Columns["MaSoSanPham"].HeaderText = "Ma SP";
                dgvSanPham.Columns["TenSanPham"].HeaderText = "Ten san pham";
                dgvSanPham.Columns["GiaBan"].HeaderText = "Gia ban";
                dgvSanPham.Columns["SoLuongTon"].HeaderText = "Ton kho";
                dgvSanPham.Columns["TenDanhMuc"].HeaderText = "Danh muc";
                dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            }
        }

        private void LoadKhachHang()
        {
            cboKhachHang.Items.Clear();
            cboKhachHang.Items.Add("-- Khach le --");
            
            string sql = "SELECT MaKhachHang, HoTen, SoDienThoai FROM KhachHang ORDER BY HoTen";
            DataTable dt = Functions.GetDataToTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                string display = row["HoTen"].ToString();
                if (row["SoDienThoai"] != DBNull.Value && !string.IsNullOrEmpty(row["SoDienThoai"].ToString()))
                {
                    display += " - " + row["SoDienThoai"].ToString();
                }
                cboKhachHang.Items.Add(new ComboBoxItem(Convert.ToInt32(row["MaKhachHang"]), display));
            }
            cboKhachHang.SelectedIndex = 0;
        }

        private void ResetForm()
        {
            dtGioHang.Rows.Clear();
            selectedKhachHangId = 0;
            cboKhachHang.SelectedIndex = 0;
            txtGhiChu.Text = "";
            numGiamGia.Value = 0;
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataRow row in dtGioHang.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }
            
            decimal giamGia = numGiamGia.Value;
            decimal thanhToan = tongTien - giamGia;
            if (thanhToan < 0) thanhToan = 0;
            
            lblTongTien.Text = tongTien.ToString("N0") + " VND";
            lblThanhToan.Text = thanhToan.ToString("N0") + " VND";
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ThemVaoGioHang();
            }
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            ThemVaoGioHang();
        }

        private void ThemVaoGioHang()
        {
            if (dgvSanPham.CurrentRow == null) return;
            
            int maSP = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value);
            string maSoSP = dgvSanPham.CurrentRow.Cells["MaSoSanPham"].Value?.ToString() ?? "";
            string tenSP = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value?.ToString() ?? "";
            decimal giaBan = Convert.ToDecimal(dgvSanPham.CurrentRow.Cells["GiaBan"].Value);
            int tonKho = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["SoLuongTon"].Value);
            
            // Kiem tra da co trong gio hang chua
            foreach (DataRow row in dtGioHang.Rows)
            {
                if (Convert.ToInt32(row["MaSanPham"]) == maSP)
                {
                    int soLuongHienTai = Convert.ToInt32(row["SoLuong"]);
                    if (soLuongHienTai + 1 > tonKho)
                    {
                        MessageBox.Show("So luong trong kho khong du!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    row["SoLuong"] = soLuongHienTai + 1;
                    row["ThanhTien"] = Convert.ToDecimal(row["DonGia"]) * (soLuongHienTai + 1);
                    TinhTongTien();
                    return;
                }
            }
            
            // Them moi vao gio hang
            DataRow newRow = dtGioHang.NewRow();
            newRow["MaSanPham"] = maSP;
            newRow["MaSoSanPham"] = maSoSP;
            newRow["TenSanPham"] = tenSP;
            newRow["DonGia"] = giaBan;
            newRow["SoLuong"] = 1;
            newRow["ThanhTien"] = giaBan;
            dtGioHang.Rows.Add(newRow);
            
            TinhTongTien();
        }

        private void btnXoaKhoiGio_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null) return;
            
            int index = dgvGioHang.CurrentRow.Index;
            if (index >= 0 && index < dtGioHang.Rows.Count)
            {
                dtGioHang.Rows.RemoveAt(index);
                TinhTongTien();
            }
        }

        private void btnXoaGioHang_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0) return;
            
            if (MessageBox.Show("Xoa tat ca san pham trong gio hang?", "Xac nhan", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtGioHang.Rows.Clear();
                TinhTongTien();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Gio hang trong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Lay thong tin khach hang
            if (cboKhachHang.SelectedIndex > 0)
            {
                selectedKhachHangId = ((ComboBoxItem)cboKhachHang.SelectedItem).Value;
            }
            
            // Tinh tong tien
            decimal tongTien = 0;
            foreach (DataRow row in dtGioHang.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }
            decimal giamGia = numGiamGia.Value;
            decimal thanhToan = tongTien - giamGia;
            if (thanhToan < 0) thanhToan = 0;
            
            // Tao hoa don
            string maHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string sqlHoaDon = @"INSERT INTO HoaDon (SoHoaDon, NgayBan, MaKhachHang, TongTien, GiamGia, ThanhTien, MaNhanVien)
                                VALUES (@MaHD, GETDATE(), @MaKH, @TongTien, @GiamGia, @ThanhTien, @MaNV);
                                SELECT SCOPE_IDENTITY();";
            
            SqlParameter[] paramsHD = {
                new SqlParameter("@MaHD", maHD),
                new SqlParameter("@MaKH", selectedKhachHangId > 0 ? (object)selectedKhachHangId : DBNull.Value),
                new SqlParameter("@TongTien", tongTien),
                new SqlParameter("@GiamGia", giamGia),
                new SqlParameter("@ThanhTien", thanhToan),
                new SqlParameter("@MaNV", frmLogin.MaNguoiDung)
            };
            
            object result = Functions.GetFieldValues(sqlHoaDon, paramsHD);
            if (result == null)
            {
                MessageBox.Show("Loi tao hoa don!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            int maHoaDon = Convert.ToInt32(result);
            
            // Them chi tiet hoa don va cap nhat ton kho
            foreach (DataRow row in dtGioHang.Rows)
            {
                int maSP = Convert.ToInt32(row["MaSanPham"]);
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                decimal thanhTienItem = Convert.ToDecimal(row["ThanhTien"]);
                
                // Them chi tiet
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
                
                // Cap nhat ton kho
                string sqlCapNhat = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL WHERE MaSanPham = @MaSP";
                SqlParameter[] paramsCapNhat = {
                    new SqlParameter("@SL", soLuong),
                    new SqlParameter("@MaSP", maSP)
                };
                Functions.RunSQL(sqlCapNhat, paramsCapNhat);
            }
            
            // Cap nhat tong chi tieu khach hang
            if (selectedKhachHangId > 0)
            {
                string sqlCapNhatKH = "UPDATE KhachHang SET TongChiTieu = TongChiTieu + @TongTien WHERE MaKhachHang = @MaKH";
                SqlParameter[] paramsKH = {
                    new SqlParameter("@TongTien", thanhToan),
                    new SqlParameter("@MaKH", selectedKhachHangId)
                };
                Functions.RunSQL(sqlCapNhatKH, paramsKH);
            }
            
            MessageBox.Show("Thanh toan thanh cong!\nMa hoa don: " + maHD, "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ResetForm();
            LoadSanPham();
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string danhMuc = cboDanhMuc.Text;
            string keyword = txtTimSanPham.Text.Trim();
            LoadSanPham(danhMuc, keyword);
        }

        private void txtTimSanPham_TextChanged(object sender, EventArgs e)
        {
            string danhMuc = cboDanhMuc.Text;
            string keyword = txtTimSanPham.Text.Trim();
            LoadSanPham(danhMuc, keyword);
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void dgvGioHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvGioHang.Columns["SoLuong"].Index)
            {
                DataRow row = dtGioHang.Rows[e.RowIndex];
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                row["ThanhTien"] = soLuong * donGia;
                TinhTongTien();
            }
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedIndex > 0)
            {
                selectedKhachHangId = ((ComboBoxItem)cboKhachHang.SelectedItem).Value;
            }
            else
            {
                selectedKhachHangId = 0;
            }
        }
    }

    // Class ho tro cho ComboBox
    public class ComboBoxItem
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public ComboBoxItem(int value, string text)
        {
            Value = value;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}

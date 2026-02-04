using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
            LoadSanPham();
            SetupDataGridView();
            dtpNgayNhap.Value = DateTime.Now;
        }

        private void LoadNhaCungCap()
        {
            try
            {
                string query = "SELECT MaNCC, TenNCC FROM NhaCungCap ORDER BY TenNCC";
                DataTable dt = Functions.GetDataTable(query);
                cmbNhaCungCap.DataSource = dt;
                
                cmbNhaCungCap.DisplayMember = "TenNCC";
                cmbNhaCungCap.ValueMember = "MaNCC";
                cmbNhaCungCap.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSanPham()
        {
            try
            {
                string query = "SELECT MaSanPham, TenSanPham, GiaNhap, SoLuongTon FROM SanPham WHERE TrangThai = 1 ORDER BY TenSanPham";
                DataTable dt = Functions.GetDataTable(query);
                
                cmbSanPham.DataSource = dt;
                cmbSanPham.DisplayMember = "TenSanPham";
                cmbSanPham.ValueMember = "MaSanPham";
                cmbSanPham.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add("MaSanPham", "Mã SP");
            dgvChiTiet.Columns.Add("TenSanPham", "Tên sản phẩm");
            dgvChiTiet.Columns.Add("SoLuong", "Số lượng");
            dgvChiTiet.Columns.Add("DonGia", "Đơn giá");
            dgvChiTiet.Columns.Add("ThanhTien", "Thành tiền");

            dgvChiTiet.Columns["MaSanPham"].Width = 80;
            dgvChiTiet.Columns["TenSanPham"].Width = 200;
            dgvChiTiet.Columns["SoLuong"].Width = 80;
            dgvChiTiet.Columns["DonGia"].Width = 100;
            dgvChiTiet.Columns["ThanhTien"].Width = 120;

            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSanPham.SelectedIndex >= 0)
            {
                DataRowView drv = (DataRowView)cmbSanPham.SelectedItem;
                txtGiaNhap.Text = Convert.ToDecimal(drv["GiaNhap"]).ToString("N0");
                lblTonHienTai.Text = drv["SoLuongTon"].ToString();
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cmbSanPham.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong;
            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            decimal donGia;
            if (!decimal.TryParse(txtGiaNhap.Text.Replace(",", "").Replace(".", ""), out donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaNhap.Focus();
                return;
            }

            DataRowView drv = (DataRowView)cmbSanPham.SelectedItem;
            int maSP = Convert.ToInt32(drv["MaSanPham"]);

            // Kiểm tra sản phẩm đã có trong danh sách chưa
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (Convert.ToInt32(row.Cells["MaSanPham"].Value) == maSP)
                {
                    MessageBox.Show("Sản phẩm đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            decimal thanhTien = soLuong * donGia;
            dgvChiTiet.Rows.Add(maSP, drv["TenSanPham"].ToString(), soLuong, donGia, thanhTien);

            TinhTongTien();
            ResetInput();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count > 0)
            {
                dgvChiTiet.Rows.RemoveAt(dgvChiTiet.SelectedRows[0].Index);
                TinhTongTien();
            }
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void ResetInput()
        {
            cmbSanPham.SelectedIndex = -1;
            txtSoLuong.Text = "1";
            txtGiaNhap.Clear();
            lblTonHienTai.Text = "0";
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (cmbNhaCungCap.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào danh sách nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Cập nhật số lượng tồn kho
                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    int maSP = Convert.ToInt32(row.Cells["MaSanPham"].Value);
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);

                    string updateQuery = @"UPDATE SanPham 
                                          SET SoLuongTon = SoLuongTon + @SoLuong,
                                              GiaNhap = @GiaNhap
                                          WHERE MaSanPham = @MaSanPham";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@SoLuong", soLuong),
                        new SqlParameter("@GiaNhap", donGia),
                        new SqlParameter("@MaSanPham", maSP)
                    };

                    Functions.RunSQL(updateQuery, parameters);
                }

                MessageBox.Show("Nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvChiTiet.Rows.Clear();
                TinhTongTien();
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

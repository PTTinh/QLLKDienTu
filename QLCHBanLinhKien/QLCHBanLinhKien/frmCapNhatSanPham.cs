using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmCapNhatSanPham : Form
    {
        private int maSanPham = 0;
        private bool isEditMode = false;

        public frmCapNhatSanPham()
        {
            InitializeComponent();
            isEditMode = false;
        }

        public frmCapNhatSanPham(int maSanPham)
        {
            InitializeComponent();
            this.maSanPham = maSanPham;
            isEditMode = true;
        }

        private void frmCapNhatSanPham_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadNhaCungCap();

            if (isEditMode)
            {
                lblTitle.Text = "CẬP NHẬT SẢN PHẨM";
                this.Text = "Cập nhật sản phẩm";
                LoadSanPham();
            }
            else
            {
                lblTitle.Text = "THÊM SẢN PHẨM MỚI";
                this.Text = "Thêm sản phẩm mới";
                txtMaSoSanPham.Text = GenerateMaSo();
            }
        }

        private void LoadDanhMuc()
        {
            try
            {
                string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc";
                DataTable dt = Functions.GetDataTable(query);
                
                cmbDanhMuc.DataSource = dt;
                cmbDanhMuc.DisplayMember = "TenDanhMuc";
                cmbDanhMuc.ValueMember = "MaDanhMuc";
                cmbDanhMuc.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                string query = @"SELECT * FROM SanPham WHERE MaSanPham = @MaSanPham";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaSanPham", maSanPham)
                };

                DataTable dt = Functions.GetDataTable(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtMaSoSanPham.Text = row["MaSoSanPham"].ToString();
                    txtTenSanPham.Text = row["TenSanPham"].ToString();
                    cmbDanhMuc.SelectedValue = row["MaDanhMuc"];
                    cmbNhaCungCap.SelectedValue = row["MaNCC"];
                    txtGiaBan.Text = Convert.ToDecimal(row["GiaBan"]).ToString("N0");
                    txtGiaNhap.Text = Convert.ToDecimal(row["GiaNhap"]).ToString("N0");
                    txtSoLuongTon.Text = row["SoLuongTon"].ToString();
                    txtTonToiThieu.Text = row["TonToiThieu"].ToString();
                    txtTonToiDa.Text = row["TonToiDa"].ToString();
                    txtMoTa.Text = row["MoTa"].ToString();
                    chkTrangThai.Checked = Convert.ToBoolean(row["TrangThai"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateMaSo()
        {
            return "SP" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                decimal giaBan = decimal.Parse(txtGiaBan.Text.Replace(",", "").Replace(".", ""));
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text.Replace(",", "").Replace(".", ""));
                int soLuongTon = int.Parse(txtSoLuongTon.Text);
                int tonToiThieu = int.Parse(txtTonToiThieu.Text);
                int tonToiDa = int.Parse(txtTonToiDa.Text);

                if (isEditMode)
                {
                    string query = @"UPDATE SanPham SET 
                                     MaSoSanPham = @MaSoSanPham, TenSanPham = @TenSanPham, 
                                     MaDanhMuc = @MaDanhMuc, MaNCC = @MaNCC,
                                     GiaBan = @GiaBan, GiaNhap = @GiaNhap, 
                                     SoLuongTon = @SoLuongTon, TonToiThieu = @TonToiThieu, 
                                     TonToiDa = @TonToiDa, MoTa = @MoTa, TrangThai = @TrangThai
                                     WHERE MaSanPham = @MaSanPham";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaSoSanPham", txtMaSoSanPham.Text.Trim()),
                        new SqlParameter("@TenSanPham", txtTenSanPham.Text.Trim()),
                        new SqlParameter("@MaDanhMuc", cmbDanhMuc.SelectedValue),
                        new SqlParameter("@MaNCC", cmbNhaCungCap.SelectedValue),
                        new SqlParameter("@GiaBan", giaBan),
                        new SqlParameter("@GiaNhap", giaNhap),
                        new SqlParameter("@SoLuongTon", soLuongTon),
                        new SqlParameter("@TonToiThieu", tonToiThieu),
                        new SqlParameter("@TonToiDa", tonToiDa),
                        new SqlParameter("@MoTa", txtMoTa.Text.Trim()),
                        new SqlParameter("@TrangThai", chkTrangThai.Checked),
                        new SqlParameter("@MaSanPham", maSanPham)
                    };

                    bool result = Functions.RunSQL(query, parameters);
                    if (result)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    string query = @"INSERT INTO SanPham (MaSoSanPham, TenSanPham, MaDanhMuc, MaNCC, 
                                     GiaBan, GiaNhap, SoLuongTon, TonToiThieu, TonToiDa, MoTa, TrangThai)
                                     VALUES (@MaSoSanPham, @TenSanPham, @MaDanhMuc, @MaNCC, 
                                     @GiaBan, @GiaNhap, @SoLuongTon, @TonToiThieu, @TonToiDa, @MoTa, @TrangThai)";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaSoSanPham", txtMaSoSanPham.Text.Trim()),
                        new SqlParameter("@TenSanPham", txtTenSanPham.Text.Trim()),
                        new SqlParameter("@MaDanhMuc", cmbDanhMuc.SelectedValue),
                        new SqlParameter("@MaNCC", cmbNhaCungCap.SelectedValue),
                        new SqlParameter("@GiaBan", giaBan),
                        new SqlParameter("@GiaNhap", giaNhap),
                        new SqlParameter("@SoLuongTon", soLuongTon),
                        new SqlParameter("@TonToiThieu", tonToiThieu),
                        new SqlParameter("@TonToiDa", tonToiDa),
                        new SqlParameter("@MoTa", txtMoTa.Text.Trim()),
                        new SqlParameter("@TrangThai", chkTrangThai.Checked)
                    };

                    bool result = Functions.RunSQL(query, parameters);
                    if (result)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSoSanPham.Text))
            {
                MessageBox.Show("Vui lòng nhập mã số sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSoSanPham.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return false;
            }

            if (cmbDanhMuc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDanhMuc.Focus();
                return false;
            }

            if (cmbNhaCungCap.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNhaCungCap.Focus();
                return false;
            }

            decimal giaBan, giaNhap;
            if (!decimal.TryParse(txtGiaBan.Text.Replace(",", "").Replace(".", ""), out giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiaNhap.Text.Replace(",", "").Replace(".", ""), out giaNhap) || giaNhap <= 0)
            {
                MessageBox.Show("Giá nhập không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaNhap.Focus();
                return false;
            }

            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmCapNhatSanPham : Form
    {
        private int maSanPham = 0;
        private bool isAddNew = true;

        public frmCapNhatSanPham()
        {
            InitializeComponent();
            isAddNew = true;
        }

        public frmCapNhatSanPham(int maSP)
        {
            InitializeComponent();
            this.maSanPham = maSP;
            isAddNew = false;
        }

        private void frmCapNhatSanPham_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadNhaCungCap();

            if (!isAddNew)
            {
                LoadSanPham();
                txtMaSoSanPham.Enabled = false;
                this.Text = "Cập nhật Sản phẩm";
            }
            else
            {
                this.Text = "Thêm Sản phẩm mới";
                txtMaSoSanPham.Text = GenerateMaSoSP();
            }
        }

        private string GenerateMaSoSP()
        {
            string sql = "SELECT COUNT(*) FROM SanPham";
            DataTable dt = Functions.GetDataToTable(sql);
            int count = Convert.ToInt32(dt.Rows[0][0]) + 1;
            return "SP" + DateTime.Now.ToString("yyyyMMdd") + count.ToString("000");
        }

        private void LoadDanhMuc()
        {
            string sql = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc";
            Functions.FillCombo(sql, cboDanhMuc, "MaDanhMuc", "TenDanhMuc");
            cboDanhMuc.SelectedIndex = -1;
        }

        private void LoadNhaCungCap()
        {
            string sql = "SELECT MaNCC, TenNCC FROM NhaCungCap ORDER BY TenNCC";
            Functions.FillCombo(sql, cboNhaCungCap, "MaNCC", "TenNCC");
            cboNhaCungCap.SelectedIndex = -1;
        }

        private void LoadSanPham()
        {
            string sql = $"SELECT * FROM SanPham WHERE MaSanPham = {maSanPham}";
            DataTable dt = Functions.GetDataToTable(sql);
            
            if (dt.Rows.Count > 0)
            {
                txtMaSoSanPham.Text = dt.Rows[0]["MaSoSanPham"].ToString();
                txtTenSanPham.Text = dt.Rows[0]["TenSanPham"].ToString();
                cboDanhMuc.SelectedValue = dt.Rows[0]["MaDanhMuc"];
                cboNhaCungCap.SelectedValue = dt.Rows[0]["MaNCC"];
                txtGiaBan.Text = dt.Rows[0]["GiaBan"].ToString();
                txtGiaNhap.Text = dt.Rows[0]["GiaNhap"].ToString();
                txtSoLuongTon.Text = dt.Rows[0]["SoLuongTon"].ToString();
                txtTonToiThieu.Text = dt.Rows[0]["TonToiThieu"].ToString();
                txtTonToiDa.Text = dt.Rows[0]["TonToiDa"].ToString();
                txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                chkTrangThai.Checked = Convert.ToBoolean(dt.Rows[0]["TrangThai"]);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSoSanPham.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTenSanPham.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDanhMuc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaBan = 0, giaNhap = 0;
            int soLuongTon = 0, tonMin = 10, tonMax = 100;

            if (!decimal.TryParse(txtGiaBan.Text, out giaBan))
            {
                MessageBox.Show("Giá bán không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(txtGiaNhap.Text, out giaNhap);
            int.TryParse(txtSoLuongTon.Text, out soLuongTon);
            int.TryParse(txtTonToiThieu.Text, out tonMin);
            int.TryParse(txtTonToiDa.Text, out tonMax);

            string sql;
            if (isAddNew)
            {
                // Kiểm tra trùng mã sản phẩm
                string checkSql = $"SELECT COUNT(*) FROM SanPham WHERE MaSoSanPham = '{txtMaSoSanPham.Text}'";
                if (Functions.CheckKey(checkSql))
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sql = $@"INSERT INTO SanPham (MaSoSanPham, TenSanPham, MaDanhMuc, MaNCC, GiaBan, GiaNhap, 
                        SoLuongTon, TonToiThieu, TonToiDa, MoTa, TrangThai)
                        VALUES ('{txtMaSoSanPham.Text}', N'{txtTenSanPham.Text}', {cboDanhMuc.SelectedValue}, 
                        {(cboNhaCungCap.SelectedIndex >= 0 ? cboNhaCungCap.SelectedValue.ToString() : "NULL")}, 
                        {giaBan}, {giaNhap}, {soLuongTon}, {tonMin}, {tonMax}, 
                        N'{txtMoTa.Text}', {(chkTrangThai.Checked ? 1 : 0)})";
                
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sql = $@"UPDATE SanPham SET TenSanPham = N'{txtTenSanPham.Text}', 
                        MaDanhMuc = {cboDanhMuc.SelectedValue}, 
                        MaNCC = {(cboNhaCungCap.SelectedIndex >= 0 ? cboNhaCungCap.SelectedValue.ToString() : "NULL")},
                        GiaBan = {giaBan}, GiaNhap = {giaNhap}, SoLuongTon = {soLuongTon},
                        TonToiThieu = {tonMin}, TonToiDa = {tonMax}, MoTa = N'{txtMoTa.Text}',
                        TrangThai = {(chkTrangThai.Checked ? 1 : 0)}
                        WHERE MaSanPham = {maSanPham}";
                
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Functions.RunSQL(sql);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

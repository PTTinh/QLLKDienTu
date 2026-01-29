using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmTimSanPhamNhanh : Form
    {
        DataTable tblSanPham;
        public int SelectedMaSanPham { get; set; }
        public string SelectedTenSanPham { get; set; }
        public decimal SelectedGiaBan { get; set; }
        public int SelectedSoLuongTon { get; set; }

        public frmTimSanPhamNhanh()
        {
            InitializeComponent();
            SelectedMaSanPham = -1;
        }

        private void frmTimSanPhamNhanh_Load(object sender, EventArgs e)
        {
            LoadAllProducts();
            txtTuKhoa.Focus();
        }

        private void LoadAllProducts()
        {
            string sql = @"SELECT MaSanPham, TenSanPham, MaSoSanPham, GiaBan, SoLuongTon
                           FROM SanPham 
                           WHERE TrangThai = 1 AND SoLuongTon > 0
                           ORDER BY TenSanPham";
            tblSanPham = Functions.GetDataToTable(sql);
            BindDataToGridView(tblSanPham);
        }

        private void BindDataToGridView(DataTable dt)
        {
            dgvSanPham.DataSource = dt;
            dgvSanPham.Columns[0].HeaderText = "Mã SP";
            dgvSanPham.Columns[1].HeaderText = "Tên Sản Phẩm";
            dgvSanPham.Columns[2].HeaderText = "Mã Số";
            dgvSanPham.Columns[3].HeaderText = "Giá Bán";
            dgvSanPham.Columns[4].HeaderText = "Tồn Kho";

            dgvSanPham.Columns[0].Width = 60;
            dgvSanPham.Columns[1].Width = 250;
            dgvSanPham.Columns[2].Width = 80;
            dgvSanPham.Columns[3].Width = 100;
            dgvSanPham.Columns[4].Width = 80;

            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void TimKiem()
        {
            string tuKhoa = txtTuKhoa.Text.Trim();
            
            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadAllProducts();
                return;
            }

            string sql = @"SELECT MaSanPham, TenSanPham, MaSoSanPham, GiaBan, SoLuongTon
                           FROM SanPham 
                           WHERE TrangThai = 1 AND SoLuongTon > 0 
                           AND (TenSanPham LIKE N'%" + tuKhoa + @"%' 
                            OR MaSoSanPham LIKE N'%" + tuKhoa + @"%')
                           ORDER BY TenSanPham";
            
            tblSanPham = Functions.GetDataToTable(sql);
            BindDataToGridView(tblSanPham);
        }

        private void dgvSanPham_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null)
            {
                SelectProduct();
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            SelectProduct();
        }

        private void SelectProduct()
        {
            if (dgvSanPham.CurrentRow != null)
            {
                int rowIndex = dgvSanPham.CurrentRow.Index;
                DataRow row = tblSanPham.Rows[rowIndex];

                SelectedMaSanPham = Convert.ToInt32(row["MaSanPham"]);
                SelectedTenSanPham = row["TenSanPham"].ToString();
                SelectedGiaBan = Convert.ToDecimal(row["GiaBan"]);
                SelectedSoLuongTon = Convert.ToInt32(row["SoLuongTon"]);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

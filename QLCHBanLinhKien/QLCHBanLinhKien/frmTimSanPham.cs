using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmTimSanPham : Form
    {
        public int MaSanPhamSelected { get; private set; }

        public frmTimSanPham()
        {
            InitializeComponent();
        }

        private void frmTimSanPham_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            SetupDataGridView();
            LoadData();
        }

        private void LoadDanhMuc()
        {
            try
            {
                string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc";
                DataTable dt = Functions.GetDataTable(query);

                DataRow allRow = dt.NewRow();
                allRow["MaDanhMuc"] = 0;
                allRow["TenDanhMuc"] = "-- Tất cả --";
                dt.Rows.InsertAt(allRow, 0);

                cmbDanhMuc.DataSource = dt;
                cmbDanhMuc.DisplayMember = "TenDanhMuc";
                cmbDanhMuc.ValueMember = "MaDanhMuc";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.Columns.Clear();

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSanPham", HeaderText = "Mã", DataPropertyName = "MaSanPham", Width = 50, Visible = false });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSoSanPham", HeaderText = "Mã SP", DataPropertyName = "MaSoSanPham", Width = 100 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenSanPham", HeaderText = "Tên sản phẩm", DataPropertyName = "TenSanPham", Width = 220 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenDanhMuc", HeaderText = "Danh mục", DataPropertyName = "TenDanhMuc", Width = 120 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiaBan", HeaderText = "Giá bán", DataPropertyName = "GiaBan", Width = 100 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongTon", HeaderText = "Tồn kho", DataPropertyName = "SoLuongTon", Width = 70 });

            dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSanPham.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadData()
        {
            try
            {
                string query = @"SELECT sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, 
                                 dm.TenDanhMuc, sp.GiaBan, sp.SoLuongTon
                                 FROM SanPham sp
                                 LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                                 WHERE sp.TrangThai = 1";

                // Lọc theo từ khóa
                if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    query += " AND (sp.MaSoSanPham LIKE @TuKhoa OR sp.TenSanPham LIKE @TuKhoa)";
                }

                // Lọc theo danh mục
                int maDanhMuc = Convert.ToInt32(cmbDanhMuc.SelectedValue);
                if (maDanhMuc > 0)
                {
                    query += " AND sp.MaDanhMuc = @MaDanhMuc";
                }

                // Lọc theo tồn kho
                if (chkConHang.Checked)
                {
                    query += " AND sp.SoLuongTon > 0";
                }

                query += " ORDER BY sp.TenSanPham";

                SqlParameter[] parameters;
                if (!string.IsNullOrWhiteSpace(txtTimKiem.Text) && maDanhMuc > 0)
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TuKhoa", "%" + txtTimKiem.Text.Trim() + "%"),
                        new SqlParameter("@MaDanhMuc", maDanhMuc)
                    };
                }
                else if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TuKhoa", "%" + txtTimKiem.Text.Trim() + "%")
                    };
                }
                else if (maDanhMuc > 0)
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaDanhMuc", maDanhMuc)
                    };
                }
                else
                {
                    parameters = new SqlParameter[0];
                }

                DataTable dt = Functions.GetDataTable(query, parameters);
                dgvSanPham.DataSource = dt;
                lblSoKetQua.Text = $"Tìm thấy {dt.Rows.Count} sản phẩm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmTimKhachHang : Form
    {
        public int MaKhachHangSelected { get; private set; }

        public frmTimKhachHang()
        {
            InitializeComponent();
            LoadData();
        }

        private void frmTimKhachHang_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dgvKhachHang.Columns.Clear();

            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaKhachHang", HeaderText = "Mã", DataPropertyName = "MaKhachHang", Width = 50, Visible = false });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSoKhachHang", HeaderText = "Mã KH", DataPropertyName = "MaSoKhachHang", Width = 100 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", HeaderText = "Họ tên", DataPropertyName = "HoTen", Width = 180 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoDienThoai", HeaderText = "Số điện thoại", DataPropertyName = "SoDienThoai", Width = 120 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email", Width = 150 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoaiKhachHang", HeaderText = "Loại KH", DataPropertyName = "LoaiKhachHang", Width = 100 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "TongChiTieu", HeaderText = "Tổng chi tiêu", DataPropertyName = "TongChiTieu", Width = 120 });

            dgvKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
            dgvKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadData()
        {
            try
            {
                string query = @"SELECT MaKhachHang, MaSoKhachHang, HoTen, SoDienThoai, 
                                 Email, LoaiKhachHang, TongChiTieu
                                 FROM KhachHang WHERE 1=1";

                // Lọc theo từ khóa
                if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    query += " AND (MaSoKhachHang LIKE @TuKhoa OR HoTen LIKE @TuKhoa OR SoDienThoai LIKE @TuKhoa)";
                }

                // Lọc theo loại khách hàng
                if (cmbLoaiKH.SelectedIndex > 0)
                {
                    query += " AND LoaiKhachHang = @LoaiKH";
                }

                query += " ORDER BY HoTen";

                SqlParameter[] parameters;
                if (!string.IsNullOrWhiteSpace(txtTimKiem.Text) && cmbLoaiKH.SelectedIndex > 0)
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TuKhoa", "%" + txtTimKiem.Text.Trim() + "%"),
                        new SqlParameter("@LoaiKH", cmbLoaiKH.SelectedItem.ToString())
                    };
                }
                else if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TuKhoa", "%" + txtTimKiem.Text.Trim() + "%")
                    };
                }
                else if (cmbLoaiKH.SelectedIndex > 0)
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@LoaiKH", cmbLoaiKH.SelectedItem.ToString())
                    };
                }
                else
                {
                    parameters = new SqlParameter[0];
                }

                DataTable dt = Functions.GetDataTable(query, parameters);
                dgvKhachHang.DataSource = dt;
                lblSoKetQua.Text = $"Tìm thấy {dt.Rows.Count} khách hàng";
                cmbLoaiKH.Items.Clear();
                cmbLoaiKH.Items.Add("-- Tất cả --");
                cmbLoaiKH.Items.Add("Thường");
                cmbLoaiKH.Items.Add("VIP");
                cmbLoaiKH.Items.Add("Sỉ");
                cmbLoaiKH.SelectedIndex = 0;
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

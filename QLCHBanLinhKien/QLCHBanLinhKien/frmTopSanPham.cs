using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmTopSanPham : Form
    {
        public frmTopSanPham()
        {
            InitializeComponent();
        }

        private void frmTopSanPham_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }

        private void SetupDataGridView()
        {
            dgvTopSanPham.AutoGenerateColumns = false;
            dgvTopSanPham.Columns.Clear();

            dgvTopSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "STT", HeaderText = "STT", Width = 50 });
            dgvTopSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSoSanPham", HeaderText = "Mã SP", DataPropertyName = "MaSoSanPham", Width = 100 });
            dgvTopSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenSanPham", HeaderText = "Tên sản phẩm", DataPropertyName = "TenSanPham", Width = 250 });
            dgvTopSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenDanhMuc", HeaderText = "Danh mục", DataPropertyName = "TenDanhMuc", Width = 120 });
            dgvTopSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongBan", HeaderText = "SL bán", DataPropertyName = "SoLuongBan", Width = 80 });
            dgvTopSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "DoanhThu", HeaderText = "Doanh thu", DataPropertyName = "DoanhThu", Width = 130 });
            dgvTopSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongTon", HeaderText = "Tồn kho", DataPropertyName = "SoLuongTon", Width = 80 });

            dgvTopSanPham.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTopSanPham.Columns["SoLuongBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTopSanPham.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
            dgvTopSanPham.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTopSanPham.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadData()
        {
            try
            {
                int top = (int)numTop.Value;
                string query = $@"SELECT TOP {top} 
                                  sp.MaSoSanPham, sp.TenSanPham, dm.TenDanhMuc,
                                  SUM(ct.SoLuong) AS SoLuongBan,
                                  SUM(ct.ThanhTien) AS DoanhThu,
                                  sp.SoLuongTon
                                  FROM ChiTietHoaDon ct
                                  INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                                  LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                                  INNER JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon
                                  WHERE hd.NgayBan >= @TuNgay AND hd.NgayBan < @DenNgay
                                    AND hd.TrangThai = N'Hoàn thành'
                                  GROUP BY sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, dm.TenDanhMuc, sp.SoLuongTon
                                  ORDER BY SoLuongBan DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TuNgay", dtpTuNgay.Value.Date),
                    new SqlParameter("@DenNgay", dtpDenNgay.Value.Date.AddDays(1))
                };

                DataTable dt = Functions.GetDataTable(query, parameters);

                // Thêm số thứ tự
                dgvTopSanPham.DataSource = dt;
                for (int i = 0; i < dgvTopSanPham.Rows.Count; i++)
                {
                    dgvTopSanPham.Rows[i].Cells["STT"].Value = i + 1;
                }

                // Tính tổng
                decimal tongDoanhThu = 0;
                int tongSoLuong = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(row["DoanhThu"]);
                    tongSoLuong += Convert.ToInt32(row["SoLuongBan"]);
                }
                lblTongSoLuong.Text = tongSoLuong.ToString("N0");
                lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

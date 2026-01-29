using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmTopKhachHang : Form
    {
        public frmTopKhachHang()
        {
            InitializeComponent();
        }

        private void frmTopKhachHang_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }

        private void SetupDataGridView()
        {
            dgvTopKhachHang.AutoGenerateColumns = false;
            dgvTopKhachHang.Columns.Clear();

            dgvTopKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "STT", HeaderText = "STT", Width = 50 });
            dgvTopKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSoKhachHang", HeaderText = "Mã KH", DataPropertyName = "MaSoKhachHang", Width = 100 });
            dgvTopKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", HeaderText = "Họ tên", DataPropertyName = "HoTen", Width = 180 });
            dgvTopKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoDienThoai", HeaderText = "Số điện thoại", DataPropertyName = "SoDienThoai", Width = 120 });
            dgvTopKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoaiKhachHang", HeaderText = "Loại KH", DataPropertyName = "LoaiKhachHang", Width = 100 });
            dgvTopKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoHoaDon", HeaderText = "Số HĐ", DataPropertyName = "SoHoaDon", Width = 70 });
            dgvTopKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "TongChiTieu", HeaderText = "Tổng chi tiêu", DataPropertyName = "TongChiTieu", Width = 130 });

            dgvTopKhachHang.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTopKhachHang.Columns["SoHoaDon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTopKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
            dgvTopKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadData()
        {
            try
            {
                int top = (int)numTop.Value;
                string query = $@"SELECT TOP {top} 
                                  k.MaSoKhachHang, k.HoTen, k.SoDienThoai, k.LoaiKhachHang,
                                  COUNT(h.MaHoaDon) AS SoHoaDon,
                                  SUM(h.ThanhTien) AS TongChiTieu
                                  FROM KhachHang k
                                  INNER JOIN HoaDon h ON k.MaKhachHang = h.MaKhachHang
                                  WHERE h.NgayBan >= @TuNgay AND h.NgayBan < @DenNgay
                                    AND h.TrangThai = N'Hoàn thành'
                                  GROUP BY k.MaKhachHang, k.MaSoKhachHang, k.HoTen, k.SoDienThoai, k.LoaiKhachHang
                                  ORDER BY TongChiTieu DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TuNgay", dtpTuNgay.Value.Date),
                    new SqlParameter("@DenNgay", dtpDenNgay.Value.Date.AddDays(1))
                };

                DataTable dt = Functions.GetDataTable(query, parameters);

                // Thêm số thứ tự
                dgvTopKhachHang.DataSource = dt;
                for (int i = 0; i < dgvTopKhachHang.Rows.Count; i++)
                {
                    dgvTopKhachHang.Rows[i].Cells["STT"].Value = i + 1;
                }

                // Tính tổng
                decimal tongChiTieu = 0;
                int tongHoaDon = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongChiTieu += Convert.ToDecimal(row["TongChiTieu"]);
                    tongHoaDon += Convert.ToInt32(row["SoHoaDon"]);
                }
                lblTongHoaDon.Text = tongHoaDon.ToString("N0");
                lblTongChiTieu.Text = tongChiTieu.ToString("N0") + " VNĐ";
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

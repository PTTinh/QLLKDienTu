using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmLichSuMuaHang : Form
    {
        private int? maKhachHang = null;

        public frmLichSuMuaHang()
        {
            InitializeComponent();
        }

        public frmLichSuMuaHang(int maKhachHang)
        {
            InitializeComponent();
            this.maKhachHang = maKhachHang;
        }

        private void frmLichSuMuaHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            SetupDataGridView();

            if (maKhachHang.HasValue)
            {
                cmbKhachHang.SelectedValue = maKhachHang.Value;
            }

            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;
        }

        private void LoadKhachHang()
        {
            try
            {
                string query = "SELECT MaKhachHang, HoTen FROM KhachHang ORDER BY HoTen";
                DataTable dt = Functions.GetDataTable(query);

                DataRow allRow = dt.NewRow();
                allRow["MaKhachHang"] = 0;
                allRow["HoTen"] = "-- Tất cả khách hàng --";
                dt.Rows.InsertAt(allRow, 0);

                cmbKhachHang.DataSource = dt;
                cmbKhachHang.DisplayMember = "HoTen";
                cmbKhachHang.ValueMember = "MaKhachHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvLichSu.AutoGenerateColumns = false;
            dgvLichSu.Columns.Clear();

            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoHoaDon", HeaderText = "Số hóa đơn", DataPropertyName = "SoHoaDon", Width = 100 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayBan", HeaderText = "Ngày bán", DataPropertyName = "NgayBan", Width = 100 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKhachHang", HeaderText = "Khách hàng", DataPropertyName = "TenKhachHang", Width = 150 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "TongTien", HeaderText = "Tổng tiền", DataPropertyName = "TongTien", Width = 100 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiamGia", HeaderText = "Giảm giá", DataPropertyName = "GiamGia", Width = 80 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThanhTien", HeaderText = "Thành tiền", DataPropertyName = "ThanhTien", Width = 110 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "PhuongThuc", HeaderText = "Thanh toán", DataPropertyName = "PhuongThucThanhToan", Width = 100 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 100 });

            dgvLichSu.Columns["NgayBan"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvLichSu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvLichSu.Columns["GiamGia"].DefaultCellStyle.Format = "N0";
            dgvLichSu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvLichSu.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLichSu.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLichSu.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadData()
        {
            try
            {
                string query = @"SELECT h.MaHoaDon, h.SoHoaDon, h.NgayBan, 
                                 ISNULL(k.HoTen, N'Khách lẻ') AS TenKhachHang,
                                 h.TongTien, h.GiamGia, h.ThanhTien, 
                                 h.PhuongThucThanhToan, h.TrangThai
                                 FROM HoaDon h
                                 LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                                 WHERE h.NgayBan >= @TuNgay AND h.NgayBan < @DenNgay";

                int selectedKH = Convert.ToInt32(cmbKhachHang.SelectedValue);
                if (selectedKH > 0)
                {
                    query += " AND h.MaKhachHang = @MaKhachHang";
                }

                query += " ORDER BY h.NgayBan DESC";

                SqlParameter[] parameters;
                if (selectedKH > 0)
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TuNgay", dtpTuNgay.Value.Date),
                        new SqlParameter("@DenNgay", dtpDenNgay.Value.Date.AddDays(1)),
                        new SqlParameter("@MaKhachHang", selectedKH)
                    };
                }
                else
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TuNgay", dtpTuNgay.Value.Date),
                        new SqlParameter("@DenNgay", dtpDenNgay.Value.Date.AddDays(1))
                    };
                }

                DataTable dt = Functions.GetDataTable(query, parameters);
                dgvLichSu.DataSource = dt;

                // Tính tổng
                decimal tongTien = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
                }
                lblTongHoaDon.Text = dt.Rows.Count.ToString();
                lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
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

        private void dgvLichSu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataRowView drv = (DataRowView)dgvLichSu.Rows[e.RowIndex].DataBoundItem;
                    int maHoaDon = Convert.ToInt32(drv["MaHoaDon"]);
                    frmChiTietHoaDon frm = new frmChiTietHoaDon(maHoaDon);
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi mở chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

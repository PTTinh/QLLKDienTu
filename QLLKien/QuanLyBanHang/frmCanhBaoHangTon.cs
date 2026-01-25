using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmCanhBaoHangTon : Form
    {
        DataTable tblHangTon;

        public frmCanhBaoHangTon()
        {
            InitializeComponent();
        }

        private void frmCanhBaoHangTon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string sql = @"SELECT sp.MaSanPham, sp.MaSoSanPham, sp.TenSanPham, 
                          dm.TenDanhMuc, sp.SoLuongTon, sp.TonToiThieu, sp.TonToiDa,
                          CASE 
                              WHEN sp.SoLuongTon = 0 THEN N'Hết hàng'
                              WHEN sp.SoLuongTon <= sp.TonToiThieu THEN N'Cảnh báo'
                              ELSE N'Bình thường'
                          END AS TrangThai
                          FROM SanPham sp
                          LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                          WHERE sp.SoLuongTon <= sp.TonToiThieu AND sp.TrangThai = 1
                          ORDER BY sp.SoLuongTon ASC";

            tblHangTon = Functions.GetDataToTable(sql);
            dgvHangTon.DataSource = tblHangTon;

            dgvHangTon.Columns[0].HeaderText = "Mã SP";
            dgvHangTon.Columns[1].HeaderText = "Mã số SP";
            dgvHangTon.Columns[2].HeaderText = "Tên sản phẩm";
            dgvHangTon.Columns[3].HeaderText = "Danh mục";
            dgvHangTon.Columns[4].HeaderText = "Tồn hiện tại";
            dgvHangTon.Columns[5].HeaderText = "Tồn tối thiểu";
            dgvHangTon.Columns[6].HeaderText = "Tồn tối đa";
            dgvHangTon.Columns[7].HeaderText = "Trạng thái";

            dgvHangTon.Columns[0].Width = 60;
            dgvHangTon.Columns[1].Width = 100;
            dgvHangTon.Columns[2].Width = 250;
            dgvHangTon.Columns[3].Width = 150;
            dgvHangTon.Columns[4].Width = 100;
            dgvHangTon.Columns[5].Width = 100;
            dgvHangTon.Columns[6].Width = 100;
            dgvHangTon.Columns[7].Width = 100;

            dgvHangTon.AllowUserToAddRows = false;
            dgvHangTon.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Thống kê
            int tongSP = tblHangTon.Rows.Count;
            int hetHang = 0;
            int canhBao = 0;

            foreach (DataRow row in tblHangTon.Rows)
            {
                if (Convert.ToInt32(row["SoLuongTon"]) == 0)
                    hetHang++;
                else
                    canhBao++;
            }

            lblTongSP.Text = $"Tổng số sản phẩm cảnh báo: {tongSP}";
            lblHetHang.Text = $"Hết hàng: {hetHang}";
            lblSapHet.Text = $"Sắp hết: {canhBao}";

            // Highlight màu cho dòng hết hàng
            foreach (DataGridViewRow row in dgvHangTon.Rows)
            {
                if (row.Cells["SoLuongTon"].Value != null)
                {
                    int ton = Convert.ToInt32(row.Cells["SoLuongTon"].Value);
                    if (ton == 0)
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                    else
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (tblHangTon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Implement Excel export
            MessageBox.Show("Chức năng xuất Excel đang phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

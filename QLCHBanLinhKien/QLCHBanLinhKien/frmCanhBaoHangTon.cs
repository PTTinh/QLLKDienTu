using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmCanhBaoHangTon : Form
    {
        private DataTable dtHangTon;

        public frmCanhBaoHangTon()
        {
            InitializeComponent();
        }

        private void frmCanhBaoHangTon_Load(object sender, EventArgs e)
        {
            nudMucCanhBao.Value = 10; // Mac dinh 10 san pham
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Functions.Connect();

                string sql = @"SELECT sp.MaSanPham AS MaSP, sp.TenSanPham AS TenSP, dm.TenDanhMuc, ncc.TenNCC, sp.SoLuongTon, sp.GiaBan AS DonGiaBan
                               FROM SanPham sp
                               LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                               LEFT JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC
                               WHERE sp.SoLuongTon <= @MucCanhBao
                               ORDER BY sp.SoLuongTon ASC";

                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                cmd.Parameters.AddWithValue("@MucCanhBao", (int)nudMucCanhBao.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtHangTon = new DataTable();
                da.Fill(dtHangTon);

                dgvHangTon.DataSource = dtHangTon;

                // Format columns
                if (dgvHangTon.Columns["MaSP"] != null)
                    dgvHangTon.Columns["MaSP"].HeaderText = "Ma SP";
                if (dgvHangTon.Columns["TenSP"] != null)
                    dgvHangTon.Columns["TenSP"].HeaderText = "Ten san pham";
                if (dgvHangTon.Columns["TenDanhMuc"] != null)
                    dgvHangTon.Columns["TenDanhMuc"].HeaderText = "Danh muc";
                if (dgvHangTon.Columns["TenNCC"] != null)
                    dgvHangTon.Columns["TenNCC"].HeaderText = "Nha cung cap";
                if (dgvHangTon.Columns["SoLuongTon"] != null)
                {
                    dgvHangTon.Columns["SoLuongTon"].HeaderText = "So luong ton";
                    dgvHangTon.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvHangTon.Columns["DonGiaBan"] != null)
                {
                    dgvHangTon.Columns["DonGiaBan"].HeaderText = "Don gia";
                    dgvHangTon.Columns["DonGiaBan"].DefaultCellStyle.Format = "N0";
                }

                // Highlight rows with 0 stock
                foreach (DataGridViewRow row in dgvHangTon.Rows)
                {
                    if (row.Cells["SoLuongTon"].Value != null)
                    {
                        int soLuong = Convert.ToInt32(row.Cells["SoLuongTon"].Value);
                        if (soLuong == 0)
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                        }
                        else if (soLuong <= 5)
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        }
                    }
                }

                lblTongSP.Text = "Tong san pham can nhap: " + dtHangTon.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai du lieu: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Functions.Disconnect();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (dtHangTon == null || dtHangTon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmReportViewer.ShowCanhBaoHangTon(dtHangTon, (int)nudMucCanhBao.Value);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

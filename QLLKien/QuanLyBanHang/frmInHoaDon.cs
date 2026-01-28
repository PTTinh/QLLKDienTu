using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmInHoaDon : Form
    {
        private int maHoaDon;

        public frmInHoaDon()
        {
            InitializeComponent();
        }

        public frmInHoaDon(int maHD)
        {
            InitializeComponent();
            this.maHoaDon = maHD;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                LoadHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHoaDon()
        {
            DataTable dtHoaDon = new DataTable();
            DataTable dtChiTiet = new DataTable();

            // Lấy thông tin hóa đơn
            string sqlHoaDon = @"SELECT h.MaHoaDon, h.SoHoaDon, h.NgayBan, h.TongTien, h.GiamGia, 
                                h.ThueVAT, h.ThanhTien, h.PhuongThucThanhToan,
                                k.HoTen as TenKhachHang, k.SoDienThoai, k.DiaChi,
                                n.HoTen as TenNhanVien
                         FROM HoaDon h
                         LEFT JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                         LEFT JOIN NguoiDung n ON h.MaNhanVien = n.MaNguoiDung
                         WHERE h.MaHoaDon = " + maHoaDon;
            
            dtHoaDon = Functions.GetDataToTable(sqlHoaDon);

            // Lấy chi tiết hóa đơn
            string sqlChiTiet = @"SELECT sp.TenSanPham, sp.MaSoSanPham,
                                 ct.SoLuong, ct.DonGia, ct.GiamGia, ct.ThanhTien
                          FROM ChiTietHoaDon ct
                          INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                          WHERE ct.MaHoaDon = " + maHoaDon;

            dtChiTiet = Functions.GetDataToTable(sqlChiTiet);

            if (dtHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Hiển thị hóa đơn dạng text (không dùng rdlc để tránh lỗi assembly)
            reportViewer1.Visible = false;
            DisplayInvoicePanel(dtHoaDon, dtChiTiet);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.PrintDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveDialog.FileName = "HoaDon_" + maHoaDon + ".pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    byte[] bytes = reportViewer1.LocalReport.Render(
                        "PDF", null, out mimeType, out encoding,
                        out extension, out streamids, out warnings);

                    System.IO.FileStream fs = new System.IO.FileStream(
                        saveDialog.FileName, System.IO.FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                    MessageBox.Show("Đã xuất file thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xuất Excel
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportHoaDonToExcel(maHoaDon);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Hiển thị thông tin hóa đơn và chi tiết hóa đơn dạng text khi không có file báo cáo.
        /// </summary>
        private void DisplayInvoiceInfo(DataTable dtHoaDon, DataTable dtChiTiet)
        {
            string info = "THÔNG TIN HÓA ĐƠN\n";
            if (dtHoaDon.Rows.Count > 0)
            {
                var row = dtHoaDon.Rows[0];
                info += $"Số hóa đơn: {row["SoHoaDon"]}\n";
                info += $"Ngày bán: {row["NgayBan"]}\n";
                info += $"Khách hàng: {row["TenKhachHang"]}\n";
                info += $"Nhân viên: {row["TenNhanVien"]}\n";
                info += $"Tổng tiền: {row["TongTien"]}\n";
                info += $"Giảm giá: {row["GiamGia"]}\n";
                info += $"Thuế VAT: {row["ThueVAT"]}\n";
                info += $"Thành tiền: {row["ThanhTien"]}\n";
                info += $"Phương thức thanh toán: {row["PhuongThucThanhToan"]}\n";
                info += $"Địa chỉ: {row["DiaChi"]}\n";
                info += $"SĐT: {row["SoDienThoai"]}\n";
            }
            info += "\nCHI TIẾT HÓA ĐƠN\n";
            foreach (DataRow dr in dtChiTiet.Rows)
            {
                info += $"Sản phẩm: {dr["TenSanPham"]} - Mã: {dr["MaSoSanPham"]} - SL: {dr["SoLuong"]} - Đơn giá: {dr["DonGia"]} - Giảm giá: {dr["GiamGia"]} - Thành tiền: {dr["ThanhTien"]}\n";
            }

            // Hiển thị thông tin ra một MessageBox hoặc TextBox (nếu có)
            MessageBox.Show(info, "Thông tin hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Hiển thị hóa đơn dạng Panel với format đẹp
        /// </summary>
        private void DisplayInvoicePanel(DataTable dtHoaDon, DataTable dtChiTiet)
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            panel.BackColor = System.Drawing.Color.White;
            this.Controls.Add(panel);
            panel.BringToFront();

            int y = 20;

            // Tiêu đề
            Label lblTitle = new Label();
            lblTitle.Text = "CỬA HÀNG LINH KIỆN ĐIỆN TỬ";
            lblTitle.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(200, y);
            panel.Controls.Add(lblTitle);
            y += 35;

            Label lblSubTitle = new Label();
            lblSubTitle.Text = "HÓA ĐƠN BÁN HÀNG";
            lblSubTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new System.Drawing.Point(250, y);
            panel.Controls.Add(lblSubTitle);
            y += 40;

            if (dtHoaDon.Rows.Count > 0)
            {
                var row = dtHoaDon.Rows[0];

                // Thông tin hóa đơn
                AddLabel(panel, $"Số HĐ: {row["SoHoaDon"]}", 20, y, true);
                AddLabel(panel, $"Ngày: {Convert.ToDateTime(row["NgayBan"]):dd/MM/yyyy HH:mm}", 400, y, false);
                y += 25;

                AddLabel(panel, $"Khách hàng: {row["TenKhachHang"]}", 20, y, false);
                y += 25;

                AddLabel(panel, $"SĐT: {row["SoDienThoai"]}", 20, y, false);
                AddLabel(panel, $"Nhân viên: {row["TenNhanVien"]}", 400, y, false);
                y += 25;

                AddLabel(panel, $"Địa chỉ: {row["DiaChi"]}", 20, y, false);
                y += 35;

                // Đường kẻ
                Label line1 = new Label();
                line1.Text = "─────────────────────────────────────────────────────────────────────────────────";
                line1.Location = new System.Drawing.Point(20, y);
                line1.AutoSize = true;
                panel.Controls.Add(line1);
                y += 20;

                // Chi tiết hóa đơn
                AddLabel(panel, "CHI TIẾT HÓA ĐƠN", 20, y, true);
                y += 30;

                // Header
                AddLabel(panel, "STT", 20, y, true);
                AddLabel(panel, "Tên sản phẩm", 60, y, true);
                AddLabel(panel, "SL", 300, y, true);
                AddLabel(panel, "Đơn giá", 350, y, true);
                AddLabel(panel, "Thành tiền", 450, y, true);
                y += 25;

                int stt = 1;
                foreach (DataRow dr in dtChiTiet.Rows)
                {
                    AddLabel(panel, stt.ToString(), 20, y, false);
                    AddLabel(panel, dr["TenSanPham"].ToString(), 60, y, false);
                    AddLabel(panel, dr["SoLuong"].ToString(), 300, y, false);
                    AddLabel(panel, string.Format("{0:N0}", dr["DonGia"]), 350, y, false);
                    AddLabel(panel, string.Format("{0:N0}", dr["ThanhTien"]), 450, y, false);
                    y += 22;
                    stt++;
                }

                y += 10;
                // Đường kẻ
                Label line2 = new Label();
                line2.Text = "─────────────────────────────────────────────────────────────────────────────────";
                line2.Location = new System.Drawing.Point(20, y);
                line2.AutoSize = true;
                panel.Controls.Add(line2);
                y += 25;

                // Tổng tiền
                AddLabel(panel, $"Tổng tiền: {string.Format("{0:N0}", row["TongTien"])} VNĐ", 350, y, false);
                y += 25;
                AddLabel(panel, $"Giảm giá: {string.Format("{0:N0}", row["GiamGia"])} VNĐ", 350, y, false);
                y += 25;
                AddLabel(panel, $"Thuế VAT: {string.Format("{0:N0}", row["ThueVAT"])} VNĐ", 350, y, false);
                y += 30;

                Label lblThanhTien = new Label();
                lblThanhTien.Text = $"THÀNH TIỀN: {string.Format("{0:N0}", row["ThanhTien"])} VNĐ";
                lblThanhTien.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
                lblThanhTien.ForeColor = System.Drawing.Color.DarkRed;
                lblThanhTien.AutoSize = true;
                lblThanhTien.Location = new System.Drawing.Point(350, y);
                panel.Controls.Add(lblThanhTien);
                y += 30;

                AddLabel(panel, $"Thanh toán: {row["PhuongThucThanhToan"]}", 350, y, false);
                y += 40;

                // Cảm ơn
                Label lblCamOn = new Label();
                lblCamOn.Text = "Cảm ơn quý khách!";
                lblCamOn.Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Italic);
                lblCamOn.AutoSize = true;
                lblCamOn.Location = new System.Drawing.Point(280, y);
                panel.Controls.Add(lblCamOn);
            }
        }

        private void AddLabel(Panel panel, string text, int x, int y, bool bold)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("Arial", 10, bold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(x, y);
            panel.Controls.Add(lbl);
        }
    }
}

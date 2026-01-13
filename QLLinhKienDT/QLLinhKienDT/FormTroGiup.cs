using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using QLLinhKienDT.Utils;

namespace QLLinhKienDT
{
    public partial class FormTroGiup : Form
    {
        public FormTroGiup()
        {
            InitializeComponent();
            FormTheme.ApplyTheme(this);
        }

        private void FormTroGiup_Load(object sender, EventArgs e)
        {
            // Tải nội dung hướng dẫn
            LoadHuongDan();
        }

        // Tải nội dung hướng dẫn
        private void LoadHuongDan()
        {
            try
            {
                string htmlContent = @"
                Hướng dẫn sử dụng phần mềm Quản lý Linh kiện Điện tử
                
                1. Quản lý Sản phẩm
                • Nhấp vào 'Sản phẩm' để quản lý danh sách sản phẩm
                • Click 'Thêm' để thêm sản phẩm mới
                • Chọn sản phẩm và click 'Sửa' để cập nhật thông tin
                • Click 'Xóa' để xóa sản phẩm (không thể hoàn tác)
                
                2. Quản lý Khách hàng
                • Vào 'Khách hàng' để xem danh sách
                • Thêm khách hàng mới bằng nút 'Thêm'
                • Chọn khách hàng để xem lịch sử mua hàng
                
                3. Tạo Hóa đơn
                • Chọn 'Bán hàng' → 'Tạo hóa đơn'
                • Chọn khách hàng từ danh sách
                • Thêm sản phẩm và nhập số lượng
                • Hệ thống tự động tính toán tổng tiền, giảm giá và VAT
                • Click 'Lưu' để ghi lại hóa đơn
                
                4. Tìm kiếm nâng cao
                • Vào 'Tìm kiếm' để sử dụng tính năng tìm kiếm
                • Nhập từ khóa để tìm sản phẩm, khách hàng hoặc hóa đơn
                • Lọc theo danh mục để thu hẹp kết quả
                • Hệ thống cung cấp gợi ý khi bạn gõ
                
                5. Báo cáo & Thống kê
                • Chọn 'Báo cáo' để xem thống kê doanh thu
                • Xem biểu đồ doanh thu, sản phẩm bán chạy
                • Xuất báo cáo ra file Excel hoặc PDF
                
                6. Cấu hình hệ thống
                • Vào 'Cấu hình' để điều chỉnh các thông số:
                  - Tỷ lệ VAT
                  - Mức cảnh báo tồn kho
                ";

                rtbHuongDan.Text = htmlContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hướng dẫn: " + ex.Message);
            }
        }

        // Nút về nhóm
        private void btnVeNhom_Click(object sender, EventArgs e)
        {
            ShowAboutGroup();
        }

        // Hiển thị thông tin về nhóm
        private void ShowAboutGroup()
        {
            string aboutText = "Phần mềm Quản lý Linh kiện Điện tử\n\n" +
                             "Phiên bản: 1.0\n" +
                             "Ngày tạo: 2026\n\n" +
                             "Nhóm phát triển:\n" +
                             "- Người 1 (Toàn) - Quản lý sản phẩm\n" +
                             "- Người 2 (Dững) - Quản lý khách hàng & bán hàng\n" +
                             "- Người 3 (Hân) - Quản lý nhà cung cấp & người dùng\n" +
                             "- Người 4 (Khanh) - Báo cáo & thống kê\n" +
                             "- Người 5 (Tính) - Tìm kiếm & hỗ trợ\n\n" +
                             "Email hỗ trợ: support@qllienkien.com\n" +
                             "Điện thoại: 1900-xxxx";

            MessageBox.Show(aboutText, "Về chúng tôi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút kiểm tra cập nhật
        private void btnKiemTraCapNhat_Click(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        // Kiểm tra cập nhật
        private void CheckUpdate()
        {
            try
            {
                // Phiên bản hiện tại
                string currentVersion = "1.0";

                // Thường xuyên kiểm tra từ server (tạm thời giả lập)
                string latestVersion = "1.0"; // Giả sử là phiên bản mới nhất

                if (currentVersion == latestVersion)
                {
                    MessageBox.Show("Bạn đang sử dụng phiên bản mới nhất!\nPhiên bản: " + currentVersion,
                                  "Kiểm tra cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                        "Có phiên bản mới: " + latestVersion + "\n" +
                        "Bạn muốn tải xuống và cài đặt?",
                        "Cập nhật phần mềm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Thực hiện cập nhật
                        MessageBox.Show("Đang tải xuống cập nhật...\n\nVui lòng chờ!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra cập nhật: " + ex.Message);
            }
        }

        // Sự kiện nút đóng
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

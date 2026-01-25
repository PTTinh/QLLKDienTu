using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmMains : Form
    {
        public frmMains()
        {
            InitializeComponent();
        }

        private void frmMains_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void OpenChildForm(Form childForm)
        {
            // Đóng form con hiện tại nếu có
            foreach (Control control in panelDesktopPane.Controls)
            {
                if (control is Form)
                {
                    control.Dispose();
                    panelDesktopPane.Controls.Remove(control);
                    break;
                }
            }
            
            // Mở form con mới
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktopPane.Controls.Add(childForm);
            panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        

        private void mnuKhachhang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyKhachHang());
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDoiMatKhau());
        }

        private void mnuCauHinh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCauHinh());
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect();
            Application.Exit();
        }

        private void mnuChatlieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyDanhMuc());
        }

        private void mnuHanghoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDanhSachSanPham());
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyNhaCungCap());
        }

        private void mnuNhanvien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyNguoiDung());
        }

        private void mnuHoadonban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPOS());
        }

        private void mnuFindHoadon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTimHDBan());
        }

        private void mnuVainet_Click(object sender, EventArgs e)
        {

        }
        private void mnuHoadon_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuFindHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTimHang());
        }

        private void mnuFindKhachhang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTimKhachHang());
        }

        private void mnuBCHangton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCanhBaoHangTon());
        }

        private void mnuBCDoanhthu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKeDoanhThu());
        }

        private void mnuDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard());
        }

        private void mnuTopSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTopSanPham());
        }

        private void mnuThongKeNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKeNhanVien());
        }

        private void mnuHientrogiup_Click(object sender, EventArgs e)
        {

        }
    }
}

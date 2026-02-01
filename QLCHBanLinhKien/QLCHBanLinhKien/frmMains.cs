using System;
using System.Windows.Forms;
using QLCHBanLinhKien.Class;

namespace QLCHBanLinhKien
{
    public partial class frmMains : Form
    {
        public frmMains()
        {
            InitializeComponent();
        }


        private void frmMains_Load(object sender, EventArgs e)
        {

            Functions.Connect();
            if (Functions.currentUserRole != "Quản trị")
            {
                this.mnuDanhMucMenu.Visible = false;
                this.mnuKho.Visible = false;
                this.mnuCauHinh.Visible = false;
                OpenChildForm(new frmPOS());
                return;
            }
            lblUser.Text = "Người dùng: " + Functions.currentUser;
            lblRole.Text = "Vai trò: " + Functions.currentUserRole;
            OpenChildForm(new frmDashboard());

        }


        private void OpenChildForm(Form childForm)
        {
            // Dong form con hien tai neu co
            foreach (Control control in panelDesktopPane.Controls)
            {
                if (control is Form)
                {
                    control.Dispose();
                    panelDesktopPane.Controls.Remove(control);
                    break;
                }
            }

            // Mo form con moi
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktopPane.Controls.Add(childForm);
            panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Functions.Disconnect();
                Application.Exit();
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Functions.Disconnect();
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                this.Close();
            }
        }


        private void mnuDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard());
        }

        // Menu Danh muc
        private void mnuSanPham_Click(object sender, EventArgs e)
        {

            OpenChildForm(new frmQuanLySanPham());
        }

        private void mnuDanhMuc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyDanhMuc());
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyKhachHang());
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyNhaCungCap());
        }

        private void mnuNguoiDung_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyNguoiDung());
        }

        // Menu Hoa don
        private void mnuBanHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPOS());
        }

        private void mnuTimHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTimHoaDon());
        }

        // Menu Bao cao
        private void mnuBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKeDoanhThu());
        }

        private void mnuBaoCaoHangTon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCanhBaoHangTon());
        }

        private void mnuThongKeNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKeNhanVien());
        }

        private void mnuTopSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTopSanPham());
        }

        private void mnuTopKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTopKhachHang());
        }

        private void mnuLichSuMuaHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLichSuMuaHang());
        }

        // Menu Tim kiem
        private void mnuTimSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTimSanPham());
        }

        private void mnuTimKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTimKhachHang());
        }

        // Menu Kho hang
        private void mnuNhapHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhapHang());
        }

        private void mnuCapNhatSanPham_Click(object sender, EventArgs e)
        {
            frmCapNhatSanPham frm = new frmCapNhatSanPham();
            frm.ShowDialog();
        }

        // Menu He thong
        private void mnuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan frm = new frmThongTinCaNhan(Functions.currentUserId);
            frm.ShowDialog();
        }

        private void mnuCauHinh_Click(object sender, EventArgs e)
        {
            frmCauHinh frm = new frmCauHinh();
            frm.ShowDialog();
        }

        // Menu Tro giup
        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chương trình quản lý cửa hàng linh kiện điện tử\nPhiên bản: 1.0.0\nTác giả: Team DEV",
                "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuHuongDan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ: support@linhkien.vn", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuDanhMucMenu_Click(object sender, EventArgs e)
        {

        }

        private void mnuKho_Click(object sender, EventArgs e)
        {

        }
    }
}

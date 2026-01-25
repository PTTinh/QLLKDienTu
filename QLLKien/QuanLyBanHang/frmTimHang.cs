using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmTimHang : Form
    {
        DataTable tblHang;
        public frmTimHang()
        {
            InitializeComponent();
        }

        //Phương thức frmTimHang_Load
        private void frmTimHang_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHang.DataSource = null;
        }

        //Phương thức ResetValues
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHang.Focus();
        }

        //Phương thức btnTimKiem_Click
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHang.Text == "") && (txtTenHang.Text == "") && 
                (txtMaChatLieu.Text == "") && (txtSoLuong.Text == "") &&
                (txtDonGiaBan.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT MaSanPham AS MaHang, TenSanPham AS TenHang, MaDanhMuc, SoLuongTon AS SoLuong, GiaNhap AS DonGiaNhap, GiaBan AS DonGiaBan, MoTa AS GhiChu FROM SanPham WHERE 1=1";
            if (txtMaHang.Text != "")
                sql = sql + " AND MaSoSanPham Like N'%" + txtMaHang.Text + "%'";
            if (txtTenHang.Text != "")
                sql = sql + " AND TenSanPham Like N'%" + txtTenHang.Text + "%'";
            if (txtMaChatLieu.Text != "")
                sql = sql + " AND MaDanhMuc Like N'%" + txtMaChatLieu.Text + "%'";
            if (txtSoLuong.Text != "")
                sql = sql + " AND SoLuongTon >=" + txtSoLuong.Text;
            if (txtDonGiaBan.Text != "")
                sql = sql + " AND GiaBan <=" + txtDonGiaBan.Text;
            tblHang = Functions.GetDataToTable(sql);
            if (tblHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHang.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTKHang.DataSource = tblHang;
            LoadDataGridView();
        }

        //Phương thức LoadDataGridView
        private void LoadDataGridView()
        {
            dgvTKHang.Columns[0].HeaderText = "Mã hàng";
            dgvTKHang.Columns[1].HeaderText = "Tên hàng";
            dgvTKHang.Columns[2].HeaderText = "Danh mục";
            dgvTKHang.Columns[3].HeaderText = "Số lượng tồn";
            dgvTKHang.Columns[4].HeaderText = "Đơn giá nhập";
            dgvTKHang.Columns[5].HeaderText = "Đơn giá bán";
            dgvTKHang.Columns[6].HeaderText = "Ghi chú";
            dgvTKHang.Columns[0].Width = 100;
            dgvTKHang.Columns[1].Width = 150;
            dgvTKHang.Columns[2].Width = 100;
            dgvTKHang.Columns[3].Width = 80;
            dgvTKHang.Columns[4].Width = 100;
            dgvTKHang.Columns[5].Width = 100;
            dgvTKHang.Columns[6].Width = 100;
            dgvTKHang.Columns[7].Width = 150;
            dgvTKHang.AllowUserToAddRows = false;
            dgvTKHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        //phương thức tìm lại
        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHang.DataSource = null;
        }

        //Phương thức txtSoLuong_KeyPress
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        //Phương thức txtDonGiaBan_KeyPress
        private void txtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

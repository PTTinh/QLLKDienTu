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
    public partial class frmTimKhachHang : Form
    {
        DataTable tblKhach;
        public frmTimKhachHang()
        {
            InitializeComponent();
        }

        //Phương thức frmTimKhachHang_Load
        private void frmTimKhachHang_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKKhachHang.DataSource = null;
        }

        //Phương thức ResetValues
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaKhach.Focus();
        }

        //Phương thức btnTimKiem_Click
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaKhach.Text == "") && (txtTenKhach.Text == "") && 
                (txtDiaChi.Text == "") && (txtDienThoai.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT MaKhachHang AS MaKhach, HoTen AS TenKhach, DiaChi, SoDienThoai AS DienThoai FROM KhachHang WHERE 1=1";
            if (txtMaKhach.Text != "")
                sql = sql + " AND MaSoKhachHang Like N'%" + txtMaKhach.Text + "%'";
            if (txtTenKhach.Text != "")
                sql = sql + " AND HoTen Like N'%" + txtTenKhach.Text + "%'";
            if (txtDiaChi.Text != "")
                sql = sql + " AND DiaChi Like N'%" + txtDiaChi.Text + "%'";
            if (txtDienThoai.Text != "")
                sql = sql + " AND SoDienThoai Like N'%" + txtDienThoai.Text + "%'";
            tblKhach = Functions.GetDataToTable(sql);
            if (tblKhach.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblKhach.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTKKhachHang.DataSource = tblKhach;
            LoadDataGridView();
        }

        //Phương thức LoadDataGridView
        private void LoadDataGridView()
        {
            dgvTKKhachHang.Columns[0].HeaderText = "Mã khách";
            dgvTKKhachHang.Columns[1].HeaderText = "Tên khách";
            dgvTKKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvTKKhachHang.Columns[3].HeaderText = "Điện thoại";
            dgvTKKhachHang.Columns[0].Width = 100;
            dgvTKKhachHang.Columns[1].Width = 200;
            dgvTKKhachHang.Columns[2].Width = 300;
            dgvTKKhachHang.Columns[3].Width = 150;
            dgvTKKhachHang.AllowUserToAddRows = false;
            dgvTKKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        //phương thức tìm lại
        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKKhachHang.DataSource = null;
        }

        //Phương thức txtDienThoai_KeyPress
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
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

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
using QLLinhKienDT.Utils;

namespace QLLinhKienDT
{
    public partial class FormTimKiemNangCao : Form
    {
        public FormTimKiemNangCao()
        {
            InitializeComponent();
            FormTheme.ApplyTheme(this);
        }

        private void FormTimKiemNangCao_Load(object sender, EventArgs e)
        {
            // Khởi tạo form
            LoadComboboxData();
            SetupAutoComplete();
        }

        // Tải dữ liệu vào combobox
        private void LoadComboboxData()
        {
            try
            {
                // Tải danh mục sản phẩm
                DataTable dtDanhMuc = DataAccess.ExecuteQuery("SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc");
                cboLoaiTimKiem.Items.Add("Tất cả");
                foreach (DataRow row in dtDanhMuc.Rows)
                {
                    cboLoaiTimKiem.Items.Add(row["TenDanhMuc"].ToString());
                }
                cboLoaiTimKiem.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Thiết lập tính năng auto-suggest
        private void SetupAutoComplete()
        {
            txtTimKiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTimKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }



        // Xử lý sự kiện khi người dùng gõ từ khóa
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length > 1)
            {
                // Gợi ý các sản phẩm khi gõ
                LoadAutoCompleteSuggestions(txtTimKiem.Text);
            }
        }

        // Tải gợi ý auto-complete
        private void LoadAutoCompleteSuggestions(string keyword)
        {
            try
            {
                // Sử dụng TOP thay vì LIMIT (SQL Server)
                string query = "SELECT TOP 10 DISTINCT TenSanPham FROM SanPham WHERE TenSanPham LIKE '%" + keyword + "%'";
                DataTable dt = DataAccess.ExecuteQuery(query);
                
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                foreach (DataRow row in dt.Rows)
                {
                    collection.Add(row["TenSanPham"].ToString());
                }
                txtTimKiem.AutoCompleteCustomSource = collection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Nút tìm kiếm sản phẩm
        private void btnTimSanPham_Click(object sender, EventArgs e)
        {
            TimKiemSanPham();
        }

        // Hàm tìm kiếm sản phẩm
        private void TimKiemSanPham()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string category = (cboLoaiTimKiem.SelectedItem != null) ? cboLoaiTimKiem.SelectedItem.ToString() : "Tất cả";

                // Xây dựng câu truy vấn
                string query = "SELECT MaSanPham, TenSanPham, GiaBan, SoLuongTon FROM SanPham WHERE 1=1";

                // Lọc theo từ khóa
                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND TenSanPham LIKE N'%" + keyword + "%'";
                }

                // Lọc theo danh mục an toàn
                if (category != "Tất cả" && !string.IsNullOrEmpty(category))
                {
                    // Tách mã danh mục từ tên danh mục trước
                    string queryCategory = "SELECT MaDanhMuc FROM DanhMuc WHERE TenDanhMuc = N'" + category.Replace("'", "''") + "'";
                    DataTable dtCategory = DataAccess.ExecuteQuery(queryCategory);
                    
                    if (dtCategory.Rows.Count > 0)
                    {
                        string maDanhMuc = dtCategory.Rows[0]["MaDanhMuc"].ToString();
                        query += " AND MaDanhMuc = " + maDanhMuc;
                    }
                    else
                    {
                        MessageBox.Show("Danh mục không tồn tại!");
                        return;
                    }
                }

                // Thực thi truy vấn và hiển thị kết quả
                DataTable dt = DataAccess.ExecuteQuery(query);
                dgvKetQua.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // Nút tìm kiếm khách hàng
        private void btnTimKhachHang_Click(object sender, EventArgs e)
        {
            TimKiemKhachHang();
        }

        // Hàm tìm kiếm khách hàng
        private void TimKiemKhachHang()
        {
            try
            {
                string keyword = txtTimKiem.Text;
                string query = "SELECT MaKhachHang, HoTen, SoDienThoai, Email, LoaiKhachHang FROM KhachHang WHERE 1=1";

                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND (HoTen LIKE '%" + keyword + "%' OR SoDienThoai LIKE '%" + keyword + "%')";
                }

                DataTable dt = DataAccess.ExecuteQuery(query);
                dgvKetQua.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // Nút tìm kiếm hóa đơn
        private void btnTimHoaDon_Click(object sender, EventArgs e)
        {
            TimKiemHoaDon();
        }

        // Hàm tìm kiếm hóa đơn
        private void TimKiemHoaDon()
        {
            try
            {
                string keyword = txtTimKiem.Text;
                string query = "SELECT MaHoaDon, SoHoaDon, NgayBan, TongTien, TrangThai FROM HoaDon WHERE 1=1";

                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND SoHoaDon LIKE '%" + keyword + "%'";
                }

                DataTable dt = DataAccess.ExecuteQuery(query);
                dgvKetQua.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // Nút xóa tìm kiếm
        private void btnXoaTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLoaiTimKiem.SelectedIndex = 0;
            dgvKetQua.DataSource = null;
        }
    }
}

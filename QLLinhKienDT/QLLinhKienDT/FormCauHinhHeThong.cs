using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLLinhKienDT.Utils;

namespace QLLinhKienDT
{
    public partial class FormCauHinhHeThong : Form
    {
        public FormCauHinhHeThong()
        {
            InitializeComponent();
        }

        private void FormCauHinhHeThong_Load(object sender, EventArgs e)
        {
            // Tải cài đặt từ database
            LoadSettings();
        }

        // Tải cài đặt từ database
        private void LoadSettings()
        {
            try
            {
                // Tải VAT
                string vatValue = GetCauHinhValue("VAT", "10");
                txtVAT.Text = vatValue;

                // Tải tồn kho tối thiểu
                string minStockValue = GetCauHinhValue("TonToiThieu", "5");
                txtTonToiThieu.Text = minStockValue;

                // Tải tồn kho tối đa
                string maxStockValue = GetCauHinhValue("TonToiDa", "100");
                txtTonToiDa.Text = maxStockValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải cài đặt: " + ex.Message);
            }
        }

        // Lấy giá trị cấu hình từ database
        private string GetCauHinhValue(string tenCauHinh, string defaultValue)
        {
            try
            {
                string query = "SELECT GiaTri FROM HeThongCauHinh WHERE TenCauHinh = '" + tenCauHinh + "'";
                DataTable dt = DataAccess.ExecuteQuery(query);
                
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["GiaTri"].ToString();
                }
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        // Nút lưu cài đặt
        private void btnLuuCaiDat_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        // Lưu cài đặt vào database
        private void SaveSettings()
        {
            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (!IsValidNumber(txtVAT.Text))
                {
                    MessageBox.Show("VAT phải là số!");
                    return;
                }

                if (!IsValidNumber(txtTonToiThieu.Text))
                {
                    MessageBox.Show("Tồn kho tối thiểu phải là số!");
                    return;
                }

                if (!IsValidNumber(txtTonToiDa.Text))
                {
                    MessageBox.Show("Tồn kho tối đa phải là số!");
                    return;
                }

                // Lưu VAT
                UpdateCauHinh("VAT", txtVAT.Text);

                // Lưu tồn kho tối thiểu
                UpdateCauHinh("TonToiThieu", txtTonToiThieu.Text);

                // Lưu tồn kho tối đa
                UpdateCauHinh("TonToiDa", txtTonToiDa.Text);

                MessageBox.Show("Lưu cài đặt thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu cài đặt: " + ex.Message);
            }
        }

        // Cập nhật cấu hình vào database
        private void UpdateCauHinh(string tenCauHinh, string giaTri)
        {
            try
            {
                string query = "UPDATE HeThongCauHinh SET GiaTri = N'" + giaTri + "', NgayCapNhat = GETDATE() WHERE TenCauHinh = '" + tenCauHinh + "'";
                DataAccess.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật cấu hình: " + ex.Message);
            }
        }

        // Kiểm tra chuỗi có phải số không
        private bool IsValidNumber(string text)
        {
            return decimal.TryParse(text, out _);
        }
    }
}

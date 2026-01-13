using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLinhKienDT.Utils
{
    public static class DataAccess
    {
        private static string ConnectionString => @"Data Source=TINH\SQLEXPRESS;Initial Catalog=QLCHLinhKienDienTu;Integrated Security=True";
        // Kiểm tra chuỗi kết nối
        private static void EnsureConnectionString()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new InvalidOperationException("Chuỗi kết nối cơ sở dữ liệu không được cấu hình.");
        }

        // Thực thi truy vấn và trả về DataTable
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            EnsureConnectionString();
            var dt = new DataTable();
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"Truy vấn cơ sở dữ liệu thất bại: {ex.Message}", ex);
            }
        }
        // Thực thi câu lệnh không trả về dữ liệu
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            EnsureConnectionString();
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Thực thi non-query cơ sở dữ liệu thất bại: {ex.Message}", ex);
            }
        }

        // Thực thi truy vấn trả về một giá trị duy nhất
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            EnsureConnectionString();
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Truy vấn scalar cơ sở dữ liệu thất bại: {ex.Message}", ex);
            }
        }
    }
}

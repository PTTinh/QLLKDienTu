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

        private static void EnsureConnectionString()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new InvalidOperationException("Connection string 'QLLinhKienConnection' is not configured in App.config.");
        }

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
                throw new Exception($"Database query failed: {ex.Message}", ex);
            }
        }

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
                throw new Exception($"Database non-query failed: {ex.Message}", ex);
            }
        }

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
                throw new Exception($"Database scalar query failed: {ex.Message}", ex);
            }
        }
    }
}

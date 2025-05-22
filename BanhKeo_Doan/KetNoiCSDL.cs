using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanhKeo_Doan
{
    internal class KetNoiCSDL
    {
        private static string connectionString = "Server=localhost\\MSSQLSERVER01;Database=QuanLyBanBanhKeo_DoAn;Trusted_Connection=True;";

        public void ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public SqlDataReader ExecuteReader(string query)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }


        public DataTable GetData(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi truy vấn: " + ex.Message);
                }
                return dt;
            }
        }
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

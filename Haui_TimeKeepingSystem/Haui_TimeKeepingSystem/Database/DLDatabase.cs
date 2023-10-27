using Haui_TimeKeepingSystem.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui_TimeKeepingSystem.Database
{
    public class DLDatabase
    {
        private static string ConnectionString = ConfigurationSettings.AppSettings["DatabaseConnection"];
        private SqlConnection conn = new SqlConnection(ConnectionString);
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader dr;
        private SqlDataAdapter da;

        /// <summary>
        /// Lấy lịch sử chấm công để xuất excel
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public DataTable GetHistoryForExport(string sqlCommand)
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                da = new SqlDataAdapter(sqlCommand, conn);
                da.Fill(dt);
                conn.Close();
            }
            catch (Exception ee)
            {

            }
            return dt;
        }

        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public DataTable GetallEmployee(string sqlCommand)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                da = new SqlDataAdapter(sqlCommand, conn);
                da.Fill(dt);
                conn.Close();
            }
            catch (Exception ee)
            {

            }

            return dt;
        }

        /// <summary>
        /// Thêm lịch sử chấm công
        /// </summary>
        /// <param name="Stored"></param>
        /// <param name="item"></param>
        public void InsertHistory(string Stored, clsEmployeeTimeKeeping item)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Stored;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", new Guid());
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ee)
            {

            }
        }

        /// <summary>
        /// Lấy lịch sử chấm công của 1 nhân viên nào đó
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public DataTable GetKeppingHistoryByEmployeeCode(string sqlCommand)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                da = new SqlDataAdapter(sqlCommand, conn);
                da.Fill(dt);
                conn.Close();
            }
            catch (Exception ee)
            {

            }

            return dt;
        }

        /// <summary>
        /// Cập nhật lịch sử chấm công
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="item"></param>
        public void UpdateHistory(string cmd, clsEmployeeTimeKeeping item)
        {
            
        }
    }
}

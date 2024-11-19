using Haui_TimeKeepingSystem.Common;
using iTextSharp.text.rtf.table;
using Org.BouncyCastle.Cms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using static iTextSharp.text.pdf.AcroFields;

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
                cmd.Parameters.AddWithValue("@ID", item.ID);
                cmd.Parameters.AddWithValue("@FingerID", item.FingerID); // nếu có vân tay thì sửa lại
                cmd.Parameters.AddWithValue("@CardID", item.CardID);
                cmd.Parameters.AddWithValue("@EmployeeName", item.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeCode", item.EmployeeCode);
                cmd.Parameters.AddWithValue("@Department", item.Department);
                cmd.Parameters.AddWithValue("@EmployeeJob", item.EmployeeJob);
                cmd.Parameters.AddWithValue("@InputTime", item.InputTime);
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
        public void UpdateHistory(string Stored, clsEmployeeTimeKeeping item)
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
                cmd.Parameters.AddWithValue("@ID", item.ID);
                cmd.Parameters.AddWithValue("@OutputTime", item.OutputTime);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ee)
            {

            }
        }

        /// <summary>
        /// Lấy ra fingerID lớn nhất để thêm người mới
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public string GetNewFingerID(string sqlCommand)
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
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["FingerID"].ToString();
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// Thực hiện lưu nhân viên mới thêm
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="employee"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SaveEmployee(string Stored, clsEmployee employee)
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
                cmd.Parameters.AddWithValue("@ID", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@FingerID", employee.FingerID);
                cmd.Parameters.AddWithValue("@CardID", employee.CardID);
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@EmployeeJob", employee.EmployeeJob);
                cmd.Parameters.AddWithValue("@ImagePath", employee.ImagePath);
                cmd.Parameters.AddWithValue("@Type", employee.Type);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ee)
            {

            }
        }

        public void DeleteEmployee(string Stored, int fingerID)
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
                cmd.Parameters.AddWithValue("@FingerID", fingerID);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ee)
            {

            }
        }


        public void DeleteEmployeeByCard(string Stored, string cardID)
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
                cmd.Parameters.AddWithValue("@CardID", cardID);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ee)
            {

            }
        }

        public string GetCurrentPassWord(string sqlCommand)
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
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["PassWord"].ToString();
            }
            else
            {
                return "0";
            }
        }

        public void UpdatePassWord(string query, string passWord)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PassWord", passWord);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteHistory(string sqlCommand)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}

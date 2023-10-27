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
    public class BLDatabase
    {
        DLDatabase db = new DLDatabase();

        /// <summary>
        /// Lấy lịch sử chấm công để xuất excel
        /// </summary>
        /// <returns></returns>
        public DataTable GetHistoryForExport()
        {
            DateTime now = DateTime.Now;
            DateTime ToDate = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            DateTime FromDate = new DateTime(now.Year, now.Month, 1, 00, 00, 00);

            string sqlCommand = "EXEC dbo.Proc_GetKeppingHistory @FromDate = '" + FromDate + "', @ToDate = '" + ToDate + "', @EmployeeCode = 'all'";
            return db.GetHistoryForExport(sqlCommand);
        }

        /// <summary>
        /// Lấy ra danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        public DataTable GetallEmployee()
        {
            string cmd = "Proc_GetAllEmployee";
            return db.GetallEmployee(cmd);
        }

        /// <summary>
        /// Thêm mới lịch sử chấm công của nhân viên
        /// </summary>
        /// <param name="item"></param>
        public void InsertHistory(clsEmployeeTimeKeeping item)
        {
            string cmd = "Proc_InsertHistory";
            db.InsertHistory(cmd, item);
        }

        /// <summary>
        /// Lấy lịch sử chấm công của 1 nhân viên
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public DataTable GetKeppingHistoryByEmployeeCode(string employeeCode)
        {
            DateTime now = DateTime.Now;
            DateTime ToDate = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            DateTime FromDate = new DateTime(now.Year, now.Month, now.Day, 00, 00, 00);

            string sqlCommand = "EXEC dbo.Proc_GetKeppingHistory @FromDate = '" + FromDate + "', @ToDate = '" + ToDate + "', @EmployeeCode = '" + employeeCode + "'";
            return db.GetKeppingHistoryByEmployeeCode(employeeCode);
        }

        /// <summary>
        /// Cập nhật lịch sử chấm công
        /// </summary>
        /// <param name="item"></param>
        public void UpdateHistory(clsEmployeeTimeKeeping item)
        {
            string cmd = "Proc_UpdateHistory";
            db.UpdateHistory(cmd, item);
        }
    }
}

﻿using TimeKeepingSystem.Common;
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
using System.Windows.Media.Imaging;
using static iTextSharp.text.pdf.AcroFields;

namespace TimeKeepingSystem.Database
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

            string sqlCommand = "EXEC dbo.Proc_GetKeppingHistory @FromDate = '" + FromDate.ToString("yyyy-MM-dd 00:00:00") + "', @ToDate = '" + ToDate.ToString("yyyy-MM-dd 23:59:59") + "', @EmployeeCode = '" + employeeCode + "'";
            return db.GetKeppingHistoryByEmployeeCode(sqlCommand);
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

        /// <summary>
        /// Tính toán ID của người mới
        /// </summary>
        /// <returns></returns>
        public string GetNewFingerID()
        {
            string cmd = "Proc_GetLastFingerID";
            int newID = int.Parse(db.GetNewFingerID(cmd)) + 1;
            return newID.ToString();
        }

        /// <summary>
        /// Thực hiện lưu thông tin nhân viên mới
        /// </summary>
        /// <param name="employee"></param>
        public void SaveEmployee(clsEmployee employee)
        {
            string cmd = "Proc_InsertEmployee";
            db.SaveEmployee(cmd, employee);
        }

        public void DeleteEmployee(int fingerID)
        {
            string cmd = "Proc_DeleteEmployee";
            db.DeleteEmployee(cmd, fingerID);
        }

        public void DeleteEmployeeByCard(string CardID)
        {
            string cmd = "Proc_DeleteEmployeeByCard";
            db.DeleteEmployeeByCard(cmd, CardID);
        }

        public string GetCurrentPassWord()
        {
            string cmd = "SELECT * FROM PassWordManagerment";
            string PW = db.GetCurrentPassWord(cmd);
            return PW;
        }

        public void UpdatePassWord(string PassWord)
        {
            string cmd = "Update PassWordManagerment Set PassWord = @PassWord";
            db.UpdatePassWord(cmd, PassWord);
        }

        public void DeleteHistory()
        {
            string sqlCommand = "DELETE dbo.History";
             db.DeleteHistory(sqlCommand);
        }
    }
}

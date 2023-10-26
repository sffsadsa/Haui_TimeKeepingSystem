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
        public DataTable GetHistoryForExport()
        {
            DateTime now = DateTime.Now;
            DateTime ToDate = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            DateTime FromDate = new DateTime(now.Year, now.Month, 1, 00, 00, 00);

            string sqlCommand = "EXEC dbo.Proc_GetAlarmHistoryForExport @FromDate = '" + FromDate + "', @ToDate = '" + ToDate + "'";
            return db.GetHistoryForExport(sqlCommand);
        }

        public DataTable GetallEmployee()
        {
            string cmd = "Proc_GetAllEmployee";
            return db.GetallEmployee(cmd);
        }

        public void InsertHistory(clsEmployee item)
        {
            string cmd = "Proc_InsertHistory";
            db.InsertHistory(cmd, item);
        }
    }
}

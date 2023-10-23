using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui_TimeKeepingSystem.Database
{
    public class BLDatabase
    {
        public DataTable GetHistoryForExport()
        {
            DateTime now = DateTime.Now;
            DateTime ToDate = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            DateTime FromDate = ToDate.AddDays(-8);
            DLDatabase db = new DLDatabase();
            string sqlCommand = "";
            return db.GetHistoryForExport(sqlCommand);
        }
    }
}

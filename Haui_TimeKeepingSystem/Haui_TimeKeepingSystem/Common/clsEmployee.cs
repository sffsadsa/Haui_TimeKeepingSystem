using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui_TimeKeepingSystem.Common
{
    public class clsEmployee
    {
        public string FingerID { get; set; }
        public string CardID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string Department { get; set; }
        public string EmployeeJob { get; set; }
        public string ImagePath { get; set; }
        public string Type { get; set; }
    }

    public class clsEmployeeTimeKeeping
    {
        public Guid ID { get; set; }
        public string FingerID { get; set; }
        public string CardID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string Department { get; set; }
        public string EmployeeJob { get; set; }
        public DateTime InputTime { get; set; }
        public DateTime OutputTime { get; set; }
    }
}

using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Haui_TimeKeepingSystem.Common
{
    public class ExcelComunication
    {
        public List<clsEmployee> GetAllEmployee()
        {
            // tạo ra danh sách UserInfo rỗng để hứng dữ liệu.
            List<clsEmployee> employeeList = new List<clsEmployee>();
            try
            {
                // mở file excel
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "/Report/Employee.xlsx";
                var package = new ExcelPackage(path);

                // lấy ra sheet đầu tiên để thao tác
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];

                // duyệt tuần tự từ dòng thứ 2 đến dòng cuối cùng của file. lưu ý file excel bắt đầu từ số 1 không phải số 0
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    try
                    {
                        // biến j biểu thị cho một column trong file
                        int j = 1;
                        string FingerID = workSheet.Cells[i, j++].Value.ToString();
                        string Name = workSheet.Cells[i, j++].Value.ToString();
                        string EmployeeCode = workSheet.Cells[i, j++].Value.ToString();
                        string Department = workSheet.Cells[i, j++].Value.ToString();

                        // tạo UserInfo từ dữ liệu đã lấy được
                        clsEmployee user = new clsEmployee()
                        {
                            FingerID = FingerID,
                            Name = Name,
                            EmployeeCode = EmployeeCode,
                            Department = Department
                        };

                        // add UserInfo vào danh sách userList
                        employeeList.Add(user);

                    }
                    catch (Exception exe)
                    {

                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error!");
            }
          
            return employeeList;
        }
    }
}

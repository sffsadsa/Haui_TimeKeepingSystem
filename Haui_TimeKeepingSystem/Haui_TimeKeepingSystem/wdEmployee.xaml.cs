using Aspose.Cells;
using Haui_TimeKeepingSystem.Database;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Haui_TimeKeepingSystem
{
    /// <summary>
    /// Interaction logic for wdHistory.xaml
    /// </summary>
    public partial class wdEmployee : Window
    {
        DataTable _dtReport = new DataTable();
        BLDatabase oBL = new BLDatabase();
        string _deleteEmployeeID, _deleteEmployeeName, _deleteEmployeeCode,_employeeType;
        public wdEmployee()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _dtReport = oBL.GetallEmployee();
            grdHistory.ItemsSource = _dtReport.DefaultView;
        }

        private void grdHistory_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                _deleteEmployeeID = row_selected["CardID"].ToString();
                _deleteEmployeeID = row_selected["FingerID"].ToString();
                _deleteEmployeeName = row_selected["EmployeeName"].ToString();
                _deleteEmployeeCode = row_selected["EmployeeCode"].ToString();
                _employeeType = row_selected["Type"].ToString();
            }
        }

        private void btnExportExCell_Click(object sender, RoutedEventArgs e)
        {
            string TemplateFileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "/Report/ReportTemplate.xlsx";
            TemplateFileName = TemplateFileName.Substring(6, TemplateFileName.Length - 6);
            ArrayList strSheetName = new ArrayList();
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }
            if (File.Exists(TemplateFileName))
            {
                try
                {
                    if (_dtReport.Rows.Count <= 0)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    DataSet ds = new DataSet();
                    ds = _dtReport.DataSet;
                    strSheetName.Add("Danh sách nhân viên");

                    Workbook wbMapping = new Workbook(TemplateFileName);
                    Worksheet wbSheetHistory = wbMapping.Worksheets[0];
                    int x = wbSheetHistory.Cells.ImportDataTable(_dtReport, true, 1, 0);
                    wbMapping.Save(filePath);
                    File.Open(filePath, FileMode.Open);
                    // MessageBox.Show("Xuất khẩu báo cáo thành công. Vui lòng tuy cập vào "+ filePath + " để xem báo cáo!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Có lỗi khi lưu file!");
                }
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_employeeType != "Admin")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng " + _deleteEmployeeName + " - " + _deleteEmployeeCode + " ?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    oBL.DeleteEmployee(int.Parse(_deleteEmployeeID));//xóa bằng mã vân tay
                    //oBL.DeleteEmployeeByCard(_deleteEmployeeID);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    _dtReport.Clear();
                    _dtReport = oBL.GetallEmployee();
                    grdHistory.ItemsSource = _dtReport.DefaultView;
                }
            }
            else
                MessageBox.Show(_deleteEmployeeName + " là chủ nhà. Không thể xóa");


        }
    }
}



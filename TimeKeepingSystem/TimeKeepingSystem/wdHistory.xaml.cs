using Aspose.Cells;
using TimeKeepingSystem.Database;
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

namespace TimeKeepingSystem
{
    /// <summary>
    /// Interaction logic for wdHistory.xaml
    /// </summary>
    public partial class wdHistory : Window
    {
        DataTable _dtReport = new DataTable();
        BLDatabase oBL = new BLDatabase();
        public wdHistory()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _dtReport = oBL.GetHistoryForExport();
            grdHistory.ItemsSource = _dtReport.DefaultView;
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
                    strSheetName.Add("Lịch sử chấm công");

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

        private void btnEmployeeList_Click(object sender, RoutedEventArgs e)
        {
            wdEmployee frm = new wdEmployee();
            frm.ShowDialog();
        }

        private void btnDeleteHistory_Click(object sender, RoutedEventArgs e)
        {
            oBL.DeleteHistory();
            MessageBox.Show("Xóa lịch sử thành công");

            _dtReport = oBL.GetHistoryForExport();
            grdHistory.ItemsSource = _dtReport.DefaultView;
        }
    }
}



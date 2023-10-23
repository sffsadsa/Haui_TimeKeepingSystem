using Aspose.Cells;
using Haui_TimeKeepingSystem.Database;
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

            string TempplateFileName = "D:\\Report\\Report Template.xlsx";
            ArrayList strSheetName = new ArrayList();

            // Xuất Excel
            if (_dtReport.Rows.Count <= 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (File.Exists(TempplateFileName))
            {
                try
                {
                    if (Title == "Chi tiết lịch sử vận chuyển")
                    {
                        DataSet ds = new DataSet();
                        ds = _dtReport.DataSet;
                        strSheetName.Add("Lịch sử lệnh vận chuyển");
                        strSheetName.Add("Lịch sử Lỗi vận hành");

                        Workbook wbMapping = new Workbook(TempplateFileName);
                        Worksheet wbSheetCommandHistory = wbMapping.Worksheets[0];
                        Worksheet wbSheetAlarmHistory = wbMapping.Worksheets[1];

                        int x = wbSheetCommandHistory.Cells.ImportDataTable(_dtReport, true, 1, 0);

                        string filePath = "D:\\Report\\Weekly Report_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";

                        wbMapping.Save(filePath);
                    }

                    MessageBox.Show("Xuất khẩu báo cáo thành công. Vui lòng tuy cập vào <<D:\\Report>> để xem báo cáo!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                }
                return;
            }
        }
    }
}
    


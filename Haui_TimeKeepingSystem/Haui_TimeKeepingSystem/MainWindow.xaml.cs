using Haui_TimeKeepingSystem.Common;
using Haui_TimeKeepingSystem.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Haui_TimeKeepingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort STM_Input = new SerialPort();
        List<clsEmployee> lstEmployee;
        BLDatabase oBL = new BLDatabase();
        private string strConnectFail = "Không thể kết nối tới máy chấm công của bạn. Vui lòng kiểm tra lại!";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetallEmployee();
            try
            {
                STM_Input.PortName = XINIFILE.ReadValue("COM_STM");
                STM_Input.BaudRate = int.Parse(XINIFILE.ReadValue("BAURATE"));
                STM_Input.Open();
                STM_Input.DataReceived += STM_Input_DataReceived;
            }
            catch (Exception)
            {
                MessageBox.Show(strConnectFail, "Lỗi kết nối Lora", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void GetallEmployee()
        {
            lstEmployee = new List<clsEmployee>();
            clsEmployee employee = new clsEmployee();
            DataTable dt = new DataTable();
            dt = oBL.GetallEmployee();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    employee.FingerID = dr["FingerID"].ToString();
                    employee.EmployeeName = dr["EmployeeName"].ToString();
                    employee.EmployeeCode = dr["EmployeeCode"].ToString();
                    employee.Department = dr["Department"].ToString();
                    employee.EmployeeJob = dr["EmployeeJob"].ToString();
                    lstEmployee.Add(employee);
                }
            }
        }

        private void STM_Input_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data;
                if (STM_Input.BytesToRead > 500)
                {
                    STM_Input.DiscardInBuffer();
                    return;
                }
                data = STM_Input.ReadTo("x");
                data = data.Substring(1, data.Length - 1);
                DataAnalys(data);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void DataAnalys(string data)
        {
            foreach (var item in lstEmployee)
            {
                if(item.FingerID == data)
                {
                    oBL.InsertHistory(item);
                }    
            }    
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            wdHistory frm = new wdHistory();
            frm.ShowDialog();
        }
    }
}

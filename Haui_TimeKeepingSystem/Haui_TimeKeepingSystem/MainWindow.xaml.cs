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
using static iTextSharp.text.pdf.AcroFields;

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
        private bool mAddEmployee = false;
        private string strConnectFail = "Không thể kết nối tới máy chấm công của bạn. Vui lòng kiểm tra lại!";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            CheckLiensce();
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

        private void CheckLiensce()
        {
            DateTime LiesnceDate = new DateTime(2024, 12, 31, 23, 59, 59);
            DateTime dateTime = DateTime.Now;

            int x = (dateTime - LiesnceDate).Days;
            if (x > 0)
            {
                string str = "Phần mềm đã hết hạn bản quyền sử dụng. Vui lòng liên hệ nhà cung cấp để được hỗ trợ Email:trananh260697@gmail.com Phone:0962174807";
                if (MessageBox.Show(str, "Hết hạn bản quyền", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    this.Close();
                }
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
                    employee.ImagePath = dr["ImagePath"].ToString();
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
                if (!mAddEmployee)
                {
                    DataAnalys(data);
                }
                else
                {
                    AddNewEmployee(data);
                    mAddEmployee = false;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void AddNewEmployee(string data)
        {

        }

        /// <summary>
        /// Xử lý khi có người chấm công
        /// </summary>
        /// <param name="data"></param>
        private void DataAnalys(string data)
        {
            foreach (var item in lstEmployee)
            {
                if (item.FingerID == data)
                {
                    clsEmployeeTimeKeeping TimeKeeping = new clsEmployeeTimeKeeping();
                    TimeKeeping.FingerID = item.FingerID;
                    TimeKeeping.EmployeeCode = item.EmployeeCode;
                    TimeKeeping.EmployeeName = item.EmployeeName;
                    TimeKeeping.Department = item.Department;
                    TimeKeeping.EmployeeJob = item.EmployeeJob;

                    txtEmployeeName.Text = TimeKeeping.EmployeeName;
                    txtEmployeeCode.Text = TimeKeeping.EmployeeCode;
                    txtDepartMent.Text = TimeKeeping.Department;
                    txtJob.Text = TimeKeeping.EmployeeJob;
                    txtName.Text = TimeKeeping.EmployeeName;
                    txtCode.Text = TimeKeeping.EmployeeCode;

                    img_People.Source = new BitmapImage(new Uri("pack://application:,,," + item.ImagePath)); //"/Images/service.png"

                    DataTable KeepHistory = oBL.GetKeppingHistoryByEmployeeCode(item.EmployeeCode);
                    if (KeepHistory != null)
                    {
                        //Nếu đã chấm công vào lớn hơn 5p thì tính là chấm công ra
                        if ((DateTime.Now - DateTime.Parse(KeepHistory.Rows[0]["InputTime"].ToString())).TotalMinutes > 5)
                        {
                            TimeKeeping.ID = Guid.Parse(KeepHistory.Rows[0]["ID"].ToString());
                            TimeKeeping.InputTime = DateTime.Parse(KeepHistory.Rows[0]["InputTime"].ToString());
                            TimeKeeping.OutputTime = DateTime.Now;
                            oBL.UpdateHistory(TimeKeeping);
                        }

                        txtInputTime.Text = TimeKeeping.InputTime.ToString("HH:mm:ss dd/MM/yyyy");
                        txtOutputTime.Text = TimeKeeping.OutputTime.ToString("HH:mm:ss dd/MM/yyyy");

                    }
                    else
                    {
                        //Nếu không có lịch sử chấm công thì thực hiện chấm công vào
                        TimeKeeping.ID = Guid.NewGuid();
                        TimeKeeping.InputTime = DateTime.Now;
                        txtInputTime.Text = TimeKeeping.InputTime.ToString("HH:mm:ss dd/MM/yyyy");

                        oBL.InsertHistory(TimeKeeping);

                    }

                }
            }
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            wdHistory frm = new wdHistory();
            frm.ShowDialog();
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vui lòng đặt tay vào máy quét", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            mAddEmployee = true;
        }
    }
}

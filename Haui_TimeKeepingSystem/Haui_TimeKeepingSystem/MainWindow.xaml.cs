﻿using Haui_TimeKeepingSystem.Common;
using Haui_TimeKeepingSystem.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
        List<clsEmployee> lstEmployee = new List<clsEmployee>();
        BLDatabase oBL = new BLDatabase();
        private bool mAddEmployee = false;
        private string strConnectFail = "Không thể kết nối tới máy chấm công của bạn. Vui lòng kiểm tra lại!";
        private string mFingerID = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //img_People.Source = new BitmapImage(new Uri("pack://application:,,," + "./Resources/NVA.png")); //"/Images/service.png"

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
            DateTime LiesnceDate = new DateTime(2024, 02, 15, 23, 59, 59);
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

        /// <summary>
        /// Lấy ra danh sách nhân viên
        /// </summary>
        private void GetallEmployee()
        {
            lstEmployee.Clear();       
            DataTable dt = new DataTable();
            dt = oBL.GetallEmployee();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    clsEmployee employee = new clsEmployee();
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

        /// <summary>
        /// Xử lý nhận dữ liệu từ dưới arduino gửi lên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Cú pháp gửi từ arduino lên PC: i + data + x
        /// data: A1 : hoàn thành lấy vân tay lần 1
        ///       A2 : Hoàn thành lấy vân tay lần 2
        ///       ID vân tay lấy từ arduino
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
                //data = STM_Input.ReadExisting();
                data = STM_Input.ReadTo("x");
                data = data.Substring(1, data.Length - 1);
                if (!mAddEmployee)
                {

                    this.Dispatcher.Invoke(() =>
                    {
                        DataAnalys(data);
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        AddNewEmployee(data);
                    });
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// Thực hiện các bước thêm vân tay nhân viên mới
        /// </summary>
        /// <param name="data"></param>
        private void AddNewEmployee(string data)
        {
            if (data.Contains("A1"))
            {
                // Hoàn thành quét vân tay lần 1
                MessageBox.Show("Vui lòng xác thực lại vân tay", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            if (data.Contains("A2"))
            {
                this.Dispatcher.Invoke(() =>
                {
                    // Hoàn thành quét vân tay lần 2 ==> Lưu xong vân tay vào arduino
                    wdAddEmployee frm = new wdAddEmployee();
                    frm.FingerID = mFingerID;
                    frm.ShowDialog();
                    mAddEmployee = false;
                    GetallEmployee();
                });
            }       
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
                    if (KeepHistory.Rows.Count > 0)
                    {
                        //Nếu đã chấm công vào lớn hơn 5p thì tính là chấm công ra
                        if ((DateTime.Now - DateTime.Parse(KeepHistory.Rows[0]["InputTime"].ToString())).TotalMinutes > 3)
                        {
                            TimeKeeping.ID = Guid.Parse(KeepHistory.Rows[0]["ID"].ToString());
                            TimeKeeping.InputTime = DateTime.Parse(KeepHistory.Rows[0]["InputTime"].ToString());
                            TimeKeeping.OutputTime = DateTime.Now;
                            oBL.UpdateHistory(TimeKeeping);
                            txtInputTime.Text = TimeKeeping.InputTime.ToString("HH:mm:ss dd/MM/yyyy");
                            txtOutputTime.Text = TimeKeeping.OutputTime.ToString("HH:mm:ss dd/MM/yyyy");
                        }
                        else
                        {
                            TimeKeeping.InputTime = DateTime.Parse(KeepHistory.Rows[0]["InputTime"].ToString());
                            txtInputTime.Text = TimeKeeping.InputTime.ToString("HH:mm:ss dd/MM/yyyy");
                            txtOutputTime.Text = "";
                        }
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

        /// <summary>
        /// Thực hiện lấy ra lịch sử chấm công nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            wdHistory frm = new wdHistory();
            frm.ShowDialog();
        }

        /// <summary>
        /// Thực hiện thêm nhân viên mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Vui lòng đặt tay vào máy quét", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                mFingerID = oBL.GetNewFingerID();
                STM_Input.Write("t");
                Thread.Sleep(1000);
                STM_Input.Write(mFingerID);
                mAddEmployee = true;

            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.ToString());
            }

        }
    }
}

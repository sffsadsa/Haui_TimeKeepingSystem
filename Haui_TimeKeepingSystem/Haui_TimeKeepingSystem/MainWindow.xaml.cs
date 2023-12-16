using Haui_TimeKeepingSystem.Common;
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
        private bool mRemoveEmployee = false;
        private bool mRemoveAll = false;
        private bool mAddStep1 = false;
        private bool mAddStep2 = false;
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
            STM_Input.Write("c01");
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
                    employee.CardID = dr["CardID"].ToString();
                    employee.EmployeeName = dr["EmployeeName"].ToString();
                    employee.EmployeeCode = dr["EmployeeCode"].ToString();
                    employee.Department = dr["Department"].ToString();
                    employee.EmployeeJob = dr["EmployeeJob"].ToString();
                    employee.ImagePath = dr["ImagePath"].ToString();
                    employee.Type = dr["Type"].ToString();
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
        ///       A3 + RFID_code: mã RFID của nv mới khi thêm
        ///       ID vân tay lấy từ arduino
        ///  f_ + RFID +x  : gửi mã thẻ của nhân viên khi quẹt chấm công
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

                this.Dispatcher.Invoke(() =>
                {
                    Xulydata(data);
                });

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        /// <summary>
        /// Thực hiện xử lý data nhận được
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Xulydata(string data)
        {
            try
            {
                if (data.Substring(0, 1) == "i")
                {
                    data = data.Substring(1, data.Length - 1);
                    if (!mAddEmployee)
                    {
                        //chấm công bẳng vân tay
                        this.Dispatcher.Invoke(() =>
                        {
                            DataAnalys(data);
                        });
                    }
                    else
                    {
                        if (!mAddStep1)
                        {
                            //data = data.Substring(1, data.Length - 1);
                            //thêm nhân viên
                            this.Dispatcher.Invoke(() =>
                            {
                                if (CheckAdminFingerID(data))
                                {
                                    MessageBox.Show("Vui lòng đặt tay vào máy quét", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                                    mFingerID = oBL.GetNewFingerID();
                                    STM_Input.Write("t" + mFingerID);
                                    mAddStep1 = true;
                                }
                                else
                                {
                                    MessageBox.Show("Bạn không có quyền hạn thêm nhân viên", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                                    STM_Input.Write("c01");
                                    mAddEmployee = false;
                                }
                            });
                        }
                        else if (mAddStep1)
                        {
                            //AddNewEmployee(data);
                            if (data.Contains("A2"))
                            {
                                MessageBox.Show("Vui lòng quẹt thẻ nhân viên", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                                mAddStep1 = false;
                                mAddStep2 = true;
                            }

                        }
                    }

                }
                else if (data.Substring(0, 1) == "f")
                {
                    data = data.Substring(1, data.Length - 1);
                    if (!mAddEmployee)
                    {
                        //Chấm công bằng thẻ
                        this.Dispatcher.Invoke(() =>
                        {             
                            CheckInByCard(data);
                        });
                    }
                    else
                    {
                        if ( !mAddStep1 && !mAddStep2)
                        {
                            if (CheckAdminCard(data))
                            {
                                MessageBox.Show("Vui lòng đặt tay vào máy quét", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                                mFingerID = oBL.GetNewFingerID();
                                STM_Input.Write("t" + mFingerID);

                                mAddStep1 = true;
                            }
                            else
                            {
                                MessageBox.Show("Bạn không có quyền hạn thêm nhân viên", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                                STM_Input.Write("c01");
                                mAddEmployee = false;
                            }
                        }
                        else if ( mAddStep2)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                // Hoàn thành quét vân tay lần 2 ==> Lưu xong vân tay vào arduino
                                wdAddEmployee frm = new wdAddEmployee();
                                frm.CardID = data;
                                frm.FingerID = mFingerID;
                                frm.ShowDialog();
                                mAddEmployee = false;
                                mAddStep1 = false;
                                mAddStep2 = false;
                                GetallEmployee();
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Kiểm tra vân tay admin
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool CheckAdminFingerID(string data)
        {
            bool Result = false;
            foreach (var item in lstEmployee)
            {
                if (item.FingerID == data && item.Type == "Admin")
                {
                    Result = true;
                    break;
                }

            }
            return Result;
        }

        /// <summary>
        /// Kiểm tra thẻ admin
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool CheckAdminCard(string data)
        {
            bool Result = false;
            foreach (var item in lstEmployee)
            {
                if (item.CardID == data && item.Type == "Admin")
                {
                    Result = true;
                    break;
                }

            }
            return Result;
        }

        /// <summary>
        /// nhân viên chấm công bằng thẻ RF
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void CheckInByCard(string data)
        {
            foreach (var item in lstEmployee)
            {
                if (item.CardID == data)
                {
                    clsEmployeeTimeKeeping TimeKeeping = new clsEmployeeTimeKeeping();
                    TimeKeeping.FingerID = item.FingerID;
                    TimeKeeping.CardID = item.CardID;
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

                    string cmd = "if" + DateTime.Now.ToString("HH:mm:ss") + TimeKeeping.EmployeeName;
                    STM_Input.Write(cmd);

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
        /// Thực hiện các bước thêm vân tay nhân viên mới
        /// </summary>
        /// <param name="data"></param>
        private void AddNewEmployee(string data)
        {
            //if (data.Contains("A1"))
            //{
            //    // Hoàn thành quét vân tay lần 1
            //    MessageBox.Show("Vui lòng xác thực lại vân tay", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            //}

            if (data.Contains("A3"))
            {

            }
        }

        /// <summary>
        /// Xử lý khi có người chấm công bằng vân tay
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
                    TimeKeeping.CardID = item.CardID;
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

                    string cmd = "if" + DateTime.Now.ToString("HH:mm:ss") + TimeKeeping.EmployeeName;
                    STM_Input.Write(cmd);

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
            GetallEmployee();
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
                MessageBox.Show("Vui lòng quẹt thẻ nhân viên của cán bộ quản lý nhân sự", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                mAddEmployee = true;

            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.ToString());
            }

        }
    }
}

using TimeKeepingSystem.Common;
using TimeKeepingSystem.Database;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for wdAddEmployee.xaml
    /// </summary>
    public partial class wdAddEmployee : Window
    {
        BLDatabase oBL = new BLDatabase();
        private string mFingerID;
        private string mCardID;

        public string FingerID { get => mFingerID; set => mFingerID = value; }
        public string CardID { get => mCardID; set => mCardID = value; }

        public wdAddEmployee()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            txtCardID.Text = mCardID;
            txtFingerID.Text = mFingerID;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (ValidateData())
                {
                    clsEmployee employee = new clsEmployee();
                    employee.FingerID = txtFingerID.Text;
                    employee.CardID = mCardID;
                    employee.EmployeeName = txtEmployeeName.Text;
                    employee.EmployeeCode = txtEmployeeCode.Text;
                    employee.Department = txtDepartMent.Text;
                    employee.EmployeeJob = txtJob.Text;
                    employee.ImagePath = txtPicturePath.Text;
                    employee.Type = "Normal";

                    oBL.SaveEmployee(employee);
                    MessageBox.Show("Thêm mới người dùng hoàn tất.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
            });
        }

        private bool ValidateData()
        {
            string strMess = "Thông tin <<{0}>> không được để trống. Vui lòng kiểm tra lại.";
            bool Result = true;
            if (txtFingerID.Text == string.Empty || txtFingerID.Text == "")
            {
                MessageBox.Show(string.Format(strMess, "Mã thẻ từ"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtEmployeeName.Text == string.Empty || txtEmployeeName.Text == "Tên người dùng")
            {
                MessageBox.Show(string.Format(strMess, "Tên người dùng"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtEmployeeCode.Text == string.Empty || txtEmployeeCode.Text == "Mã người dùng")
            {
                MessageBox.Show(string.Format(strMess, "Mã người dùng"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtDepartMent.Text == string.Empty || txtDepartMent.Text == "Số phòng")
            {
                MessageBox.Show(string.Format(strMess, "Số phòng"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtJob.Text == string.Empty || txtJob.Text == "Quan hệ với chủ nhà")
            {
                MessageBox.Show(string.Format(strMess, "Bộ phận"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtPicturePath.Text == string.Empty || txtPicturePath.Text == "Hình ảnh người dùng")
            {
                MessageBox.Show(string.Format(strMess, "Hình ảnh người dùng"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return Result;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }


        private void btnOpenFile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            OpenFileDialog dialog = new OpenFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName.Replace('\\', ',');
            }
            int x = filePath.Split(',').Length;
            string path = "./" + filePath.Split(',')[x - 2] + "/" + filePath.Split(',')[x - 1];
            txtPicturePath.Text = path;
        }

    }
}

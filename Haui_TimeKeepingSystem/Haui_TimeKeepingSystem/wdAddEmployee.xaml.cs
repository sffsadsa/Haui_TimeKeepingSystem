using Haui_TimeKeepingSystem.Common;
using Haui_TimeKeepingSystem.Database;
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

namespace Haui_TimeKeepingSystem
{
    /// <summary>
    /// Interaction logic for wdAddEmployee.xaml
    /// </summary>
    public partial class wdAddEmployee : Window
    {
        BLDatabase oBL = new BLDatabase();
        private string mFingerID;

        public string FingerID { get => mFingerID; set => mFingerID = value; }

        public wdAddEmployee()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            txtFingerID.Text = mFingerID;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData())
            {
                clsEmployee employee = new clsEmployee();
                employee.FingerID = txtFingerID.Text;
                employee.EmployeeName = txtEmployeeName.Text;
                employee.EmployeeCode = txtEmployeeCode.Text;
                employee.Department = txtDepartMent.Text;
                employee.EmployeeJob = txtJob.Text;
                employee.ImagePath = txtPicturePath.Text;

                oBL.SaveEmployee(employee);
                MessageBox.Show("Thêm mới nhân viên hoàn tất.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

        }

        private bool ValidateData()
        {
            string strMess = "Thông tin <<{0}>> không được để trống. Vui lòng kiểm tra lại.";
            bool Result = true;
            if (txtFingerID.Text == string.Empty || txtFingerID.Text == "")
            {
                MessageBox.Show(string.Format(strMess, "Mã vân tay"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtEmployeeName.Text == string.Empty || txtEmployeeName.Text == "")
            {
                MessageBox.Show(string.Format(strMess, "Tên nhân viên"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtEmployeeCode.Text == string.Empty || txtEmployeeCode.Text == "")
            {
                MessageBox.Show(string.Format(strMess, "Mã nhân viên"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtDepartMent.Text == string.Empty || txtDepartMent.Text == "")
            {
                MessageBox.Show(string.Format(strMess, "Bộ phận"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtJob.Text == string.Empty || txtJob.Text == "Vị trí công việc")
            {
                MessageBox.Show(string.Format(strMess, "Bộ phận"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtPicturePath.Text == string.Empty || txtPicturePath.Text == "Vị trí công việc")
            {
                MessageBox.Show(string.Format(strMess, "Hình ảnh nhân viên"), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return Result;
        }
    }
}

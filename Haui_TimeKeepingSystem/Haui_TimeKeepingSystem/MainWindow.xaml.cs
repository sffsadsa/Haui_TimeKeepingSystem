using Haui_TimeKeepingSystem.Common;
using System;
using System.Collections.Generic;
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
        private string strConnectFail = "Không thể kết nối tới máy chấm công của bạn. Vui lòng kiểm tra lại!";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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

        private void STM_Input_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            wdHistory frm = new wdHistory();
            frm.ShowDialog();
        }
    }
}

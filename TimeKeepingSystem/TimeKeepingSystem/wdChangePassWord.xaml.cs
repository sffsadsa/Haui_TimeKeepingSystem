using TimeKeepingSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TimeKeepingSystem
{
    /// <summary>
    /// Interaction logic for wdChangePassWord.xaml
    /// </summary>
    public partial class wdChangePassWord : Window
    {
        public wdChangePassWord()
        {
            InitializeComponent();
        }
        BLDatabase oBL = new BLDatabase();
        string strPassWord;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            strPassWord = oBL.GetCurrentPassWord();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    oBL.UpdatePassWord(txtNewPassWord.Password);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }           
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool ValidateData()
        {
            if (txtNewPassWord.Password != txtCheckNewPassWord.Password)
            {
                MessageBox.Show("Kiểm tra mật khẩu không đúng. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (txtPassWord.Password != strPassWord)
            {
                MessageBox.Show("Mất khẩu không đúng. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }    
                return true;
        }
    }
}

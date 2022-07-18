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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using PasswordManager;

namespace LoginForm00
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterUser MyRegisterUser = new RegisterUser(); //
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void txtBox_Username_MouseLeave(object sender, MouseEventArgs e)
        {
            txtBox_Username.SetCurrentValue(BackgroundProperty, Brushes.Transparent);
            icon_Account.SetCurrentValue(BackgroundProperty, Brushes.Transparent);
        }

        private void txtBox_Username_MouseEnter(object sender, MouseEventArgs e)
        {
            txtBox_Username.SetCurrentValue(BackgroundProperty, Brushes.DeepSkyBlue);
            icon_Account.SetCurrentValue(BackgroundProperty, Brushes.DeepSkyBlue);
        }


        private void PswBox_MouseLeave(object sender, MouseEventArgs e)
        {
            PswBox.SetCurrentValue(BackgroundProperty, Brushes.Transparent);
            icon_Key.SetCurrentValue(BackgroundProperty, Brushes.Transparent);
        }

        private void PswBox_MouseEnter(object sender, MouseEventArgs e)
        {
            PswBox.SetCurrentValue(BackgroundProperty, Brushes.DeepSkyBlue);
            icon_Key.SetCurrentValue(BackgroundProperty, Brushes.DeepSkyBlue);
        }
    }
}

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

namespace PasswordManager
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

        private void Window_Loaded(object sender, RoutedEventArgs e) //EVENT when program start
        { 
            MessageBox.Show("Indtast dit brugernavn og kode for at logge på", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) //EVENT when Checkbox is checked
        {
            lb_TipsForKode.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) //EVENT when Checkbox is unchecked
        {
            lb_TipsForKode.Visibility = Visibility.Hidden;
        }
    }
}

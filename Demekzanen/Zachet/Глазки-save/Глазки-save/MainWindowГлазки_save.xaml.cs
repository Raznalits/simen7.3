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

namespace Глазки_save
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowГлазки_save : Window
    {
        public MainWindowГлазки_save()
        {
            InitializeComponent();
            Main.Navigate(new Sun());

        }

        private void Admin(object sender, RoutedEventArgs e)
        {
           Main.Navigate(new Admin());
        }

        private void User(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new Users());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Main.GoBack();
        }
        private void Buck(object sender, EventArgs e)
        {
            if (Main.CanGoBack) Bucs.Visibility = Visibility.Visible;
            else Bucs.Visibility = Visibility.Hidden;
        }
    }
}

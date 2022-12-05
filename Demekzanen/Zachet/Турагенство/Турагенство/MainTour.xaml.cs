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

namespace Турагенство
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainTour : Window
    {
        public MainTour()
        {
            InitializeComponent();
            Mainy.Navigate(new Main());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Mainy.GoBack();
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            Mainy.Navigate(new Admin());
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            Mainy.Navigate(new User());
        }

        private void Buck(object sender, EventArgs e)
        {
            if (Mainy.CanGoBack) Bucs.Visibility = Visibility.Visible;
            else Bucs.Visibility = Visibility.Hidden;
        }
    }
}

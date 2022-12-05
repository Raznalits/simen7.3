using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Благодать
{
    /// <summary>
    /// Логика взаимодействия для StarSmena.xaml
    /// </summary>
    public partial class StarSmena : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        DateTime date = new DateTime(0, 0);
        public StarSmena()
        {




            InitializeComponent();
            Classes.Connect.modeldb = new model.DA_BlagodatEntities1();

            UserTB.Text = model.DA_BlagodatEntities1.currentuser.Email;
            RoleTB.Text = "(" + model.DA_BlagodatEntities1.currentuser.Post + ")";

            var fullFilePath = model.DA_BlagodatEntities1.currentuser.photo;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Relative);
            bitmap.EndInit();

            UserPhoto.Source = bitmap;

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            date = date.AddSeconds(1);
            TimeTB.Text = date.ToString("HH:mm:ss");

            if (TimeTB.Text == "00:05:00")
            {
                MessageBox.Show("Время сеанса подходит к концу!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TimeTB.Text == "00:10:00")
            {
                timer.Stop();
                App.IsGone = true;
                //Administrator.Sun.Navigate(new Admin());
                NavigationService.Navigate(new Sun());
            }
        }
    }
}

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Глазки_save
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>

    public partial class Admin : Page
    {
        Random _random = new Random();
        public Admin()
        {
            InitializeComponent();
            UpdateCaptcha();
            Classes.Connect.modeldb = new Model.testscriptDAEntities();
        }

        string symbol = "";
        int att = 0;

        private void UpdateCaptcha()
        {
            SPanelSymbols.Children.Clear();
            CanvasNoise.Children.Clear();


            symbol = "";
            GenerateSymbols(5);
            GenerateNoise(2);
        }

        public string Symbols;

        private void GenerateSymbols(int count)
        {
            string alphabet = "WERPASFHKXVBM234578";
            for (int i = 0; i < count; i++)
            {
                string symbols = alphabet.ElementAt(_random.Next(0, alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();

                lbl.Text = symbols;
                lbl.FontSize = _random.Next(15, 30);
                lbl.RenderTransform = new RotateTransform(_random.Next(-45, 45));
                lbl.Margin = new Thickness(5, 0, 5, 0);

                symbol = symbol + symbols;

                //lbl.Foreground = ra



                SPanelSymbols.Children.Add(lbl);
                Symbols = Symbols + symbol;
            }
        }



        private void GenerateNoise(int volumeNoise)
        {
            for (int i = 0; i < volumeNoise; i++)
            {
                Border border = new Border();
                border.Background = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256)));
                border.Height = _random.Next(2, 10);
                border.Width = _random.Next(10, 40);



                border.RenderTransform = new RotateTransform(_random.Next(-20, 20));

                CanvasNoise.Children.Add(border);
                Canvas.SetLeft(border, _random.Next(20, 100));
                Canvas.SetTop(border, _random.Next(20, 40));

                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256)));
                ellipse.Height = ellipse.Width = _random.Next(15, 30);



                CanvasNoise.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, _random.Next(10, 100));
                Canvas.SetTop(ellipse, _random.Next(10, 26));
            }
        }
        private void BtnUpdateCaptcha_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }

        private void login(object sender, RoutedEventArgs e)

        {
            LogIn();
        }

        private void LogIn()
        {
            try
            {
                //table user чтоб извлечь login and passworld 
                var userObj = Classes.Connect.modeldb.user.FirstOrDefault(x =>
               x.Name == log.Text && x.Passworld == pass.Password);
                Console.WriteLine(log.Text);
                if (userObj != null)
                {
                    Model.testscriptDAEntities.currentuser = userObj;
                    {
                        switch (userObj.ID)
                        {
                            case 1:
                                NavigationService.Navigate(new Administrator());
                                break;

                            case 2:
                                NavigationService.Navigate(new StarSmena());
                                break;

                            case 3:
                                NavigationService.Navigate(new Maneger());
                                break;
                                //public static user currentuser;

                        }
                    }

                }
                else
                {
                    att++;
                    CheckAttemps();
                    UpdateCaptcha();
                    MessageBox.Show("Не удается войти!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void CheckAttemps()
        {
            if (att == 2)
            {
                Console.WriteLine(TBCaptcha.Text);
                Capcha.Visibility = Visibility.Visible;
                CapchaBox.Visibility = Visibility.Visible;
                loginBT.Visibility = Visibility.Hidden;
                

                if (TBCaptcha.Text == symbol)
                {
                    loginBT.Visibility = Visibility.Visible;
                }
                else
                {
                    CapchaLogin.Visibility = Visibility.Visible;
                }
            }
            if(att == 3)
            {
                NavigationService.Navigate(new Sun());
            }

        }



        private void TbxShowPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Width = pass.Width;
            TxbPassword.Visibility = Visibility.Visible;
            pass.Visibility = Visibility.Collapsed;
            TxbPassword.Text = pass.Password;
        }

        private void TbxShowPass_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Collapsed;
            pass.Visibility = Visibility.Visible;
        }

        private void Check_Capcha(object sender, RoutedEventArgs e)
        {
            CheckAttemps();
        }
    }
}

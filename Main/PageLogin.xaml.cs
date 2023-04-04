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
using ESUN.AppData;

namespace ESUN.Main
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        ESUNEntities2 Entities = new ESUNEntities2();
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txbLogin.Text.Length == 0)
            {
                MessageBox.Show("Логин пуст");
                return;
            }
            if (psbPassword.Password.Length == 0)
            {
                MessageBox.Show("Пароль пуст");
                return;
            }
            if (Entities.User.Where(x => x.Login == txbLogin.Text).ToList().Count == 0)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
            if (Entities.User.Where(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password).ToList().Count > 0)
            {
                switch (Entities.User.Where(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password).ToList()[0].IdRole)
                {
                    case 1:
                        MessageBox.Show("Добро пожаловать, Учитель");
                        AppFrame.frameMain.Navigate(new PageMain());
                        break;
                    case 2:
                        MessageBox.Show("Добро пожаловать, ученик");
                        AppFrame.frameMain.Navigate(new PageMain());
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }

        private void IconPasswordN1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IconPasswordN1.Visibility = Visibility.Hidden;
            IconPasswordN2.Visibility = Visibility.Visible;
            PasswordTextBox.Text = psbPassword.Password;
            psbPassword.Visibility = Visibility.Hidden;
            PasswordTextBox.Visibility = Visibility.Visible;
        }

        private void IconPasswordN2_MouseLeave(object sender, MouseEventArgs e)
        {
            IconPasswordN2.Visibility = Visibility.Hidden;
            IconPasswordN1.Visibility = Visibility.Visible;
            psbPassword.Visibility = Visibility.Visible;
            PasswordTextBox.Visibility = Visibility.Hidden;
        }

        private void IconPasswordN2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IconPasswordN2.Visibility = Visibility.Hidden;
            IconPasswordN1.Visibility = Visibility.Visible;
            psbPassword.Visibility = Visibility.Visible;
            PasswordTextBox.Visibility = Visibility.Hidden;
        }
    }
}

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
using ESUN.Main;

namespace ESUN.Main
{
    /// <summary>
    /// Логика взаимодействия для PageT1.xaml
    /// </summary>
    public partial class PageT1 : Page
    {
        public PageT1()
        {
            InitializeComponent();
            cmb.SelectedValuePath = "Id";
            cmb.DisplayMemberPath = "Surname";
            cmb.ItemsSource = AppConnect.model0db.Student.ToList();
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;
            if (One.IsChecked == true)
            {
                points++;
            }
            if (Two.IsChecked == true)
            {
                points++;
            }
            if (Three.IsChecked == true)
            {
                points++;
            }
            if (Four.IsChecked == true)
            {
                points++;
            }
            if (Five.IsChecked == true)
            {
                points++;
            }
            cmb.Visibility = Visibility.Hidden;
            End.Visibility = Visibility.Hidden;
            Answer.Visibility = Visibility.Visible;
            Evaluation.Visibility = Visibility.Visible;
            Res.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
            Answer.Content = "Количество верных ответов: " + Convert.ToString(points);
            int louse = 5;
            if (5 > points && points > 3)
            {
                louse = louse - 1;
            }
            if (4 > points && points > 2)
            {
                louse = louse - 2;
            }
            if (3 > points)
            {
                louse = louse - 3;
            }
            Res.Text = (louse).ToString();
            int test1 = Convert.ToInt32(Res.Text);
            int t = 1;
            try
            {
                Journal obj = new Journal()
                {
                    Student = cmb.SelectedItem as Student,
                    IdTopic = t,
                    Evaluation = test1
                };
                AppConnect.model0db.Journal.Add(obj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена:",
                    ")", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка:" + ex.Message.ToString(),
                    "Критическая ошибка!", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageTestMenu());
        }
    }
}

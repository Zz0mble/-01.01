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
using ESUN.Tool;

namespace ESUN.Main
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
            dataGrid.ItemsSource = AppConnect.model0db.Journal.ToList();
            CmbGroup.SelectedValuePath = "Class.Name";
            CmbGroup.DisplayMemberPath = "Class.Name";
            CmbGroup.ItemsSource = AppConnect.model0db.Student.ToList();
        }
        private void Filtr()
        {
            var SerachList = AppConnect.model0db.Journal.ToList();
            string group = Convert.ToString(CmbGroup.SelectedValue);
            if (CmbGroup.SelectedIndex >= 0)
            {
                SerachList = SerachList.Where(x => x.Student.Classs == group).ToList();
            }
            if (txtB.Text != "")
            {
                SerachList = SerachList.Where(x => x.Student.FIO.ToLower().Contains(txtB.Text.ToLower())).ToList();
            }
            dataGrid.ItemsSource = SerachList.ToList();

        }

        private void txtB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtr();
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string group = Convert.ToString(CmbGroup.SelectedValue);
            Filtr();
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageStudent());
        }

        private void Theory_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageTheory());
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageTestMenu());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageLogin());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEditStudent Data = new AddEditStudent(null);
            Data.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            updateProduct();
        }
        private void updateProduct()
        {
            if (dataGrid.SelectedItem as Student == null)
            {
                var result = MessageBox.Show("Выберете ученика", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    return;
                }
            }
            AddEditStudent edit = new AddEditStudent(dataGrid.SelectedItem as Student);
            edit.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данные", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var removeProduct = dataGrid.SelectedItem as Journal;
                AppConnect.model0db.Journal.Remove(removeProduct);
                AppConnect.model0db.SaveChanges();
                dataGrid.ItemsSource = AppConnect.model0db.Journal.ToList();
                MessageBox.Show("Данные удалены");
            }

            else
            {
                MessageBox.Show("В таблице нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

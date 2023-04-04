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
using ESUN.TestTest;

namespace ESUN.Main
{
    /// <summary>
    /// Логика взаимодействия для PageTestMenu.xaml
    /// </summary>
    public partial class PageTestMenu : Page
    {
        public PageTestMenu()
        {
            InitializeComponent();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageT1());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageMain());
        }

        private void Test1_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageT2());
        }
    }
}

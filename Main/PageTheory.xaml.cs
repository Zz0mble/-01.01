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
using Word = Microsoft.Office.Interop.Word;
using ESUN.AppData;

namespace ESUN.Main
{
    /// <summary>
    /// Логика взаимодействия для PageTheory.xaml
    /// </summary>
    public partial class PageTheory : Page
    {
        public PageTheory()
        {
            InitializeComponent();
        }

        private void Firs_Click(object sender, RoutedEventArgs e)
        {
            var wordApp = new Word.Application();
            Word.Document document = wordApp.Documents.Open(@"C:/Users/user/Desktop/Дипломмммм/Главный/ЭСУНпФд7К/ЭСУНпФд7К/Word/Введение.docx");
            wordApp.Visible = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageMain());
        }
    }
}

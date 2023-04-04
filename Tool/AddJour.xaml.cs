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
using System.Windows.Shapes;
using ESUN.AppData;
using ESUN.Main;

namespace ESUN.Tool
{
    /// <summary>
    /// Логика взаимодействия для AddJour.xaml
    /// </summary>
    public partial class AddJour : Window
    {
        private Journal _Jour = new Journal();
        public AddJour(Journal SelectedJour)
        {
            InitializeComponent();
            if (SelectedJour != null)
                _Jour = SelectedJour;
            Idd.ItemsSource = ESUNEntities2.GetContext().Student.ToList();
            DataContext = _Jour;
        }

        private void Idd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_Jour.Id == 0)
                ESUNEntities2.GetContext().Journal.Add(_Jour);
            try
            {
                /*Journal studObj = new Journal()
                {
                    IdStudent = AccountHelpClass.id,
                };*/
                ESUNEntities2.GetContext().SaveChanges();

                MessageBox.Show("Данные сохранены");
                AppFrame.frameMain.Navigate(new PageMain());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
        }
    }
}

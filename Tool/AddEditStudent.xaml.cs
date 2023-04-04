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
    /// Логика взаимодействия для AddEditStudent.xaml
    /// </summary>
    public partial class AddEditStudent : Window
    {
        private Student _currentStud = new Student();
        //private Journal _Jour = new Journal();
        public AddEditStudent(Student SelectedStud)
        {
            InitializeComponent();
            if (SelectedStud != null)
                _currentStud = SelectedStud;

            //_Jour.IdStudent = AccountHelpClass.id;

            cmbt1.ItemsSource = ESUNEntities2.GetContext().Class.ToList();
            DataContext = _currentStud;
            //Idd.ItemsSource = ESUNEntities1.GetContext().Student.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (_currentStud.Id == 0)
                ESUNEntities2.GetContext().Student.Add(_currentStud);
            try
            {
                /*Journal studObj = new Journal()
                {
                    IdStudent = AccountHelpClass.id,
                };*/
                ESUNEntities2.GetContext().SaveChanges();

                MessageBox.Show("Данные сохранены");
                AppFrame.frameMain.Navigate(new PageStudent());
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }

        }
    }
}

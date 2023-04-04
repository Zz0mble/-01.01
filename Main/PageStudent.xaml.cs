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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System.IO;
using System.Data;
using ExcelDataReader;

namespace ESUN.Main
{
    /// <summary>
    /// Логика взаимодействия для PageStudent.xaml
    /// </summary>
    public partial class PageStudent : Page
    {
        IExcelDataReader edr;
        public PageStudent()
        {
            InitializeComponent();
            dataGrid.ItemsSource = AppConnect.model0db.Student.ToList();
            CmbGroup.SelectedValuePath = "Class.Name";
            CmbGroup.DisplayMemberPath = "Class.Name";
            CmbGroup.ItemsSource = AppConnect.model0db.Student.ToList();
        }
        private void Filtr()
        {
            var SerachList = AppConnect.model0db.Student.ToList();
            string group = Convert.ToString(CmbGroup.SelectedValue);
            if (CmbGroup.SelectedIndex >= 0)
            {
                SerachList = SerachList.Where(x => x.Class.Name == group).ToList();
            }
            if (txtB.Text != "")
            {
                SerachList = SerachList.Where(x => x.FIO.ToLower().Contains(txtB.Text.ToLower())).ToList();
            }
            dataGrid.ItemsSource = SerachList.ToList();

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
                var removeProduct = dataGrid.SelectedItem as Student;
                AppConnect.model0db.Student.Remove(removeProduct);
                AppConnect.model0db.SaveChanges();
                dataGrid.ItemsSource = AppConnect.model0db.Student.ToList();
                MessageBox.Show("Данные удалены");
            }

            else
            {
                MessageBox.Show("В таблице нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void Journal_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageMain());
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

        private void Ex_Click(object sender, RoutedEventArgs e)
        {
            var spisok = AppConnect.model0db.Student.ToList();
            var aplication = new Excel.Application();
            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = aplication.Worksheets.Item[1];

            int RowIndex = 2;
            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]];
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            header.Font.Bold = true;
            worksheet.Cells[1][1] = "Id";
            worksheet.Cells[2][1] = "ФИО";
            worksheet.Cells[3][1] = "Класс";

            for (int i = 0; i < spisok.Count; i++)
            {
                worksheet.Cells[1][RowIndex] = spisok[i].Id;
                int g = spisok[i].Id;
                Student form0bj = AppConnect.model0db.Student.FirstOrDefault(x => x.Id == g);
                if (form0bj != null)
                {
                    worksheet.Cells[2][RowIndex] = form0bj.FIO;
                    worksheet.Cells[3][RowIndex] = form0bj.Class.Name;
                }
                RowIndex++;
            }
            aplication.Visible = true;
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EXCEL Files (*.xlsx)|*.xlsx|EXCEL Files 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != true)
                return;

            dataGrid.ItemsSource = readFile(openFileDialog.FileName);

        }
        private DataView readFile(string fileNames)
        {

            var extension = fileNames.Substring(fileNames.LastIndexOf('.'));
            // Создаем поток для чтения.
            FileStream stream = File.Open(fileNames, FileMode.Open, FileAccess.Read);
            // В зависимости от расширения файла Excel, создаем тот или иной читатель.
            // Читатель для файлов с расширением *.xlsx.
            if (extension == ".xlsx")
                edr = ExcelReaderFactory.CreateOpenXmlReader(stream);
            // Читатель для файлов с расширением *.xls.
            else if (extension == ".xls")
                edr = ExcelReaderFactory.CreateBinaryReader(stream);

            //// reader.IsFirstRowAsColumnNames
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };
            // Читаем, получаем DataView и работаем с ним как обычно.
            DataSet dataSet = edr.AsDataSet(conf);
            DataView dtView = dataSet.Tables[0].AsDataView();

            // После завершения чтения освобождаем ресурсы.
            edr.Close();
            return dtView;
        }
    }
}

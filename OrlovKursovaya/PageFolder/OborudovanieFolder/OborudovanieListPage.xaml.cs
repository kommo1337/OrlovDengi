using OrlovKursovaya.ClassFolder;
using OrlovKursovaya.DataFolder;
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

namespace OrlovKursovaya.PageFolder.OborudovanieFolder
{
    /// <summary>
    /// Логика взаимодействия для OborudovanieListPage.xaml
    /// </summary>
    public partial class OborudovanieListPage : Page
    {
        public OborudovanieListPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = DBEntities.GetContext().Oborudovanie
                .ToList().OrderBy(u => u.OborudovanieName);
        }

        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportClass.ToExcelFile(DgUser, "Экспорт оборудования");
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Oborudovanie oborudovanie = DgUser.SelectedItem as Oborudovanie;

            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите оборудование" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"оборудование с именем " +
                    $"{oborudovanie.OborudovanieName}?"))
                {
                    DBEntities.GetContext().Oborudovanie
                        .Remove(DgUser.SelectedItem as Oborudovanie);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Оборудование удалено");
                    DgUser.ItemsSource = DBEntities.GetContext()
                        .Oborudovanie.ToList().OrderBy(u => u.OborudovanieName);
                }

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "Оборудование для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new OborudovanieEditPage(DgUser.SelectedItem as Oborudovanie));
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext()
                .Oborudovanie.Where(u => u.OborudovanieName
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.OborudovanieName);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }
    }
}

using OrlovKursovaya.ClassFolder;
using OrlovKursovaya.DataFolder;
using OrlovKursovaya.PageFolder.EmployeeFolder;
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

namespace OrlovKursovaya.ClientFolder
{
    /// <summary>
    /// Логика взаимодействия для ClientListPage.xaml
    /// </summary>
    public partial class ClientListPage : Page
    {
        public ClientListPage()
        {
            InitializeComponent();
        }
        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportClass.ToExcelFile(DgUser, "Экспорт клиентов");
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Client client = DgUser.SelectedItem as Client;

            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите клиента" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"клиента с именем " +
                    $"{client.FIO}?"))
                {
                    DBEntities.GetContext().Client
                        .Remove(DgUser.SelectedItem as Client);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Клиент удален");
                    DgUser.ItemsSource = DBEntities.GetContext()
                        .Client.ToList().OrderBy(u => u.FIO);
                }

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "клиента для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new ClientEditPage(DgUser.SelectedItem as Client));
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext()
                .Client.Where(u => u.FIO
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.FIO);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }
    }
}

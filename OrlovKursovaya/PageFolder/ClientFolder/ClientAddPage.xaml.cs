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

namespace OrlovKursovaya.ClientFolder
{
    /// <summary>
    /// Логика взаимодействия для ClientAddPage.xaml
    /// </summary>
    public partial class ClientAddPage : Page
    {
        public ClientAddPage()
        {
            InitializeComponent();
            RemontCb.ItemsSource = DBEntities.GetContext()
               .Remont.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().Client.Add(new Client()
                {
                    FIO = FIOTb.Text,
                    ClientPassport = int.Parse(PassportCb.Text),
                    ClientAdress = AdressCb.Text,
                    ClientDateOfBirth = DateTime.Parse(DateOfBirthCb.Text),
                    PhoneNumber = PhoneNumberTb.Text,
                    Email = EmailCb.Text,
                    RemontId = int.Parse(RemontCb.SelectedValue.ToString())

                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Клиент успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

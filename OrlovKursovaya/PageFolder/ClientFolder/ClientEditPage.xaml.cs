using OrlovKursovaya.ClassFolder;
using OrlovKursovaya.DataFolder;
using OrlovKursovaya.PageFolder.AdminFolder;
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
    /// Логика взаимодействия для ClientEditPage.xaml
    /// </summary>
    public partial class ClientEditPage : Page
    {
        Client client = new Client();
        public ClientEditPage(Client client)
        {
            InitializeComponent();
            DataContext = client;

            this.client.ClientId = client.ClientId;            
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client = DBEntities.GetContext().Client
                    .FirstOrDefault(u => u.ClientId == client.ClientId);
                client.FIO = FIOTb.Text;
                client.ClientPassport = int.Parse(PassportCb.Text);
                client.ClientAdress = AdressCb.Text;
                client.ClientDateOfBirth = DateTime.Parse(DateOfBirthCb.Text);
                client.PhoneNumber = PhoneNumberTb.Text;
                client.Email = EmailCb.Text;
                client.RemontId = int.Parse(RemontCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ClientListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

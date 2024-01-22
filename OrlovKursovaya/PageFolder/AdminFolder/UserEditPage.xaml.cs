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

namespace OrlovKursovaya.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        User user = new User();
        public UserEditPage(User user)
        {
            InitializeComponent();
            DataContext = user;

            this.user.UserId = user.UserId;

            RoleCb.ItemsSource = DBEntities.GetContext()
                .Role.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = RoleCb.SelectedIndex + 1;
                user = DBEntities.GetContext().User
                    .FirstOrDefault(u => u.UserId == user.UserId);
                user.UserName = LoginTb.Text;
                user.UserPassword = PasswordCb.Text;
                user.RoleId = index;
                user.FIO = FIOTb.Text;
                user.PhoneNumber = PhoneNumberTb.Text;
                user.Email = EmailTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new UserListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}

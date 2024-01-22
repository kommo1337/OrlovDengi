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
    /// Логика взаимодействия для UserAddPage.xaml
    /// </summary>
    public partial class UserAddPage : Page
    {
        public UserAddPage()
        {
            InitializeComponent();
            RoleCb.ItemsSource = DBEntities.GetContext()
               .Role.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordCb.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordCb.Focus();
            }
            else if (RoleCb.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите роль для пользователя");
                RoleCb.Focus();
            }
            else
            {
                try
                {
                    int index = RoleCb.SelectedIndex + 1;
                    DBEntities.GetContext().User.Add(new User()
                    {
                        UserName = LoginTb.Text,
                        UserPassword = PasswordCb.Text,
                        RoleId = index,
                        FIO = FIOTb.Text,
                        PhoneNumber = PhoneNumberTb.Text,
                        Email= EmailTb.Text
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Пользователь успешно добавлен");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                    throw;
                }
            }
        }
    }
}

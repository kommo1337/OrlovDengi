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

namespace OrlovKursovaya.PageFolder.EmployeeFolder
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddPage.xaml
    /// </summary>
    public partial class EmployeeAddPage : Page
    {
        public EmployeeAddPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().Employee.Add(new Employee()
                {
                    FIO = FIOTb.Text,
                    PhoneNumber = PhoneNumberCb.Text,
                    DateOfBirth = DateTime.Parse(DateOfBirthCb.Text.ToString()),
                    Email = EmailTb.Text,
                    Passport = int.Parse(PassportTb.Text.ToString()),
                    Adress = AdressTb.Text

                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Работник успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }
    }
}

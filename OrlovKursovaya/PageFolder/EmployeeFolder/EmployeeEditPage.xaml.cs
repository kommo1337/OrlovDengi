using Microsoft.Office.Interop.Excel;
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
    /// Логика взаимодействия для EmployeeEditPage.xaml
    /// </summary>
    public partial class EmployeeEditPage
    {
        Employee employee = new Employee();
        public EmployeeEditPage(Employee employee)
        {
            InitializeComponent();
            DataContext = employee;

            this.employee.EmployeeId = employee.EmployeeId;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                employee = DBEntities.GetContext().Employee
                    .FirstOrDefault(u => u.EmployeeId == employee.EmployeeId);
                employee.FIO = FIOTb.Text;
                employee.PhoneNumber = PhoneNumberCb.Text;
                employee.DateOfBirth = DateTime.Parse(DateOfBirthCb.Text.ToString());
                employee.Email = EmailTb.Text;
                employee.Passport = int.Parse(PassportTb.Text.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new EmployeeListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}

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
    /// Логика взаимодействия для OborudovanieAddPage.xaml
    /// </summary>
    public partial class OborudovanieAddPage : Page
    {
        public OborudovanieAddPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().Oborudovanie.Add(new Oborudovanie()
                {
                    OborudovanieName = NameTb.Text,
                    OborudovanieCount = CountTb.Text,
                    OborudovanieDescription = DescpirtionTb.Text,
                    TypeId = int.Parse(TypeCb.SelectedValue.ToString()),
                    Price= PriceTb.Text
                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Оборудование успешно добавлено");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }
    }
}

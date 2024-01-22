using OrlovKursovaya.ClassFolder;
using OrlovKursovaya.DataFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для OborudovanieEditPage.xaml
    /// </summary>
    public partial class OborudovanieEditPage : Page
    {
        Oborudovanie oborudovanie = new Oborudovanie();
        public OborudovanieEditPage(Oborudovanie oborudovanie)
        {
            InitializeComponent();
            DataContext = oborudovanie;

            this.oborudovanie.OborudovanieId = oborudovanie.OborudovanieId;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                oborudovanie = DBEntities.GetContext().Oborudovanie
                    .FirstOrDefault(u => u.OborudovanieId == oborudovanie.OborudovanieId);
                oborudovanie.OborudovanieName = NameTb.Text;
                oborudovanie.OborudovanieCount = CountTb.Text;
                oborudovanie.OborudovanieDescription = DescpirtionTb.Text;
                oborudovanie.TypeId = int.Parse(TypeCb.SelectedValue.ToString());
                oborudovanie.Price = PriceTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new OborudovanieListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}

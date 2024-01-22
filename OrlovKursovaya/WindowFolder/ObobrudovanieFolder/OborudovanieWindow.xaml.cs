using OrlovKursovaya.ClassFolder;
using OrlovKursovaya.PageFolder.OborudovanieFolder;
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
using System.Windows.Shapes;

namespace OrlovKursovaya.WindowFolder.ObobrudovanieFolder
{
    /// <summary>
    /// Логика взаимодействия для OborudovanieWindow.xaml
    /// </summary>
    public partial class OborudovanieWindow : Window
    {
        public OborudovanieWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new OborudovanieListPage());
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

        private void ListBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OborudovanieListPage());
        }

        private void AddBookBtn_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OborudovanieAddPage());
        }
    }
}

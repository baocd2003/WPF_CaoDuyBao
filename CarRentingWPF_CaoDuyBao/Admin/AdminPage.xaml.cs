using Service;
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

namespace CarRentingWPF_CaoDuyBao.Admin
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public ICustomerManagmentService _cusService;
        public AdminPage()
        {
            InitializeComponent();
            AdminFrame.Content = new CusManagement();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new CusManagement();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new CarManagement();
        }

        private void rentingBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new RentingManagement();
        }

        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Report();
        }
    }
}

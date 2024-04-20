using BusinessObject.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRentingWPF_CaoDuyBao.Admin
{
    /// <summary>
    /// Interaction logic for RentingManagement.xaml
    /// </summary>
    public partial class RentingManagement : Page
    {
        private ICustomerManagmentService _cusService;
        public RentingManagement()
        {
            InitializeComponent();
            _cusService = new CustomerManagementService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CusDgv.SelectedItem != null)
            {
                Customer selectedCus = (Customer) CusDgv.SelectedItem;
                var addRentPage = new AddRenting(selectedCus, null);
                addRentPage.Show();
            }
            else
            {
                MessageBox.Show("Please chooose your customer");
            }
        }

        private void ViewHis_Click(object sender, RoutedEventArgs e)
        {
            if (CusDgv.SelectedItem != null)
            {
                Customer cus = (Customer) CusDgv.SelectedItem;
                var historyPage = new ViewHistory(cus);
                historyPage.Show();
            }        
        }

        private void CusDgv_Loaded(object sender, RoutedEventArgs e)
        {
            CusDgv.ItemsSource = _cusService.GetAllCustomers().Where(c => c.CustomerStatus == 1).ToList();
        }

        private void CusDgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

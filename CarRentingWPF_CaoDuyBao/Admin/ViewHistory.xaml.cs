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
using System.Windows.Shapes;

namespace CarRentingWPF_CaoDuyBao.Admin
{
    /// <summary>
    /// Interaction logic for ViewHistory.xaml
    /// </summary>
    public partial class ViewHistory : Window
    {
        private IRentingManagementService _rentSevice;
        private Customer _cus;
        public ViewHistory(Customer cus)
        {
            InitializeComponent();
            _rentSevice = new RentingManagementService();
           _cus = cus;
        }

        private void HistoryDgv_Loaded(object sender, RoutedEventArgs e)
        {
            HistoryDgv.ItemsSource = _rentSevice.ViewHistory(_cus.CustomerId);
        }

        private void DetailsDgv_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void HistoryDgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HistoryDgv.SelectedItem != null)
            {
                RentingTransaction trans = (RentingTransaction)HistoryDgv.SelectedItem;
                DetailsDgv.ItemsSource = _rentSevice.ViewHistoryDetails(trans.RentingTransationId);
            }
            else
            {

            }
        }
    }
}

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
    /// Interaction logic for CheckoutRenting.xaml
    /// </summary>
    public partial class CheckoutRenting : Window
    {
        private List<RentingDetail> list;

        private Customer selectedCus { get; set; }
        private ICarManagementService _carService;
        private IRentingManagementService _rentService;
        public CheckoutRenting(Customer customer, List<RentingDetail> detailList)
        {
            InitializeComponent();
            if (detailList == null)
            {
                list = new List<RentingDetail>();
            }
            list = detailList;
            selectedCus = customer;
            _carService = new CarManagementService();
            _rentService = new RentingManagementService();
        }

        private void addMoreBtn_Click(object sender, RoutedEventArgs e)
        {
            var addMore = new AddRenting(selectedCus, list);
            this.Hide();
            addMore.Show();
        }

        private void completeBtn_Click(object sender, RoutedEventArgs e)
        {
            decimal? totalPrice = 0;
            foreach (RentingDetail r in list)
            {
                totalPrice += r.Price;
            }
            RentingTransaction rentTrans = new RentingTransaction
            {
                RentingTransationId = _rentService.GetTransactions().Count + 1,
                CustomerId = selectedCus.CustomerId,
                RentingDate = DateTime.Now,
                RentingStatus = 1,
                TotalPrice = totalPrice
            };
            rentTrans.RentingDetails = list;
            _rentService.AddRenting(rentTrans);
            MessageBox.Show("Add sucessfully");
            var historyPage = new ViewHistory(selectedCus);
            this.Hide();
            historyPage.Show();
        }

        private void DetailDgv_Loaded(object sender, RoutedEventArgs e)
        {
            //List<RentingDetail> cloneList = list;
          
            DetailDgv.ItemsSource =list;
        }
    }
}

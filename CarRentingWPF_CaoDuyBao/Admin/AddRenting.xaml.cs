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
    /// Interaction logic for AddRenting.xaml
    /// </summary>
    public partial class AddRenting : Window
    {
        private List<RentingDetail> list { get; set; }
        private Customer selectedCus {  get; set; }
        private ICarManagementService _carService;
        private IRentingManagementService _rentService;
        public AddRenting(Customer customer, List<RentingDetail> list)
        {
            InitializeComponent();
           
            _carService = new CarManagementService();
            _rentService = new RentingManagementService();
            if (list == null)
            {
                list = new List<RentingDetail>();
            }
            this.list = list;
            this.selectedCus = customer;
        }

        private void CarDgv_Loaded(object sender, RoutedEventArgs e)
        {
            CarDgv.ItemsSource = _carService.GetAllCar();
        }

        private void addRent_Click(object sender, RoutedEventArgs e)
        {
            if (CarDgv.SelectedItem != null)
            {
                int carNum = 0;
                CarInformation selectedCar = (CarInformation)CarDgv.SelectedItem;   
                if (sDatePick.Text == "" || eDatePick.Text == "")
                {
                    MessageBox.Show("Please select Date");
                    return;
                }
                if ((sDatePick.SelectedDate < DateTime.Now || eDatePick.SelectedDate < DateTime.Now))
                {
                    MessageBox.Show("Please select date after now");
                    return;
                }

                if (sDatePick.SelectedDate > eDatePick.SelectedDate)
                {
                    MessageBox.Show("End Date must > Start Date");
                    return;
                }

                if (int.TryParse(carNumTxt.Text, out int num))
                {
                    carNum = num;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number");
                    return;
                }
                if (_rentService.CheckOverLap((DateTime)sDatePick.SelectedDate, (DateTime)eDatePick.SelectedDate, selectedCar.CarId))
                {
                    MessageBox.Show("Selected Dates for this car has been rented. Please pick dates again");
                    return;
                }
                RentingDetail rentDetail = new RentingDetail
                {
                    StartDate = Convert.ToDateTime(sDatePick.SelectedDate),
                    EndDate = Convert.ToDateTime(eDatePick.SelectedDate),
                    NumberOfCars = carNum,
                    CarId = selectedCar.CarId,
                    Price = selectedCar.CarRentingPricePerDay * carNum
                };

                if (list.Count > 0)
                {
                    foreach (RentingDetail item in list)
                    {
                        if (item.CarId == rentDetail.CarId)
                        {
                            MessageBox.Show("This car has alread been added. If you want, please hire this car in other transaction");
                            return;
                        }
                    }
                }
                list.Add(rentDetail);
                var checkout = new CheckoutRenting(selectedCus,list);
                this.Hide();
                checkout.Show();
            }
            else
            {
                MessageBox.Show("Please Select a car");
            }
            
           
        }
    }
}

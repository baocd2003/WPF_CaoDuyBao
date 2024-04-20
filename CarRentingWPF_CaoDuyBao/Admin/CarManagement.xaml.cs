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
    /// Interaction logic for CarManagement.xaml
    /// </summary>
    public partial class CarManagement : Page
    {
        private ICarManagementService _carService = new CarManagementService();
        public CarManagement()
        {
            InitializeComponent();
            
            _carService = new CarManagementService();
        }

        private void CarDgv_Loaded(object sender, RoutedEventArgs e)
        {
            CarDgv.ItemsSource = _carService.GetAllCar();
        }

        private void CarDgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarDgv.SelectedItem != null) {
                CarInformation sCar = (CarInformation)CarDgv.SelectedItem;
                carNameTxt.Text = sCar.CarName;
                carDesTxt.Text = sCar.CarDescription;
                carPriceTxt.Text = sCar.CarRentingPricePerDay.ToString();
                carDoorsTxt.Text = sCar.NumberOfDoors.ToString();
                carCapaTxr.Text = sCar.SeatingCapacity.ToString();
                carFuelTxt.Text = sCar.FuelType.ToString();
                carYearTxt.Text = sCar.Year.ToString();
                supplierCb.SelectedItem = sCar.Supplier.SupplierName;
                manuCb.SelectedItem = sCar.Manufacturer.ManufacturerName;
            }
            else
            {
                carNameTxt.Text = "";
                carDesTxt.Text = "";
                carPriceTxt.Text = "";
                carDoorsTxt.Text = "";
                carCapaTxr.Text = "";
                carFuelTxt.Text = "";
            }
        }

        private void supplierCb_Loaded(object sender, RoutedEventArgs e)
        {
            supplierCb.ItemsSource = _carService.GetSuppliers().Select(s => s.SupplierName);
            supplierCb.SelectedIndex = 0;
        }

        private void manuCb_Loaded(object sender, RoutedEventArgs e)
        {
            manuCb.ItemsSource = _carService.GetManufacturers().Select(s => s.ManufacturerName);
            manuCb.SelectedIndex = 0;
        }

        private void add_Btn_Click(object sender, RoutedEventArgs e)
        {
            int check = 0;
            string name = "";
            string des = "";
            decimal price = 0;
            int numDoors = 0;
            int capa = 0;
            string fuel = "";
            int year = 0;
            if (carNameTxt.Text == "" || carNameTxt.Text == null)
            {
                MessageBox.Show("Please add name");
            }
            else
            {
                name = carNameTxt.Text;
                check++;
            }
            if (carDesTxt.Text == "" || carDesTxt.Text == null)
            {
                MessageBox.Show("Please add des");
            }
            else
            {
                des = carDesTxt.Text;
                check++;
            }
            if (carFuelTxt.Text == "" || carFuelTxt.Text == null)
            {
                MessageBox.Show("Please add fuel type");
            }
            else
            {
                fuel = carFuelTxt.Text;
                check++;
            }
            if (decimal.TryParse(carPriceTxt.Text, out decimal cprice))
            {
                price = cprice;
                check++;
            }
            else{
                MessageBox.Show("Price must be a numer");
            }

            if (int.TryParse(carDoorsTxt.Text, out int cdoors))
            {
                numDoors = cdoors;
                check++;
            }
            else
            {
                MessageBox.Show("Doors quantity must be a numer");
            }
            if (int.TryParse(carCapaTxr.Text, out int ccapa))
            {
                capa = ccapa;
                check++;
            }
            else
            {
                MessageBox.Show("Capacity quantity must be a numer");
            }

            if (int.TryParse(carYearTxt.Text, out int cyear))
            {
                year = cyear;
                check++;
            }
            else
            {
                MessageBox.Show("Year must be a numer");
            }

            if (check == 7)
            {
                CarInformation car = new CarInformation
                {
                    CarName = name,
                    CarDescription = des,
                    CarRentingPricePerDay = price,
                    SeatingCapacity = capa,
                    Year = year,
                    NumberOfDoors = numDoors,
                    FuelType = fuel,
                    CarStatus = 1,
                    SupplierId = _carService.GetSpByName((string)supplierCb.SelectedItem).SupplierId,
                    ManufacturerId = _carService.GetManuByName((string)manuCb.SelectedItem).ManufacturerId
                };
                _carService.AddCar(car);
                MessageBox.Show("Add car sucessfully");
                CarDgv.ItemsSource = _carService.GetAllCar();
            }


        }

        private void update_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(CarDgv.SelectedItem != null)
            {
                CarInformation sCar = (CarInformation)CarDgv.SelectedItem;
                int check = 0;
                string name = sCar.CarName;
                string des = sCar.CarDescription;
                decimal price = (decimal)sCar.CarRentingPricePerDay;
                int numDoors = (int)sCar.NumberOfDoors;
                int capa = (int)sCar.SeatingCapacity;
                string fuel = sCar.FuelType;
                supplierCb.SelectedItem = _carService.GetSupById(sCar.SupplierId).SupplierName;
                manuCb.SelectedItem = _carService.GetManufacturerById(sCar.ManufacturerId).ManufacturerName;
                int year = 0;
                if (carNameTxt.Text == "" || carNameTxt.Text == null)
                {
                    MessageBox.Show("Please add name");
                }
                else
                {
                    name = carNameTxt.Text;
                    check++;
                }
                if (carDesTxt.Text == "" || carDesTxt.Text == null)
                {
                    MessageBox.Show("Please add des");
                }
                else
                {
                    des = carDesTxt.Text;
                    check++;
                }
                if (carFuelTxt.Text == "" || carFuelTxt.Text == null)
                {
                    MessageBox.Show("Please add fuel type");
                }
                else
                {
                    fuel = carFuelTxt.Text;
                    check++;
                }
                if (decimal.TryParse(carPriceTxt.Text, out decimal cprice))
                {
                    price = cprice;
                    check++;
                }
                else
                {
                    MessageBox.Show("Price must be a numer");
                }

                if (int.TryParse(carDoorsTxt.Text, out int cdoors))
                {
                    numDoors = cdoors;
                    check++;
                }
                else
                {
                    MessageBox.Show("Doors quantity must be a numer");
                }
                if (int.TryParse(carDoorsTxt.Text, out int ccapa))
                {
                    capa = ccapa;
                    check++;
                }
                else
                {
                    MessageBox.Show("Capacity quantity must be a numer");
                }

                if (int.TryParse(carYearTxt.Text, out int cyear))
                {
                    year = cyear;
                    check++;
                }
                else
                {
                    MessageBox.Show("Year must be a numer");
                }

                if (check == 7)
                {
                    CarInformation car = new CarInformation
                    {
                        CarId = sCar.CarId,
                        CarName = name,
                        CarDescription = des,
                        CarRentingPricePerDay = price,
                        SeatingCapacity = capa,
                        Year = year,
                        NumberOfDoors = numDoors,
                        FuelType = fuel,
                        CarStatus = 1,
                        SupplierId = _carService.GetSpByName((string)supplierCb.SelectedItem).SupplierId,
                        ManufacturerId = _carService.GetManuByName((string)manuCb.SelectedItem).ManufacturerId
                    };
                    _carService.UpdateCar(car);
                    MessageBox.Show("Update car sucessfully");

                    CarDgv.ItemsSource = _carService.GetAllCar();
                }
            }
            else
            {
                MessageBox.Show("Please select a car");
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (query != null || query.Text != "")
            {
                CarDgv.ItemsSource = _carService.SearchByCarName(query.Text);
            }
            else
            {
                CarDgv.ItemsSource = _carService.GetAllCar();
            }
        }

        private void del_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (CarDgv.SelectedItem != null)
            {
                _carService.RemoveCar((CarInformation) CarDgv.SelectedItem);
                CarDgv.ItemsSource = _carService.GetAllCar();
                MessageBox.Show("Delete sucessfully");
            }
        }
    }
}

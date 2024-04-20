using BusinessObject.Models;
using CarRentingWPF_CaoDuyBao.Admin;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarRentingWPF_CaoDuyBao.CustomerPage
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        Customer selectedCus;
        private ICustomerManagmentService _cusService;
        public UserProfile(Customer cus)
        {
            InitializeComponent();
            selectedCus = cus;
            _cusService = new CustomerManagementService();
        }

        private void history_btn_Click(object sender, RoutedEventArgs e)
        {
            var viewHis = new ViewHistory(selectedCus);
            viewHis.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cNameTxt.Text = selectedCus.CustomerName;
            cPhoneTxt.Text = selectedCus.Telephone;
            birthDp.Text = selectedCus.CustomerBirthday.ToString();
            nameLb.Content = selectedCus.CustomerName;
        }

        private void rentBtn_Click(object sender, RoutedEventArgs e)
        {
            var addRenting = new AddRenting(selectedCus, null);
            addRenting.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String cusName = "";
            String cusPhone = "";
            String cusMail = "";
            DateTime cusBirth = DateTime.Parse("1/1/2000");
            int check = 0;
            if (cNameTxt.Text == "" || cNameTxt.Text == null)
            {
                MessageBox.Show("Please add name");
            }
            else
            {
                cusName = cNameTxt.Text;
                check++;
            }
            if (int.TryParse(cPhoneTxt.Text, out int num))
            {
                if (cPhoneTxt.Text.Length == 10)
                {
                    cusPhone = cPhoneTxt.Text;
                    check++;
                }
                else
                {
                    MessageBox.Show("Not enough 10 digits");
                }
            }
            else
            {
                MessageBox.Show("Not a number");
            };

            DateTime currentDate = DateTime.Now;
            if (birthDp.SelectedDate != null)
            {
                if (birthDp.SelectedDate < currentDate)
                {
                    cusBirth = (DateTime)birthDp.SelectedDate;
                    check++;
                }
                else
                {
                    MessageBox.Show("Please select date before now!!");
                }

            }
            else
            {
                MessageBox.Show("Not a date");
            }
            if (check == 3)
            {
                Customer cus = new Customer
                {
                    CustomerId = selectedCus.CustomerId,
                    CustomerName = cusName,
                    Telephone = cusPhone,
                    Email = selectedCus.Email,
                    CustomerBirthday = cusBirth,
                    Password = selectedCus.Password,
                    CustomerStatus = selectedCus.CustomerStatus
                };
                _cusService.UpdateCus(cus);
                MessageBox.Show("Update sucessfully");
            }
        }
    }
}

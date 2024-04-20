using BusinessObject.Models;
using Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRentingWPF_CaoDuyBao.Admin
{
    /// <summary>
    /// Interaction logic for CusManagement.xaml
    /// </summary>
    public partial class CusManagement : Page
    {
        //private ICustomerManagementRepo _cusRepo;
        private ICustomerManagmentService _cusService;
        public List<String> statusList = new List<String>() { 
            "Active","InActive"
        };

        public CusManagement()
        {
            InitializeComponent();
            //_cusRepo = new CustomerManagementRepo();
            _cusService = new CustomerManagementService();
        }

        private void CusDgv_Loaded(object sender, RoutedEventArgs e)
        {
            CusDgv.ItemsSource = _cusService.GetAllCustomers();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CusDgv.SelectedItem != null)
            {
                Customer selectedCus = CusDgv.SelectedItem as Customer;
                if (selectedCus != null)
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
                    string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                    Regex regex = new Regex(pattern);
                    if (regex.IsMatch(cMailTxt.Text))
                    {
                        cusMail = cMailTxt.Text;
                        check++;
                    }
                    else
                    {
                        MessageBox.Show("Email must have @");
                    }

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
                    if (check == 4)
                    {
                        Customer cus = new Customer
                        {
                            CustomerId = selectedCus.CustomerId,
                            CustomerName = cusName,
                            Email = cusMail,
                            Telephone = cusPhone,
                            Password = cPassTxt.Text,
                            CustomerBirthday = cusBirth,
                            CustomerStatus = cStatusCb.SelectedItem.ToString() == "Active" ? (byte?)1 : (byte?)0
                        };
                        _cusService.UpdateCus(cus);
                        CusDgv.ItemsSource = _cusService.GetAllCustomers();
                        MessageBox.Show("Update sucessfully");

                    }


                }
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
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
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(cMailTxt.Text))
            {
                if (!_cusService.IsCusExisted(cMailTxt.Text))
                {
                    cusMail = cMailTxt.Text;
                    check++;
                }
                else
                {
                    MessageBox.Show("Account has already existed");
                }

            }
            else
            {
                MessageBox.Show("Email must have @");
            }

            String cusPass = cPassTxt.Text;
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

            if (check == 4)
            {
                Customer cus = new Customer
                {
                    CustomerName = cusName,
                    Email = cusMail,
                    Telephone = cusPhone,
                    Password = cusPass,
                    CustomerBirthday = cusBirth,
                    CustomerStatus = cStatusCb.SelectedItem.ToString() == "Active" ? (byte?)1 : (byte?)0
                };
                _cusService.AddCus(cus);
                CusDgv.ItemsSource = _cusService.GetAllCustomers();
                MessageBox.Show("Add sucessfully");


            }
        }

        private void CusDgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CusDgv.SelectedItem != null)
            {
                Customer selectedCus = CusDgv.SelectedItem as Customer;
                if (selectedCus != null)
                {
                    cNameTxt.Text = selectedCus.CustomerName;
                    cPhoneTxt.Text = selectedCus.Telephone;
                    cMailTxt.Text = selectedCus.Email;
                    birthDp.Text = selectedCus.CustomerBirthday.ToString();
                    cStatusCb.SelectedItem = selectedCus.CustomerStatus == 1 ? "Active" : "InActive";
                }
                else
                {
                    cNameTxt.Text = "";
                    cPhoneTxt.Text = "";
                    cMailTxt.Text = "";
                    birthDp.Text = "";
                }
            }
        }

        private void cStatusCb_Loaded(object sender, RoutedEventArgs e)
        {
         
            cStatusCb.ItemsSource = statusList;
            cStatusCb.SelectedIndex = 0;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CusDgv.SelectedItem != null)
            {
                _cusService.DeleteCus((Customer) CusDgv.SelectedItem);
                MessageBox.Show("Delete Sucessfully");
                CusDgv.ItemsSource = _cusService.GetAllCustomers();
            }
            else
            {
                MessageBox.Show("Please select customer");
            }
        }
    }
}

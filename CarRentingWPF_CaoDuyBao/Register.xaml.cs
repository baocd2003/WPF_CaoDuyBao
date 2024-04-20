using BusinessObject.Models;
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

namespace CarRentingWPF_CaoDuyBao
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private ICustomerManagmentService _cusService;
        public Register()
        {
            InitializeComponent();
            _cusService = new CustomerManagementService();
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
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
                    CustomerStatus = 1
                };
                _cusService.AddCus(cus);
                MessageBox.Show("Register Sucessfully");
                var loginPage = new Login();
                this.Hide();
                loginPage.Show();
            }
        }
    }
}

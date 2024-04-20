using BusinessObject.Models;
using CarRentingWPF_CaoDuyBao.Admin;
using CarRentingWPF_CaoDuyBao.CustomerPage;
using Repository;
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

namespace CarRentingWPF_CaoDuyBao
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private ICustomerManagementRepo _cusRepo;
        private ICustomerManagmentService _cusManagmentService;
        public Login()
        {
            InitializeComponent();
            _cusManagmentService = new CustomerManagementService();
            _cusRepo = new CustomerManagementRepo();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTxt.Text;
            string password = PassTxt.Text;
            Customer cus = _cusManagmentService.LoginAsCustomer(email, password);
            int check = _cusManagmentService.LoginAsAdmin(email, password);
            if (check == 1)
            {
                MessageBox.Show("Login As Admin");
                var adminPage = new AdminPage();
                adminPage.Show();
                this.Hide();
            }
            else
            {
                if (cus != null) {
                    if (cus.CustomerStatus == 1)
                    {
                        MessageBox.Show("Login as Customer");
                        var userPro = new UserProfile(cus);
                        userPro.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Your account has been blocked");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Wrong email or password");
                }
            }
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var registerPage = new Register();
            this.Hide();
            registerPage.Show();
        }
    }
}

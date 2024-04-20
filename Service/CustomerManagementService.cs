using BusinessObject.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerManagementService : ICustomerManagmentService
    {
        private ICustomerManagementRepo _customerManagementRepo;
        public CustomerManagementService() { 
            _customerManagementRepo = new CustomerManagementRepo();
        }
        public void AddCus(Customer cus)
        => _customerManagementRepo.AddCus(cus);

        public void DeleteCus(Customer cus)
        => _customerManagementRepo.DeleteCus(cus);

        public List<Customer> GetAllCustomers()
        => _customerManagementRepo.GetAllCustomers();

        public bool IsCusExisted(string mail)
       => _customerManagementRepo.IsCusExisted(mail);

        public int LoginAsAdmin(string email, string password)
        => _customerManagementRepo.LoginAsAdmin(email, password);

        public Customer LoginAsCustomer(string email, string password)
        => _customerManagementRepo.LoginAsCustomer(email, password);

        public void Register(string email, string password)
        => _customerManagementRepo.Register(email, password);

        public void UpdateCus(Customer cus)
        => _customerManagementRepo.UpdateCus(cus);
    }
}

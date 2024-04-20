using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICustomerManagmentService
    {
        public Customer LoginAsCustomer(string email, string password);
        public List<Customer> GetAllCustomers();
        public void Register(string email, string password);
        public int LoginAsAdmin(string email, string password);
        public bool IsCusExisted(string mail);
        public void AddCus(Customer cus);
        public void UpdateCus(Customer cus);
        public void DeleteCus(Customer cus);
    }
}

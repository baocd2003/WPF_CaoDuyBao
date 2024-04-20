using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerManagementRepo : ICustomerManagementRepo
    {
        public void AddCus(Customer cus)
       => CustomerManagementDAO.Instance.AddCus(cus);

        public void DeleteCus(Customer cus)
        => CustomerManagementDAO.Instance.DeleteCus(cus);

        public List<Customer> GetAllCustomers()
        => CustomerManagementDAO.Instance.GetAllCustomers();

        public bool IsCusExisted(string mail)
        => CustomerManagementDAO.Instance.IsCusExisted(mail);

        public int LoginAsAdmin(string email, string password)
        {
            int check = 0;
            try
            {
                String filePath = "appsettings.json";

                if (File.Exists(filePath))
                {

                    String jsonContent = File.ReadAllText(filePath);

                    var jsonData = JsonSerializer.Deserialize<Customer>(jsonContent);

                    if (jsonData != null)
                    {
                        if (email == jsonData.Email && password == jsonData.Password)
                        {
                            check = 1;
                        }
                        else
                        {
                            check = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return check;
        }

        public Customer LoginAsCustomer(string email, string password)
        => CustomerManagementDAO.Instance.LoginAsCustomer(email, password);

        public void Register(string email, string password)
        => CustomerManagementDAO.Instance.Register(email, password);

        public void UpdateCus(Customer cus)
        => CustomerManagementDAO.Instance.UpdateCus(cus);
    }
}

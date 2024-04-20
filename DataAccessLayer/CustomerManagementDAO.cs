using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public  class CustomerManagementDAO
    {
        private static CustomerManagementDAO instance = null;
        private FUCarRentingManagementContext _db = null;

        public CustomerManagementDAO()
        {
            _db = new FUCarRentingManagementContext();
        }
        public static CustomerManagementDAO Instance { get
            { 
                if(instance == null)
                {
                    instance = new CustomerManagementDAO();
                }
                return instance; 
            } 
        }

        public Customer LoginAsCustomer(string email, string password)
        {
            var _dbContext = new FUCarRentingManagementContext();
            return _db.Customers.FirstOrDefault(c => c.Email == email && c.Password == password);
        }

        public List<Customer> GetAllCustomers()
        {
            var _dbContext = new FUCarRentingManagementContext();
            return _dbContext.Customers.ToList();

        }

        public void Register(string email, string password)
        {
            try
            {
                Customer cus = new Customer
                {
                    Email = email,
                    Password = password
                };
                _db.Customers.Add(cus);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool IsCusExisted(string mail)
        {
            return _db.Customers.FirstOrDefault(c => c.Email == mail) != null ? true : false;
        }


        public void AddCus(Customer cus)
        {
            try
            {
                _db.Customers.Add(cus);
                _db.SaveChanges();
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateCus(Customer cus)
        {
            try
            {
                Customer checkCus = _db.Customers.FirstOrDefault(c => c.CustomerId == cus.CustomerId);
                if (checkCus != null)
                {
                    var _dbContext = new FUCarRentingManagementContext();
                    _dbContext.Customers.Update(cus);
                    _dbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public void DeleteCus(Customer cus)
        {
            try
            {
                var _dbContext = new FUCarRentingManagementContext();
                Customer _cus = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == cus.CustomerId);
                List<RentingTransaction> historyList = _dbContext.RentingTransactions.Where(rt => rt.CustomerId == cus.CustomerId).ToList();
                if (!historyList.Any())
                {
                    _dbContext.Customers.Remove(_cus);
                    _dbContext.SaveChanges();
                }
                else
                {
                    _cus.CustomerStatus = 0;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }
}

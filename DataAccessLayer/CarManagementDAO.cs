using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CarManagementDAO
    {
        private static CarManagementDAO instance = null;
        private FUCarRentingManagementContext _dbContext = null;

        public CarManagementDAO()
        {
            _dbContext = new FUCarRentingManagementContext();
        }
        public static CarManagementDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CarManagementDAO();
                }
                return instance;
            }
        }

        public List<CarInformation> GetAllCar()
        {
            try
            {
                var _db = new FUCarRentingManagementContext();
                return _db.CarInformations.Include(c => c.Supplier).Include(c => c.Manufacturer).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           

        }

        public CarInformation GetCar(int id) {
            try
            {
                var _db = new FUCarRentingManagementContext();
                return _db.CarInformations.FirstOrDefault(c => c.CarId == id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void AddCar(CarInformation car)
        {
            try
            {
                _dbContext.CarInformations.Add(car);
                _dbContext.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            
        }

        public void RemoveCar(CarInformation car)
        {
            try
            {
                var _db = new FUCarRentingManagementContext();

                List<RentingDetail> rentList = _db.RentingDetails.Where(rt => rt.CarId == car.CarId).ToList();
                CarInformation _car = _db.CarInformations.FirstOrDefault(c => c.CarId == car.CarId);
                if (rentList.Any())
                {
                    _car.CarStatus = 0;
                    _db.SaveChanges();
                }
                else
                {
                    _db.CarInformations.Remove(_car);
                    _db.SaveChanges();
                }
            }catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCar(CarInformation car)
        {
            try
            {
                CarInformation c = GetCar(car.CarId);
                if (c != null)
                {
                    var _db = new FUCarRentingManagementContext();
                    _db.CarInformations.Update(car);
                    _db.SaveChanges();
                }
            }
            catch(Exception e) {
                throw new Exception(e.Message);
            }
        }

        public bool IsCarExisted(CarInformation car)
        {
            try
            {
                var _db = new FUCarRentingManagementContext();
                CarInformation carE = _db.CarInformations.FirstOrDefault(c => c.CarId == car.CarId);
                return car != null ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Supplier> GetSuppliers()
        {
            try
            {
                var _db = new FUCarRentingManagementContext();
                return _db.Suppliers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Manufacturer> GetManufacturers()
        {
            try
            {
                var _db = new FUCarRentingManagementContext();
                return _db.Manufacturers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public Supplier GetSpByName(string name)
        {
            var _db = new FUCarRentingManagementContext();
            return _db.Suppliers.FirstOrDefault(s => s.SupplierName == name);
        }

        public Manufacturer GetManuByName(string name)
        {
            var _db = new FUCarRentingManagementContext();
            return _db.Manufacturers.FirstOrDefault(m => m.ManufacturerName == name);
        }

        public Supplier GetSupById(int id)
            => _dbContext.Suppliers.FirstOrDefault(s => s.SupplierId == id);

        public Manufacturer GetManufacturerById(int id)
            => _dbContext.Manufacturers.FirstOrDefault(m => m.ManufacturerId == id);

        public List<CarInformation> SearchByCarName(string name)
        => _dbContext.CarInformations.Where(c => c.CarName.Contains(name)).ToList();
    }
}

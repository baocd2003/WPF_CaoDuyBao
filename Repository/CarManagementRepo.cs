using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CarManagementRepo : ICarManagementRepo
    {
        public void AddCar(CarInformation car)
       => CarManagementDAO.Instance.AddCar(car);

        public List<CarInformation> GetAllCar()
        => CarManagementDAO.Instance.GetAllCar();

        public CarInformation GetCar(int id)
        => CarManagementDAO.Instance.GetCar(id);

        public Manufacturer GetManuByName(string name)
       =>CarManagementDAO.Instance.GetManuByName(name);

        public Manufacturer GetManufacturerById(int id)
        =>CarManagementDAO.Instance.GetManufacturerById(id);

        public List<Manufacturer> GetManufacturers()
       => CarManagementDAO.Instance.GetManufacturers();

        public Supplier GetSpByName(string name)
       =>CarManagementDAO.Instance.GetSpByName(name);

        public Supplier GetSupById(int id)
        =>CarManagementDAO.Instance.GetSupById(id);

        public List<Supplier> GetSuppliers()
        =>CarManagementDAO.Instance.GetSuppliers();

        public bool IsCarExisted(CarInformation car)
        => CarManagementDAO.Instance.IsCarExisted(car);

        public void RemoveCar(CarInformation car)
        => CarManagementDAO.Instance.RemoveCar(car);

        public List<CarInformation> SearchByCarName(string name)
        => CarManagementDAO.Instance.SearchByCarName(name);

        public void UpdateCar(CarInformation car)
       => CarManagementDAO.Instance.UpdateCar(car);
    }
}

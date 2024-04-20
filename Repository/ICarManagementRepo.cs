using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICarManagementRepo
    {
        public List<CarInformation> GetAllCar();
        public CarInformation GetCar(int id);
        public void AddCar(CarInformation car);
        public void RemoveCar(CarInformation car);
        public void UpdateCar(CarInformation car);
        public bool IsCarExisted(CarInformation car);
        public List<Supplier> GetSuppliers();
        public List<Manufacturer> GetManufacturers();
        public Supplier GetSpByName(string name);
        public Manufacturer GetManuByName(string name);
        public List<CarInformation> SearchByCarName(string name);
        public Supplier GetSupById(int id);
        public Manufacturer GetManufacturerById(int id);


    }
}

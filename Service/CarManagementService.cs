using BusinessObject.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CarManagementService : ICarManagementService
    {
        private ICarManagementRepo _carRepo;

        public CarManagementService()
        {
            _carRepo = new CarManagementRepo();
        }

        public void AddCar(CarInformation car)
       => _carRepo.AddCar(car);

        public List<CarInformation> GetAllCar()
       => _carRepo.GetAllCar();

        public CarInformation GetCar(int id)
       => _carRepo.GetCar(id);

        public Manufacturer GetManuByName(string name)
        =>_carRepo.GetManuByName(name);

        public Manufacturer GetManufacturerById(int id)
       => _carRepo.GetManufacturerById(id);

        public List<Manufacturer> GetManufacturers()
        => _carRepo.GetManufacturers();

        public Supplier GetSpByName(string name)
        =>_carRepo.GetSpByName(name);

        public Supplier GetSupById(int id)
        => _carRepo.GetSupById(id);

        public List<Supplier> GetSuppliers()
        => _carRepo.GetSuppliers();

        public bool IsCarExisted(CarInformation car)
       => _carRepo.IsCarExisted(car);

        public void RemoveCar(CarInformation car)
        => _carRepo.RemoveCar(car);

        public List<CarInformation> SearchByCarName(string name)
       => _carRepo.SearchByCarName(name);

        public void UpdateCar(CarInformation car)
       => _carRepo.UpdateCar(car);
    }
}

using BusinessObject.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RentingManagementService : IRentingManagementService
    {
        private IRentingManagementRepo _rentingRepo;

        public RentingManagementService()
        {
            _rentingRepo = new RentingManagementRepo();
        }
        public void AddRenting(RentingTransaction trans)
       => _rentingRepo.AddRenting(trans);

        public void AddRentngDetails(List<RentingDetail> list)
        => _rentingRepo.AddRentngDetails(list);

        public bool CheckOverLap(DateTime sDate, DateTime eDate, int carId)
        => _rentingRepo.CheckOverLap(sDate, eDate, carId);

        public List<RentingTransaction> GetTransactions()
        => _rentingRepo.GetTransactions();

        public List<RentingDetail> ReportDetails(DateTime sDate, DateTime eDate)
        =>   _rentingRepo.ReportDetails(sDate, eDate);  

        public List<RentingTransaction> ViewHistory(int customerId)
        => _rentingRepo.ViewHistory(customerId);

        public List<RentingDetail> ViewHistoryDetails(int transId)
        => _rentingRepo.ViewHistoryDetails(transId);
    }
}

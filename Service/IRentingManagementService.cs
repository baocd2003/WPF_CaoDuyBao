using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IRentingManagementService
    {
        public void AddRenting(RentingTransaction trans);
        public void AddRentngDetails(List<RentingDetail> list);
        public List<RentingTransaction> GetTransactions();
        public List<RentingTransaction> ViewHistory(int customerId);
        public List<RentingDetail> ViewHistoryDetails(int transId);
        public bool CheckOverLap(DateTime sDate, DateTime eDate, int carId);
        public List<RentingDetail> ReportDetails(DateTime sDate, DateTime eDate);
        

    }
}

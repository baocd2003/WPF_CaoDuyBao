using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RentingManagementRepo : IRentingManagementRepo
    {
        public void AddRenting(RentingTransaction trans)
        => RentingManagementDAO.Instance.AddRenting(trans);

        public void AddRentngDetails(List<RentingDetail> list)
       => RentingManagementDAO.Instance.AddRentngDetails(list);

        public bool CheckOverLap(DateTime sDate, DateTime eDate, int carId)
        => RentingManagementDAO.Instance.CheckOverLap(sDate, eDate, carId);

        public List<RentingTransaction> GetTransactions()
        => RentingManagementDAO.Instance.GetTransactions();

        public List<RentingDetail> ReportDetails(DateTime sDate, DateTime eDate)
        => RentingManagementDAO.Instance.ReportDetails(sDate, eDate);   

        public List<RentingTransaction> ViewHistory(int customerId)
        => RentingManagementDAO.Instance.ViewHistory(customerId);

        public List<RentingDetail> ViewHistoryDetails(int transId)
        => RentingManagementDAO.Instance.ViewHistoryDetails(transId);
    }
}

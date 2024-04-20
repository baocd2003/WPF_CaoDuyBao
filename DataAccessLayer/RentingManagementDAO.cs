using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RentingManagementDAO
    {
        private static RentingManagementDAO instance = null;
        private FUCarRentingManagementContext _db = null;

        public RentingManagementDAO()
        {
            _db = new FUCarRentingManagementContext();
        }
        public static RentingManagementDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RentingManagementDAO();
                }
                return instance;
            }
        }

        public void AddRenting(RentingTransaction trans)
        {
            try
            {
                _db.RentingTransactions.Add(trans);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void AddRentngDetails(List<RentingDetail> list)
        {
            try
            {
                foreach(RentingDetail rt in list)
                {
                    _db.RentingDetails.Add(rt);
                    _db.SaveChanges();
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<RentingTransaction> GetTransactions()
        {
            try
            {
                return _db.RentingTransactions.ToList();
            }catch(Exception e )
            {
                throw new Exception(e.Message);
            }
        }

        public List<RentingTransaction> ViewHistory(int customerId)
        {
            try {
                return _db.RentingTransactions.Where(rt => rt.CustomerId == customerId).ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<RentingDetail> ViewHistoryDetails(int transId)
        {
            try
            {
                var _dbContext = new FUCarRentingManagementContext();
                return _dbContext.RentingDetails.Include(rt => rt.Car).ThenInclude(c => c.Manufacturer).Include(rt => rt.Car)
                    .ThenInclude(c => c.Supplier).Where(rd => rd.RentingTransactionId == transId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool CheckOverLap(DateTime sDate, DateTime eDate, int carId)
        {
            try
            {
                List<RentingDetail> carRented = _db.RentingDetails.Where(rt => rt.CarId == carId).ToList();
                foreach (RentingDetail rt in carRented)
                {
                    if (eDate.Date <= rt.StartDate.Date || sDate.Date >= rt.EndDate.Date)
                    {
                        continue;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return false;

        }

        public List<RentingDetail> ReportDetails(DateTime sDate, DateTime eDate)
        {
            try {
                var _dbContext = new FUCarRentingManagementContext();
                return _dbContext.RentingDetails.Include(rd => rd.Car).ThenInclude(c => c.Supplier).
                    Include(rd => rd.Car).ThenInclude(c => c.Manufacturer)
                    .Where(rd => rd.StartDate >= sDate && rd.EndDate <= eDate).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }




    }
}

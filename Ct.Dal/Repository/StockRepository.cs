using Ct.common.Entities;
using Ct.Common.Models;
using Ct.Dal.Data;
using Ct.Dal.InterfacesDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.ClassDal
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StockRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Stock> GetAllStock()
        {
            return _dbContext.StockTable.ToList();
        }

        public void DeleteStock(int id)
        {
            var stocks = _dbContext.StockTable.Find(id);
            _dbContext.StockTable.Remove(stocks);
            _dbContext.SaveChanges();
        }

        public void AddStock(Stock stock)
        {
            _dbContext.StockTable.Add(stock);
            _dbContext.SaveChanges();
        }

        public void UpdateStock(Stock stock)
        {
           // var existingStock = _dbContext.StockTable.Find(stock.Stock_id);
            _dbContext.StockTable.Update(stock);
            _dbContext.SaveChanges();
        }


        public Stock GetStockById(int id)
        {
            var stock = _dbContext.StockTable.FirstOrDefault(s => s.Stock_id == id);
            return stock;
        }

        public bool IsStockExist(int stockid)
        {
            return _dbContext.StockTable.Any(s => s.Stock_id == stockid);
        }

        public Stock GetStockByIdfromCloth(int id)
        {
            var stock = _dbContext.StockTable.FirstOrDefault(s => s.Cloth_id == id);
            return stock;
        }
        public List<Stock> GetByDate(DateTime datetime)
        {
            var dateToMatch = datetime.Date;

            var records = _dbContext.StockTable
                .Where(p => p.Date.Date == dateToMatch)
                .ToList();
            return records;
        }

    }
}

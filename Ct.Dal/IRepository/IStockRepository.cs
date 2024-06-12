using Ct.common.Entities;
using Ct.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.InterfacesDal
{
    public interface IStockRepository
    {
        public List<Stock> GetAllStock();

        public void DeleteStock(int id);

        public void AddStock(Stock stock);

        public void UpdateStock(Stock stock);

        public Stock GetStockById(int id);

        public bool IsStockExist(int stockid);

        public Stock GetStockByIdfromCloth(int id);

        public List<Stock> GetByDate(DateTime datetime);

    }
}

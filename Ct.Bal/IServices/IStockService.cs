using Ct.common.Models;
using Ct.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.InterfacesBal
{
    public interface IStockService
    {
        public List<ShowStockModel> GetAllStock();

        public void DeleteStock(int id);

        public void AddStock(StockModel model);

        public void UpdateStock(StockDto model);

        public StockModel GetStockById(int id);
    }
}

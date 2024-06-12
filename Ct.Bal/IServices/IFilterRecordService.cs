using Ct.common.Entities;
using Ct.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.BAL.IServices
{
    public interface IFilterRecordService
    {
        public List<ShowClothModel> GetClothByBrandId(int id);
        public List<ShowClothModel> GetClothByCatId(int id);
        public List<ShowStockModel> GetByDate(DateTime datetime);


    }
}

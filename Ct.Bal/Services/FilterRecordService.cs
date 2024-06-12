using AutoMapper;
using Ct.BAL.IServices;
using Ct.common.Entities;
using Ct.Common.Models;
using Ct.Dal.InterfacesDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.BAL.Services
{
    public class FilterRecordService:IFilterRecordService
    {
        private readonly IClothRepository _clothRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public FilterRecordService(IClothRepository clothRepository, IMapper mapper, IStockRepository stockRepository)
        {
            _clothRepository = clothRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;

        }
        public List<ShowClothModel> GetClothByBrandId(int id)
        {
            var cloths = _clothRepository.GetClothByBrand(id);
           
            if (cloths == null ||  cloths.Count == 0)
            {
                throw new Exception("cloth of this brand is not found");
            }
            var clothModels = _mapper.Map<List<ShowClothModel>>(cloths);
            return clothModels;      
         
        }

        public List<ShowClothModel> GetClothByCatId(int id)
        {
            var cloths = _clothRepository.GetClothByCatId(id);

            if (cloths == null || cloths.Count == 0)
            {
                throw new Exception("cloth of this Category is not found");
            }
            var clothModels = _mapper.Map<List<ShowClothModel>>(cloths);
            return clothModels;
        }

        public List<ShowStockModel> GetByDate(DateTime datetime)
        {
            var records = _stockRepository.GetByDate(datetime);
            if(records == null || records.Count == 0)
            {
                throw new Exception("this date not found");
            }
            var clothmodels = _mapper.Map<List<ShowStockModel>>(records); 
            return clothmodels;   

        }
      
    }
}

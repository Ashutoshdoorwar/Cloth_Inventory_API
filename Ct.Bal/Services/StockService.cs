using AutoMapper;
using Ct.Bal.InterfacesBal;
using Ct.common.Entities;
using Ct.common.Models;
using Ct.Common.Models;
using Ct.Dal.InterfacesDal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.ClassBal
{
    public class StockService :IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IClothRepository _clothRepository;
        private readonly IMapper _mapper;

        public StockService(IStockRepository stockDataAccess, IMapper mapper, IClothRepository clothRepository)
        {
            _stockRepository = stockDataAccess;
            _mapper = mapper;
            _clothRepository = clothRepository; 
        }

        public List<ShowStockModel> GetAllStock()
        {
            var stocks = _stockRepository.GetAllStock();
            var stock = _mapper.Map<List<ShowStockModel>>(stocks);
            return stock;
        }

        public void DeleteStock(int id)
        {
            if (id > 0)
            {
                _stockRepository.DeleteStock(id);
            } 
        }

        public void AddStock(StockModel model)
        {
            bool isExist = _clothRepository.IsClothExist(model.Cloth_id);
            if (!isExist)
            {
                throw new Exception("Cloth is not valid");
            }

            var existingstock = _stockRepository.GetStockById(model.Cloth_id);
            if (existingstock != null)
            {
               existingstock.Quantity += model.Quantity;
                var stocks = _mapper.Map<Stock>(existingstock);
                _stockRepository.UpdateStock(stocks);

                var cloth = _clothRepository.GetClothById(model.Cloth_id);
                if (cloth != null)
                {
                    cloth.Quantity += model.Quantity;
                    _clothRepository.UpdateClothFromStock(cloth);
                }
            }
            else
            {
                var stocks = _mapper.Map<Stock>(model);
                _stockRepository.AddStock(stocks);
              
            }   
             
        }

        public void UpdateStock(StockDto model)
        {
            var existingstock = _stockRepository.GetStockById(model.Stock_id);
            if (existingstock == null)
            {
                throw new ArgumentException("Stock ID not found.");
            }
            bool clothid = _clothRepository.IsClothExist(model.Cloth_id);
            if (!clothid)
            {
                throw new Exception("cloth id not found");
            }
            existingstock.Cloth_id = model.Cloth_id;
            existingstock.Quantity += model.Quantity;

            var stocks = _mapper.Map<Stock>(existingstock);
            _stockRepository.UpdateStock(stocks);

            var cloth = _clothRepository.GetClothById(model.Cloth_id);
            if (cloth != null)
            {
                cloth.Quantity += model.Quantity;
                _clothRepository.UpdateClothFromStock(cloth);
            }
         
        }

        public StockModel GetStockById(int id)
        {
            var stock = _stockRepository.GetStockById(id);
            if (stock == null)
            {
                throw new ArgumentException("stock not found");
            }
            return _mapper.Map<StockModel>(stock);
        }
    }
}

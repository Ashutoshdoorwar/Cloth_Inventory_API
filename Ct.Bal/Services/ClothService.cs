using AutoMapper;
using Ct.Bal.InterfacesBal;
using Ct.common.Entities;
using Ct.common.Models;
using Ct.Common.Models;
using Ct.Dal.ClassDal;
using Ct.Dal.InterfacesDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.ClassBal
{
    public class ClothService : IClothService
    {
        private readonly IClothRepository _clothRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStockRepository _stockRepository;

        private readonly IMapper _mapper;

        public ClothService(IClothRepository clothRepository, IMapper mapper, IBrandRepository brandRepository
            , ICategoryRepository categoryRepository, IStockRepository stockRepository)
        {
            _clothRepository = clothRepository;
            _mapper = mapper;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _stockRepository = stockRepository;
        }

        public void AddCloth(ClothModel clothModel)
        {
            var clothexist = _clothRepository.ClothExist(clothModel.Cloth_name);
            if (clothexist != null)
            {


                throw new Exception("This cloth is already exist ,You can't add twice");
            }
            else
            {
                var cloth = _mapper.Map<Cloth>(clothModel);
                validation(cloth);
                int newid = _clothRepository.GetCurrentId();

                newid += 1;
                var newStock = new Stock
                {
                    Cloth_id = newid,
                    Quantity = cloth.Quantity,
                    Cloth_name = cloth.Cloth_name,
                    Cloth_price = clothModel.Cloth_price,
                    Date = clothModel.DateTime,

                };
                var brand = _brandRepository.GetBrandById(clothModel.Brand_id);
                cloth.Brand_name = brand.Brand_name;
                var category = _categoryRepository.GetCategoryId(clothModel.Category_id);
                cloth.Category_name = category.Category_name;

                _clothRepository.AddCloth(cloth, newStock);
            }
        }

        public void DeleteCloth(int id)
        {
            var clothid = _clothRepository.IsClothExist(id);
            if (!clothid)
            {
                throw new Exception("Cloth is not found");
            }
            _clothRepository.DeleteCloth(id);
        }
        //review this code.........
        public void UpdateCloth(ClothDto clothdto)
        {
            var cloth = _mapper.Map<Cloth>(clothdto);
            validation(cloth);
            bool clothid = _clothRepository.IsClothExist(clothdto.Cloth_id);
            if (!clothid)
            {
                throw new Exception("cloth id not found");
            }
            var existingstock = _stockRepository.GetStockByIdfromCloth(cloth.Cloth_id);
            
            if (existingstock != null)
            {
               // existingstock.Cloth_name = cloth.Cloth_name;
                existingstock.Quantity += cloth.Quantity;

            }
            var existingcloth = _clothRepository.GetClothById(clothdto.Cloth_id);
            if(existingcloth != null)
            {
                //cloth.Cloth_name = existingcloth.Cloth_name;
                //cloth.Brand_name = existingcloth.Brand_name;
                //cloth.Category_name = existingcloth.Category_name;
                //cloth.Quantity += existingcloth.Quantity;
                existingcloth.Quantity += clothdto.Quantity;

                _clothRepository.UpdateCloth(existingcloth, existingstock);
            }
           
        }

        public List<ShowClothModel> GetAllCloth()
        {
            var clothEntities = _clothRepository.GetAllCloth();
            var clothModels = _mapper.Map<List<ShowClothModel>>(clothEntities);
            return clothModels;
        }


        public ShowClothModel GetClothById(int id)
        {
            var cloth = _clothRepository.GetClothById(id);
            if (cloth == null)
            {
                throw new ArgumentException("cloths not found");
            }
            var clothmodel = _mapper.Map<ShowClothModel>(cloth);
            return clothmodel;
        }

        private void validation(Cloth cloth)
        {
            if (!_brandRepository.checkBrand(cloth.Brand_id))
            {
                throw new ArgumentException("check your brand id once again !!");
            }
            if (!_categoryRepository.checkCategory(cloth.Category_id))
            {
                throw new AggregateException("check your category id once again !!");
            }
        }

        
    }
}

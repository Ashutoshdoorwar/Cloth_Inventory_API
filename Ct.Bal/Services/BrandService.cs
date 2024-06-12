using AutoMapper;
using Ct.Bal.InterfacesBal;
using Ct.common.Entities;
using Ct.common.Models;
using Ct.Dal.ClassDal;
using Ct.Dal.InterfacesDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.ClassBal
{
    public class BrandService :IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;

        }
        public List<BrandDto> GetAllBrands()
        {
            var brands = _brandRepository.GetAllBrands();
            var branDto = _mapper.Map<List<BrandDto>>(brands);
            return branDto;
        }

        public void AddBrand(BrandModel brandModel)
        {
            bool existbrand = _brandRepository.checkBrandByName(brandModel.Brand_name);
            if(existbrand)
            { 
                throw new ArgumentNullException(nameof(brandModel), "BrandModel cannot be null");
            }
            var brands = _mapper.Map<Brand>(brandModel); //change model to entity
            _brandRepository.AddBrand(brands);
        }

        public BrandModel GetBrandById(int id)
        {
            var brand = _brandRepository.GetBrandById(id);
            if(brand  == null)
            {
                throw new Exception("Enter valid Brand id");
            }
            var brands = _mapper.Map<BrandModel>(brand);
            return brands;
        }

        public void DeleteBrandById(int id)
        {
            _brandRepository.DeleteBrandById(id);

        }

        public void UpdateBrand(BrandDto branddto)
        {
            var brand = _mapper.Map<Brand>(branddto);
            bool brands = _brandRepository.checkBrand(brand.Brand_id);
            if (!brands)
            {
                throw new ArgumentException("Brand with ID not found.");
            }

            _brandRepository.UpdateBrand(brand);
        }
    }
}

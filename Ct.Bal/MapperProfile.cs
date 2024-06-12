using AutoMapper;
using Ct.common.Entities;
using Ct.common.Models;
using Ct.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Users, UsersModel>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Brand, BrandModel>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Cloth, ClothModel>().ReverseMap();
            CreateMap<Cloth, ShowClothModel>().ReverseMap();
            CreateMap<Cloth, ClothDto>().ReverseMap();
            CreateMap<Stock, StockModel>().ReverseMap(); 
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<Stock, ShowStockModel>().ReverseMap();

        }
    }
}

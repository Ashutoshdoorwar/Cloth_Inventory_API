using Ct.common.Entities;
using Ct.common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.InterfacesBal
{
    public interface IBrandService
    {
        public List<BrandDto> GetAllBrands();

        public void AddBrand(BrandModel brandModel);

        public BrandModel GetBrandById(int id);

        public void DeleteBrandById(int id);
        public void UpdateBrand( BrandDto branddto);
    }
}

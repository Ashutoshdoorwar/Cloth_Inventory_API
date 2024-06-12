using Ct.common.Entities;
using Ct.common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.InterfacesDal
{
    public interface IBrandRepository
    {
        public List<Brand> GetAllBrands();

        public void AddBrand(Brand brand);

        public Brand GetBrandById(int id);

        public void DeleteBrandById(int id);

        public void UpdateBrand(Brand brand);
        public bool checkBrand(int brandId);

        public bool checkBrandByName(string brandname);


    }
}

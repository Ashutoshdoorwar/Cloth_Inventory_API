using Ct.common.Entities;
using Ct.common.Models;
using Ct.Dal.Data;
using Ct.Dal.InterfacesDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.ClassDal
{
    public class BrandRepository : IBrandRepository
    {

        private readonly ApplicationDbContext dbContext;
        public BrandRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Brand> GetAllBrands()
        {
            var brands = dbContext.BrandTable.ToList();
            return brands;
        }

        public void AddBrand(Brand brand)
        {
            dbContext.BrandTable.Add(brand);
            dbContext.SaveChanges();

        }
        public Brand GetBrandById(int id)
        {
            var brand = dbContext.BrandTable.FirstOrDefault(c => c.Brand_id == id);
            return brand;
        }

        public void DeleteBrandById(int id)
        {
            var brand = dbContext.BrandTable.Find(id);
            dbContext.BrandTable.Remove(brand);
            dbContext.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            dbContext.BrandTable.Update(brand);

            dbContext.SaveChanges();

        }
        public bool checkBrand(int brandId)
        {
            return dbContext.BrandTable.Any(b => b.Brand_id == brandId);
            
        }

        public bool checkBrandByName(string brandname)
        {
            return dbContext.BrandTable.Any(b => b.Brand_name == brandname);

        }

    }
}

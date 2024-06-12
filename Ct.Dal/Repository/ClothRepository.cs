using Ct.common.Entities;
using Ct.Common.Models;
using Ct.Dal.Data;
using Ct.Dal.InterfacesDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.ClassDal
{
    public class ClothRepository : IClothRepository
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IStockRepository _stockRepository;
     
        public ClothRepository(ApplicationDbContext dbContext, ICategoryRepository categoryRepository,
            IBrandRepository brandRepository, IStockRepository stockRepository)
        {
            _dbContext = dbContext;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _stockRepository = stockRepository;
        }

        public void AddCloth(Cloth cloth, Stock newStock)
        {

            _dbContext.ClothTable.Add(cloth);
            _dbContext.StockTable.Add(newStock);
            _dbContext.SaveChanges();
        }


        public void DeleteCloth(int id)
        {
            var cloth = _dbContext.ClothTable.FirstOrDefault(c => c.Cloth_id == id);
            var existingstock = _dbContext.StockTable.FirstOrDefault(s => s.Cloth_id == cloth.Cloth_id);

            _dbContext.ClothTable.Remove(cloth);
            _dbContext.StockTable.Remove(existingstock);
            _dbContext.SaveChanges();
        }

        public void UpdateCloth(Cloth cloth, Stock stock)
        {
                _dbContext.ClothTable.Update(cloth);
              //  _dbContext.SaveChanges();
                _dbContext.StockTable.Update(stock);
                 _dbContext.SaveChanges();
            
            
        }
        public void UpdateClothFromStock(Cloth cloth)
        {
            _dbContext.ClothTable.Update(cloth);
            _dbContext.SaveChanges();
        }
        public List<Cloth> GetAllCloth()
        {
            return _dbContext.ClothTable.ToList();
        }

        public Cloth GetClothById(int id)
        {
            var cloths = _dbContext.ClothTable.FirstOrDefault(c => c.Cloth_id == id);
            return cloths;
        }

        public bool IsClothExist(int clothid)
        {
            return _dbContext.ClothTable.Any(c => c.Cloth_id == clothid);
        }

        public int GetCurrentId()
        {

            if (_dbContext.ClothTable.Any())
            {

                var id = _dbContext.ClothTable.Max(c => c.Cloth_id);
                return id;
            }
            else
            {
                return 0;
            }
           
           
        }

        public List<Cloth> GetClothByBrand(int id)
        {
            var cloths = _dbContext.ClothTable.Where(p=> p.Brand_id == id).ToList();
            return cloths;
        }

        public List<Cloth> GetClothByCatId(int id)
        {
            var cloths = _dbContext.ClothTable.Where(p => p.Category_id == id).ToList();
            return cloths;
        }

        public Cloth ClothExist(string clothname)
        {
            return _dbContext.ClothTable.FirstOrDefault(c => c.Cloth_name == clothname);
        }

     



    }
}

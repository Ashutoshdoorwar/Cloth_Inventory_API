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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Category> GetAllCategory()
        {
            return dbContext.CategoryTable.ToList();

        }
        public void AddCategory(Category category)
        {
           
            dbContext.CategoryTable.Add(category);
            dbContext.SaveChanges();
        }

        public Category GetCategoryId(int id)
        {
            return dbContext.CategoryTable.FirstOrDefault(c => c.Category_id == id);
        }


        public void DeleteCategoryId(int id)
        {
            var category = dbContext.CategoryTable.FirstOrDefault(c => c.Category_id == id);
            dbContext.CategoryTable.Remove(category);

            dbContext.SaveChanges();
        }

        public void UpdateCategoryById(Category category)
        {
            dbContext.CategoryTable.Update(category);
           
            dbContext.SaveChanges();
            
        }

        public bool checkCategory(int categoryid)
        {
            return dbContext.CategoryTable.Any(c => c.Category_id == categoryid);
        }

        public bool checkCategoryByName(string categoryname)
        {
            return dbContext.CategoryTable.Any(c => c.Category_name == categoryname);
        }
    }
}

using Ct.common.Entities;
using Ct.common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.InterfacesDal
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategory();

        public void AddCategory(Category category);

        public Category GetCategoryId(int id);

        public void DeleteCategoryId(int id);

        public void UpdateCategoryById(Category category);

        public bool checkCategory(int categoryId);
        public bool checkCategoryByName(string categoryname);
    }
}

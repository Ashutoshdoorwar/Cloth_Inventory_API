using Ct.common.Entities;
using Ct.common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.InterfacesBal
{
    public interface ICategoryService
    {
        public List<CategoryDto> GetAllCategory();
        public void AddCategory(CategoryModel categorymodel);

        public CategoryModel GetCategoryId(int id);

        public void DeleteCategoryId(int id);

        public void UpdateCategoryById(CategoryDto categorydto);
    }
}

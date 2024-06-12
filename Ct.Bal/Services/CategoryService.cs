using AutoMapper;
using Ct.Bal.InterfacesBal;
using Ct.common.Entities;
using Ct.common.Models;
using Ct.Dal.InterfacesDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.ClassBal
{
   
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public List<CategoryDto> GetAllCategory()
        {
             var category = _categoryRepository.GetAllCategory();
            var categorydto = _mapper.Map<List<CategoryDto>>(category);
            return categorydto;
        }

        public void AddCategory(CategoryModel categoryModel)
        {
            var categry = _categoryRepository.checkCategoryByName(categoryModel.Category_name);
            if (categry)
            {
                throw new Exception("category already exist");
            }
            else
            {
                var category = _mapper.Map<Category>(categoryModel);
                _categoryRepository.AddCategory(category);
            }
        }

        public CategoryModel GetCategoryId(int id)
        {
            var category = _categoryRepository.GetCategoryId(id);
            if(category == null)
            {
                throw new ArgumentException("Category not found");
            }
            var categorymodel = _mapper.Map<CategoryModel>(category);
            return categorymodel;
        }

        public void DeleteCategoryId(int id)
        {
            _categoryRepository.DeleteCategoryId(id);
        }

        public void UpdateCategoryById(CategoryDto categorydto)
        {
            var categoryentity = _mapper.Map<Category>(categorydto);
            bool categoryexist = _categoryRepository.checkCategory(categoryentity.Category_id);
            if(!categoryexist)
            {
                throw new Exception("Enter valid category");
            }
            _categoryRepository.UpdateCategoryById(categoryentity);
        }
    }
}

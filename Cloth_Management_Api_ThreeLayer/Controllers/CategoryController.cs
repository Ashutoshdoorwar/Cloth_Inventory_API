using Ct.Bal.InterfacesBal;
using Ct.common.EmailModel;
using Ct.common.Entities;
using Ct.common.Models;
using CT.Email.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloth_Management_Api_ThreeLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IEmailService emailService;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, IEmailService emailService)
        {
            _categoryService = categoryService;

            this.emailService = emailService;

        }


        [Authorize]
        [HttpGet]
        [Route("getallCategory")]
        public IActionResult GetAllCategory()
        {
           var allcategory = _categoryService.GetAllCategory();

            return Ok(allcategory);

        }

        [Authorize]
        [HttpPost]
        [Route("AddCategory")]  
        public async Task <IActionResult> AddCategory(CategoryModel categorymodel)
        {
            try
            {
                if (categorymodel == null)
                {
                    return BadRequest("Model Can't be Null");
                }
                _categoryService.AddCategory(categorymodel);

                var mailrequest = new MailRequest();
                mailrequest.ToEmail = EmailTemplate.ToEmail;
                mailrequest.Subject = EmailTemplate.Subject.Replace("@", "Category");
                mailrequest.Body = $"<h1>{EmailTemplate.Body.Replace("@", "Category")}: {categorymodel.Category_name}</h1>";
                await emailService.SendEmailAsync(mailrequest);

                return Content("Category Added successfully");
            }
            catch (Exception)
            {
                return BadRequest("Category already exist");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetCategoryId/{id}")]
        public IActionResult GetCategoryId(int id)
        {
            try
            {
                var category = _categoryService.GetCategoryId(id);
                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(404, "You entered the ID is not matched");
            }
           
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteById/{id}")]
        public IActionResult DeleteCategoryId(int id)
        {
            try
            {
                _categoryService.DeleteCategoryId(id);
                return Ok("category deleted sucessfully");
            }
            catch (Exception)
            {
                return StatusCode(404, "You entered the ID is not matched");
            }
           
        }


        [Authorize]
        [HttpPut]
        [Route("UpdateCategory")]

        public IActionResult UpdateCategoryById(CategoryDto categorydto)
        {
            try
            {
                _categoryService.UpdateCategoryById(categorydto);
                return Ok("Category updated succesffulyy");
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went Wrong Check your Category Id and Category Name ??");
            }

        }
    }
}

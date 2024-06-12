using AutoMapper.Internal;
using Ct.Bal.ClassBal;
using Ct.Bal.InterfacesBal;
using Ct.common.EmailModel;
using Ct.common.Models;
using CT.Email.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloth_Management_Api_ThreeLayer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IEmailService emailService;
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService, IEmailService emailService)
        {
            _brandService = brandService;
            this.emailService = emailService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllBrands")]
        public IActionResult GetAllBrands()
        {
           var brands =  _brandService.GetAllBrands();
            return Ok(brands);
            
        }


        [Authorize]
        [HttpPost]
        [Route("AddBrand")]
        public async Task<IActionResult> AddBrand(BrandModel brandModel)
        {
            try {
                if (brandModel == null)
                {
                    return BadRequest("brand model cant be null");
                }
                _brandService.AddBrand(brandModel);

                var mailrequest = new MailRequest();
                mailrequest.ToEmail = EmailTemplate.ToEmail;
                mailrequest.Subject = EmailTemplate.Subject.Replace("@", "brand");
                mailrequest.Body = $"<h1>{EmailTemplate.Body.Replace("@", "brand")}: {brandModel.Brand_name}</h1>";

                await emailService.SendEmailAsync(mailrequest);

                return Content("Brand Added successfully");
            }
            catch (Exception)
            {
                return BadRequest("brand already exist");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetBrandById/{id}")]

        public IActionResult GetBrandById(int id)
        {
            try
            {
                var brand = _brandService.GetBrandById(id);
                return Ok(brand);
            }

            catch (Exception)
            {
                return BadRequest("you entered Brand Id is not found");
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("DeleteBrandById/{id}")]

        public IActionResult DeleteBrandById(int id)
        {
            try
            {
                _brandService.DeleteBrandById(id);
                return Ok("brand deleted succesfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong check your Brand Id");
            }
           
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateBrand")]

        public IActionResult UpdateBrand(BrandDto branddto)
        {
            try
            {
                _brandService.UpdateBrand(branddto);
                return Ok("Brand updated successfully");
            }
            catch (Exception)
            {
                    return StatusCode(500, "Some thing went wrong check id or brand name");
                
            }
        }


    }
}

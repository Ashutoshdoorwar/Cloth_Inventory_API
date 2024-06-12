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
    public class ClothController : ControllerBase
    {
        private readonly IEmailService emailService;
        private readonly IClothService _clothService;

        public ClothController(IClothService clothService, IEmailService emailService)
        {
            _clothService = clothService;
            this.emailService = emailService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllCloth")]

        public IActionResult GetAllCloth()
        {
            var cloth = _clothService.GetAllCloth();
            return Ok(cloth);
        }

        [Authorize]
        [HttpPost("AddCloth")]
        public async Task <IActionResult> AddCloth(ClothModel clothModel)
        {
            try
            {
                _clothService.AddCloth(clothModel);

                var mailrequest = new MailRequest();
                mailrequest.ToEmail = EmailTemplate.ToEmail;
                mailrequest.Subject = EmailTemplate.Subject.Replace("@", "Cloth");
                mailrequest.Body = $"<h1>{EmailTemplate.Body.Replace("@", "Cloth")}: {clothModel.Cloth_name}</h1>";

                await emailService.SendEmailAsync(mailrequest);

                return Ok("Cloth added successfully");
            }
            catch (ArgumentException)
            {
                return StatusCode(404, "Brand id does not found");
            }
            catch (AggregateException)
            {
                return StatusCode(404, "Category id does not found");
            }
            catch (Exception)
            {
                return StatusCode(404, "This cloth is already exist ,You can't add twice");
            }
            
        }


        [Authorize]
        [HttpDelete("DeleteCloth/{id}")]
        public IActionResult DeleteCloth(int id)
        {
            try
            {
                _clothService.DeleteCloth(id);
                return Ok("Cloth deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(404, "you entered the ID is not matched");
            }
           
        }

        [Authorize]
        [HttpPut("UpdateCloth")]
        public IActionResult UpdateCloth(ClothDto clothdto)
        {
            try
            {
                _clothService.UpdateCloth(clothdto);
                return Ok("Cloth updated successfully");
                
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid ID check your,brand id once again !!");
            }
            catch (AggregateException)
            {
                return BadRequest("Invalid category Id");
            }
            catch (Exception)
            {
                return BadRequest("invalid cloth id");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetClothById/{id}")]
        public IActionResult GetClothById(int id)
        {
            try
            {
                var cloth = _clothService.GetClothById(id);
                return Ok(cloth);
            }
            catch (Exception)
            {
                return StatusCode(404, "you entered the ID is not matched");
            }

        }
    }
}

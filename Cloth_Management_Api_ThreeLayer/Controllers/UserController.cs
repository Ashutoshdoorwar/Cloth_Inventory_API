using Ct.Bal.InterfacesBal;
using Ct.common.EmailModel;
using Ct.common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Cloth_Management_Api_ThreeLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPost]
        [Route(("AddUser"))]
        public IActionResult AddUser(UsersModel model)
        {
            if(model == null)
            {
                return BadRequest("user model cant empty");
            }

            var mailrequest = new MailRequest();
            mailrequest.ToEmail = EmailTemplate.ToEmail;
            mailrequest.Subject = EmailTemplate.Subject.Replace("@", "New User");
            mailrequest.Body = $"<h1>{EmailTemplate.Body.Replace("@", "New User")}: {model.Username}</h1>";

            _userService.AddUser(model);
            return Ok("User Added Succesfully");
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteUserById/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            _userService.DeleteUserById(id);
            return Ok("User deleted Sucessfullly");
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateUser/{id}")]
        public IActionResult UpdateUser(UsersModel usersModel,int id)
        {
          _userService.UpdateUsers(usersModel,id);
            return Ok("User updated Succesfuuly");
           
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
          var users =  _userService.GetAllUsers();
            return Ok(users);
            

        }

    }
}

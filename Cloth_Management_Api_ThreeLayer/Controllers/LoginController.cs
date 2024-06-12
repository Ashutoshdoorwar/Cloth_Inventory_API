using Ct.common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ct.Bal.InterfacesBal;
using Ct.Bal.ClassBal;

namespace Cloth_Management_Api_ThreeLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        private IConfiguration _config;
       // private readonly ApplicationDbContext dbContext;
        public LoginController(IConfiguration configuration, ILoginService loginService)
        {
            _loginService = loginService;
            _config = configuration;
           // this.dbContext = dbContext;

        }

        [AllowAnonymous]  //bypass the authenticaton
        [HttpPost]
        public IActionResult Login(UsersModel user)
        {
            IActionResult response = Unauthorized();
            var user_ = _loginService.AuthenticationUser(user);
            if (user_ != null)
            {
                var token = _loginService.GenerateToken(user_);
                response = Ok(new { token = token });
            }
            return response;
        }

    }
}

//using Ct.Bal.Service;
using Ct.common.EmailModel;
using CT.Email.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloth_Management_Api_ThreeLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;
        public EmailController(IEmailService emailService)
        {

            this.emailService = emailService;

        }

        [HttpPost("sendemail")]
        public async Task<IActionResult> SendEmail(MailRequest mailRequestt)
        {
            var mailrequest = new MailRequest();
            mailrequest.ToEmail = mailRequestt.ToEmail;
            mailrequest.Subject = mailRequestt.Subject;
            mailrequest.Body = mailRequestt.Body;
           
            await emailService.SendEmailAsync(mailrequest);
            return Ok();
        }

    }
}

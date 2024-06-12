using Ct.common.EmailModel;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using MailKit.Net.Smtp;
using System.Collections.Generic;
using System.Linq;
//using System.Net.Mail;
using Ct.common.Models;
using System.Text;
using System.Threading.Tasks;

namespace CT.Email.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;
        public EmailService(IOptions<EmailSettings> options)
        {
            this.emailSettings = options.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            string ccEmail = "adityagehlot0109@gmail.com";
            string bccEmail = "gehlotaditya0109@gmail.com";

            if(mailRequest.ToEmail == null)
            {
                mailRequest.ToEmail = "ashutoshdoorwar1@gmail.com";
            }
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            email.Cc.Add(MailboxAddress.Parse(ccEmail));
            email.Bcc.Add(MailboxAddress.Parse(bccEmail));


            var builder = new BodyBuilder();

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailSettings.Email, emailSettings.Password);

            await smtp.SendAsync(email);
            smtp.Disconnect(true);


        }
    }
}

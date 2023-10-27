using HotelProjectApi.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMailController : ControllerBase
    {

        [HttpPost("Index")]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("HotelProject", "example2685@gmail.com"); // kim tarafından - kime gönderilecek
            mimeMessage.From.Add(mailboxAddress); // kim tarafınan geldiğini ekledik mime messageye

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false); // bağlanma işlemi 587 : port numarası false : ssl gereksinimi
            client.Authenticate("example2685@gmail.com", "bygffpyzrstswkyj"); // mail ve maile ait key gekcek
            client.Send(mimeMessage);
            client.Disconnect(true);
            return Ok();
        }

    }
}

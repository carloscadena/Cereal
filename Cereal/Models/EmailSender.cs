using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Models
{
    public class EmailSender : IEmailSender
    {
        public IConfiguration Configuration { get; }

        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Configuration["Cereal_SendGrid_API"]);

            
            var from = new EmailAddress("carloscadena@live.com", "Carlos");
            var to = new EmailAddress(email);
            var emailSubject = subject;
            var plainTextContent = "Welcome";
            var htmlContent = htmlMessage;
            var msg = MailHelper.CreateSingleEmail(from, to, emailSubject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
using GunDetection.Data.Services.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GunDetection.Data.Services
{
    public static class SendEmailService
    {
        public static async Task<bool> SendEmail(string email ,string asunto,  string html)
        {

            var client = new SendGridClient(CredencialMails.ApiKey);
            var from = new EmailAddress(CredencialMails.MailFrom );
            var subject = asunto;
            var to = new EmailAddress(email );
            var plainTextContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, html);
            var response = await client.SendEmailAsync(msg);
            return true;
        }
    }
}

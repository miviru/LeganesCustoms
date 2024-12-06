using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace LeganesCustomsBlazor.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly string _apiKey;

        public SendGridEmailSender(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("miguel10leg@gmail.com", "Leganes Customs");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlMessage);
            await client.SendEmailAsync(msg);
        }
    }
}

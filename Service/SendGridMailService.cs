namespace Notary.Service
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Notary.DTO;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class SendGridMailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(EmailDTO emailDto)
        {
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "example user");
            var to = new EmailAddress(emailDto.Email);
            var msg = new SendGridMessage
            {
                From = from,
                Subject = "Your subject here", 
                PlainTextContent = emailDto.SelectedText, 
                HtmlContent = "<strong>HTML content here</strong>", 
            };
            msg.AddTo(to); 
            var response = await client.SendEmailAsync(msg);
        }
    }
}


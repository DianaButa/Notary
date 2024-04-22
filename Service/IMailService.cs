namespace Notary.Service
{
    using System.Threading.Tasks;
    using Notary.DTO;

    public interface IMailService
    {
        Task SendEmailAsync(EmailDTO emailDto);
    }
}

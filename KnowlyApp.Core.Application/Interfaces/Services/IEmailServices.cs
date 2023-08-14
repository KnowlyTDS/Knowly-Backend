using KnowlyApp.Core.Application.DTOs.Email;
using KnowlyApp.Core.Domain.Settings;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public MailSettings MailSettings { get; }

        Task SendAsync(EmailRequest request);
    }
}
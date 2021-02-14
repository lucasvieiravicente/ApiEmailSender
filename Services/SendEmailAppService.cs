using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ApiEmails.Domain;
using ApiEmails.Domain.Utils;
using Microsoft.Extensions.Configuration;

namespace ApiEmails.Services
{
    public class SendEmailAppService : ISendEmailAppService
    {
        private readonly string _receiverEmail;
        private readonly string _senderEmail;
        private readonly string _loginEmail;
        private readonly string _loginPassword;
        private readonly string _smtp;
        private const int _port = 587;

        public SendEmailAppService(IConfiguration configuration)
        {
            _receiverEmail = configuration["EmailsConfigs:ReceiverEmail"];
            _senderEmail = configuration["EmailsConfigs:SenderEmail"];
            _loginEmail = configuration["EmailsConfigs:Login"];
            _loginPassword = configuration["EmailsConfigs:Password"];
            _smtp = configuration["EmailsConfigs:Smtp"];
        }

        public async Task SendEmail(EmailViewModel email)
        {
            var smtp = new SmtpClient(_smtp, _port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,

                Credentials = new NetworkCredential(_loginEmail, _loginPassword)
            };

            MailMessage mail = EmailConstructor.ConstructMail(email, _senderEmail, _receiverEmail);
            await smtp.SendMailAsync(mail);
            smtp.Dispose();
        }
    }
}

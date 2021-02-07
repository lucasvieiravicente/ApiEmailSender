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
        private readonly IConfiguration _configuration;
        private readonly string _receiverEmail;
        private readonly string _senderEmail;
        private readonly string _loginEmail;
        private readonly string _loginPassword;
        private readonly string _smtp;
        private const int _port = 587;

        public SendEmailAppService(IConfiguration configuration)
        {
            _configuration = configuration;
            _receiverEmail = _configuration["EmailsConfigs:ReceiverEmail"];
            _senderEmail = _configuration["EmailsConfigs:SenderEmail"];
            _loginEmail = _configuration["EmailsConfigs:Login"];
            _loginPassword = _configuration["EmailsConfigs:Password"];
            _smtp =  _configuration["EmailsConfigs:Smtp"];
        }

        public async Task SendEmail(EmailViewModel email)
        {
            var smtp = new SmtpClient(_smtp, _port)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,

                Credentials = new NetworkCredential(_loginEmail, _loginPassword)
            };

            var mail = EmailConstructor.ConstructMail(email, _senderEmail, _receiverEmail);
            await smtp.SendMailAsync(mail);
            smtp.Dispose();
        }
    }
}

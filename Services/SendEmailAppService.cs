using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ApiEmails.Domain;
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
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_senderEmail),
                Body = $@"<p>{email.Body}</p>
                          <p><b>E-mail</b>: {email.Email}</p> 
                          <p><b>Telefone</b>: {email.PhoneNumber}</p>",
                Subject = !string.IsNullOrEmpty(email.Subject) ? email.Subject : $"Contato via API Email - {email.Name}",
                IsBodyHtml = true
            };
            mail.To.Add(_receiverEmail);

            using(var smtp = new SmtpClient(_smtp, 587))
            {
                smtp.EnableSsl = true;                
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;

                smtp.Credentials = new NetworkCredential(_loginEmail, _loginPassword);

                await smtp.SendMailAsync(mail);
            }
        }
    }
}

using System.Net.Mail;
using System.Text;

namespace ApiEmails.Domain.Utils
{
    public static class EmailConstructor
    {
        public static MailMessage ConstructMail(EmailViewModel email, string senderEmail, string receiverEmail)
        {
            return new MailMessage(new MailAddress(senderEmail), new MailAddress(receiverEmail))
            {
                Subject = !string.IsNullOrEmpty(email.Subject) ? email.Subject : SystemMessages.SUBJECT_DEFAULT,
                Body = CreateBody(email),
                IsBodyHtml = true
            };
        }

        private static string CreateBody(EmailViewModel email)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"<h2>Contato de {email.Name}</h2>");
            sb.AppendLine($"<p>{email.Body}</p>");
            sb.AppendLine($"<p><b>E-mail</b>: {email.Email}</p>");
            sb.AppendLine($"<p><b>Telefone</b>: {email.PhoneNumber}</p>");

            return sb.ToString();
        }
    }
}

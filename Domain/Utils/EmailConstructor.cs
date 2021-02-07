using System.Net.Mail;

namespace ApiEmails.Domain.Utils
{
    public static class EmailConstructor
    {
        public static MailMessage ConstructMail(EmailViewModel email, string senderEmail, string receiverEmail)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(senderEmail),
                Body = $@"<p>{email.Body}</p>
                          <p><b>E-mail</b>: {email.Email}</p> 
                          <p><b>Telefone</b>: {email.PhoneNumber}</p>",
                Subject = !string.IsNullOrEmpty(email.Subject) ? email.Subject : $"Contato via API Email - {email.Name}",
                IsBodyHtml = true
            };
            mail.To.Add(receiverEmail);

            return mail;
        }
    }
}

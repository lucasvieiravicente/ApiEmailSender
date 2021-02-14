using System.Net.Mail;

namespace ApiEmails.Domain.Utils
{
    public static class EmailConstructor
    {
        public static MailMessage ConstructMail(EmailViewModel email, string senderEmail, string receiverEmail)
        {
            var mail = new MailMessage()
            {
                From = new MailAddress(senderEmail),
                Subject = !string.IsNullOrEmpty(email.Subject) ? email.Subject : $"Contato via API Email",
                Body = $@"<h2>Contato de {email.Name}</h2>
                          <p>{email.Body}</p>
                          <p><b>E-mail</b>: {email.Email}</p> 
                          <p><b>Telefone</b>: {email.PhoneNumber}</p>",
                IsBodyHtml = true
            };
            mail.To.Add(receiverEmail);

            return mail;
        }
    }
}

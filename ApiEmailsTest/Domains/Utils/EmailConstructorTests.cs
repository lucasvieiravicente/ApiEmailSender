using ApiEmails.Domain;
using ApiEmails.Domain.Utils;
using ApiEmailsTest.Fakes;
using Bogus;
using System.Net.Mail;
using Xunit;

namespace ApiEmailsTest.Domains.Utils
{
    public class EmailConstructorTests
    {
        private readonly Faker _faker = new();
        private const bool WITH_SUBJECT = true;

        [Fact]
        public void ShouldReturn_ValidMailMessage_WhenConstructMail()
        {
            EmailViewModel emailModel = EmailViewModelFake.Create();
            string senderEmail = _faker.Internet.Email();
            string receiverEmail = _faker.Internet.Email();

            MailMessage mailMessage = EmailConstructor.ConstructMail(emailModel, senderEmail, receiverEmail);

            Assert.NotNull(mailMessage);
            Assert.True(mailMessage.IsBodyHtml);
            Assert.Matches(receiverEmail, mailMessage.To.ToString());
            Assert.Matches(senderEmail, mailMessage.From?.ToString());
            Assert.Matches(SystemMessages.SUBJECT_DEFAULT, mailMessage.Subject);
            Assert.Contains(emailModel.Body, mailMessage.Body);
            Assert.Contains(emailModel.Body, mailMessage.Body);
            Assert.Contains(emailModel.Body, mailMessage.Body);
            Assert.Contains(emailModel.Body, mailMessage.Body);
        }

        [Fact]
        public void ShouldReturn_ValidMailMessage_WhenConstructMail_WithSubject()
        {
            EmailViewModel emailModel = EmailViewModelFake.Create(WITH_SUBJECT);
            string senderEmail = _faker.Internet.Email();
            string receiverEmail = _faker.Internet.Email();

            MailMessage mailMessage = EmailConstructor.ConstructMail(emailModel, senderEmail, receiverEmail);

            Assert.NotNull(mailMessage);
            Assert.True(mailMessage.IsBodyHtml);
            Assert.Matches(receiverEmail, mailMessage.To.ToString());
            Assert.Matches(senderEmail, mailMessage.From?.ToString());
            Assert.Matches(emailModel.Subject, mailMessage.Subject);
            Assert.Contains(emailModel.Body, mailMessage.Body);
            Assert.Contains(emailModel.Body, mailMessage.Body);
            Assert.Contains(emailModel.Body, mailMessage.Body);
            Assert.Contains(emailModel.Body, mailMessage.Body);
        }
    }
}

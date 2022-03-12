using ApiEmails.Domain;
using ApiEmails.Services;
using ApiEmailsTest.Fakes;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiEmailsTest.Services
{
    public class SendEmailAppServiceTests
    {
        private readonly Mock<ISendEmailAppService> _sendEmailService;
        public SendEmailAppServiceTests()
        {
            _sendEmailService = new Mock<ISendEmailAppService>();
        }

        [Fact]
        public async Task ShouldReturnSuccess_WhenService_SendEmail()
        {
            EmailViewModel email = EmailViewModelFake.Create();

            await _sendEmailService.Object.SendEmail(email);
           
            _sendEmailService.Verify(x => x.SendEmail(email), Times.Once);
        }

        [Fact]
        public async Task ShouldReturnFail_WhenService_SendEmail()
        {
            EmailViewModel email = EmailViewModelFake.Create();
            var exception = new Exception("Error");
            _sendEmailService.Setup(m => m.SendEmail(email)).Throws(exception);

            try
            {
                await _sendEmailService.Object.SendEmail(email);
            }
            catch (Exception ex)
            {
                Assert.Equal(ex, exception);
                _sendEmailService.Verify(x => x.SendEmail(email), Times.Once);
            }      
        }
    }
}

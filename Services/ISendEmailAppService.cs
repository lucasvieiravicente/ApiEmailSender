using ApiEmails.Domain;

namespace ApiEmails.Services
{
    public interface ISendEmailAppService
    {
        void SendEmail(EmailViewModel email);
    }
}

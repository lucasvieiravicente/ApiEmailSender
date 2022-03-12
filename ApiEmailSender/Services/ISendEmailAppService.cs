using ApiEmails.Domain;
using System.Threading.Tasks;

namespace ApiEmails.Services
{
    public interface ISendEmailAppService
    {
        Task SendEmail(EmailViewModel email);
    }
}

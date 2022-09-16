using System.Net.Mail;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Email
{
    public interface IEmail
    {
        Task Send(string subject, string body, string toAddress, Attachment attachment = null);
        Task Send(string subject, string body, string[] toAddresses, Attachment attachment = null);
    }
}

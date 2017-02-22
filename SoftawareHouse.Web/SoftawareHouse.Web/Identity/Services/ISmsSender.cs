using System.Threading.Tasks;

namespace SoftawareHouse.Web.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
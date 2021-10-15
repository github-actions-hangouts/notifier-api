using System.Threading.Tasks;

namespace Notifier.Services
{
    public interface INotifierService
    {
        Task Publish(string topics, string messages);
    }
}
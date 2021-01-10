using System.Threading.Tasks;
using Csharp.Telegram.Business.Domain.Messages;

namespace Csharp.Telegram.Business.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationMessage message);
    }
}

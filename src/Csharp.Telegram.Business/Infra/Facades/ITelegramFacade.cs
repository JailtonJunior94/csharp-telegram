using System.Threading.Tasks;
using Csharp.Telegram.Business.Domain.Dtos;

namespace Csharp.Telegram.Business.Infra.Facades
{
    public interface ITelegramFacade
    {
        Task SendMessageAsync(SendMessageTelegram message);
    }
}

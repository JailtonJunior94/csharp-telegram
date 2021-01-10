using System;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using Csharp.Telegram.Business.Domain.Dtos;
using Csharp.Telegram.Business.Infra.Facades;
using Csharp.Telegram.Business.Domain.Messages;
using Csharp.Telegram.Business.Infra.Configuration;
using Csharp.Telegram.Business.Application.Interfaces;

namespace Csharp.Telegram.Business.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ITelegramFacade _telegramFacade;

        public NotificationService(ITelegramFacade telegramFacade)
        {
            _telegramFacade = telegramFacade;
        }

        public async Task SendNotificationAsync(NotificationMessage message)
        {
            try
            {
                var textMessage = $@" 
                                     ERRO ❌ ❗ 💥
                                     APLICAÇÃO: {message.Application} 
                                     MÉTODO: {message.Method} 
                                     DATA: {message.Date} 
                                     REQUEST: {message.Request} 
                                     RESPONSE: {message.Response} 
                                     EXCEPTON: {message.Exception}";

                var sendMessage = new SendMessageTelegram(EnvironmentKeyVault.ChatId, textMessage);
                await _telegramFacade.SendMessageAsync(sendMessage);
            }
            catch (Exception exception)
            {
                ExceptionDispatchInfo.Capture(exception).Throw();
            }
        }
    }
}

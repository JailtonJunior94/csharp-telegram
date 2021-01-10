using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Csharp.Telegram.Business.Domain.Messages;
using Csharp.Telegram.Business.Application.Interfaces;

namespace Csharp.Telegram.Batch.Functions
{
    [ServiceBusAccount("ServiceBusConnection")]
    public class FunctionNotifications
    {
        private readonly INotificationService _service;

        public FunctionNotifications(INotificationService service)
        {
            _service = service;
        }

        [FunctionName("FunctionNotifications")]
        public async Task RunAsync([ServiceBusTrigger("%NotificationsQueueName%")] string message)
        {
            var notificationMessage = JsonConvert.DeserializeObject<NotificationMessage>(message);
            await _service.SendNotificationAsync(notificationMessage);
        }
    }
}

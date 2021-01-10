using System;

namespace Csharp.Telegram.Business.Domain.Messages
{
    public class NotificationMessage
    {
        public string Application { get; set; }
        public string Method { get; set; }
        public DateTime Date { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Exception { get; set; }
    }
}

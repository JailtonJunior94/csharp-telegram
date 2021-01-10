using Newtonsoft.Json;

namespace Csharp.Telegram.Business.Domain.Dtos
{
    public class SendMessageTelegram
    {
        public SendMessageTelegram(long chatId, string text)
        {
            ChatId = chatId;
            Text = text;
        }

        [JsonProperty("chat_id")]
        public long ChatId { get; private set; }

        [JsonProperty("text")]
        public string Text { get; private set; }
    }
}

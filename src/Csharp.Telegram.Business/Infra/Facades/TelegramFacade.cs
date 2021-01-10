using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using Csharp.Telegram.Business.Domain.Dtos;
using Csharp.Telegram.Business.Infra.Configuration;

namespace Csharp.Telegram.Business.Infra.Facades
{
    public class TelegramFacade : ITelegramFacade
    {
        private readonly HttpClient _httpClient;

        public TelegramFacade(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendMessageAsync(SendMessageTelegram message)
        {
            try
            {
                var body = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                var url = string.Format(EnvironmentKeyVault.TelegramBaseURL, EnvironmentKeyVault.BotKey);

                var response = await _httpClient.PostAsync($"{url}/sendMessage", body);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception exception)
            {
                ExceptionDispatchInfo.Capture(exception).Throw();
            }
        }
    }
}

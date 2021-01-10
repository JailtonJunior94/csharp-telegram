using Csharp.Telegram.Business.Infra.Facades;
using Microsoft.Extensions.DependencyInjection;
using Csharp.Telegram.Business.Application.Services;
using Csharp.Telegram.Business.Application.Interfaces;

namespace Csharp.Telegram.Batch.Configurations
{
    public static class DependenciesConfiguration
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            /* Services */
            services.AddScoped<INotificationService, NotificationService>();

            /* Facades */
            services.AddHttpClient<ITelegramFacade, TelegramFacade>();
        }
    }
}

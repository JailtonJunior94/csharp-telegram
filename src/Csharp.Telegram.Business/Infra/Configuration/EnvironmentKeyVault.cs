using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Csharp.Telegram.Business.Infra.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class EnvironmentKeyVault
    {
        public static T GetValue<T>(string key)
        {
            var valor = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
            return (T)ChangeType(typeof(T), valor);
        }

        private static object ChangeType(Type t, object value)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(t);
            return tc.ConvertFrom(value);
        }

        public static string ServiceBusConnection { get { return GetValue<string>("ServiceBusConnection"); } }
        public static string NotificationsQueueName { get { return GetValue<string>("NotificationsQueueName"); } }
        public static string TelegramBaseURL { get { return GetValue<string>("TelegramBaseURL"); } }
        public static string BotKey { get { return GetValue<string>("BotKey"); } }
        public static long ChatId { get { return GetValue<long>("ChatID"); } }
    }
}

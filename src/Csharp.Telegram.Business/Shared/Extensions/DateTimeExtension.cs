using System;
using System.Diagnostics.CodeAnalysis;

namespace Csharp.Telegram.Business.Shared.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DateTimeExtension
    {
        public static DateTime DataAtualBrasilia(this DateTime data)
        {
            TimeZoneInfo timeZoneBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneBrasilia);
        }
    }
}

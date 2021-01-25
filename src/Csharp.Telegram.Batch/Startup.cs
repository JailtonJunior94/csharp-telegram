using System;
using System.IO;
using System.Reflection;
using System.Globalization;
using Csharp.Telegram.Batch;
using Microsoft.Extensions.Configuration;
using Csharp.Telegram.Batch.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Csharp.Telegram.Batch
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            var fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
            string path = fileInfo.Directory.Parent.FullName;

            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Environment.CurrentDirectory)
                 .SetBasePath(path)
                 .AddJsonFile("local.settings.json", optional: true, reloadOnChange: false)
                 .AddEnvironmentVariables()
                 .Build();

            builder.Services.AddSingleton(x => configuration);
            builder.Services.RegisterDependencies();
        }
    }
}

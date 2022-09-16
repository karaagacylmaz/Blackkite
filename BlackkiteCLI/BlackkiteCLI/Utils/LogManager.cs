using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlackkiteCLI.Utils
{
    public static class LogManager
    {
        public static void Configure()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();
            var fileName = "log/log" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "") + ".txt";

            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(config)
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    //.MinimumLevel.Verbose()
                    .Enrich.FromLogContext()
                    .WriteTo.File(fileName)
                    .CreateLogger();

            Log.Logger.Information("Application Starting");

        }

       
    }
}

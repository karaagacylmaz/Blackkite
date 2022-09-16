using BlackkiteCLI.Models.Environment;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlackkiteCLI.Utils
{
    public class EnvironmentVariables
    {
        public static Environments Get()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("environment.json", optional: false);

            IConfiguration config = builder.Build();

            var environmentVariables = config.GetSection("environmentVariables").Get<Environments>();
            System.Console.WriteLine(environmentVariables.ApiBaseUrl);
            return environmentVariables;
        }
    }
}

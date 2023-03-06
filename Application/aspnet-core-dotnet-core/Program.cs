using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace aspnet_core_dotnet_core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context,config) =>
            {
                var builtconfiguration = config.Build();

                string kvURL = builtconfiguration["KeyVaultConfig:kvURL"];
                string tenantId = builtconfiguration["KeyVaultConfig:TenantId"];
                string clientId = builtconfiguration["KeyVaultConfig:ClientId"];
                string clientSecret = builtconfiguration["KeyVaultConfig:ClientSecretId"];

                var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

                var client = new SecretClient(new Uri(kvURL), credential);
                config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());

            }).UseStartup<Startup>();
    }
}

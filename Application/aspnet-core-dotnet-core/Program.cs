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
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
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

                //var keyVaultURL = settings["KeyVaultConfiguration:KeyVaultURL"];
                //var keyVaultClientId = settings["KeyVaultConfiguration:ClientId"];
                //var keyVaultClientSecret = settings["KeyVaultConfiguration:ClientSecret"];

                //var azureServiceTokenProvider = new AzureServiceTokenProvider();

                //var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

                //var scret = keyVaultClient.GetSecretAsync(keyvaultEndpoint, SecretName).GetAwaiter().GetResult();

                //config.AddAzureKeyVault(keyVaultURL, keyVaultClientId, keyVaultClientSecret, new DefaultKeyVaultSecretManager());

                string kvURL = builtconfiguration["KeyVaultConfiguration:KeyVaultURL"];
                string tenantId = builtconfiguration["KeyVaultConfiguration:TenantId"];
                string clientId = builtconfiguration["KeyVaultConfiguration:ClientId"];
                string clientSecret = builtconfiguration["KeyVaultConfiguration:ClientSecret"];

                //config.AddAzureKeyVault($"https://{root["KeyVault:Vault"]}.vault.azure.net/", root["KeyVault:ClientId"], root["KeyVault:ClientSecret"]);

                var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

                var client = new SecretClient(new Uri(kvURL), credential);
                config.AddAzureKeyVault(client, new Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions());

            }).UseStartup<Startup>();
    }
}

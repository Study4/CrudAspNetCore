﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CrudAspNetCore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((context, config) =>
                 {
                     if (context.HostingEnvironment.EnvironmentName == "NativeAppService")
                     {
                         var builtConfig = config.Build();

                         var azureServiceTokenProvider = new AzureServiceTokenProvider();

                         var keyVaultClient = new KeyVaultClient(
                             new KeyVaultClient.AuthenticationCallback(
                                 azureServiceTokenProvider.KeyVaultTokenCallback));

                         config.AddAzureKeyVault(
                             builtConfig["KeyVault:BaseUrl"],
                             keyVaultClient,
                             new DefaultKeyVaultSecretManager());

                     }
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }


}

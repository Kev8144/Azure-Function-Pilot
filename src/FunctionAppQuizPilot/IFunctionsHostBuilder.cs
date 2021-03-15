using System;
using System.Linq;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

static class IFunctionsHostBuilderConfigurationExtensions
{
    /// <summary>
    /// Configures both local and deployed function to read json settings from configuration file
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IFunctionsHostBuilder AddAppSettingsToConfiguration(this IFunctionsHostBuilder builder)
    {
        var currentDirectory = "/home/site/wwwroot";
        bool isLocal = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID"));
        if (isLocal)
        {
            currentDirectory = Environment.CurrentDirectory;
        }

        var tmpConfig = new ConfigurationBuilder()
            .SetBasePath(currentDirectory)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .Build();

        var environmentName = tmpConfig["Environment"];

        var configurationBuilder = new ConfigurationBuilder();

        var descriptor = builder.Services.FirstOrDefault(d => d.ServiceType == typeof(IConfiguration));
        if (descriptor?.ImplementationInstance is IConfiguration configRoot)
        {
            configurationBuilder.AddConfiguration(configRoot);
        }

        var configuration = configurationBuilder.SetBasePath(currentDirectory)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"local.settings.{environmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        builder.Services.Replace(ServiceDescriptor.Singleton(typeof(IConfiguration), configuration));

        return builder;
    }
}
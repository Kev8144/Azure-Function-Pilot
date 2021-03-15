using FunctionAppQuizModel.Application;
using FunctionAppQuizModel.Models;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionAppQuizPilot.Startup))]

namespace FunctionAppQuizPilot
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IGreetings, Greetings>();

            IFunctionsHostBuilderConfigurationExtensions.AddAppSettingsToConfiguration(builder);
        }
    }
}

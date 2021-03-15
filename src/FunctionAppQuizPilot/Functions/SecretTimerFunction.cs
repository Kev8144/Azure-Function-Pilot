using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionAppQuizModel.Functions
{
    public static class SecretTimerFunction
    {
        [Disable]
        [FunctionName("SecretTimer")]
        public static void Run([TimerTrigger("*/1 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"If you are reading this in the log, then this function is not disabled. Executed at: {DateTime.Now}");
        }
    }
}

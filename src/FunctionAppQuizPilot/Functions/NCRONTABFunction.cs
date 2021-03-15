using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionAppQuizModel.Functions
{
    public static class NCRONTABFunction
    {
        [Disable]
        [FunctionName("NCRONTABFunction")]
        public static void Run([TimerTrigger("0 15 12 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"To better understand NCRONTAB expressions use the following link for more information: https://github.com/atifaziz/NCrontab");
        }
    }
}

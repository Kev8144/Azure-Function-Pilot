using FunctionAppQuizModel.Functions;
using FunctionAppQuizPilot;
using Functions.Tests.Helpers;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Functions.Tests.Functions
{
    public class DefaultTimerTemplateShould
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public void LogAMessage()
        {
            var logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.List);
            DefaultTimerTemplate.Run(null, logger);
            var msg = logger.Logs[0];
            Assert.Contains("C# Timer trigger function executed at", msg);
        }
    }
}
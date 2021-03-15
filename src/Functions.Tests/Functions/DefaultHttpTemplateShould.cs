using FunctionAppQuizModel;
using FunctionAppQuizModel.Functions;
using Functions.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Functions.Tests.Functions
{
    public class DefaultHttpTemplateShould
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void ReturnAString()
        {
            var request = TestFactory.CreateHttpRequest("name", "Kevin");
            var response = (OkObjectResult)await DefaultHttpTemplate.Run(request, logger);
            Assert.Equal("Hello, Kevin. This HTTP triggered function executed successfully.", response.Value);
        }

        [Theory]
        [MemberData(nameof(TestFactory.Data), MemberType = typeof(TestFactory))]
        public async void ReturnKnownStringFromData(string queryStringKey, string queryStringValue)
        {
            var request = TestFactory.CreateHttpRequest(queryStringKey, queryStringValue);
            var response = (OkObjectResult)await DefaultHttpTemplate.Run(request, logger);
            Assert.Equal($"Hello, {queryStringValue}. This HTTP triggered function executed successfully.", response.Value);
        }

       
    }
}
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using FunctionAppQuizModel.Models;

namespace FunctionAppQuizModel.Functions
{
    public class SeasonHttpFunction
    {
        private readonly IConfiguration _configuration;
        private readonly IGreetings _greetings;

        public SeasonHttpFunction(IGreetings greetings, IConfiguration configuration)
        {
            _configuration = configuration;
            _greetings = greetings;
        }
        [FunctionName("SeasonHttpFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var responseMessage = "";

            // Dependecy injection of file
            var mySeason = _greetings.GetSeason(DateTime.Now);

            // Dependecy injection configuration - retrieve value from config file
            var desiredSeasonDate = DateTime.Parse(_configuration["WINTER"]);

            var desiredSeason = _greetings.GetSeason(desiredSeasonDate);


            responseMessage = mySeason + ". My desired season greetings is: "+ desiredSeason.Substring(0, desiredSeason.Length - 3);

            return new OkObjectResult(responseMessage);
        }
    }
}

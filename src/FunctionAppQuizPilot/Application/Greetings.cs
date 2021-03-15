using FunctionAppQuizModel.Models;
using System;

namespace FunctionAppQuizModel.Application
{
    public class Greetings : IGreetings
    {
        /// <summary>
        /// Get desired season
        /// </summary>
        /// <returns></returns>
        public string GetSeason(DateTime currentDate)
        {
            if (currentDate.Month < 6 && currentDate.Month > 0)
            {
                return "Spring greets you :-)";
            }
            else if (currentDate.Month > 6 && currentDate.Month < 9)
            {
                return "Summer greets you :-)";
            }
            else if (currentDate.Month > 9 && currentDate.Month <= 12)
            {
                return "Winter greets you :-)";
            }

            return "No season found";
        }
    }
}
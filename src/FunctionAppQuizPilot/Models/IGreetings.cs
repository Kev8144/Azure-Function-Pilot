using System;

namespace FunctionAppQuizModel.Models
{
    public interface IGreetings
    {
        string GetSeason(DateTime dateTime);
    }
}
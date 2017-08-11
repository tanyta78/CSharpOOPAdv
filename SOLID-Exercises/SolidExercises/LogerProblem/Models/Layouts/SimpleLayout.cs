using LoggerProblem.Interfaces;

namespace LoggerProblem.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string timeStamp, string reportLevel, string message)
        {
            return $"{timeStamp}-{reportLevel}-{message}";
        }
    }
}
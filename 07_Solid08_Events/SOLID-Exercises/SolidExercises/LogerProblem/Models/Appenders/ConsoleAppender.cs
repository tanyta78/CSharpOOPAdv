using LoggerProblem.Interfaces;
using System;

namespace LoggerProblem.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string timeStamp, string reportLevel, string message)
        {
            this.Count++;
            string formatted = this.Layout.FormatMessage(timeStamp, reportLevel, message);
            Console.WriteLine(formatted);
        }
    }
}
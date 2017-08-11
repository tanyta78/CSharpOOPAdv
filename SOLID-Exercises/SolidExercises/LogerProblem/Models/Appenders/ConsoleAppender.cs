using System;
using LoggerProblem.Enums;
using LoggerProblem.Interfaces;

namespace LoggerProblem.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }


        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        public void Append(string timeStamp, string reportLevel, string message)
        {
            string formatted = this.Layout.FormatMessage(timeStamp,reportLevel,message);
            Console.WriteLine(formatted);
        }
    }
}
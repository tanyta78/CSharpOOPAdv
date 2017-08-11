using LoggerProblem.Enums;
using LoggerProblem.Interfaces;

namespace LoggerProblem.Models.Appenders
{
    public class FileAppender:IAppender
    {
        private ILayout layout;

        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        public LogFile File { get; set; }

        public void Append(string timeStamp, string reportLevel, string message)
        {
            string formatted = this.Layout.FormatMessage(timeStamp, reportLevel, message);
            this.File.Write(formatted);
        }
    }
}
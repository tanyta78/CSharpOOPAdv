using LoggerProblem.Interfaces;

namespace LoggerProblem.Models.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout) : base(layout)
        {
            this.File = new LogFile();
        }

        public LogFile File { get; set; }

        public override void Append(string timeStamp, string reportLevel, string message)
        {
            this.Count++;
            string formatted = this.Layout.FormatMessage(timeStamp, reportLevel, message);
            this.File.Write(formatted);
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
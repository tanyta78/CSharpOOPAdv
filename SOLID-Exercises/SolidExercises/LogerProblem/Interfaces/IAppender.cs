using LoggerProblem.Enums;

namespace LoggerProblem.Interfaces
{
    public interface IAppender
    {
        int Count { get; }

        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string timeStamp, string reportLevel, string message);
    }
}
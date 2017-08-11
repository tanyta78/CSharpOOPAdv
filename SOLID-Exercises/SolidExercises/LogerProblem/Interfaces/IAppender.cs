using LoggerProblem.Enums;

namespace LoggerProblem.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; }

        void Append(string timeStamp, string reportLevel, string message);
    }
}
using LoggerProblem.Interfaces;
using System.Text;

namespace LoggerProblem.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public string FormatMessage(string timeStamp, string reportLevel, string message)
        {
            StringBuilder sb = new StringBuilder();

            return sb.AppendLine($"<log>")
                .AppendLine($"  <date>{timeStamp}</date>")
                .AppendLine($"  <level>{reportLevel}</level>")
                .AppendLine($"  <message>{message}</message>")
                .Append($"</log>")
                .ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerProblem.Interfaces;

namespace LoggerProblem.Models.Layouts
{
   public class XmlLayout:ILayout
    {
        public string FormatMessage(string timeStamp, string reportLevel, string message)
        {
            StringBuilder sb=new StringBuilder();

            return sb.AppendLine($"<log>")
                .AppendLine($"  <date>{timeStamp}</date>")
                .AppendLine($"  <level>{reportLevel}</level>")
                .AppendLine($"  <message>{message}</message>")
                .Append($"</log>")
                .ToString();
        }
    }
}

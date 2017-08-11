using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerProblem.Models
{
    public class LogFile
    {
        private const string DefaultFileName = "log.txt";

        private StringBuilder sb;


        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size{ get;private set; }

        private int GetLettersSum(string formated)
        {
            return formated
                .Where(c => char.IsLetter(c))
                .Sum(c => c);
        }

        public void Write(string formatted)
        {
            this.sb.AppendLine(formatted);
            File.AppendAllText(DefaultFileName,formatted+Environment.NewLine);
            this.Size = this.GetLettersSum(formatted);
        }
    }
}
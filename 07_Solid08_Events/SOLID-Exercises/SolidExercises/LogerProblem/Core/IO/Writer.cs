using LoggerProblem.Interfaces;
using System;

namespace LoggerProblem.Core.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
    }
}
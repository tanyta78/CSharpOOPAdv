using LoggerProblem.Interfaces;
using System;

namespace LoggerProblem.Core.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
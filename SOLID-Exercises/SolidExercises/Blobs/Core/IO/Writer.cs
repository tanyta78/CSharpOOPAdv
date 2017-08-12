using Blobs.Interfaces;
using System;

namespace Blobs.Core.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
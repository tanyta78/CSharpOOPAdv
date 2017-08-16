namespace RecyclingStation.BusinestLayer.IO
{
    using System;
    using RecyclingStation.BusinestLayer.Contracts.IO;

   public class ConsoleReader:IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

namespace ListProcessingProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO;

    public class StartUp
    {
       public static void Main(string[] args)
        {
            OutputWriter.WriteMessageOnNewLine("Hello user! Please input your list of string for processing!");
            List<string> listStrings = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            CommandInterpreter currentInterpreter = new CommandInterpreter(listStrings);
            InputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}

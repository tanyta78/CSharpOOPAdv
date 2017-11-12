namespace ListProcessingProject.IO
{
    using System;

   public class InputReader
    {
        private CommandInterpreter interpreter;
        private const string endCommand = "end";

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            //read string array
            OutputWriter.WriteMessageOnNewLine("Please write your command for list processing!");

            string input = Console.ReadLine().Trim();

            while (input != endCommand)
            {
                this.interpreter.InterpredCommand(input);
                OutputWriter.WriteMessage("To finish write end!!!");
                OutputWriter.WriteMessageOnNewLine("Please write your command for list processing!");
               
                input = Console.ReadLine().Trim();
            }

            OutputWriter.WriteMessage($"Finished");

        }
    }
}


namespace ListProcessingProject.Models
{
    using System.Collections.Generic;
    using Exceptions;
    using IO;

    public class SortCommand:Command
    {
        public SortCommand(List<string> input, string[] cmdData) : base(input, cmdData)
        {
        }

        public override void Execute()
        {
            if (this.CmdData.Length != 1)
            {
                throw new InvalidCommandParametersException();
            }

            this.Input.Sort();

            OutputWriter.WriteMessageOnNewLine(string.Join(" ", this.Input));
        }
    }
}

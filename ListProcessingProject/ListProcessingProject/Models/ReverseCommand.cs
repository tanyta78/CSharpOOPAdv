namespace ListProcessingProject.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using IO;

    public class ReverseCommand:Command
    {
        public ReverseCommand(List<string> input, string[] cmdData) : base(input, cmdData)
        {
        }

        public override void Execute()
        {
            if (this.CmdData.Length != 1)
            {
                throw new InvalidCommandParametersException();
            }

            this.Input.Reverse();

            OutputWriter.WriteMessageOnNewLine(string.Join(" ",this.Input));
        }
    }
}

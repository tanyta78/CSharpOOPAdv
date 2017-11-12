namespace ListProcessingProject.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using IO;

    class RollLeftCommand : Command
    {
        public RollLeftCommand(List<string> input, string[] cmdData) : base(input, cmdData)
        {
        }

        public override void Execute()
        {
            if (this.CmdData.Length != 1)
            {
                throw new InvalidCommandParametersException();
            }
            this.Input.Add(this.Input[0]);
            this.Input.RemoveAt(0);


            OutputWriter.WriteMessageOnNewLine(string.Join(" ", this.Input));
        }
    }
}

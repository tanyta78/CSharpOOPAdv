namespace ListProcessingProject.Models
{
    using System.Collections.Generic;
    using Exceptions;
    using IO;

    public class PrependCommand:Command
    {
        public PrependCommand(List<string> input, string[] cmdData) : base(input, cmdData)
        {
        }

        public override void Execute()
        {
            if (this.CmdData.Length != 2)
            {
                throw new InvalidCommandParametersException();
            }

            var strToPrepend = this.CmdData[1];
            this.Input.Insert(0, strToPrepend);

            OutputWriter.WriteMessageOnNewLine(string.Join(" ", this.Input));
        }
        
    }
}

namespace ListProcessingProject.Models
{
    using System.Collections.Generic;
    using Exceptions;
    using IO;

   public class AppendCommand : Command
    {
        public AppendCommand(List<string> input, string[] cmdData) : base(input, cmdData)
        {
        }

        public override void Execute()
        {
            if (this.CmdData.Length != 2)
            {
                
                throw new InvalidCommandParametersException();
            }

            var strToAppend = this.CmdData[1];
            this.Input.Add(strToAppend);
            OutputWriter.WriteMessageOnNewLine(string.Join(" ", this.Input));
        }


    }
}

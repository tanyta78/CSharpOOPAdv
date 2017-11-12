namespace ListProcessingProject.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using IO;

    public class CountCommand : Command
    {
        public CountCommand(List<string> input, string[] cmdData) : base(input, cmdData)
        {
        }

        public override void Execute()
        {
            if (this.CmdData.Length != 2)
            {
                throw new InvalidCommandParametersException();
            }

            var strToCount = this.CmdData[1];
            var result = this.Input.Count(e => e.Equals(strToCount));

            OutputWriter.WriteMessageOnNewLine(result.ToString());
        }
    }
}

namespace ListProcessingProject.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using IO;

    public class RollRightCommand:Command
    {
        public RollRightCommand(List<string> input, string[] cmdData) : base(input, cmdData)
        {
        }

        public override void Execute()
        {
            if (this.CmdData.Length != 1)
            {
                throw new InvalidCommandParametersException();
            }
            this.Input.Insert(0,this.Input[this.Input.Count - 1]);
            this.Input.RemoveAt(this.Input.Count-1);
            
            OutputWriter.WriteMessageOnNewLine(string.Join(" ", this.Input));
        }
    }
}

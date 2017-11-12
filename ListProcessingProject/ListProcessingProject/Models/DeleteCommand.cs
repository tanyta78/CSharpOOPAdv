namespace ListProcessingProject.Models
{
    using System.Collections.Generic;
    using Exceptions;
    using IO;

    public class DeleteCommand : Command
    {
        public DeleteCommand(List<string> input, string[] cmdData) : base(input, cmdData)
        {
        }

        public override void Execute()
        {
            if (this.CmdData.Length != 2)
            {
                throw new InvalidCommandParametersException();
            }

            var indexToDelete = int.Parse(this.CmdData[1]);

            if (indexToDelete < 0 || indexToDelete >= this.CmdData.Length)
            {
                throw new InvalidIndexException();
            }


            this.Input.RemoveAt(indexToDelete);

            OutputWriter.WriteMessageOnNewLine(string.Join(" ", this.Input));


        }
    }
}

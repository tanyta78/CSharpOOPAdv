namespace ListProcessingProject.Models
{
    using System.Collections.Generic;
    using Exceptions;
    using IO;

    public class InsertCommand:Command
    {
        public InsertCommand(List<string> input, string[] cmdData) : base(input, cmdData)
        {
        }

        public override void Execute()
        {
            if (this.CmdData.Length != 3)
            {
                throw new InvalidCommandParametersException();
            }

            var indexToInsert = int.Parse(this.CmdData[1]);
            var stringToInsert = this.CmdData[2];

            if (indexToInsert < 0 || indexToInsert >= this.CmdData.Length)
            {
                throw new InvalidIndexException();
            }
            else
            {
                this.Input.Insert(indexToInsert,stringToInsert);

                OutputWriter.WriteMessageOnNewLine(string.Join(" ", this.Input));
            }
        }
    }
}

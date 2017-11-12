namespace ListProcessingProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public abstract class Command
    {
        private List<string> input;
        private string[] cmdData;

        public Command(List<string> input, string[] cmdData)
        {
            this.Input = input;
            this.CmdData = cmdData;
        }


        public List<string> Input
        {
            get { return this.input; }
           set
            {
                if (value == null || value.Count == 0)
                {
                    throw new InvalidDataException();
                }
                this.input = value;
            }
        }

        public string[] CmdData
        {
            get { return this.cmdData; }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    //to do - change type of exception when created
                    throw new NullReferenceException();
                }
                this.cmdData = value;
            }
        }

        public abstract void Execute();
    }
}

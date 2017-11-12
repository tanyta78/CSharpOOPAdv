namespace ListProcessingProject.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Exceptions;
    using Models;

    public class CommandInterpreter
    {
        private List<string> list;

        public CommandInterpreter(List<string> list)
        {
            this.List = list;
        }

        public List<string> List
        {
            get { return this.list; }
            set { this.list = value; }
        }

        public void InterpredCommand(string input)
        {
            string[] cmdData = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = cmdData[0];

            try
            {
                Command cmd = this.ParseCommand(this.list, commandName, cmdData);
                cmd.Execute();
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private Command ParseCommand(List<string> listForManipulation, string command, string[] cmdData)
        {

            switch (command)
            {
                case "append": return new AppendCommand(listForManipulation, cmdData);
                case "prepend": return new PrependCommand(listForManipulation, cmdData);
                case "reverse": return new ReverseCommand(listForManipulation, cmdData);
                case "insert": return new InsertCommand(listForManipulation, cmdData);
                case "delete": return new DeleteCommand(listForManipulation, cmdData);
                case "rollleft": return new RollLeftCommand(listForManipulation, cmdData);
                case "rollright": return new RollRightCommand(listForManipulation, cmdData);
                case "sort":
                    return new SortCommand(listForManipulation,
           cmdData);
                case "count":
                    return new CountCommand(listForManipulation,
                        cmdData);
                // case "end":
                //  return new EndCommand(listForManipulation,
                // cmdData);
                default:

                    throw new InvalidCommandException();


            }

        }
    }
}

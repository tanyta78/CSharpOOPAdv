namespace ListProcessingProject.Exceptions
{
    using System;

    public class InvalidCommandException:Exception
    {
        private const string InvalidCommandName = "Error: invalid command";

        public InvalidCommandException(string message) : base(message)
        {
        }

        public InvalidCommandException() : base(InvalidCommandName)
        {
        }
    }
}

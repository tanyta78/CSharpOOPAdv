namespace ListProcessingProject.Exceptions
{
    using System;
    
   public class InvalidCommandParametersException:Exception
    {
        private const string InvalidCommandParameters = "Error: invalid command parameters";

        public InvalidCommandParametersException(string message) : base(message)
        {
        }

        public InvalidCommandParametersException() : base(InvalidCommandParameters)
        {
        }
    }
}

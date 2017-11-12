namespace ListProcessingProject.Exceptions
{
    using System;

    public class InvalidIndexException:Exception
   {
        private const string InvalidIndex = "Error: invalid index";

        public InvalidIndexException(string index) : base(index)
        {
            
        }

        public InvalidIndexException() : base(InvalidIndex)
        {
        }
    }
}

namespace SOLID.Contracts.Core
    {
   public interface ICommandInterpreter
   {
        IExecutable InterpretCommand(string[] data, string commandName);
   }
}

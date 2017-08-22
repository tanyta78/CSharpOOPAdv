namespace SOLID.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using SOLID.Contracts.Core;
    using SOLID.Contracts.Data;

    public class CommandInterpreter:ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        private IUnitFactory unitFactory;
        private IRepository repository;

        public CommandInterpreter(IUnitFactory unitFactory, IRepository repository)
        {
            this.unitFactory = unitFactory;
            this.repository = repository;
        }


        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string commandCompleteName =
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;

            Type commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandCompleteName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            object[] commandParams =
            {
                data,
                this.repository,
                this.unitFactory
            };
            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, commandParams);

            /*ако не знаем параметрите на командата е по добре да се направи  
            IExecutable commands = (IExecutable)Activator.CreateInstance(commandType, new object[]{data});
            FieldInfo[] fieldsOfCommand = commands.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .ToArray();
            FieldInfo[] fieldsOfInterpreter =
                typeof(CommandInterpreter).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand)
            {
                if (fieldsOfInterpreter.Any(f=>f.FieldType==field.FieldType))
                {
                    field.SetValue(commands,fieldsOfInterpreter.First(f=>f.FieldType==field.FieldType).GetValue(this));
                }
            }
            */

            return command;
        }
    }
}

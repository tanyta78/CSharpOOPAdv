namespace _03BarracksFactory.Core
{
    using Attributes;
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IUnitFactory unitFactory;
        private IRepository repository;

        public CommandInterpreter(IUnitFactory unitFactory, IRepository repository)
        {
            this.unitFactory = unitFactory;
            this.repository = repository;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Type commandType = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower().StartsWith(commandName) && t.Name.ToLower().EndsWith("command"));

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            FieldInfo[] commandFields = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
                .ToArray();

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });
            command = this.InjectDependencies(command);

            return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            FieldInfo[] fieldsOfCommand = command.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
                .ToArray();

            FieldInfo[] fieldsOFInterpreter = typeof(CommandInterpreter)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand)
            {
                if (fieldsOFInterpreter.Any(f => f.FieldType == field.FieldType))
                {
                    field.SetValue(command,
                        fieldsOFInterpreter.First(f => f.FieldType == field.FieldType).GetValue(this));
                }
            }

            return command;
        }
    }
}
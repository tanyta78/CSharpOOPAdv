using _03BarracksFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IUnitFactory unitFactory;
        private IRepository repository;

        public CommandInterpreter(IUnitFactory unitFactory, IRepository repository)
        {
            this.UnitFactory = unitFactory;
            this.Repository = repository;
        }

        public IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            set { unitFactory = value; }
        }

        public IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
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

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });

            FieldInfo[] fieldsOfCommand = command.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
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
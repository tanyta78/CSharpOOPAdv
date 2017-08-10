using _03BarracksFactory.Contracts;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using DependenceInjection.Attributes;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
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
                .FirstOrDefault(t => t.Name==commandCompleteName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            object[] commandParams =
            {
                data
            };

            IExecutable command = (IExecutable) Activator.CreateInstance(commandType, commandParams);

            command = this.InjectDependencies(command);
            
           return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            FieldInfo[] commandFields = command.GetType()
                .GetFields(BindingFlags.Instance|BindingFlags.NonPublic)
                .Where(f=>f.GetCustomAttributes<InjectAttribute>() !=null)
                .ToArray();

            FieldInfo[] interpreterFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var commandField in commandFields)
            {
                commandField.SetValue(command,
                    interpreterFields
                    .First(f=>f.FieldType==commandField.FieldType)
                    .GetValue(this));
            }

            return command;
        }
    }
}
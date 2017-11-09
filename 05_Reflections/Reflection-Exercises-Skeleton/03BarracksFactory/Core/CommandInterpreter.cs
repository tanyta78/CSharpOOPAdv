using _03BarracksFactory.Contracts;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

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
                data,
                this.repository,
                this.unitFactory
            };

            IExecutable command = (IExecutable) Activator.CreateInstance(commandType, commandParams);

           return command;
        }
    }
}
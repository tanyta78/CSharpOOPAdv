using System.Linq;

namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;

    internal class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    data = data.Skip(1).ToArray();
                    IExecutable command = this.commandInterpreter.InterpretCommand(data, commandName);

                    Console.WriteLine(command.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
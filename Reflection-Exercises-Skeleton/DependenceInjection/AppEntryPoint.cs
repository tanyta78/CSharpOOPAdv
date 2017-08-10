using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core;
using _03BarracksFactory.Core.Factories;
using _03BarracksFactory.Data;

namespace DependenceInjection
{
   internal class AppEntryPoint
    {
        private static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(unitFactory, repository);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    using SOLID.Contracts.Core;
    using SOLID.Contracts.Data;
    using SOLID.Core;
    using SOLID.Core.Factories;
    using SOLID.Data;

    public class StartUp
    {
        static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(unitFactory, repository);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();

        }
    }
}

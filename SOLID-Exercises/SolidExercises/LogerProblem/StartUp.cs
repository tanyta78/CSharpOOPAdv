using LoggerProblem.Core;
using LoggerProblem.Core.IO;
using LoggerProblem.Factories;
using LoggerProblem.Interfaces;

namespace LoggerProblem
{
    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            Controller controller = new Controller(layoutFactory, appenderFactory);
            Engine engine = new Engine(reader, writer, controller);

            engine.Run();
        }
    }
}
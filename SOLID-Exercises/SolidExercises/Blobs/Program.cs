using Blobs.Core;
using Blobs.Core.IO;
using Blobs.Interfaces;

namespace Blobs
{
    public class Program
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            GameActionsExecutor gameActionsExecutor = new GameActionsExecutor();

            Engine engine = new Engine(reader, writer, gameActionsExecutor);
            engine.Run();
        }
    }
}
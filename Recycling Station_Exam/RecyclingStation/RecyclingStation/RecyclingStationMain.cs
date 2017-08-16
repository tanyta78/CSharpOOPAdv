namespace RecyclingStation
{
    using RecyclingStation.BusinestLayer.Contracts.Core;
    using RecyclingStation.BusinestLayer.Contracts.IO;
    using RecyclingStation.BusinestLayer.Core;
    using RecyclingStation.BusinestLayer.IO;

    public class RecyclingStationMain
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();

            IWriter writer=new ConsoleWriter();

            IRecyclingManager recyclingManager = new RecyclingManager();

            IEngine engine = new Engine(reader,writer,recyclingManager);

            engine.Run();
        }
    }
}

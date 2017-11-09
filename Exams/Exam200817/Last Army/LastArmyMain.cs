using System.Runtime.InteropServices;

public class LastArmyMain
{
    public static void Main()
    {
        /* var input = ConsoleReader.ReadLine();
         var gameController = new GameController();
         var result = new StringBuilder();

         while (!input.Equals("Enough! Pull back!"))
         {
             try
             {
                 gameController.GiveInputToGameController(input);
             }
             catch (ArgumentException arg)
             {
                 result.AppendLine(arg.Message);
             }
             input = ConsoleReader.ReadLine();
         }

         gameController.RequestResult(result);
         ConsoleWriter.WriteLine(result.ToString());*/
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        //IStrategyHolder strategyHolder = new StrategyHolder(new Dictionary<Type, IGarbageDisposalStrategy>());

        //IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);
        //IWasteFactory wasteFactory = new WasteFactory();
        //IRecyclingManager recyclingManager = new RecyclingManager(garbageProcessor, wasteFactory);

        IEngine engine = new Engine(reader, writer);

        engine.Run();

        
    }
}

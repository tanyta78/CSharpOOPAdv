namespace RecyclingStation
{
    using System;
    using System.Collections.Generic;
    using RecyclingStation.BusinestLayer.Contracts.Core;
    using RecyclingStation.BusinestLayer.Contracts.Factories;
    using RecyclingStation.BusinestLayer.Contracts.IO;
    using RecyclingStation.BusinestLayer.Core;
    using RecyclingStation.BusinestLayer.Factories;
    using RecyclingStation.BusinestLayer.IO;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class RecyclingStationMain
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer=new ConsoleWriter();

            IStrategyHolder strategyHolder = new StrategyHolder(new Dictionary<Type, IGarbageDisposalStrategy>());

            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);
            IWasteFactory wasteFactory = new WasteFactory();
            IRecyclingManager recyclingManager = new RecyclingManager(garbageProcessor,wasteFactory);

            IEngine engine = new Engine(reader,writer,recyclingManager);

            engine.Run();
        }
    }
}

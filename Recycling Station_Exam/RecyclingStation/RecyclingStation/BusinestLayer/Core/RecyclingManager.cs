namespace RecyclingStation.BusinestLayer.Core
{
    using RecyclingStation.BusinestLayer.Contracts.Core;
    using RecyclingStation.BusinestLayer.Contracts.Factories;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class RecyclingManager:IRecyclingManager
    {
        private const string ProcessGarbageMessageToFormat = "{0} kg of {1} successfully processed!";
        private const string StatusMessageToFormat = "Energy: {0} Capital: {1}";
        private const string FloatingPointNumberFormat = "f2";

        private IGarbageProcessor garbageProcessor;
        private IWasteFactory wasteFactory;

        private double capitalBalance;
        private double energyBalance;

        public RecyclingManager(IGarbageProcessor garbageProcessor, IWasteFactory wasteFactory)
        {
            this.garbageProcessor = garbageProcessor;
            this.wasteFactory = wasteFactory;
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {

            IWaste someWaste = this.wasteFactory.Create(name,weight,volumePerKg,type);

            IProcessingData processedData = this.garbageProcessor.ProcessWaste(someWaste);

            this.capitalBalance += processedData.CapitalBalance;
            this.energyBalance += processedData.EnergyBalance;

            string formattedMessage = string.Format(ProcessGarbageMessageToFormat, someWaste.Weight.ToString(FloatingPointNumberFormat), someWaste.Name);

            return formattedMessage;
            // return $"{someWaste.Weight} kg of {someWaste.Name} successfully processed!";
        }

       public string Status()
       {
           string formattedMessage = string.Format(StatusMessageToFormat, this.energyBalance.ToString(FloatingPointNumberFormat), this.capitalBalance.ToString(FloatingPointNumberFormat));

           return formattedMessage;
           //  return $"Energy: {this.energyBalance:f2} Capital: {this.capitalBalance:f2}";
       }
    }
}

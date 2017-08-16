namespace RecyclingStation.BusinestLayer.Strategies
{
    using RecyclingStation.BusinestLayer.Data;
    using RecyclingStation.WasteDisposal.Interfaces;

   public abstract class GarbageDisposalStrategy:IGarbageDisposalStrategy
   {
       protected abstract double CalculateEnergyBalance(IWaste garbage);

       protected abstract double CalculateCapitalBalance(IWaste garbage);

        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            double energyBalance=this.CalculateEnergyBalance(garbage);
            double capitalBalance=this.CalculateCapitalBalance(garbage);

            return new ProcesingData(energyBalance,capitalBalance);
        }
    }
}

namespace RecyclingStation.BusinestLayer.Strategies
{
   using RecyclingStation.WasteDisposal.Interfaces;

    public class RecycableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            double energyProduced = 0;
            double energyUsed = garbage.CalculateWasteTotalVolume() * 0.5;

            return energyProduced-energyUsed;
        }

        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            double capitalEarned = garbage.Weight * 400;
            double capitalUsed = 0;

            return capitalEarned-capitalUsed;
        }
    }
}

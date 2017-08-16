namespace RecyclingStation.BusinestLayer.Strategies
{
    using RecyclingStation.WasteDisposal.Interfaces;

    class BurnableGarbageDisposalStrategy:GarbageDisposalStrategy
    {
        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            double energyProduced = garbage.CalculateWasteTotalVolume() ;
            double energyUsed = garbage.CalculateWasteTotalVolume() * 0.2;

            return energyProduced - energyUsed;
        }

        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            double capitalEarned = 0;
            double capitalUsed = 0;

            return capitalEarned - capitalUsed;
        }
    }
}

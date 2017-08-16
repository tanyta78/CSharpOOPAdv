﻿namespace RecyclingStation.BusinestLayer.Entities.Garbages
{
    using RecyclingStation.BusinestLayer.Attributes;
    using RecyclingStation.BusinestLayer.Strategies;

   [BurnableStrategy(typeof(BurnableGarbageDisposalStrategy))]
   public class BurnableGarbage:Garbage
    {
        public BurnableGarbage(string name, double volumePerKg, double weight) : base(name, volumePerKg, weight)
        {
        }
    }
}

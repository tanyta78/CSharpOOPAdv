namespace RecyclingStation.BusinestLayer.Entities.Garbages
{
    using RecyclingStation.BusinestLayer.Attributes;
    using RecyclingStation.BusinestLayer.Strategies;
   
    [StorableStrategy(typeof(StorableGarbageDisposalStrategy))]
    public  class StorableGarbage:Garbage
    {
        public StorableGarbage(string name, double volumePerKg, double weight) : base(name, volumePerKg, weight)
        {
        }
    }
}

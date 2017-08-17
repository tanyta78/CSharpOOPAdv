namespace RecyclingStation.BusinestLayer.Entities.Garbages
{
    using RecyclingStation.BusinestLayer.Attributes;
    using RecyclingStation.BusinestLayer.Strategies;

    [RecyclableStrategy(typeof(RecycableGarbageDisposalStrategy))]
    public class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double volumePerKg, double weight) : base(name, volumePerKg, weight)
        {
        }
    }
}
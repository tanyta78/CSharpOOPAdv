public class NightVision : Ammunition
{
    private const double NightVisionWeight = 0.8;

    public NightVision(string name)
        : base(name)
    {
        this.Weight = NightVisionWeight;
        this.WearLevel = Weight * 100;
    }
}
public class Helmet : Ammunition
{
    private const double HelmetWeight = 2.3;

    public Helmet(string name)
        : base(name)
    {
        this.Weight = HelmetWeight;
        this.WearLevel = Weight * 100;
    }
}
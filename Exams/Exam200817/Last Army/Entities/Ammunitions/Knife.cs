public class Knife : Ammunition
{
    private const double KnifeWeight = 0.4;

    public Knife(string name)
        : base(name)
    {
        this.Weight = KnifeWeight;
        this.WearLevel = Weight * 100;
    }
}
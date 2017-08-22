public class Gun : Ammunition
{
    protected const double GunWeight = 1.4;

    public Gun(string name)
        : base(name)
    {
        this.Weight = GunWeight;
        this.WearLevel = Weight * 100;


    }
}
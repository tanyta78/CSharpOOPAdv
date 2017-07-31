public abstract class Gem
{
    public Clarity clarity;

    protected Gem(Clarity clarity, int strength, int agility, int vitality)
    {
        this.clarity = clarity;
        this.Strength = strength;
        this.Agility = agility;
        this.Vitality = vitality;
        this.SetClarity();
    }

    private void SetClarity()
    {
        var statClarity = (int)clarity;
        this.Strength += statClarity;
        this.Agility += statClarity;
        this.Vitality += statClarity;
    }

    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Vitality { get; set; }
}
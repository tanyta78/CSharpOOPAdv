public class Amethyst : Gem
{
    private const int Strength = 2;
    private const int Agility = 8;
    private const int Vitality = 4;

    public Amethyst(Clarity clarity) : base(clarity, Strength, Agility, Vitality)
    {
    }
}
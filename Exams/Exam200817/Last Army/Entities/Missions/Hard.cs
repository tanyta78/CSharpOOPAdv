public class Hard : Mission
{
    private const double enduranceRequired = 80;
    private const double wearLevelDecrementHard = 70;
    private const string nameHard = "Disposal of terrorists";

    public Hard( double scoreToComplete) : base(nameHard, enduranceRequired, scoreToComplete, wearLevelDecrementHard)
    {
    }
}


public class Medium : Mission
{
    private const double enduranceRequired = 50;
    private const double wearLevelDecrementMedium = 50;
    private const string nameMedium = "Capturing dangerous criminals";


    public Medium( double scoreToComplete) : base(nameMedium, enduranceRequired, scoreToComplete, wearLevelDecrementMedium)
    {
    }
}


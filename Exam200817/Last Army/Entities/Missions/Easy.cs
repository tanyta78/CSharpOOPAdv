public class Easy : Mission
{
    private const double enduranceRequired = 20;
    private const double wearLevelDecrementEasy = 30;
    private const string nameEasy = "Suppression of civil rebellion";

    public Easy(double scoreToComplete) : base(nameEasy, enduranceRequired, scoreToComplete, wearLevelDecrementEasy)
    {
    }
}


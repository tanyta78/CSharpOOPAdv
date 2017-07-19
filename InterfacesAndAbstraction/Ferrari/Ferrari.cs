public class Ferrari : ICar
{
    public Ferrari(string driver)
    {
        Model = "488-Spider";
        Driver = driver;
    }

    public string Model { get; }
    public string Driver { get; }

    public string PushDownBrakes()
    {
        return "Brakes!";
    }

    public string PushDownGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.PushDownBrakes()}/{this.PushDownGasPedal()}/{this.Driver}";
    }
}
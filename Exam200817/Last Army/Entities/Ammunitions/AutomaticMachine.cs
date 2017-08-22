public class AutomaticMachine : Ammunition
{
    private const double AutomaticMachineWeight = 6.3;

    public AutomaticMachine(string name)
        : base(name)
    {
        this.Weight = AutomaticMachineWeight;
        this.WearLevel = Weight * 100;
    }
}
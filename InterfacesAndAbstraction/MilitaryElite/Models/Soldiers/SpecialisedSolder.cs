using System.Text;

public abstract class SpecialisedSolder : Private, ISpecialisedSoldier
{
    public string Corps { get; private set; }

    public SpecialisedSolder(string id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{base.ToString()}");
        sb.AppendLine($"Corps: {this.Corps}");

        return sb.ToString().Trim();
    }
}
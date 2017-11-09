using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSolder, IEngineer
{
    public IList<IRepair> Repairs { get; }

    public Engineer(string id, string firstName, string lastName, double salary, string corps, IList<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
    {
        Repairs = repairs;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{base.ToString()}");
        sb.AppendLine($"Repairs:");
        foreach (Repair repair in this.Repairs)
        {
            sb.AppendLine(repair.ToString());
        }

        return sb.ToString().Trim();
    }
}
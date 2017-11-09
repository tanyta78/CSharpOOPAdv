using System.Text;

public class Repair : IRepair
{
    public Repair(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    public string PartName { get; }
    public int HoursWorked { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"  Part Name: {PartName} Hours Worked: {HoursWorked}");

        return sb.ToString().Trim();
    }
}
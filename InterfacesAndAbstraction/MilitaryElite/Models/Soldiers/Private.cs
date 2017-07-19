using System.Text;

public class Private : Soldier, IPrivate
{
    public double Salary { get; private set; }

    public Private(string id, string firstName, string lastName, double salary) : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{base.ToString()} Salary: {this.Salary:f2}");

        return sb.ToString().Trim();
    }
}
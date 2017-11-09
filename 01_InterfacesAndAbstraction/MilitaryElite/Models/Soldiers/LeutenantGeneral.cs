using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public IList<ISoldier> Privates { get; }

    public LeutenantGeneral(string id, string firstName, string lastName, double salary, IList<ISoldier> soldiers) : base(id, firstName, lastName, salary)
    {
        Privates = soldiers;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{base.ToString()}");
        sb.AppendLine("Privates:");
        foreach (Private @private in this.Privates)
        {
            sb.AppendLine(@private.ToString());
        }

        return sb.ToString().Trim();
    }
}
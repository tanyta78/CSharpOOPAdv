using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSolder, ICommando
{
    public Commando(string id, string firstName, string lastName, double salary, string corps, IList<IMission> missions) : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }

    public IList<IMission> Missions { get; private set; }

    public void CompleteMission()
    {
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{base.ToString()}");
        sb.AppendLine($"Missions:");
        foreach (Mission mission in this.Missions)
        {
            sb.AppendLine(mission.ToString());
        }

        return sb.ToString().Trim();
    }
}
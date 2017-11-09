using System.Collections.Generic;

public class Army : IArmy
{
    public Army()
    {
        this.Soldiers = new List<ISoldier>();
    }

    public IReadOnlyList<ISoldier> Soldiers { get; }

    public void AddSoldier(ISoldier soldier)
    {
    }

    public void RegenerateTeam(string soldierType)
    {
    }
}
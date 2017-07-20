using System;
using System.Collections.Generic;
using System.Linq;

public class SoldierCreator
{
    private static List<ISoldier> soldiers;

    public SoldierCreator()
    {
        this.Soldiers = new List<ISoldier>();
    }

    public List<ISoldier> Soldiers
    {
        get { return soldiers; }
        set { soldiers = value; }
    }

    public Private CreatePrivate(List<string> cmdArgs)
    {
        var id = cmdArgs[0];
        var firstName = cmdArgs[1];
        var lastName = cmdArgs[2];
        var salary = double.Parse(cmdArgs[3]);
        var soldier = new Private(id, firstName, lastName, salary);

        return soldier;
    }

    public Spy CreateSpy(List<string> cmdArgs)
    {
        var id = cmdArgs[0];
        var firstName = cmdArgs[1];
        var lastName = cmdArgs[2];
        var codeNumber = int.Parse(cmdArgs[3]);
        var soldier = new Spy(id, firstName, lastName, codeNumber);

        return soldier;
    }

    public LeutenantGeneral CreateGeneral(List<string> cmdArgs)
    {
        var id = cmdArgs[0];
        var firstName = cmdArgs[1];
        var lastName = cmdArgs[2];
        var salary = double.Parse(cmdArgs[3]);
        var privates = ExtractPrivates(cmdArgs.Skip(4).ToList());

        var soldier = new LeutenantGeneral(id, firstName, lastName, salary, privates);

        return soldier;
    }

    private static IList<ISoldier> ExtractPrivates(List<string>privates)
    {
        var list = new List<ISoldier>();

        foreach (var soldier in privates)
        {
            list.Add(soldiers.First(s => s.ID == soldier));
        }

        return list;
    }

    public Engineer CreateEngineer(List<string> cmdArgs)
    {
        var id = cmdArgs[0];
        var firstName = cmdArgs[1];
        var lastName = cmdArgs[2];
        var salary = double.Parse(cmdArgs[3]);
        var corps = cmdArgs[4];
        var repairs = new List<IRepair>();

        for (int i = 5; i < cmdArgs.Count - 1; i += 2)
        {
            var partName = cmdArgs[i];
            var hours = int.Parse(cmdArgs[i + 1]);
            repairs.Add(new Repair(partName, hours));
        }
        var soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);

        return soldier;
    }

    public Commando CreateCommando(List<string> cmdArgs)
    {
        var id = cmdArgs[0];
        var firstName = cmdArgs[1];
        var lastName = cmdArgs[2];
        var salary = double.Parse(cmdArgs[3]);
        var corps = cmdArgs[4];
        var missions = new List<IMission>();

        for (int i = 5; i < cmdArgs.Count - 1; i += 2)
        {
            var codeName = cmdArgs[i];
            var state = cmdArgs[i + 1];
            if (state == "inProgress" || state == "Finished")
            {
                missions.Add(new Mission(codeName, state));
            }
        }
        var soldier = new Commando(id, firstName, lastName, salary, corps, missions);

        return soldier;
    }
}
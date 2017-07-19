using System;
using System.Linq;

public class Engine
{
    private SoldierCreator creator;

    public Engine()
    {
        this.Creator = new SoldierCreator();
    }

    public SoldierCreator Creator
    {
        get { return creator; }
        set { creator = value; }
    }

    public void Start()
    {
        var commandLine = Console.ReadLine().Split();

        while (commandLine[0] != "End")
        {
            var command = commandLine[0];
            var cmdArgs = commandLine.Skip(1).ToList();
            switch (command)
            {
                case "Private":
                    Soldier soldierPrivate = this.Creator.CreatePrivate(cmdArgs);
                    this.Creator.Soldiers.Add(soldierPrivate);
                    break;

                case "LeutenantGeneral":
                    Soldier soldierGeneral = this.Creator.CreateGeneral(cmdArgs);
                    this.Creator.Soldiers.Add(soldierGeneral);
                    break;

                case "Engineer":
                    if (cmdArgs[4] == "Airforces" || cmdArgs[4] == "Marines")
                    {
                        Soldier soldierEngineer = this.Creator.CreateEngineer(cmdArgs);
                        this.Creator.Soldiers.Add(soldierEngineer);
                    }
                    break;

                case "Commando":
                    if (cmdArgs[4] == "Airforces" || cmdArgs[4] == "Marines")
                    {
                        Soldier soldierCommando = this.Creator.CreateCommando(cmdArgs);
                        this.Creator.Soldiers.Add(soldierCommando);
                    }
                    break;
            }

            commandLine = Console.ReadLine().Split();
        }
    }
}
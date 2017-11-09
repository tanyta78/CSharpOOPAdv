using System;

public class Engine : IEngine
{
    private const string TerminatingCommand = "Enough! Pull back!";

    private IReader reader;
    private IWriter writer;

    private MissionController missionControllerField;
    private IWareHouse wareHouse;
    private IArmy army;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        this.WareHouse = new WareHouse();
        this.army = new Army();
        this.missionControllerField = new MissionController(this.army, this.WareHouse);
    }

    public IWareHouse WareHouse
    {
        get { return this.wareHouse; }
        set { this.wareHouse = value; }
    }

    public void Run()
    {
        string inputLine;

        while ((inputLine = this.reader.ReadLine()) != TerminatingCommand)
        {
            string[] cmdArgs = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (cmdArgs[0])
            {
                case "Soldier":
                    //to do soldier Soldier Ranker Ivan 28 55 100
                   
                    if (cmdArgs.Length == 3)
                    {
                        //to do soldier regenerate
                    }
                    else
                    {
                        string type = cmdArgs[1];
                        string name = cmdArgs[2];
                        int age = int.Parse(cmdArgs[3]);
                        double experience = double.Parse(cmdArgs[4]);
                        double endurance = double.Parse(cmdArgs[6]);
                        ISoldier currentSoldier = SoldierFactory.CreateSoldier(type, name, age, experience, endurance);
                        foreach (var weapon in currentSoldier.Weapons)
                        {
                            
                        }
                       
                    }

                    break;

                case "WareHouse":
                    string ammunitionName = cmdArgs[1];
                    int number = int.Parse(cmdArgs[2]);

                    IAmmunition currentAmmunition = AmmunitionFactory.CreateAmmunition(ammunitionName);

                    if (!this.WareHouse.Storage.ContainsKey(currentAmmunition))
                    {
                        this.WareHouse.Storage.Add(currentAmmunition, 0);
                    }

                    this.WareHouse.Storage[currentAmmunition] += number;

                    break;

                case "Mission":
                    //to do mission
                    break;
            }
        }
    }
}
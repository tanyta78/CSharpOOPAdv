using System.Collections.Generic;

public class WareHouse : IWareHouse
{
    private Dictionary<IAmmunition, int> storage;

    public Dictionary<IAmmunition, int> Storage
    {
        get { return this.storage; }
        set { this.storage = value; }
    }

    public WareHouse()
    {
        this.Storage = new Dictionary<IAmmunition, int>();
    }

    public void EquipArmy(IArmy army)
    {
        //to do
    }
}
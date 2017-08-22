using System.Collections.Generic;

public interface IWareHouse
{
    Dictionary<IAmmunition, int> Storage { get; set; }

    void EquipArmy(IArmy army);
}
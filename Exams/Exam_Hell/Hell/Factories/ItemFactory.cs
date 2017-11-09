using System.Collections.Generic;

public class ItemFactory
{
    public IItem CreateItem(IList<string> args)
    {
        string itemName = args[0];
        int strengthBonus = int.Parse(args[2]);
        int agilityBonus = int.Parse(args[3]);
        int intelligenceBonus = int.Parse(args[4]);
        int hitPointsBonus = int.Parse(args[5]);
        int damageBonus = int.Parse(args[6]);

        IItem item = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);

        return item;
    }
}
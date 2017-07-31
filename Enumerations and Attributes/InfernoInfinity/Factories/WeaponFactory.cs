using System;
using System.Collections.Generic;

public class WeaponFactory
{
    public Weapon Create(List<string> args)
    {
        var elements = args[0].Split();
        var rarityType = elements[0];
        var weaponType = elements[1];
        var weaponName = args[1];
        Rarity rarity = (Rarity)Enum.Parse(typeof(Rarity), rarityType);

        Weapon weapon = null;
        switch (weaponType)
        {
            case "Axe":
                weapon = new Axe(rarity, weaponName);
                break;

            case "Sword":
                weapon = new Sword(rarity, weaponName);
                break;

            case "Knife":
                weapon = new Knife(rarity, weaponName);
                break;
        }

        return weapon;
    }
}
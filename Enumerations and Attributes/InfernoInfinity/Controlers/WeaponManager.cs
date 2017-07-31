using System.Collections.Generic;
using System.Linq;

public class WeaponManager
{
    private readonly List<Weapon> weapons;
    private readonly WeaponFactory weaponFactory;
    private readonly GemFactory gemFactory;

    public WeaponManager()
    {
        this.weapons = new List<Weapon>();
        this.weaponFactory = new WeaponFactory();
        this.gemFactory = new GemFactory();
    }

    public void Create(List<string> args)
    {
        Weapon weapon = weaponFactory.Create(args);
        weapons.Add(weapon);
    }

    public void Add(List<string> args)
    {
        var weaponName = args[0];
        var index = int.Parse(args[1]);
        var gemArguments = args[2];
        Gem gem = gemFactory.Create(gemArguments);
        var currentWeapon = weapons.FirstOrDefault(w => w.Name == weaponName);
        currentWeapon.AddGem(index, gem);
    }

    public void Remove(List<string> args)
    {
        var weaponName = args[0];
        var index = int.Parse(args[1]);
        var currentWeapon = weapons.FirstOrDefault(w => w.Name == weaponName);
        currentWeapon.RemoveGem(index);
    }

    public string Print(string name)
    {
        var currentWeapon = weapons.FirstOrDefault(w => w.Name == name);
        currentWeapon.CalculateStats();
        return $"{currentWeapon}";
    }
}
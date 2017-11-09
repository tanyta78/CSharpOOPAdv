﻿using System.Collections.Generic;

public interface IHero
{
    string Name { get; }

    long Strength { get; }

    long Agility { get; }

    long Intelligence { get; }

    long HitPoints { get; }

    long Damage { get; }

    long PrimaryStats { get; }

    long SecondaryStats { get; }

    IInventory Inventory { get; }

    ICollection<IItem> Items { get; }

    void AddRecipe(IRecipe recipe);

    int CompareTo(AbstractHero other);

}
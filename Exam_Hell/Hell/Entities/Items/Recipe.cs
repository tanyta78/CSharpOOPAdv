using System.Collections.Generic;

public class Recipe : IRecipe
{
    public Recipe(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus, IList<string> requiredItems)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
        this.RequiredItems = new List<string>(requiredItems);
    }

    public string Name { get; set; }
    public int StrengthBonus { get; set; }
    public int AgilityBonus { get; set; }
    public int IntelligenceBonus { get; set; }
    public int HitPointsBonus { get; set; }
    public int DamageBonus { get; set; }
    public IList<string> RequiredItems { get; set; }
}
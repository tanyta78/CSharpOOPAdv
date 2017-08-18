using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero, IComparable<AbstractHero>
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name)
    {
        this.Name = name;
        this.Strength = 0;
        this.Agility = 0;
        this.Intelligence = 0;
        this.HitPoints = 0;
        this.Damage = 0;
        this.Inventory = new HeroInventory();
    }

    public IInventory Inventory
    {
        get { return this.inventory; }
        set { this.inventory = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.Inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }
    public string Name { get; set; }

    public long Strength
    {
        get { return this.strength + this.Inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.Inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

   

    public long HitPoints
    {
        get { return this.hitPoints + this.Inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.Inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            Type typeOfInventory = typeof(HeroInventory);
            FieldInfo[] fieldInfo = typeOfInventory
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo commonItemsStorage = fieldInfo.First(f => f.GetCustomAttributes<ItemAttribute>() != null);

            IDictionary<string, IItem> items = (IDictionary<string, IItem>)commonItemsStorage.GetValue(this.inventory);

            return items.Values;
        }
    }



    public void AddRecipe(IRecipe recipe)
    {
        this.Inventory.AddRecipeItem(recipe);
    }
   
    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Hero: {this.Name}, Class: {GetType().Name}");
        sb.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        sb.AppendLine($"Strength: {this.Strength}");
        sb.AppendLine($"Agility: {this.Agility}");
        sb.AppendLine($"Intelligence: {this.Intelligence}");
        if (this.Items.Count > 0)
        {
            sb.AppendLine($"Items:");
            foreach (var item in this.Items)
            {
                sb.AppendLine(item.ToString());
            }
        }
        else
        {
            sb.AppendLine($"Items: None");
        }

        return sb.ToString().Trim();
    }
}
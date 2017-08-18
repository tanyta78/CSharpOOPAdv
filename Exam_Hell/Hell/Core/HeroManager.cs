using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IHeroManager
{
    private Dictionary<string, AbstractHero> heroes;
    private ItemFactory itemFactory;

    public HeroManager(ItemFactory itemFactory)
    {
        this.heroes = new Dictionary<string, AbstractHero>();
        this.itemFactory = itemFactory;

    }

    public string AddHero(List<String> arguments)
    {
        string result = String.Empty;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type typeOfHero = Type.GetType(heroType);
            var constructors = typeOfHero.GetConstructors();
            var inventory = new HeroInventory();


            AbstractHero hero = (AbstractHero) constructors[0].Invoke(new object[] {heroName});

            this.heroes.Add(heroName, hero);

            result = string.Format($"Created {heroType} - {hero.Name}");
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(List<String> arguments)
    {
        string result = String.Empty;
        string heroName = arguments[1];

        IItem currentItem = this.itemFactory.CreateItem(arguments);


        this.heroes[heroName].Inventory.AddCommonItem(currentItem);

        result = string.Format(Constants.ItemCreateMessage, currentItem.Name, heroName);
        return result;
    }

    public string AddRecipeToHero(List<string> arguments)
    {
        var recipeName = arguments[0];
        var heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);
        var neededItems = arguments.Skip(7).ToList();

        IRecipe recipe = new Recipe(recipeName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus, neededItems);

        this.heroes[heroName].AddRecipe(recipe);

        return string.Format(Constants.RecipeCreatedMessage, recipeName, heroName);
    }

    public string Inspect(List<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string PrintAllHeroes()
    {
        var sb = new StringBuilder();
        var counter = 1;


        var heroesToPrint = this.heroes.Values.OrderByDescending(h => h.PrimaryStats)
            .ThenByDescending(h => h.SecondaryStats);

        foreach (var hero in heroesToPrint)
        {
            List<string> itemsByName = new List<string>();
            foreach (var heroItem in hero.Items)
            {
                itemsByName.Add(heroItem.Name);
            }

            sb.AppendLine($"{counter++}. {hero.GetType().Name}: {hero.Name}");
            sb.AppendLine($"###HitPoints: {hero.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Damage}");
            sb.AppendLine($"###Strength: {hero.Strength}");
            sb.AppendLine($"###Agility: {hero.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Intelligence}");
            if (itemsByName.Any())
            {
                sb.AppendLine($"###Items: {string.Join(", ", itemsByName)}");
            }
            else
            {
                sb.AppendLine($"###Items: None");
            }
        }

        return sb.ToString().Trim();
    }

}
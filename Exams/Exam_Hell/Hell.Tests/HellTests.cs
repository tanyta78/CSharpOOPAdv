using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class HellTests
{
    private HeroInventory inventory;
    private IItem itemForTests;
    private IItem itemForTests2;
    private RecipeItem recipeForTest1;

    [SetUp]
    public void InitializeInventory()
    {
        this.inventory=new HeroInventory();
        this.itemForTests=new CommonItem("Knife", 1, 2, 3, 4, 5);
        this.itemForTests2= new CommonItem("Gun", 5, 4, 3, 2, 1);
        this.recipeForTest1=new RecipeItem("Res",1,2,3,4,5,new List<string>(){ "Knife" , "Gun" });
    }

   
    [Test]
    public void CheckConstructor()
    {
        //Arrange
        Type invType = typeof(HeroInventory);

        //Act

        var sut = (HeroInventory)Activator.CreateInstance(invType, new object[] { });

        //Assert

        Assert.IsAssignableFrom(invType,sut);
    }

    [Test]
   public void AddItemsIncreaceCount()
    {
        //Arrange
        Type invType = typeof(HeroInventory);
        
        var allNonPublicFields =
            invType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

        FieldInfo searcheField = null;

        foreach (var field in allNonPublicFields)
        {
            var s = field.GetCustomAttributes().Any(a=>a.GetType()==typeof(ItemAttribute));
            if (s)
            {
                searcheField = field;
                break;
            }
           
        }
    
        //Act
        this.inventory.AddCommonItem(this.itemForTests);
        this.inventory.AddCommonItem(this.itemForTests2);
 
        Dictionary < string, IItem> after = (Dictionary<string, IItem>) searcheField.GetValue(this.inventory);
        // Convert.ChangeType(number, typeof(Continent)));
       
        //Assert
        Assert.AreEqual(2,after.Count);
    }

    [Test]
    public void AddItemNullThrowException()
    {
        //Arrange
        Type invType = typeof(HeroInventory);
        

        //Assert
        Assert.Throws<NullReferenceException>(() => this.inventory.AddCommonItem(null));
    }

    [Test]
    public void TotalStrengthBonus()
    {
        //Act
        this.inventory.AddCommonItem(this.itemForTests);
        this.inventory.AddCommonItem(this.itemForTests2);
        var totalBonus = this.itemForTests.StrengthBonus + this.itemForTests2.StrengthBonus;

        //Assert
        Assert.AreEqual(totalBonus, this.inventory.TotalStrengthBonus);
    }

    [Test]
    public void TotalAgilityBonus()
    {
        //Act
        this.inventory.AddCommonItem(this.itemForTests);
        this.inventory.AddCommonItem(this.itemForTests2);
        var totalBonus = this.itemForTests.AgilityBonus + this.itemForTests2.AgilityBonus;

        //Assert
        Assert.AreEqual(totalBonus, this.inventory.TotalAgilityBonus);
    }

    [Test]
    public void TotalIntelligenceBonus()
    {
        //Act
        this.inventory.AddCommonItem(this.itemForTests);
        this.inventory.AddCommonItem(this.itemForTests2);
        var totalBonus = this.itemForTests.IntelligenceBonus + this.itemForTests2.IntelligenceBonus;

        //Assert
        Assert.AreEqual(totalBonus, this.inventory.TotalIntelligenceBonus);
    }

    [Test]
    public void TotalHitPointsBonus()
    {
        //Act
        this.inventory.AddCommonItem(this.itemForTests);
        this.inventory.AddCommonItem(this.itemForTests2);
        var totalBonus = this.itemForTests.HitPointsBonus + this.itemForTests2.HitPointsBonus;

        //Assert
        Assert.AreEqual(totalBonus, this.inventory.TotalHitPointsBonus);
    }

    [Test]
    public void TotalDamageBonus()
    {
        //Act
        this.inventory.AddCommonItem(this.itemForTests);
        this.inventory.AddCommonItem(this.itemForTests2);
        var totalBonus = this.itemForTests.DamageBonus + this.itemForTests2.DamageBonus;

        //Assert
        Assert.AreEqual(totalBonus, this.inventory.TotalDamageBonus);
    }

    [Test]
    public void TotalStatsBonus()
    {
        //Act
        this.inventory.AddCommonItem(this.itemForTests);


        long expected = this.itemForTests.IntelligenceBonus + this.itemForTests.AgilityBonus +
                       this.itemForTests.DamageBonus + this.itemForTests.HitPointsBonus +
                       this.itemForTests.StrengthBonus;
        

        long actual = this.inventory.TotalAgilityBonus +
                               this.inventory.TotalDamageBonus +
                               this.inventory.TotalHitPointsBonus +
                               this.inventory.TotalIntelligenceBonus +
                               this.inventory.TotalStrengthBonus;

        Assert.AreEqual(expected,actual);
    }

    [Test]
    public void NewInventoryStatsAreZero()
    {
       
        long totalStatsBonus = this.inventory.TotalAgilityBonus
                               + this.inventory.TotalStrengthBonus
                               + this.inventory.TotalIntelligenceBonus
                               + this.inventory.TotalHitPointsBonus
                               + this.inventory.TotalDamageBonus;

        Assert.AreEqual(0, totalStatsBonus);
    }

    [Test]
    public void AddRecipeItem()
    {
        this.inventory.AddRecipeItem(this.recipeForTest1);

        Type invType = typeof(HeroInventory);

        var fieldRecipeItems =
            invType.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

        var d = (Dictionary<string, IRecipe>) fieldRecipeItems.GetValue(this.inventory);
       
        Assert.AreEqual(1,d.Count);
    }

    [Test]
    public void  CheckRecipes()
    {
        //Arrange 
       Type invType = typeof(HeroInventory);

        var commonItems =
            invType.GetField("commonItems", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

        
        //Act

        this.inventory.AddRecipeItem(this.recipeForTest1);
        this.inventory.AddCommonItem(this.itemForTests);
        this.inventory.AddCommonItem(this.itemForTests2);

       var d= (Dictionary<string, IItem>)commonItems.GetValue(this.inventory);

        Assert.AreEqual(1, d.Count);
    }

}
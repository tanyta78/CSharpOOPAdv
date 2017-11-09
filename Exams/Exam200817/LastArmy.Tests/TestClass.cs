using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

[TestFixture]
public class TestClass
{
    private IArmy army;
    private IWareHouse wareHouse;
    private Queue<IMission> missionQueue;

    [SetUp]
    public void TestMethod()
    {
        Type missContType = typeof(MissionController);
        this.army = new Army();
        var ranker = SoldierFactory.CreateSoldier("Ranker", "Ivan", 47, 23 ,100);
        var corporal = SoldierFactory.CreateSoldier("Corporal", "Ivaylo", 21, 78, 100);
        this.army.AddSoldier(ranker);
        this.army.AddSoldier(corporal);
        var missionEasy = MissionFactory.CreateMission("Easy", 1);


    }

  
    [Test]
    public void ff()
    {
        //Arrange
        Type missContType = typeof(MissionController);
        var ctor = missContType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];

        //Act

        var sut = (MissionController)Activator.CreateInstance(missContType, new object[] {this.army,this.wareHouse });

        //Assert

        Assert.IsAssignableFrom(missContType, sut);
    }

    [Test]


}
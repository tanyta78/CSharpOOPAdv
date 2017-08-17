using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RecyclingStation.BusinestLayer.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.BusinestLayer.Strategies;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Attributes;

[TestFixture]
public class StrategyHolderTests
{
    private IGarbageDisposalStrategy ds;
     private Dictionary<Type, IGarbageDisposalStrategy> strategies;

    [SetUp]
    public void TestInit()
    {
       this.ds = new BurnableGarbageDisposalStrategy();
       this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();

    }
    
    [Test]
    public void TestPropertyForReadOnlyColection()
    {
        //Arrange
        Type dystype = typeof(DisposableAttribute);
       
        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        Type type = sut.GetDisposalStrategies.GetType();


        //Assert
        var test = type.GetInterfaces();
        Assert.IsTrue(sut.AddStrategy(dystype,ds));
    }

    [Test]
    public void AddStrategy()
    {
        //Arrange
       Type dystype = typeof(DisposableAttribute);
       IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        bool result = sut.AddStrategy(dystype, ds);


        //Assert
     
        Assert.IsTrue(result);
    }

    [Test]
    public void AddSameStrategiesAndCheckCollectionHaveOne()
    {
        //Arrange
      
        Type dystype = typeof(DisposableAttribute);
         IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        bool result = sut.AddStrategy(dystype, ds);
        bool result1 = sut.AddStrategy(dystype, ds);
        bool result2 = sut.AddStrategy(dystype, ds);


        //Assert

        Assert.AreEqual(1,sut.GetDisposalStrategies.Count);
    }

    [Test]
    public void AddDiffStrategiesAndCheckCollectionCount()
    {
        //Arrange
       
        Type dystype = typeof(BurnableStrategyAttribute);
        Type dystype2 = typeof(RecyclableStrategyAttribute);
        Type dystype3 = typeof(StorableStrategyAttribute);

        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        bool result = sut.AddStrategy(dystype, ds);
        bool result1 = sut.AddStrategy(dystype3, ds);
        bool result2 = sut.AddStrategy(dystype2, ds);


        //Assert

        Assert.AreEqual(3, sut.GetDisposalStrategies.Count);
    }

    [Test]
    public void RemoveStrategy()
    {
        //Arrange
        Type dystype = typeof(DisposableAttribute);
        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        bool result = sut.AddStrategy(dystype, ds);
       
        //Assert

        Assert.IsTrue(sut.RemoveStrategy(dystype));
    }

    [Test]
    public void RemoveSomeStrategyAndTestCount()
    {
        //Arrange
        Type dystype = typeof(BurnableStrategyAttribute);
        Type dystype2 = typeof(RecyclableStrategyAttribute);
        Type dystype3 = typeof(StorableStrategyAttribute);

        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        bool result = sut.AddStrategy(dystype, ds);
        bool result1 = sut.AddStrategy(dystype2, ds);
        bool result2 = sut.AddStrategy(dystype3, ds);

        bool removeResult = sut.RemoveStrategy(dystype);

        //Assert

        Assert.AreEqual(2,sut.GetDisposalStrategies.Count);
    }
}


namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type typeOfUnit = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == unitType);
            return (IUnit)Activator.CreateInstance(typeOfUnit);
        }
    }
}
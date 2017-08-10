namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type typeOfUnit = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == unitType);
            return (IUnit)Activator.CreateInstance(typeOfUnit);
        }
    }
}
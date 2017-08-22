namespace SOLID.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using SOLID.Contracts.Core;
    using SOLID.Contracts.Entities;

    public class UnitFactory:IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type typeOfUnit = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == unitType);
            return (IUnit)Activator.CreateInstance(typeOfUnit);
        }
    }
}

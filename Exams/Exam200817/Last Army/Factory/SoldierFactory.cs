using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type typeOfSoldier = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(soldierTypeName, StringComparison.OrdinalIgnoreCase));

        object[] typeArgs = new object[] { name, age, experience, endurance };

        ISoldier defaultSoldier = (ISoldier)Activator.CreateInstance(typeOfSoldier, typeArgs);

        return defaultSoldier;
    }


}
using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public  IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type typeOfAmmunition = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(ammunitionName, StringComparison.OrdinalIgnoreCase));


        if (typeOfAmmunition == null)
        {
            throw new ArgumentNullException("This ammunition don't exist!");
        }

        IAmmunition defaultAmmunition = (IAmmunition)Activator.CreateInstance(typeOfAmmunition, ammunitionName);

        return defaultAmmunition;


    }

    
}
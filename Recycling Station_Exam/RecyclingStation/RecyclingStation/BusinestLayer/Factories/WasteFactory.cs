using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingStation.BusinestLayer.Factories
{
    using System.Reflection;
    using RecyclingStation.BusinestLayer.Contracts.Factories;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class WasteFactory:IWasteFactory
    {

        private const string GarbageSuffix = "Garbage";

        public IWaste Create(string name, double weight, double volumePerKg, string type)
        {
            string fullTypeName = type + GarbageSuffix;
            Type garbageTypeToActivate = Assembly.GetExecutingAssembly()
                .GetTypes().FirstOrDefault(t => t.Name.Equals(fullTypeName, StringComparison.OrdinalIgnoreCase));

            object[] typeArgs = new object[] {name, weight, volumePerKg};

           // IWaste waste = (IWaste)Activator.CreateInstance(garbageTypeToActivate, name,weight,volumePerKg);

             IWaste waste = (IWaste)Activator.CreateInstance(garbageTypeToActivate, typeArgs);



            return waste;
        }
    }
}

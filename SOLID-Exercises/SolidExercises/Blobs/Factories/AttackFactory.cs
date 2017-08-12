using Blobs.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Blobs.Factories
{
    public class AttackFactory
    {
        private const string BehvaiorNameSuffix = "Attack";

        public IAttack CreateAttack(string behaviorTypeStr)
        {
            string behaviorCompleteName = behaviorTypeStr + BehvaiorNameSuffix;
            Type behaviorType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.Name == behaviorCompleteName);

            return (IAttack)Activator.CreateInstance(behaviorType);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MyInjection.Core.Attribites;

namespace MyInjection.Core.RegisteringStrategies
{
    public class AttributeRegistratingStrategy : AbsstractRegistratingStrategy
    {
        public AttributeRegistratingStrategy(Assembly assembly) : base(assembly)
        {
        }

        public override void Register(IDictionary<Type, Type> types, IDictionary<Type, object> objects)
        {
            IEnumerable<Type> decoratedTypes = this.Assembly.GetTypes()
                 .Where(t => t.GetTypeInfo()
                 .GetCustomAttributes<InjectionCandidateAttribute>().Any());

            foreach (Type decoratedTypeImplem in decoratedTypes)
            {
                foreach (Type abstraction in decoratedTypeImplem.GetInterfaces())
                {
                    types[abstraction] = decoratedTypeImplem;
                }
            }
        }
    }
}
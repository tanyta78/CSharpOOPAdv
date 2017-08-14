using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyInjection.Core.RegisteringStrategies
{
    public abstract class AbsstractRegistratingStrategy : IRegisteringStrategy
    {
        protected Assembly Assembly { get; }

        protected AbsstractRegistratingStrategy(Assembly assembly)
        {
            this.Assembly = assembly;
        }

        public abstract void Register(IDictionary<Type, Type> types, IDictionary<Type, object> objects);
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace MyInjection.Core.RegisteringStrategies
{
    public class ManualRegistratingStrategy : IRegisteringStrategy
    {
        private readonly Dictionary<Type, Type> dependencies;

        private readonly Dictionary<Type, object> cache;

        public ManualRegistratingStrategy()
        {
            this.dependencies = new Dictionary<Type, Type>();
            this.cache = new Dictionary<Type, object>();
        }

        public ManualRegistratingStrategy Register<TAbstr, TImpl>() where TImpl : TAbstr
        {
            this.dependencies[typeof(TAbstr)] = typeof(TImpl);

            return this;
        }

        public void Register(IDictionary<Type, Type> types, IDictionary<Type, object> objects)
        {
            foreach (var dependency in this.dependencies)
            {
                types[dependency.Key] = dependency.Value;
            }

            foreach (var cacheobj in this.cache)
            {
                objects[cacheobj.Key] = cacheobj.Value;
            }
        }
    }
}
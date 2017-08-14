using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MyInjection.Core.RegisteringStrategies;

namespace MyInjection.Core
{
    public class Container
    {
        private Dictionary<Type, Type> dependencies;

        private Dictionary<Type, object> cache;

        public Container(params IRegisteringStrategy[] strategies)
        {
            this.dependencies = new Dictionary<Type, Type>();
            this.cache = new Dictionary<Type, object>();
            this.InvoleStrategies(strategies);
        }

        private void InvoleStrategies(IRegisteringStrategy[] strategies)
        {
            foreach (IRegisteringStrategy strategy in strategies)
            {
                strategy.Register(this.dependencies, this.cache);
            }
        }

        public T Get<T>()
        {
            var interfaceType = typeof(T);
            if (!interfaceType.GetTypeInfo().IsInterface
                && !interfaceType.GetTypeInfo().IsAbstract)
            {
                throw new Exception("We can only make DI with Interfaces! You should depend on abstractions, man!");
            }
            return (T)this.Get(interfaceType);
        }

        private object Get(Type interfaceType)
        {
            if (cache.ContainsKey(interfaceType))
            {
                return this.cache[interfaceType];
            }

            Type realType = this.dependencies[interfaceType];

            ConstructorInfo ctorInfo = realType.GetConstructors().FirstOrDefault();

            ParameterInfo[] args = ctorInfo.GetParameters();

            Object[] argsToPassToCtor = new object[args.Length];
            int counter = 0;

            //итерираме през параметрите на конструктора
            // опитваме се да ги създадем и тях
            //при създадени параметри,ги вкарваме в масив от обекти защото така очаква Reflection-а
            foreach (ParameterInfo arg in args)
            {
                Type argType = arg.ParameterType;
                object obj = this.Get(argType);
                argsToPassToCtor[counter++] = obj;
            }

            // инстанцираме обекта през ConstructorInfo.Invoke(масива с параметри)
            //добавяме в кеша и връщаме обекта
            object objToCashe = ctorInfo.Invoke(argsToPassToCtor);

            this.cache[interfaceType] = objToCashe;

            return objToCashe;
        }
    }
}
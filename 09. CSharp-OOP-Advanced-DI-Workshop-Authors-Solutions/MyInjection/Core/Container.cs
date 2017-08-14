using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MyInjection.Repositories;
using MyInjection.Servicies;

namespace MyInjection.Core
{
    public class Container
    {
        private Dictionary<Type, Type> dependencies;

        public Container()
        {
            this.dependencies = new Dictionary<Type, Type>();
            //only for test
            //this.dependencies[typeof(IUserService)] = typeof(UserService);
            //this.dependencies[typeof(IUserRepository)] = typeof(DefaultUserRepository);
            //this.dependencies[typeof(IPaymentRepository)] = typeof(DefaultPaymentRepository);
            //this.dependencies[typeof(ISoftUniRepository)] = typeof(DefaultSoftUniRepository);
        }

        public T Get<T>()
        {
            var interfaceType = typeof(T);
            return (T)this.Get(interfaceType);
        }

        private object Get(Type interfaceType)
        {
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
            //връщаме обекта
            return ctorInfo.Invoke(argsToPassToCtor);
        }
    }
}
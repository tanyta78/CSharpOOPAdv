using System;
using System.Collections;
using System.Collections.Generic;

namespace MyInjection.Core.RegisteringStrategies
{
    public interface IRegisteringStrategy
    {
        void Register(IDictionary<Type, Type> types, IDictionary<Type, object> objects);
    }
}
namespace _03BarracksFactory.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
    }
}
using LoggerProblem.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace LoggerProblem.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutName)
        {
            Type layoutType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == layoutName);
            return (ILayout)Activator.CreateInstance(layoutType);
        }
    }
}
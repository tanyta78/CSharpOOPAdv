using LoggerProblem.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace LoggerProblem.Factories
{
    public class AppenderFactory
    {
        public IAppender CreateAppender(string appenderName, ILayout layout)
        {
            Type appenderType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == appenderName);
            return (IAppender)Activator.CreateInstance(appenderType, layout);
        }
    }
}
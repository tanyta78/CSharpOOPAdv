using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LoggerProblem.Interfaces;

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

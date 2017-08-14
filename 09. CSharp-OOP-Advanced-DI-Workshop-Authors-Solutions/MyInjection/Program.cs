using System;
using MyInjection.Core;
using MyInjection.Core.RegisteringStrategies;
using MyInjection.Repositories;
using MyInjection.Servicies;
using System.Reflection;
using System.Resources;
using MyInjection.Resources;

namespace MyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ResourceManager rm = new ResourceManager("MyInjection.Resources.Vars", Assembly.GetEntryAssembly());

            // Console.WriteLine(rm.GetString("dbPath"));

            var container = new Container(
                typeof(Vars).FullName,
                Assembly.GetEntryAssembly(),
                new SingleImplementationStrategy(Assembly.GetEntryAssembly()),
                new ManualRegistratingStrategy()
                .Register<ISoftUniRepository, DefaultSoftUniRepository>(),
                new AttributeRegistratingStrategy(Assembly.GetEntryAssembly())
                );

            var userService = container.Get<IUserService>();

            userService.Rename();
        }
    }
}
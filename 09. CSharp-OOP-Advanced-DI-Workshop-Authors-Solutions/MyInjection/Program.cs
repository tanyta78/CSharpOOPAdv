using System.Linq.Expressions;
using System.Reflection;
using MyInjection.Core;
using MyInjection.Core.RegisteringStrategies;
using MyInjection.Repositories;
using MyInjection.Servicies;

namespace MyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new Container(
                new SingleImplementationStrategy(Assembly.GetEntryAssembly()),
                new ManualRegistratingStrategy().Register<ISoftUniRepository, DefaultSoftUniRepository>()
                );

            var userService = container.Get<IUserService>();

            userService.Rename();
        }
    }
}
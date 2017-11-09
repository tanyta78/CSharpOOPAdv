using System.Linq;
using System.Reflection;

namespace _02BlackBoxInteger
{
    using System;

    internal class BlackBoxIntegerTests
    {
        private static void Main(string[] args)
        {
           

            Type myType = Type.GetType("_02BlackBoxInteger.BlackBoxInt");

            var classMethods = myType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public |
                                                 BindingFlags.Static);
            //var ctor1 = myType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder,
            //    new Type[] { }, null);
            
            var ctor = myType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[1];
            
            //  var instance = (BlackBoxInt)Activator.CreateInstance(myType, true);= create instance without ctor

            var instance = (BlackBoxInt)ctor.Invoke(new object[] { });

            var allFields = myType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            var innerValue = allFields.First(f => f.Name == "innerValue");

            var cmdArs = Console.ReadLine();

            while (cmdArs != "END")
            {
                var command = cmdArs.Split('_')[0];
                var value = int.Parse(cmdArs.Split('_')[1]);

                var method = classMethods.First(m => m.Name == command);

                method.Invoke(instance, new object[] { value });
                int fieldValue = (int)innerValue.GetValue(instance);
                Console.WriteLine(fieldValue);

                cmdArs = Console.ReadLine();
            }
        }
    }
}
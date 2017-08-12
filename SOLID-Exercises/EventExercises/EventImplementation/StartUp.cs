using System;

namespace EventImplementation
{
    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            while (name != "End")
            {
                dispatcher.Name = name;

                name = Console.ReadLine();
            }
        }
    }
}
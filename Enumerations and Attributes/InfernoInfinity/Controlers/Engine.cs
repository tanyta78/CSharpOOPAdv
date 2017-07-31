using System;
using System.Linq;

public class Engine
{
    private readonly WeaponManager manager = new WeaponManager();

    public void Start()
    {
        bool isRunning = true;

        while (isRunning)
        {
            var input = Console.ReadLine();
            var tokens = input.Split(';');
            var cmd = tokens[0];
            var arguments = tokens.Skip(1).ToList();

            switch (cmd)
            {
                case "Create":
                    manager.Create(arguments);
                    break;

                case "Add":
                    manager.Add(arguments);
                    break;

                case "Remove":
                    manager.Remove(arguments);
                    break;

                case "Print":
                    Console.WriteLine(manager.Print(arguments[0]));
                    break;

                case "END":
                    isRunning = false;
                    break;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var enters = new Dictionary<string, IBuyer>();
        var lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var commandLine = Console.ReadLine().Split().ToList();
            if (commandLine.Count == 3)
            {
                var rebel = new Rebel(commandLine[0], int.Parse(commandLine[1]), commandLine[2]);
                enters.Add(commandLine[0], rebel);
            }
            else if (commandLine.Count == 4)
            {
                var citizen = new Citizen(commandLine[0], int.Parse(commandLine[1]), commandLine[2], commandLine[3]);
                enters.Add(commandLine[0], citizen);
            }
        }

        var buyer = Console.ReadLine();

        while (buyer != "End")
        {
            if (enters.ContainsKey(buyer))
            {
                enters[buyer].BuyFood();
            }
            buyer = Console.ReadLine();
        }

        var totalAmountOfFood = enters.Values.Select(b => b.Food).Sum();
        Console.WriteLine(totalAmountOfFood);
    }
}
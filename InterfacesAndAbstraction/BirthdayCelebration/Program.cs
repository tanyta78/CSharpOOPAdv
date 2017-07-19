using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static bool isRunning = true;

    public static void Main()
    {
        var enters = new List<IBirthable>();

        while (isRunning)
        {
            var commandLine = Console.ReadLine().Split().ToList();
            if (commandLine[0] == "End" && commandLine.Count == 1)
            {
                isRunning = false;
            }
            else if (commandLine.Count == 3 && commandLine[0] == "Pet")
            {
                var pet = new Pet(commandLine[1], commandLine[2]);
                enters.Add(pet);
            }
            else if (commandLine.Count == 5)
            {
                var citizen = new Citizen(commandLine[1], int.Parse(commandLine[2]), commandLine[3], commandLine[4]);
                enters.Add(citizen);
            }
        }

        var year = Console.ReadLine();
        foreach (var enter in enters)
        {
            if (enter.CheckBirthdate(year))
            {
                Console.WriteLine(enter.Birthdate);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static bool isRunning = true;

    public static void Main()
    {
        var enters = new List<ICheckable>();

        while (isRunning)
        {
            var commandLine = Console.ReadLine().Split().ToList();
            if (commandLine[0] == "End" && commandLine.Count == 1)
            {
                isRunning = false;
            }
            else if (commandLine.Count == 2)
            {
                var robot = new Robot(commandLine[0], commandLine[1]);
                enters.Add(robot);
            }
            else if (commandLine.Count == 3)
            {
                var citizen = new Citizen(commandLine[0], int.Parse(commandLine[1]), commandLine[2]);
                enters.Add(citizen);
            }
        }

        var checkNumber = Console.ReadLine();
        foreach (var enter in enters)
        {
            if (!enter.CheckId(checkNumber))
            {
                Console.WriteLine(enter.Id);
            }
        }
    }
}
using System;

public class Program
{
    public static bool isRunning = true;

    public static void Main()
    {
        var myList = new CustomList<string>();

        while (isRunning)
        {
            var cmdLine = Console.ReadLine().Split();
            var command = cmdLine[0];

            switch (command)
            {
                case "Add":
                    myList.Add(cmdLine[1]);
                    break;

                case "Remove":
                    myList.Remove(int.Parse(cmdLine[1]));
                    break;

                case "Contains":
                    Console.WriteLine(myList.Contains(cmdLine[1]) ? "True" : "False");
                    break;

                case "Swap":
                    myList.Swap(int.Parse(cmdLine[1]), int.Parse(cmdLine[2]));
                    break;

                case "Greater":
                    Console.WriteLine(myList.CountGreaterThan(cmdLine[1]));
                    break;

                case "Max":
                    Console.WriteLine(myList.Max());
                    break;

                case "Min":
                    Console.WriteLine(myList.Min());
                    break;

                case "Print":
                    foreach (var element in myList.Data)
                    {
                        Console.WriteLine(element);
                    }
                    break;

                case "Sort":
                    myList.Sort();
                    break;

                case "END":
                    isRunning = false;
                    break;
            }
        }
    }
}
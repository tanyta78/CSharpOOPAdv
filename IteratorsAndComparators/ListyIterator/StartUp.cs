using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var commandLine = Console.ReadLine().Split().ToList();
        var command = commandLine[0];
        ListyIterator<string> iterator = null;

        if (commandLine.Count > 1)
        {
            var parameters = commandLine.Skip(1).ToList();
            iterator = new ListyIterator<string>(parameters);
        }
        else
        {
            iterator = new ListyIterator<string>();
        }

        command = Console.ReadLine();

        while (command != "END")
        {
            switch (command)
            {
                case "Move":
                    Console.WriteLine(iterator.Move());
                    break;

                case "HasNext":
                    Console.WriteLine(iterator.HasNext());
                    break;

                case "Print":
                    try
                    {
                        Console.WriteLine(iterator.Print());
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;

                case "PrintAll":
                    try
                    {
                        Console.WriteLine(iterator.PrintAll());
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
            }

            command = Console.ReadLine();
        }
    }
}
using System;

public class Program
{
    private static void Main()
    {
        var driver = Console.ReadLine();
        var ferrari = new Ferrari(driver);
        Console.WriteLine(ferrari.ToString());
        string ferrariName = typeof(Ferrari).Name;
        string iCarInterfaceName = typeof(ICar).Name;

        bool isCreated = typeof(ICar).IsInterface;
        if (!isCreated)
        {
            throw new Exception("No interface ICar was created");
        }
    }
}
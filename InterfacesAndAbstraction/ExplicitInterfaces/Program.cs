using System;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();
        while (input[0] != "End")
        {
            var citizen = new Citizen(input[0], input[1], int.Parse(input[2]));
            var iperson = (IPerson)citizen;
            var iresident = (IResident)citizen;
            Console.WriteLine(iperson.GetName());
            Console.WriteLine(iresident.GetName());
            input = Console.ReadLine().Split();
        }
    }
}
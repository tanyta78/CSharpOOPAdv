using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var phone = new Smartphone();
        var numbers = Console.ReadLine().Split().ToList();
        var sites = Console.ReadLine().Split().ToList();
        foreach (var number in numbers)
        {
            phone.Call(number);
        }
        foreach (var site in sites)
        {
            phone.Browse(site);
        }
    }
}
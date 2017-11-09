using System;
using System.Linq;

public class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToList();

        Lake myLake = new Lake(input);

        Console.WriteLine(string.Join(", ", myLake));
    }
}
using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var lines = int.Parse(Console.ReadLine());
        var box = new Box<double>();

        for (int i = 0; i < lines; i++)
        {
            var val = double.Parse(Console.ReadLine());
            box.Add(val);
        }

        var elementToCompareWith = double.Parse(Console.ReadLine());
        Console.WriteLine(box.CountGreaterThan(elementToCompareWith));
    }
}
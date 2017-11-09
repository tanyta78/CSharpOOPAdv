using System;

public class Program
{
    public static void Main()
    {
        var personalInfo = Console.ReadLine().Split();

        var nameAddress = new Tuplee<string, string>($"{personalInfo[0]} {personalInfo[1]}", personalInfo[2]);
        Console.WriteLine(nameAddress);

        personalInfo = Console.ReadLine().Split();
        var nameBeers = new Tuplee<string, int>(personalInfo[0], int.Parse(personalInfo[1]));
        Console.WriteLine(nameBeers);

        personalInfo = Console.ReadLine().Split();
        var info = new Tuplee<int, double>(int.Parse(personalInfo[0]), double.Parse(personalInfo[1]));
        Console.WriteLine(info);
    }
}
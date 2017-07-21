using System;

public class Program
{
    public static void Main(string[] args)
    {
        var personalInfo = Console.ReadLine().Split();

        var nameAddress = new Threeuple<string, string, string>($"{personalInfo[0]} {personalInfo[1]}", personalInfo[2], personalInfo[3]);
        Console.WriteLine(nameAddress);

        personalInfo = Console.ReadLine().Split();

        var nameBeers = new Threeuple<string, int, string>(personalInfo[0], int.Parse(personalInfo[1]), personalInfo[2] == "drunk" ? "True" : "False");
        Console.WriteLine(nameBeers);

        personalInfo = Console.ReadLine().Split();

        var info = new Threeuple<string, double, string>(personalInfo[0], double.Parse(personalInfo[1]), personalInfo[2]);
        Console.WriteLine(info);
    }
}
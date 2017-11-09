using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var persons = new List<Person>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var personInfo = input.Split(' ').ToList();
            persons.Add(new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]));
        }

        var index = int.Parse(Console.ReadLine()) - 1;
        var personCompareTo = persons[index];
        var numberOfEqualPeople = 0;

        foreach (var person in persons)
        {
            if (personCompareTo.CompareTo(person) == 0)
            {
                numberOfEqualPeople++;
            }
        }

        Console.WriteLine(numberOfEqualPeople - 1 == 0
            ? "No matches"
            : $"{numberOfEqualPeople} {persons.Count - numberOfEqualPeople} {persons.Count}");
    }
}
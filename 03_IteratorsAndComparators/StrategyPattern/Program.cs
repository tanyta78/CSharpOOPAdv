using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        SortedSet<Person> personsByName = new SortedSet<Person>(new CompareByName());
        SortedSet<Person> personsByAge = new SortedSet<Person>(new CompareByAge());

        var countOfPersons = int.Parse(Console.ReadLine());
        for (int i = 0; i < countOfPersons; i++)
        {
            var tokens = Console.ReadLine().Split();
            var name = tokens[0];
            var age = int.Parse(tokens[1]);

            var person = new Person(name, age);
            personsByName.Add(person);
            personsByAge.Add(person);
        }

        PrintPersons(personsByName);
        PrintPersons(personsByAge);
    }

    private static void PrintPersons(SortedSet<Person> persons)
    {
        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }
}
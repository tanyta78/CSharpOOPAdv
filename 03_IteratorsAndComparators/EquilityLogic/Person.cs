using System;
using System.Collections;
using System.Collections.Generic;

public class Person : IComparable<Person>, IComparer<Person>
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }

    public int CompareTo(Person other)
    {
        return this.Compare(this, other);
    }

    public int Compare(Person x, Person y)
    {
        var result = x.Name.CompareTo(y.Name);
        if (result == 0)
        {
            result = x.Age.CompareTo(y.Age);
        }
        return result;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }

    public override bool Equals(object o)
    {
        var item = o as Person;

        if (item == null)
        {
            return false;
        }

        return this.Name.Equals(item.Name) && this.Age.Equals(item.Age);
    }

    public override int GetHashCode()
    {
        return this.Age * this.Name.Length;
    }
}
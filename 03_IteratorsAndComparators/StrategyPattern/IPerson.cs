using System;
using System.Collections.Generic;

public interface IPerson : IComparer<Person>
{
    int CompareTwoPerson(Person firstPerson, Person secondPerson);
}
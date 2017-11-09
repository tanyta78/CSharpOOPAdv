public class CompareByAge : IPerson
{
    public int Compare(Person x, Person y)
    {
        return CompareTwoPerson(x, y);
    }

    public int CompareTwoPerson(Person firstPerson, Person secondPerson)
    {
        return firstPerson.Age.CompareTo(secondPerson.Age);
    }
}
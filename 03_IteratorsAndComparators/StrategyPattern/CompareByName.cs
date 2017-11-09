public class CompareByName : IPerson
{
    public int Compare(Person x, Person y)
    {
        return CompareTwoPerson(x, y);
    }

    public int CompareTwoPerson(Person firstPerson, Person secondPerson)
    {
        var result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

        if (result == 0)
        {
            result = char.ToLower(firstPerson.Name[0]).CompareTo(char.ToLower(secondPerson.Name[0]));
        }

        return result;
    }
}
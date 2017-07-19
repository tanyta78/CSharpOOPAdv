using System;

public class Citizen : ICheckable, IBirthable
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; }
    public string Birthdate { get; set; }

    public bool CheckBirthdate(string checker)
    {
        if (this.Birthdate.EndsWith(checker))
        {
            return true;
        }
        return false;
    }

    public bool CheckId(string checker)
    {
        if (this.Id.EndsWith(checker))
        {
            return false;
        }
        return true;
    }
}
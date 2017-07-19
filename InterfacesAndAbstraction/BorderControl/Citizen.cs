using System;

public class Citizen : ICheckable
{
    public Citizen(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; }

    public bool CheckId(string checker)
    {
        if (this.Id.EndsWith(checker))
        {
            return false;
        }
        return true;
    }
}
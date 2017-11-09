using System;

public class Pet
{
    private string name;
    private int age;
    private string kind;

    public Pet(string name, int age, string kind)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = kind;
    }

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public string Kind { get => kind; set => kind = value; }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }
}
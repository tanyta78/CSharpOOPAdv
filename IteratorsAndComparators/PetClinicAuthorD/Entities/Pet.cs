public class Pet
{
    public Pet(string name, int age, string kind)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = kind;
    }

    public string Name { get; protected set; }
    public int Age { get; protected set; }
    public string Kind { get; protected set; }
}
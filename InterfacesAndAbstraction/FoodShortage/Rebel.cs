﻿public class Rebel : IBuyer
{
    public Rebel(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
        this.Food = 0;
    }

    public int Food { get; set; }
    public string Name { get; set; }
    public int Age { get; private set; }
    public string Group { get; private set; }

    public void BuyFood()
    {
        this.Food += 5;
    }
}
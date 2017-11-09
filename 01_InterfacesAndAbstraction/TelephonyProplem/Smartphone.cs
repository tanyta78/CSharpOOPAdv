using System;

public class Smartphone : IBrowsable, ICallable
{
    public void Browse(string site)
    {
        var hasDigit = false;
        foreach (var ch in site)
        {
            if (char.IsDigit(ch))
            {
                hasDigit = true;
                break;
            }
        }
        if (hasDigit)
        {
            Console.WriteLine($"Invalid URL!");
        }
        else
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }

    public void Call(string number)
    {
        var hasDigit = true;
        foreach (var ch in number)
        {
            if (!char.IsDigit(ch))
            {
                hasDigit = false;
                break;
            }
        }
        if (hasDigit)
        {
            Console.WriteLine($"Calling... {number}");
        }
        else
        {
            Console.WriteLine($"Invalid number!");
        }
    }
}
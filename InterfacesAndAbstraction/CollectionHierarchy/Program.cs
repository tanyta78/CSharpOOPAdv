using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        var mycollection = Console.ReadLine().Split();
        var addColl = new AddCollection<string>();
        var addRemoveColl = new AddRemoveColection<string>();
        var mylist = new MyList<string>();

        var sb = new StringBuilder();
        foreach (var element in mycollection)
        {
            sb.Append($"{addColl.Add(element)} ");
        }
        Console.WriteLine(sb.ToString().Trim());

        sb.Clear();
        foreach (var element in mycollection)
        {
            sb.Append($"{addRemoveColl.Add(element)} ");
        }
        Console.WriteLine(sb.ToString().Trim());

        sb.Clear();
        foreach (var element in mycollection)
        {
            sb.Append($"{mylist.Add(element)} ");
        }
        Console.WriteLine(sb.ToString().Trim());

        var numberOfRemove = int.Parse(Console.ReadLine());
        sb.Clear();
        for (int i = 0; i < numberOfRemove; i++)
        {
            sb.Append($"{addRemoveColl.Remove()} ");
        }
        Console.WriteLine(sb.ToString().Trim());

        sb.Clear();
        for (int i = 0; i < numberOfRemove; i++)
        {
            sb.Append($"{mylist.Remove()} ");
        }
        Console.WriteLine(sb.ToString().Trim());
    }
}
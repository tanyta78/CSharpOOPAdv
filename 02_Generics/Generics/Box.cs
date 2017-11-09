using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T> where T : IComparable<T>
{
    private IList<T> data;
    private T valuee;

    public Box()
    {
        this.Data = new List<T>();
    }

    public Box(T valuee)
    {
        this.valuee = valuee;
    }

    public int Count => this.Data.Count;

    public IList<T> Data
    {
        get { return data; }
        set { data = value; }
    }

    public void Add(T element)
    {
        this.Data.Add(element);
    }

    public T Remove()
    {
        var rem = Data.LastOrDefault();
        Data.RemoveAt(Data.Count - 1);
        return rem;
    }

    public override string ToString()
    {
        return this.valuee.GetType().FullName + ": " + valuee;
    }

    public void Swap(int index1, int index2)
    {
        var result = Data;
        var currentElement = result[index1];
        result[index1] = result[index2];
        result[index2] = currentElement;
        this.Data = result;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        foreach (var el in data)
        {
            if (el.CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }
}
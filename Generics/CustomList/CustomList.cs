using System;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> where T : IComparable<T>
{
    private IList<T> data;

    public CustomList()
    {
        this.Data = new List<T>();
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

    public T Remove(int index)
    {
        var rem = Data[index];
        Data.RemoveAt(index);
        return rem;
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

    public bool Contains(T element)
    {
        return Data.Contains(element);
    }

    public T Max()
    {
        return Data.Max();
    }

    public T Min()
    {
        return Data.Min();
    }
}
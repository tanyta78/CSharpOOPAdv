using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> collection;
    private int currentIndex;

    // public int CurrentIndex { get; set; }

    public ListyIterator(List<T> data)
    {
        this.collection = data;
    }

    public ListyIterator()
    {
        this.collection = new List<T>();
        this.CurrentIndex = 0;
    }

    public int CurrentIndex
    {
        get { return currentIndex; }
        set { currentIndex = value; }
    }

    public bool Move()
    {
        if (this.collection.Count - 1 > CurrentIndex)
        {
            this.CurrentIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        if (this.collection.Count - 1 > CurrentIndex)
        {
            return true;
        }

        return false;
    }

    public T Print()
    {
        if (this.collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        return this.collection[CurrentIndex];
    }

    public string PrintAll()
    {
        if (this.collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        var sb = new StringBuilder();
        foreach (var element in this.collection)
        {
            sb.Append($"{element} ");
        }

        return sb.ToString().Trim();
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T element in this.collection)
        {
            yield return element;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
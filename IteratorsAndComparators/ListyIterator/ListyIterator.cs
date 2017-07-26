using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private List<T> collection;
    public int CurrentIndex { get; set; }

    public ListyIterator(List<T> data)
    {
        this.collection = data;
    }

    public ListyIterator()
    {
        this.collection = new List<T>();
        this.CurrentIndex = 0;
    }

    public bool Move()
    {
        if (this.collection.Count > CurrentIndex)
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
}
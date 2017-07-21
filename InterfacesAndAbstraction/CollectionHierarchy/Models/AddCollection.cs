using System.Collections.Generic;

public class AddCollection<T> : IAddable<T>
{
    private List<T> data;

    public AddCollection()
    {
        this.Data = new List<T>();
    }

    public List<T> Data
    {
        get { return data; }
        set { data = value; }
    }

    public int Add(T element)
    {
        Data.Add(element);
        return this.Data.Count - 1;
    }
}
using System.Collections.Generic;
using System.Linq;

public class MyList<T> : IAddable<T>, IRemovable<T>, IUsable<T>
{
    private List<T> data;
    public int Used { get; private set; }

    public MyList()
    {
        this.Data = new List<T>();
        this.Used = 0;
    }

    public int Add(T element)
    {
        Data.Insert(0, element);
        Used++;
        return 0;
    }

    public T Remove()
    {
        var result = Data.FirstOrDefault();
        this.Data.RemoveAt(0);
        this.Used--;
        return result;
    }

    public List<T> Data
    {
        get { return data; }
        set { data = value; }
    }
}
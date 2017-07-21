using System.Collections.Generic;
using System.Linq;

public class AddRemoveColection<T> : IAddable<T>, IRemovable<T>
{
    private List<T> data;

    public AddRemoveColection()
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
        Data.Insert(0, element);
        return 0;
    }

    public T Remove()
    {
        var result = this.Data.LastOrDefault();
        Data.RemoveAt(this.Data.Count - 1);
        return result;
    }
}
public class Tuplee<T1, T2>
{
    private T1 item1;
    private T2 item2;

    public Tuplee(T1 item11, T2 item21)
    {
        this.Item1 = item11;
        this.Item2 = item21;
    }

    public T1 Item1
    {
        get { return item1; }
        set { item1 = value; }
    }

    public T2 Item2
    {
        get { return item2; }
        set { item2 = value; }
    }

    public override string ToString()
    {
        return $"{Item1} -> {Item2}";
    }
}
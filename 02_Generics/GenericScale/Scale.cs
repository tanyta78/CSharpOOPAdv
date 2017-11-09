using System;

public class Scale<T> where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    public T GetHavier()
    {
        if (left.CompareTo(right) > 0)
        {
            return left;
        }
        else if (left.CompareTo(right) < 0)
        {
            return right;
        }
        else
        {
            return default(T);
        }
    }

    public T Left { get => left; set => left = value; }
    public T Right { get => right; set => right = value; }
}
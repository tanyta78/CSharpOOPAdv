using System;

public class Sorter<T> where T : IComparable<T>
{
    private CustomList<T> myList;

    public Sorter(CustomList<T> myList)
    {
        this.MyList = myList;
    }

    public CustomList<T> MyList
    {
        get { return myList; }
        set { myList = value; }
    }

    public void Sort()
    {
        myList.Sort();
    }
}
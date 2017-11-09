using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book bookOne, Book bookTwo)
    {
        int result = bookOne.Title.CompareTo(bookTwo.Title);
        if (result == 0)
        {
            result = bookTwo.Year.CompareTo(bookOne.Year);
        }

        return result;
    }
}
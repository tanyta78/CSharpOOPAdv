using System;

public class Program
{
    public static void Main(string[] args)
    {
        var ranks = typeof(CardRanks).GetEnumValues();
        var suits = typeof(CardSuits).GetEnumValues();
        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                Console.WriteLine($"{rank} of {suit}");
            }
        }
    }
}
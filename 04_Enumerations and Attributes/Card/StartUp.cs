using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        /*var input = Console.ReadLine();
        Console.WriteLine($"{input}:");
        Array suits = Enum.GetValues(typeof(CardSuits));

         foreach (var cardSuit in suits)
         {
             Console.WriteLine($"Ordinal value: {(int)cardSuit}; Name value: {cardSuit}");
         }

        Array ranks = Enum.GetValues(typeof(CardRanks));

        foreach (var cardRank in ranks)
        {
            Console.WriteLine($"Ordinal value: {(int)cardRank}; Name value: {cardRank}");
        }*/
        /*
        var rankStr = Console.ReadLine();
        var suitStr = Console.ReadLine();

        CardRanks rank = (CardRanks)Enum.Parse(typeof(CardRanks), rankStr);
        CardSuits suit = (CardSuits)Enum.Parse(typeof(CardSuits), suitStr);

        var cardOne = new Card(rank, suit);

        rankStr = Console.ReadLine();
        suitStr = Console.ReadLine();

        rank = (CardRanks)Enum.Parse(typeof(CardRanks), rankStr);
        suit = (CardSuits)Enum.Parse(typeof(CardSuits), suitStr);

        var cardTwo = new Card(rank, suit);

        SortedSet<Card> cards = new SortedSet<Card>();
        cards.Add(cardOne);
        cards.Add(cardTwo);

        Console.WriteLine(cards.Last());*/
        /* var enumType = Console.ReadLine();

         Type type = null;
         if (enumType == "Rank")
         {
             type = typeof(CardRanks);
         }
         else
         {
             type = typeof(CardSuits);
         }

         var attributes = type.GetCustomAttributes(false);

         foreach (var attribute in attributes)
         {
             Console.WriteLine(attribute.ToString());
         }*/

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
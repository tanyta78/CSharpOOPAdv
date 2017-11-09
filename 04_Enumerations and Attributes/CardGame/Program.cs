using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var firstPlayer = Console.ReadLine();
        var secondPlayer = Console.ReadLine();

        var ranks = typeof(CardRanks).GetEnumValues();
        var suits = typeof(CardSuits).GetEnumValues();
        var cardDeck = new List<Card>();

        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                cardDeck.Add(new Card((CardRanks)rank, (CardSuits)suit));
            }
        }

        var firstPlayerCards = new SortedSet<Card>();
        var secondPlayerCards = new SortedSet<Card>();

        GetFiveCardsInHand(cardDeck, firstPlayerCards);
        GetFiveCardsInHand(cardDeck, secondPlayerCards);

        var firstPlayerBiggestCard = firstPlayerCards.Last();
        var secondPlayerBiggestCard = secondPlayerCards.Last();

        if (firstPlayerBiggestCard.CompareTo(secondPlayerBiggestCard) == 1)
        {
            Console.WriteLine($"{firstPlayer} wins with {firstPlayerBiggestCard}.");
        }
        else
        {
            Console.WriteLine($"{secondPlayer} wins with {secondPlayerBiggestCard}.");
        }
    }

    private static void GetFiveCardsInHand(List<Card> cardDeck, SortedSet<Card> playerCards)
    {
        while (playerCards.Count < 5)
        {
            var cardInfo = Console.ReadLine().Split();
            CardRanks rank;
            CardSuits suit;

            try
            {
                rank = (CardRanks)Enum.Parse(typeof(CardRanks), cardInfo[0]);
                suit = (CardSuits)Enum.Parse(typeof(CardSuits), cardInfo[2]);
                // var currentCard = new Card(rank, suit);
                var currentCard = cardDeck.FirstOrDefault(c => c.Rank == rank && c.Suit == suit);
                if (currentCard != null)
                {
                    playerCards.Add(currentCard);
                    cardDeck.Remove(currentCard);
                }
                else
                {
                    Console.WriteLine("Card is not in the deck.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No such card exists.");
            }
        }
    }
}
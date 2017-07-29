using System;

public class Card : IComparable<Card>
{
    private CardRanks rank;
    private CardSuits suit;

    public Card(CardRanks rank, CardSuits suit)
    {
        this.Rank = rank;
        this.Suit = suit;
    }

    public CardRanks Rank
    {
        get { return rank; }
        set { rank = value; }
    }

    public CardSuits Suit
    {
        get { return suit; }
        set { suit = value; }
    }

    private int GetCardPower()
    {
        return (int)this.Rank + (int)this.Suit;
    }

    public override string ToString()
    {
        return $"{this.Rank} of {this.Suit}";
    }

    public int CompareTo(Card other)
    {
        return this.GetCardPower().CompareTo(other.GetCardPower());
    }
}
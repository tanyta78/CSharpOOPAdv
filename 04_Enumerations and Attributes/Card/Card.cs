using System;

public class Card : IComparable<Card>
{
    private CardRanks rank;
    private CardSuits suit;

    public Card(CardRanks rank, CardSuits suit)
    {
        this.rank = rank;
        this.suit = suit;
    }

    private int GetCardPower()
    {
        return (int)this.rank + (int)this.suit;
    }

    public override string ToString()
    {
        return $"Card name: {this.rank} of {this.suit}; Card power: {this.GetCardPower()}";
    }

    public int CompareTo(Card other)
    {
        return this.GetCardPower().CompareTo(other.GetCardPower());
    }
}
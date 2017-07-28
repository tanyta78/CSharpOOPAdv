using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private int insertedCoins;
    private List<CoffeeType> coffeesSold;

    public CoffeeMachine()
    {
        this.coffeesSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold
    {
        get { return this.coffeesSold; }
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeeType coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);
        CoffeePrice coffeePrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);

        if (this.insertedCoins >= (int)coffeePrice)
        {
            this.coffeesSold.Add(coffeeType);
            this.insertedCoins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        Coin money = (Coin)Enum.Parse(typeof(Coin), coin);
        this.insertedCoins += (int)money;
    }
}
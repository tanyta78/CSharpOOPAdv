using System.Collections.Generic;

public class PrimitiveCalculator
{
    private IStrategy strategy;
    private Dictionary<char,IStrategy> stratigies=new Dictionary<char, IStrategy>()
    {
        {'+',new AdditionStrategy()},
        {'-',new SubtractionStrategy()},
        {'*',new MultiplyStrategy()},
        {'/',new DividingStrategy()}
    };

    public PrimitiveCalculator()
    {
        this.strategy = this.stratigies['+'];

    }

    public void ChangeStrategy(char @operator)
    {
        this.strategy = this.stratigies[@operator];
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}